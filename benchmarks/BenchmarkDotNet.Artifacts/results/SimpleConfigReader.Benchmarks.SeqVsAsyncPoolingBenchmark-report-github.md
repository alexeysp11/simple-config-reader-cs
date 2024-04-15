```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Athlon Gold 3150U with Radeon Graphics, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT AVX2


```
| Method                     | Mean        | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |------------:|----------:|----------:|-------:|----------:|
| UseSeqPooling              |    860.7 ns |   7.27 ns |   5.67 ns | 1.0624 |   2.17 KB |
| UseSeqProtectedPooling     |  2,147.1 ns |  23.21 ns |  21.71 ns | 1.0757 |    2.2 KB |
| UseAsyncPooling            | 18,927.0 ns | 246.38 ns | 230.46 ns | 9.6741 |  19.54 KB |
| UseAsyncUnprotectedPooling |          NA |        NA |        NA |     NA |        NA |

Benchmarks with issues:
  SeqVsAsyncPoolingBenchmark.UseAsyncUnprotectedPooling: DefaultJob
