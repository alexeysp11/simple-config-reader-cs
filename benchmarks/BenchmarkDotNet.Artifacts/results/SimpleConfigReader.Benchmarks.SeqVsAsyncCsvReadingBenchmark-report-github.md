```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Athlon Gold 3150U with Radeon Graphics, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT AVX2


```
| Method                     | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|--------------------------- |---------:|---------:|---------:|---------:|-------:|----------:|
| UseSeqReading              | 17.38 ns | 0.186 ns | 0.156 ns | 17.35 ns | 0.0306 |      64 B |
| UseSeqProtectedReading     | 22.31 ns | 1.405 ns | 4.143 ns | 23.58 ns | 0.0459 |      96 B |
| UseAsyncReading            | 50.87 ns | 1.053 ns | 1.081 ns | 50.98 ns | 0.0727 |     152 B |
| UseAsyncUnprotectedReading | 39.25 ns | 0.835 ns | 1.349 ns | 39.29 ns | 0.0573 |     120 B |
