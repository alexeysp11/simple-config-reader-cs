```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Athlon Gold 3150U with Radeon Graphics, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT AVX2


```
| Method                     | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|--------------------------- |---------:|---------:|---------:|---------:|-------:|----------:|
| UseSeqReading              | 17.74 ns | 0.406 ns | 0.399 ns | 17.74 ns | 0.0306 |      64 B |
| UseSeqProtectedReading     | 23.58 ns | 0.510 ns | 0.823 ns | 23.53 ns | 0.0459 |      96 B |
| UseAsyncReading            | 45.98 ns | 2.294 ns | 6.765 ns | 48.74 ns | 0.0727 |     152 B |
| UseAsyncUnprotectedReading | 42.39 ns | 0.365 ns | 0.285 ns | 42.32 ns | 0.0573 |     120 B |
