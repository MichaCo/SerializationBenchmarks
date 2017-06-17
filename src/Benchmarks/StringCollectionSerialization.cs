using System;
using System.Linq;

namespace Benchmarks
{
    public class SmallStringCollection : BaseSerializationBenchmark<StringCollectionModel>
    {
        private readonly StringCollectionModel _data;

        public SmallStringCollection()
        {
            _data = new StringCollectionModel() { Collection = Enumerable.Repeat(0, 100).Select(p => Guid.NewGuid().ToString()).ToArray() };
        }

        protected override StringCollectionModel GetData()
        {
            return _data;
        }
    }

    public class MediumStringCollection : BaseSerializationBenchmark<StringCollectionModel>
    {
        private readonly StringCollectionModel _data;

        public MediumStringCollection()
        {
            _data = new StringCollectionModel() { Collection = Enumerable.Repeat(0, 1000).Select(p => Guid.NewGuid().ToString()).ToArray() };
        }

        protected override StringCollectionModel GetData()
        {
            return _data;
        }
    }

    public class LargeStringCollection : BaseSerializationBenchmark<StringCollectionModel>
    {
        private readonly StringCollectionModel _data;

        public LargeStringCollection()
        {
            _data = new StringCollectionModel() { Collection = Enumerable.Repeat(0, 10000).Select(p => Guid.NewGuid().ToString()).ToArray() };
        }

        protected override StringCollectionModel GetData()
        {
            return _data;
        }
    }

    [Bond.Schema]
    [ProtoBuf.ProtoContract]
    public class StringCollectionModel
    {
        [Bond.Id(1)]
        [ProtoBuf.ProtoMember(1)]
        public string[] Collection { get; set; }
    }
}