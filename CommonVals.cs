using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE_Reloaded
{
    class CommonVals
    {
        public static string filters = "C# 源代码 (*.cs)|*.cs|C 源代码 (*.c)|*.c|C++ 源代码 (*.cpp;*.cxx)|*.cpp;*.cxx|Visual Basic 源代码 (*.vb)|*.vb|HTML (*.htm;*.html)|*.htm;*.html|XAML (*.xml)|*.xml|YAML (*.yml)|*.yml|Properties (*.properties)|*.properties|批处理文件 (*.bat;*.cmd)|*.bat;*.cmd|JAVA (*.java)|*.java|Python (*.py)|*.py|所有文件 (*.*)|*.*";
        public const string snapshot = "21:20-20-A";
        public const string verNumber = "1.1";
        public const bool isSnapshot = true;
        public const string programName = "SimpleEditor";
        public const string programFullName = "RelaperCrystal's Simple Editor";
        public const string programShortName = "RCSE";
        public const string legacyFormVersion = snapshot + "/1--20200515A";
    }

    public struct Setting
    {
        public bool UseMainMenu;
        public bool UseWhiteColor;
        public bool UseFluentDesign;
    }
}
