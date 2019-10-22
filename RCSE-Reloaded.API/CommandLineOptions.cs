using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE_Reloaded.API
{
    public class CommandLineOptions
    {
        [Value(0, Required = false, HelpText = "从命令行需要加载的文件。")]
        public string File { get; set; } 
    }
}
