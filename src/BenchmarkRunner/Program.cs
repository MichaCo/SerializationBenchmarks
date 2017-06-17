using System;
using System.Reflection;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Benchmarks;

namespace DotNetCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // "unit testing" (lol) the runs if it can run
            var test = new SimplePoco();
            var y = test.SerializeJson();
            y = test.SerializeJson();
            y = test.SerializeGzJson();
            y = test.SerializeGzJson();
            var yResult = test.DeserializeGzJson(y);
            y = test.SerializeBondCompact();
            y = test.SerializeProtobuf();

            do
            {
                var config = ManualConfig.Create(DefaultConfig.Instance)
                    //.With(exporters: BenchmarkDotNet.Exporters.DefaultExporters.)
                    .With(BenchmarkDotNet.Analysers.EnvironmentAnalyser.Default)
                    .With(BenchmarkDotNet.Exporters.MarkdownExporter.GitHub)
                    .With(BenchmarkDotNet.Diagnosers.MemoryDiagnoser.Default)
                    .With(StatisticColumn.Mean)
                    .With(StatisticColumn.Median)
                    //.With(StatisticColumn.Min)
                    //.With(StatisticColumn.Max)
                    .With(StatisticColumn.StdDev)
                    .With(StatisticColumn.OperationsPerSecond)
                    .With(BaselineScaledColumn.Scaled)
                    .With(BaselineScaledColumn.ScaledStdDev)
                    .With(RankColumn.Arabic)
                    .With(new SizeColumn())

                    .With(Job.Core
                        .WithTargetCount(1)
                        .WithWarmupCount(1)
                        .WithLaunchCount(1));

                //.With(Job.Clr
                //    .WithTargetCount(10)
                //    .WithWarmupCount(5)
                //    .WithLaunchCount(1));

                BenchmarkSwitcher
                    .FromAssembly(typeof(SmallStringCollection).GetTypeInfo().Assembly)
                    .Run(args, config);

                Console.WriteLine("done!");
                Console.WriteLine("Press escape to exit or any key to continue...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}