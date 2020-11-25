using System;
using benchmark_dotnet;
using Xunit;

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
    }
}
