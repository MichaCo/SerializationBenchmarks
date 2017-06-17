# Benchmarks to Compare Different Serializers

The following serializer libraries are benchmarked:

* Protobuf-net https://github.com/mgravell/protobuf-net
* Newtonsoft.Json https://github.com/JamesNK/Newtonsoft.Json
* Bond https://github.com/Microsoft/bond

## Results

See [BenchmarkDotNet.Artifacts/results](https://github.com/MichaCo/SerializationBenchmarks/tree/master/src/BenchmarkRunner/BenchmarkDotNet.Artifacts/results)

## Benchmarks

### 1. Collection of Strings
A simple collection of random strings (using `Guid.NewGuid.ToString()` n-times).

There are three benchmarks, one for a small collection (100 items), medium (1000 items) and large (10000 items).

#### Results

* [Large Collection](https://github.com/MichaCo/SerializationBenchmarks/blob/master/src/BenchmarkRunner/BenchmarkDotNet.Artifacts/results/LargeStringCollection-report-github.md)
* [Medium Collection](https://github.com/MichaCo/SerializationBenchmarks/blob/master/src/BenchmarkRunner/BenchmarkDotNet.Artifacts/results/MediumStringCollection-report-github.md)
* [Small Collection](https://github.com/MichaCo/SerializationBenchmarks/blob/master/src/BenchmarkRunner/BenchmarkDotNet.Artifacts/results/SmallStringCollection-report-github.md)

#### Ranking

1. Bond
2. Protobuf-net
3. Json
4. Json + GZ compression - ofc this is slower, GZ compression could be applied to all of the tests. To see the effect in general I think one time is enough.

Interestingly, Bond is slightly faster AND produces slightly smaller output then protobuf-net. Fast/Compact Bond seems not to make a big difference for this use-case.

### 2. Simple Poco
Testing a simple Poco with a few properties. Each benchmark run uses one object instance (400-500bytes).

#### Results

* [Simple Poco results](https://github.com/MichaCo/SerializationBenchmarks/blob/master/src/BenchmarkRunner/BenchmarkDotNet.Artifacts/results/SimplePoco-report-github.md)

#### Rankings

1. Fast Bond
2. Compact Bond
3. Protobuf-net
4. Json

* In this benchmark, there is a noticeable difference between fast (10% faster) and compact (2-3% smaller) bond in terms of performance and size.
* Fun fact, the size of gz compressed Json is only marginally smaller than Bond/Protobuf but 22+ times slower

---

Other tests TBD

* e.g. complex POCO with nested collections of POCOs...

## Implementation Details

I'm not 100% sure how to optimize the JSON and protobuf-net implementation as much as possible. 

For Bond, pooling the `OutputBuffer` is key to improve performance by ~10-20%. Without pooling the buffer, protobuf-net will be faster!

I'm also pooling the `MemoryStream` for all other implementations, the performance gain is a lot less though.

@Marc, any other things which could be improved?