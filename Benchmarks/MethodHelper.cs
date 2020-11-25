using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace benchmark_dotnet
{
    public static class MethodHelpers
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod(bool flag = true)
        {
            var stackTrace = new StackTrace(flag);
            var methodBase = stackTrace.GetFrame(1).GetMethod();
            var myClass = methodBase.ReflectedType;

            return $"{myClass}.{methodBase.Name}".ToLowerInvariant();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string StackFrame(bool flag = true)
        {
            var stackFrame = new StackFrame(1, flag);
            var methodBase = stackFrame.GetMethod();
            var myClass = methodBase.ReflectedType;

            return $"{myClass}.{methodBase.Name}".ToLowerInvariant();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CallerMemberName<T>([CallerMemberName] string memberName = "") where T : class
        {
            var type = typeof(T);
            return $"{type.Namespace}.{type.Name}.{memberName}".ToLowerInvariant();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CallerMemberName(string @namespace, string className, [CallerMemberName] string memberName = "")
        {
            return $"{@namespace}.{className}.{memberName}".ToLowerInvariant();
        }
    }
}