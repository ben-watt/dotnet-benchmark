using BenchmarkDotNet.Running;

namespace benchmark_dotnet
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TestClass>();
        }
    }
}