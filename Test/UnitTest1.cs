using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using benchmark_dotnet;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class UnitTest1
    {
        private readonly TestClass _sut;

        public UnitTest1()
        {
            _sut = new TestClass();
        }

        [Fact]
        public void StackTrace()
        {
            Assert.Equal("benchmark_dotnet.testclass.stacktrace", _sut.StackTrace());
        }

        [Fact]
        public void StackTraceFalse()
        {
            Assert.Equal("benchmark_dotnet.testclass.stacktracefalse", _sut.StackTraceFalse());
        }

        [Fact]
        public void StackFrame()
        {
            Assert.Equal("benchmark_dotnet.testclass.stackframe", _sut.StackFrame());
        }

        [Fact]
        public void StackFrameFalse()
        {
            Assert.Equal("benchmark_dotnet.testclass.stackframefalse", _sut.StackFrameFalse());
        }

        [Fact]
        public void CallMemberName()
        {
            Assert.Equal("benchmark_dotnet.testclass.callermembername", _sut.CallerMemberName());
        }

        [Fact]
        public void CallMemberNameGeneric()
        {
            Assert.Equal("benchmark_dotnet.testclass.callermembernamegeneric", _sut.CallerMemberNameGeneric());
        }

        [Fact]
        public async Task TestNameOutput()
        {
            var expectedOutput = new List<string>() {
                "benchmark_dotnet.testclass+<testnameoutput>d__6.movenext",
                "benchmark_dotnet.testclass+<testnameoutput>d__6.movenext",
                "benchmark_dotnet.testclass+<testnameoutput>d__6.movenext",
                "benchmark_dotnet.testclass+<testnameoutput>d__6.movenext",
                "benchmark_dotnet.testclass.testnameoutput",
                "benchmark_dotnet.testclass.testnameoutput"
            };

            var result = await _sut.TestNameOutput();

            for(int i = 0; i < result.Length; i++)
            {
                Assert.Equal(expectedOutput[i], result[i]);
            }
        }

        [Fact]
        public void TestFuncNameOutput()
        {
            var expectedOutput = new List<string>() {
                "test.unittest1+<>c.<testfuncnameoutput>b__9_0",
                "test.unittest1+<>c.<testfuncnameoutput>b__9_0",
                "test.unittest1+<>c.<testfuncnameoutput>b__9_0",
                "test.unittest1+<>c.<testfuncnameoutput>b__9_0",
                "benchmark_dotnet.testclass.testfuncnameoutput",
                "benchmark_dotnet.testclass.testfuncnameoutput"
            };

            var result = _sut.TestFuncNameOutput(() =>
                new List<string>()
                {
                    MethodHelpers.GetCurrentMethod(),
                    MethodHelpers.GetCurrentMethod(false),
                    MethodHelpers.StackFrame(true),
                    MethodHelpers.StackFrame(false),
                    MethodHelpers.CallerMemberName(nameof(benchmark_dotnet), nameof(TestClass)),
                    MethodHelpers.CallerMemberName<TestClass>()
                }.ToArray());

            for(int i = 0; i < result.Length; i++)
            {
                Assert.Equal(expectedOutput[i], result[i]);
            }
        }
    }
}
