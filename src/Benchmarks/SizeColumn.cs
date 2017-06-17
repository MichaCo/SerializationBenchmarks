using System;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    /// <summary>
    /// Adds a column to the benchmark report displaying the size of the serialized byte array.
    /// The column expects the benchmark target's method to return the size as an <c>int</c>.
    /// </summary>
    public class SizeColumn : IColumn
    {
        private const double OneKb = 1024;
        private const double OneMb = OneKb * 1024;

        public SizeColumn()
        {
        }

        public string Id => nameof(SizeColumn);

        public string ColumnName => "Size";

        public string GetValue(Summary summary, Benchmark benchmark)
        {
            var target = benchmark.Target;

            var instance = Activator.CreateInstance(target.Type);
            var byteLength = (int)target.Method.Invoke(instance, new object[0]);

            var mbLength = Math.Round(byteLength / OneMb, 2);
            var kbLength = Math.Round(byteLength / OneKb, 2);

            return mbLength > 1 ? $"{mbLength}mb"
                : kbLength > 1 ? $"{kbLength}kb"
                : $"{byteLength}b";
        }

        public bool IsDefault(Summary summary, Benchmark benchmark) => false;

        public bool IsAvailable(Summary summary) => true;

        public bool AlwaysShow => true;

        public ColumnCategory Category => ColumnCategory.Custom;

        public bool IsNumeric => true;

        public UnitType UnitType => UnitType.Dimensionless;

        public string GetValue(Summary summary, Benchmark benchmark, ISummaryStyle style) => GetValue(summary, benchmark);

        public int PriorityInCategory => 1;

        public override string ToString() => ColumnName;

        public string Legend => $"The size in bytes after serialization";
    }
}