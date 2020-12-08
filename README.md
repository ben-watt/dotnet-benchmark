``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.100
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                  Method |        Mean |       Error |      StdDev |
|------------------------ |------------:|------------:|------------:|
|              StackTrace | 37,170.3 ns |   670.88 ns |   560.21 ns |
|         StackTraceFalse | 12,697.5 ns |   623.26 ns | 1,818.07 ns |
|              StackFrame | 51,909.6 ns | 1,065.04 ns | 3,123.58 ns |
|         StackFrameFalse | 11,345.7 ns |   225.99 ns |   429.97 ns |
|        CallerMemberName |    180.7 ns |     3.70 ns |    10.12 ns |
| CallerMemberNameGeneric |    206.4 ns |     4.19 ns |     8.83 ns |
