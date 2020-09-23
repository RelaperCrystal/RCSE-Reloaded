using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace RCSE_Reloaded.API
{
    public class CompilerManager
    {
        public static event LogEventHandler CompilerLog;
        public static CompilerResults CompileFromFile(string fileName)
        {
            CompilerLog(typeof(CompilerManager), "正在启动编译");
            CompilerParameters para = new CompilerParameters();
            CSharpCodeProvider CodeProvider = new CSharpCodeProvider();
            para.GenerateExecutable = true;
            CompilerLog(typeof(CompilerManager), "输出为 rcse_compiled.cache.lk");
            para.OutputAssembly = "rcse_compiled.cache.lk";
            para.IncludeDebugInformation = true;
            CompilerLog(typeof(CompilerManager), "正在编译");
            return CodeProvider.CompileAssemblyFromFile(para, fileName);
        }

        public static CompilerResults CompileFromString(string source)
        {
            CompilerLog(typeof(CompilerManager), "正在启动编译");
            CompilerParameters para = new CompilerParameters();
            CSharpCodeProvider CodeProvider = new CSharpCodeProvider();
            para.GenerateExecutable = true;
            CompilerLog(typeof(CompilerManager), "输出为 rcse_compiled.cache.lk");
            para.OutputAssembly = "rcse_compiled.cache.lk";
            para.IncludeDebugInformation = true;
            CompilerLog(typeof(CompilerManager), "正在编译");
            return CodeProvider.CompileAssemblyFromSource(para, source);
        }
    }
}
