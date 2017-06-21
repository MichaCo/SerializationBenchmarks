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
 |      Method |       Mean |     Error |    StdDev |     Median |      Op/s | Scaled | ScaledSD | Rank |   Size |  Gen 0 | Allocated |
 |------------ |-----------:|----------:|----------:|-----------:|----------:|-------:|---------:|-----:|-------:|-------:|----------:|
 |        Json | 19.4044 us | 0.3599 us | 0.4000 us | 19.3273 us |  51534.74 |   2.22 |     0.06 |    6 | 3,83kb | 2.1240 |      0 GB |
 |      GzJson | 83.3933 us | 1.4486 us | 1.6682 us | 83.7984 us |  11991.37 |   9.55 |     0.24 |    7 | 2,07kb | 3.0762 |      0 GB |
 |    Protobuf |  8.7380 us | 0.1263 us | 0.1454 us |  8.7515 us |  114442.4 |   1.00 |     0.00 |    4 | 3,71kb | 0.8270 |      0 GB |
 | BondCompact |  7.8199 us | 0.1589 us | 0.1830 us |  7.7728 us | 127878.33 |   0.90 |     0.03 |    2 | 3,62kb | 0.7874 |      0 GB |
 |    BondFast |  8.1611 us | 0.2921 us | 0.3363 us |  8.1328 us | 122532.26 |   0.93 |     0.04 |    3 | 3,62kb | 0.7477 |      0 GB |
 |  BondSimple |  7.7050 us | 0.1246 us | 0.1333 us |  7.6814 us | 129786.23 |   0.88 |     0.02 |    1 | 3,91kb | 0.8423 |      0 GB |
 |    BondJson | 11.8292 us | 0.2457 us | 0.2629 us | 11.8266 us |  84536.84 |   1.35 |     0.04 |    5 | 3,82kb | 2.1851 |      0 GB |
