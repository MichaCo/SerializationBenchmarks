``` ini

BenchmarkDotNet=v0.10.4, OS=Windows 10.0.15063
Processor=Intel Core i7-6700 CPU 3.40GHz (Skylake), ProcessorCount=8
Frequency=3328124 Hz, Resolution=300.4696 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  Job-NRZYDJ : .NET Core 4.6.25211.01, 64bit RyuJIT

Runtime=Core  LaunchCount=1  TargetCount=50  
WarmupCount=3  

```
 |      Method |       Mean |     Error |    StdDev |     Median |      Op/s | Scaled | ScaledSD | Rank | Size |  Gen 0 | Allocated |
 |------------ |-----------:|----------:|----------:|-----------:|----------:|-------:|---------:|-----:|-----:|-------:|----------:|
 |        Json |  8.2092 us | 0.1175 us | 0.2236 us |  8.1276 us | 121814.55 |   5.91 |     0.24 |    6 | 665b | 1.6333 |      0 GB |
 |      GzJson | 33.3754 us | 0.5663 us | 1.1309 us | 33.2416 us |  29962.19 |  24.04 |     1.07 |    7 | 439b | 3.4204 |      0 GB |
 |    Protobuf |  1.3897 us | 0.0214 us | 0.0422 us |  1.3841 us | 719560.94 |   1.00 |     0.00 |    4 | 466b | 0.1465 |      0 GB |
 | BondCompact |  1.1026 us | 0.0117 us | 0.0228 us |  1.0996 us | 906954.63 |   0.79 |     0.03 |    3 | 459b | 0.1327 |      0 GB |
 |    BondFast |  1.0850 us | 0.0134 us | 0.0267 us |  1.0836 us | 921632.88 |   0.78 |     0.03 |    2 | 467b | 0.1179 |      0 GB |
 |  BondSimple |  1.0060 us | 0.0129 us | 0.0254 us |  1.0001 us | 994033.25 |   0.72 |     0.03 |    1 | 481b | 0.1215 |      0 GB |
 |    BondJson |  6.0689 us | 0.0872 us | 0.1721 us |  6.0382 us | 164773.53 |   4.37 |     0.18 |    5 | 608b | 1.5448 |      0 GB |
