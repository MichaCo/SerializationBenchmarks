using System;
using System.Linq;

namespace Benchmarks
{
    public class SimplePoco : BaseSerializationBenchmark<SimplePocoModel>
    {
        private static readonly SimplePocoModel _data;

        static SimplePoco()
        {
            _data = SimplePocoModel.Create();
        }

        protected override SimplePocoModel GetData()
        {
            return _data;
        }
    }

    [Bond.Schema]
    [ProtoBuf.ProtoContract]
    public class SimplePocoModel
    {
        private static Random _rnd = new Random(42);

        [Bond.Id(1)]
        [ProtoBuf.ProtoMember(1)]
        public string[] Collection { get; set; }

        [Bond.Id(2)]
        [ProtoBuf.ProtoMember(2)]
        public int Number { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public DateTime Date { get; set; }

        // bond does not support DateTime out of the box
        [Bond.Id(3)]
        public long BondDate
        {
            get => Date.Ticks;
            set
            {
                Date = new DateTime(value);
            }
        }

        [Bond.Id(5)]
        [ProtoBuf.ProtoMember(5)]
        public bool SomeFlag { get; set; } = true;

        [Bond.Id(6)]
        [ProtoBuf.ProtoMember(6)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Bond.Id(7)]
        [ProtoBuf.ProtoMember(7)]
        public double AnotherNumberA { get; set; }

        [Bond.Id(8)]
        [ProtoBuf.ProtoMember(8)]
        public double AnotherNumberB { get; set; }

        [Bond.Id(9)]
        [ProtoBuf.ProtoMember(9)]
        public double AnotherNumberC { get; set; }

        public static SimplePocoModel Create()
        {
            return new SimplePocoModel()
            {
                Collection = Enumerable.Repeat(0, 10).Select(p => Guid.NewGuid().ToString()).ToArray(),
                Number = _rnd.Next(1000000, int.MaxValue),
                Date = DateTime.UtcNow,
                AnotherNumberA = 100000d / _rnd.Next(10, 1000),
                AnotherNumberB = short.MaxValue / (double)_rnd.Next(10, 1000),
                AnotherNumberC = int.MaxValue / (double)_rnd.Next(10, 1000)
            };
        }
    }
}