using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace RCSE_Reloaded.API
{
    public class CompilerManager
    {
        public static CompilerResults CompileFromFile(string fileName)
        {
            CompilerParameters para = new CompilerParameters();
            CSharpCodeProvider CodeProvider = new CSharpCodeProvider();
            para.GenerateExecutable = true;
            para.OutputAssembly = "rcse_compiled.cache.lk";
            para.IncludeDebugInformation = true;
            return CodeProvider.CompileAssemblyFromFile(para, fileName);
        }

        public static CompilerResults CompileFromString(string source)
        {
            CompilerParameters para = new CompilerParameters();
            CSharpCodeProvider CodeProvider = new CSharpCodeProvider();
            para.GenerateExecutable = true;
            para.OutputAssembly = "rcse_compiled.cache.lk";
            para.IncludeDebugInformation = true;
            return CodeProvider.CompileAssemblyFromSource(para, source);
        }
    }
}
