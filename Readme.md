# Benchmarks to Compare Different Serializers

The following serializer libraries are benchmarked:

* Protobuf-net https://github.com/mgravell/protobuf-net
* Newtonsoft.Json https://github.com/JamesNK/Newtonsoft.Json
* Bond https://github.com/Microsoft/bond

## Benchmarks

### Collection of Strings
A simple collection of random strings (using `Guid.NewGuid.ToString()` n-times).

There are three benchmarks, one for a small collection (100 items), medium (1000 items) and large (10000 items).

### TBD
Other tests TBD

* e.g. complex POCO with nested collections of POCOs...

## Results

See [BenchmarkDotNet.Artifacts/results](https://github.com/MichaCo/SerializationBenchmarks/tree/master/src/BenchmarkRunner/BenchmarkDotNet.Artifacts/results)

### Current Rankings
1. Bond
2. Protobuf-net
3. Json
4. Json + GZ compression - ofc this is slower, GZ compression could be applied to all of the tests. To see the effect in general I think one time is enough.

Interestingly, Bond is slightly faster AND produces slightly smaller output then protobuf-net.


## Implementation Details

I'm not 100% sure how to optimize the JSON and protobuf-net implementation as much as possible. 

For Bond, pooling the `OutputBuffer` is key to improve performance by ~10-20%. Without pooling the buffer, protobuf-net will be faster!

I'm also pooling the `MemoryStream` for all other implementations, the performance gain is a lot less though.

@Marc, any other things which could be improved?