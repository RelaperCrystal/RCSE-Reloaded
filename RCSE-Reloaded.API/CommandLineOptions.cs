using CommandLine;

namespace RCSE_Reloaded.API
{
    public class CommandLineOptions
    {
        [Value(0, Required = false, HelpText = "从命令行需要加载的文件。")]
        public string File { get; set; } 

        [Option('c', "culture", Default = "default", HelpText = "设定语言。", Required = false)]
        public string Culture { get; set; }
    }
}
