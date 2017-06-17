using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Bond.IO.Unsafe;
using Bond.Protocols;
using Newtonsoft.Json;

namespace Benchmarks
{
    public abstract class BaseSerializationBenchmark<T>
    {
        private static JsonSerializer _serializer = new JsonSerializer();
        private static Bond.Serializer<CompactBinaryWriter<OutputBuffer>> _bondCompactSerializer = new Bond.Serializer<CompactBinaryWriter<OutputBuffer>>(typeof(T));
        private static Bond.Serializer<FastBinaryWriter<OutputBuffer>> _bondFastSerializer = new Bond.Serializer<FastBinaryWriter<OutputBuffer>>(typeof(T));
        private static ObjectPool<OutputBuffer> _outputBufferPool = new ObjectPool<OutputBuffer>(new OutputBufferPoolPolicy(1024));
        private static ObjectPool<MemoryStream> _memoryStreamPool = new ObjectPool<MemoryStream>(new MemoryStreamPoolPolicy(1024));

        [Benchmark]
        public int Json()
        {
            var result = SerializeJson();
            return result.Length;
        }

        [Benchmark]
        public int GzJson()
        {
            var result = SerializeGzJson();
            return result.Length;
        }

        [Benchmark(Baseline = true)]
        public int Protobuf()
        {
            var result = SerializeProtobuf();
            return result.Length;
        }

        [Benchmark]
        public int BondCompact()
        {
            var result = SerializeBondCompact();
            return result.Length;
        }

        [Benchmark]
        public int BondFast()
        {
            var result = SerializeBondFast();
            return result.Length;
        }

        protected abstract T GetData();

        public byte[] SerializeJson()
        {
            var value = GetData();
            var ms = _memoryStreamPool.Lease();
            byte[] result;

            using (var writer = new JsonTextWriter(new StreamWriter(ms, Encoding.UTF8, 1024, true)))
            {
                _serializer.Serialize(writer, value, value.GetType());
            }

            result = ms.ToArray();
            _memoryStreamPool.Return(ms);
            return result;
        }

        public byte[] SerializeGzJson()
        {
            var value = GetData();
            var ms = _memoryStreamPool.Lease();
            byte[] result;

            using (var gzWriter = new GZipStream(ms, CompressionLevel.Fastest, true))
            using (var writer = new JsonTextWriter(new StreamWriter(gzWriter)))
            {
                _serializer.Serialize(writer, value, value.GetType());

                // need to flush
                writer.Flush();
            }

            result = ms.ToArray();
            _memoryStreamPool.Return(ms);
            return result;
        }

        public T DeserializeGzJson(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var gzReader = new GZipStream(ms, CompressionMode.Decompress))
            using (var reader = new JsonTextReader(new StreamReader(gzReader)))
            {
                var obj = _serializer.Deserialize(reader, typeof(T));
                return (T)obj;
            }
        }

        public byte[] SerializeProtobuf()
        {
            var value = GetData();

            var stream = _memoryStreamPool.Lease();

            ProtoBuf.Serializer.Serialize(stream, value);
            var bytes = stream.ToArray();
            _memoryStreamPool.Return(stream);
            return bytes;
        }

        public byte[] SerializeBondCompact()
        {
            var value = GetData();

            var buffer = _outputBufferPool.Lease();
            var writer = new CompactBinaryWriter<OutputBuffer>(buffer);

            _bondCompactSerializer.Serialize(value, writer);
            var bytes = buffer.Data.ToArray();
            _outputBufferPool.Return(buffer);
            return bytes;
        }

        public byte[] SerializeBondFast()
        {
            var value = GetData();

            var buffer = _outputBufferPool.Lease();
            var writer = new FastBinaryWriter<OutputBuffer>(buffer);

            _bondFastSerializer.Serialize(value, writer);
            var bytes = buffer.Data.ToArray();
            _outputBufferPool.Return(buffer);
            return bytes;
        }

        private class OutputBufferPoolPolicy : IObjectPoolPolicy<OutputBuffer>
        {
            private readonly int _defaultBufferSize;

            public OutputBufferPoolPolicy(int defaultBufferSize)
            {
                _defaultBufferSize = defaultBufferSize;
            }

            public OutputBuffer CreateNew()
            {
                return new OutputBuffer(_defaultBufferSize);
            }

            public bool Return(OutputBuffer value)
            {
                value.Position = 0;
                return true;
            }
        }

        private class MemoryStreamPoolPolicy : IObjectPoolPolicy<MemoryStream>
        {
            private readonly int _defaultBufferSize;

            public MemoryStreamPoolPolicy(int defaultBufferSize)
            {
                _defaultBufferSize = defaultBufferSize;
            }

            public MemoryStream CreateNew()
            {
                return new MemoryStream(_defaultBufferSize);
            }

            public bool Return(MemoryStream value)
            {
                value.SetLength(0);
                value.Position = 0;
                return true;
            }
        }
    }
}