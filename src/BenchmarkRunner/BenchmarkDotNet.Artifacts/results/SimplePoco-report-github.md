``` ini

BenchmarkDotNet=v0.10.4, OS=Windows 10.0.15063
Processor=Intel Core i7-6700 CPU 3.40GHz (Skylake), ProcessorCount=8
Frequency=3328124 Hz, Resolution=300.4696 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  Job-EXPTBS : .NET Core 4.6.25211.01, 64bit RyuJIT

Runtime=Core  LaunchCount=1  TargetCount=10  
WarmupCount=5  

```
 |      Method |       Mean |     Error |    StdDev |     Median |      Op/s | Scaled | ScaledSD | Rank | Size |  Gen 0 | Allocated |
 |------------ |-----------:|----------:|----------:|-----------:|----------:|-------:|---------:|-----:|-----:|-------:|----------:|
 |        Json |  7.9678 us | 0.4205 us | 0.2502 us |  7.8742 us | 125504.83 |   5.92 |     0.18 |    4 | 664b | 1.4404 |      0 GB |
 |      GzJson | 30.6682 us | 0.4221 us | 0.2792 us | 30.6572 us |  32607.11 |  22.80 |     0.22 |    5 | 435b | 2.6978 |      0 GB |
 |    Protobuf |  1.3454 us | 0.0100 us | 0.0066 us |  1.3467 us | 743271.75 |   1.00 |     0.00 |    3 | 466b | 0.1167 |      0 GB |
 | BondCompact |  1.1878 us | 0.0450 us | 0.0298 us |  1.1928 us | 841888.63 |   0.88 |     0.02 |    2 | 459b | 0.1034 |      0 GB |
 |    BondFast |  1.0712 us | 0.0269 us | 0.0178 us |  1.0731 us | 933496.14 |   0.80 |     0.01 |    1 | 467b | 0.0874 |      0 GB |
