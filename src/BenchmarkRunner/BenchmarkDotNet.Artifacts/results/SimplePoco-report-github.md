``` ini

BenchmarkDotNet=v0.10.4, OS=Windows 10.0.15063
Processor=Intel Core i7-6700 CPU 3.40GHz (Skylake), ProcessorCount=8
Frequency=3328124 Hz, Resolution=300.4696 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  Job-VGHUDG : .NET Core 4.6.25211.01, 64bit RyuJIT

Runtime=Core  LaunchCount=1  TargetCount=10  
WarmupCount=5  

```
 |      Method |       Mean |     Error |    StdDev |     Median |      Op/s | Scaled | ScaledSD | Rank | Size |  Gen 0 | Allocated |
 |------------ |-----------:|----------:|----------:|-----------:|----------:|-------:|---------:|-----:|-----:|-------:|----------:|
 |        Json |  7.9803 us | 0.0762 us | 0.0504 us |  7.9771 us |    125309 |   5.91 |     0.05 |    4 | 665b | 1.4404 |      0 GB |
 |      GzJson | 30.9920 us | 0.3412 us | 0.2257 us | 30.9957 us |  32266.36 |  22.95 |     0.20 |    5 | 438b | 2.6489 |      0 GB |
 |    Protobuf |  1.3507 us | 0.0134 us | 0.0080 us |  1.3518 us | 740376.17 |   1.00 |     0.00 |    3 | 466b | 0.1205 |      0 GB |
 | BondCompact |  1.0842 us | 0.0101 us | 0.0060 us |  1.0841 us | 922351.37 |   0.80 |     0.01 |    2 | 459b | 0.1041 |      0 GB |
 |    BondFast |  1.0360 us | 0.0129 us | 0.0085 us |  1.0383 us | 965253.46 |   0.77 |     0.01 |    1 | 467b | 0.0889 |      0 GB |
