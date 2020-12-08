using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace benchmark_dotnet
{
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [RPlotExporter]
    public class TestClass
    {
        [Benchmark(Baseline = false)]
        public string StackTrace() => MethodHelpers.GetCurrentMethod();

        [Benchmark]
        public string StackTraceFalse() => MethodHelpers.GetCurrentMethod(false);

        [Benchmark]
        public string StackFrame() => MethodHelpers.StackFrame(true);

        [Benchmark]
        public string StackFrameFalse() => MethodHelpers.StackFrame(false);

        [Benchmark]
        public string CallerMemberName() => MethodHelpers.CallerMemberName(nameof(benchmark_dotnet), nameof(TestClass));

        [Benchmark]
        public string CallerMemberNameGeneric() => MethodHelpers.CallerMemberName<TestClass>();

        public async Task<string[]> TestNameOutput()
        {
            return new List<string>()
            {
                MethodHelpers.GetCurrentMethod(),
                MethodHelpers.GetCurrentMethod(false),
                MethodHelpers.StackFrame(true),
                MethodHelpers.StackFrame(false),
                MethodHelpers.CallerMemberName(nameof(benchmark_dotnet), nameof(TestClass)),
                MethodHelpers.CallerMemberName<TestClass>()
            }.ToArray();
        }

        public string[] TestFuncNameOutput(Func<string[]> func)
        {
            return func();
        }
    }
}