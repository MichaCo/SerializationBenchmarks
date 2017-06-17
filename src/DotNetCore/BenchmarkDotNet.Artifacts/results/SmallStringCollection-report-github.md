``` ini

BenchmarkDotNet=v0.10.4, OS=Windows 10.0.15063
Processor=Intel Core i7-6700 CPU 3.40GHz (Skylake), ProcessorCount=8
Frequency=3328124 Hz, Resolution=300.4696 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  Job-YUOOTW : .NET Core 4.6.25211.01, 64bit RyuJIT

Runtime=Core  LaunchCount=1  TargetCount=10  
WarmupCount=5  

```
 |      Method |       Mean |     Error |    StdDev |     Median |      Op/s | Scaled | ScaledSD | Rank |   Size |  Gen 0 | Allocated |
 |------------ |-----------:|----------:|----------:|-----------:|----------:|-------:|---------:|-----:|-------:|-------:|----------:|
 |        Json | 17.9437 us | 0.1171 us | 0.0697 us | 17.9405 us |  55729.74 |   2.13 |     0.02 |    4 |    3kb | 1.6907 |      0 GB |
 |      GzJson | 78.7574 us | 0.8503 us | 0.5624 us | 78.8468 us |  12697.21 |   9.37 |     0.09 |    5 | 2,05kb | 2.0508 |      0 GB |
 |    Protobuf |  8.4099 us | 0.0863 us | 0.0571 us |  8.4116 us | 118907.47 |   1.00 |     0.00 |    3 | 3,71kb | 0.6958 |      0 GB |
 | BondCompact |  7.5202 us | 0.3063 us | 0.1602 us |  7.4411 us | 132975.94 |   0.89 |     0.02 |    2 | 3,62kb | 0.6561 |      0 GB |
 |    BondFast |  7.3768 us | 0.0993 us | 0.0657 us |  7.3926 us |  135559.5 |   0.88 |     0.01 |    1 | 3,62kb | 0.7675 |      0 GB |
