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
 |      Method |        Mean |     Error |    StdDev |      Median |     Op/s | Scaled | ScaledSD | Rank |    Size |  Gen 0 | Allocated |
 |------------ |------------:|----------:|----------:|------------:|---------:|-------:|---------:|-----:|--------:|-------:|----------:|
 |        Json | 170.3996 us | 1.3537 us | 0.8954 us | 170.4471 us |  5868.56 |   2.06 |     0.01 |    3 |    38kb | 7.0801 |   0.04 MB |
 |      GzJson | 863.0608 us | 5.0993 us | 3.3729 us | 863.4582 us |  1158.67 |  10.46 |     0.05 |    4 | 20,57kb |      - |   0.04 MB |
 |    Protobuf |  82.5373 us | 0.5014 us | 0.2984 us |  82.5453 us | 12115.73 |   1.00 |     0.00 |    2 | 37,11kb | 7.2754 |   0.04 MB |
 | BondCompact |  73.3019 us | 1.6843 us | 1.1141 us |  72.9279 us | 13642.22 |   0.89 |     0.01 |    1 | 36,14kb | 6.9336 |   0.04 MB |
 |    BondFast |  73.1229 us | 1.1041 us | 0.7303 us |  73.0659 us | 13675.61 |   0.89 |     0.01 |    1 | 36,14kb | 6.9824 |   0.04 MB |
