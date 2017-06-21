``` ini

BenchmarkDotNet=v0.10.4, OS=Windows 10.0.15063
Processor=Intel Core i7-6700 CPU 3.40GHz (Skylake), ProcessorCount=8
Frequency=3328124 Hz, Resolution=300.4696 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  Job-QZBHBE : .NET Core 4.6.25211.01, 64bit RyuJIT

Runtime=Core  LaunchCount=1  TargetCount=20  
WarmupCount=3  

```
 |      Method |          Mean |      Error |     StdDev |        Median |    Op/s | Scaled | ScaledSD | Rank |     Size |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
 |------------ |--------------:|-----------:|-----------:|--------------:|--------:|-------:|---------:|-----:|---------:|---------:|---------:|---------:|----------:|
 |        Json | 1,890.4001 us | 18.8587 us | 21.7177 us | 1,885.0460 us |  528.99 |   2.00 |     0.03 |    5 | 380,88kb |  95.3125 |  95.3125 |  95.3125 |    0.4 MB |
 |      GzJson | 9,237.1423 us | 65.9004 us | 67.6749 us | 9,242.9805 us |  108.26 |   9.79 |     0.11 |    6 | 205,02kb |        - |        - |        - |   0.22 MB |
 |    Protobuf |   943.2642 us |  7.2755 us |  8.0867 us |   941.9925 us | 1060.15 |   1.00 |     0.00 |    3 | 371,09kb | 103.1250 | 103.1250 | 103.1250 |   0.38 MB |
 | BondCompact |   841.2322 us |  8.0441 us |  9.2636 us |   841.1293 us | 1188.73 |   0.89 |     0.01 |    1 | 361,33kb | 104.2969 | 104.2969 | 104.2969 |   0.37 MB |
 |    BondFast |   858.0048 us | 13.0494 us | 14.5043 us |   858.7767 us | 1165.49 |   0.91 |     0.02 |    2 | 361,33kb | 104.2969 | 104.2969 | 104.2969 |   0.37 MB |
 |  BondSimple |   853.0181 us |  7.7148 us |  8.2548 us |   849.3305 us | 1172.31 |   0.90 |     0.01 |    2 | 390,63kb | 117.9688 | 117.9688 | 117.9688 |    0.4 MB |
 |    BondJson | 1,184.2974 us |  7.6208 us |  7.8260 us | 1,184.7757 us |  844.38 |   1.26 |     0.01 |    4 | 380,88kb |  95.3125 |  95.3125 |  95.3125 |    0.4 MB |
