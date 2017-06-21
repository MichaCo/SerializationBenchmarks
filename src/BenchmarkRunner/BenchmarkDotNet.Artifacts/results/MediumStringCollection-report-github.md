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
 |      Method |        Mean |      Error |     StdDev |      Median |     Op/s | Scaled | ScaledSD | Rank |    Size |  Gen 0 | Allocated |
 |------------ |------------:|-----------:|-----------:|------------:|---------:|-------:|---------:|-----:|--------:|-------:|----------:|
 |        Json | 182.0293 us |  3.0965 us |  3.4418 us | 181.5289 us |  5493.62 |   2.12 |     0.06 |    5 |  38,1kb | 8.8867 |   0.05 MB |
 |      GzJson | 947.3251 us | 32.5245 us | 37.4553 us | 940.7056 us |   1055.6 |  11.02 |     0.48 |    6 | 20,57kb |      - |   0.04 MB |
 |    Protobuf |  86.0321 us |  1.6151 us |  1.8600 us |  85.6251 us | 11623.57 |   1.00 |     0.00 |    3 | 37,11kb | 8.1787 |   0.04 MB |
 | BondCompact |  79.5894 us |  2.9335 us |  3.3782 us |  79.6145 us | 12564.49 |   0.93 |     0.04 |    2 | 36,14kb | 7.9590 |   0.04 MB |
 |    BondFast |  76.5489 us |  1.5015 us |  1.6689 us |  76.1026 us | 13063.55 |   0.89 |     0.03 |    1 | 36,14kb | 7.9590 |   0.04 MB |
 |  BondSimple |  75.9375 us |  1.2548 us |  1.3947 us |  75.8567 us | 13168.73 |   0.88 |     0.02 |    1 | 39,07kb | 8.6670 |   0.04 MB |
 |    BondJson | 117.4700 us |  2.5068 us |  2.8869 us | 117.1784 us |  8512.81 |   1.37 |     0.04 |    4 |  38,1kb | 9.7900 |   0.04 MB |
