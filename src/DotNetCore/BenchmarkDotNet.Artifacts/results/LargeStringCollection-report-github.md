``` ini

BenchmarkDotNet=v0.10.4, OS=Windows 10.0.15063
Processor=Intel Core i7-6700 CPU 3.40GHz (Skylake), ProcessorCount=8
Frequency=3328124 Hz, Resolution=300.4696 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  Job-FXKJYR : .NET Core 4.6.25211.01, 64bit RyuJIT

Runtime=Core  LaunchCount=1  TargetCount=10  
WarmupCount=5  

```
 |      Method |          Mean |      Error |     StdDev |        Median |    Op/s | Scaled | ScaledSD | Rank |     Size |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
 |------------ |--------------:|-----------:|-----------:|--------------:|--------:|-------:|---------:|-----:|---------:|--------:|--------:|--------:|----------:|
 |        Json | 1,808.3862 us |  8.8400 us |  3.9250 us | 1,807.8351 us |  552.98 |   1.95 |     0.01 |    4 |    380kb | 79.6875 | 79.6875 | 79.6875 |    0.4 MB |
 |      GzJson | 9,286.7878 us | 61.8325 us | 40.8984 us | 9,298.0953 us |  107.68 |  10.04 |     0.05 |    5 | 205,05kb |       - |       - |       - |   0.22 MB |
 |    Protobuf |   925.3154 us |  4.6702 us |  3.0890 us |   926.1530 us | 1080.71 |   1.00 |     0.00 |    3 | 371,09kb | 95.1172 | 95.1172 | 95.1172 |   0.38 MB |
 | BondCompact |   826.7958 us | 12.8269 us |  8.4842 us |   823.9271 us | 1209.49 |   0.89 |     0.01 |    1 | 361,33kb | 97.4609 | 97.4609 | 97.4609 |   0.37 MB |
 |    BondFast |   841.4146 us | 16.7085 us | 11.0516 us |   841.5243 us | 1188.47 |   0.91 |     0.01 |    2 | 361,33kb | 95.8984 | 95.8984 | 95.8984 |   0.37 MB |
