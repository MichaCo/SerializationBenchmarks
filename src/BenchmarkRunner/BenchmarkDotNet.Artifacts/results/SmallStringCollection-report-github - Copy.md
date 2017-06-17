``` ini

BenchmarkDotNet=v0.10.4, OS=Windows 10.0.15063
Processor=Intel Core i7-6700 CPU 3.40GHz (Skylake), ProcessorCount=8
Frequency=3328124 Hz, Resolution=300.4696 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  Job-XPQPWO : .NET Core 4.6.25211.01, 64bit RyuJIT

Runtime=Core  LaunchCount=1  TargetCount=10  
WarmupCount=5  

```
 |      Method |       Mean |     Error |    StdDev |     Median |      Op/s | Scaled | ScaledSD | Rank |   Size |   Gen 0 | Allocated |
 |------------ |-----------:|----------:|----------:|-----------:|----------:|-------:|---------:|-----:|-------:|--------:|----------:|
 |        Json | 19.1640 us | 0.7980 us | 0.5278 us | 19.1340 us |  52181.12 |   2.14 |     0.06 |    4 |    3kb |  3.4119 |      0 GB |
 |      GzJson | 82.0966 us | 2.2738 us | 1.5040 us | 81.3969 us |  12180.77 |   9.16 |     0.20 |    5 | 2,06kb |  3.6865 |      0 GB |
 |    Protobuf |  8.9604 us | 0.1839 us | 0.1216 us |  8.9030 us | 111601.57 |   1.00 |     0.00 |    2 | 3,71kb |  2.3865 |      0 GB |
 | BondCompact |  7.3883 us | 0.0648 us | 0.0428 us |  7.3918 us |  135349.3 |   0.82 |     0.01 |    1 | 3,62kb |  0.7858 |      0 GB |
 |    BondFast |  9.5648 us | 0.2732 us | 0.1626 us |  9.5331 us | 104549.53 |   1.07 |     0.02 |    3 | 3,62kb | 16.1499 |      0 GB |
