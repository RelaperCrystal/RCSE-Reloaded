using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE_Reloaded.API
{
    public delegate void LogEventHandler(Type sender, string message);
    
    public class Events
    {
        public static event EventHandler ProgramStartHandlingEvent;

        public delegate void FileChangedStateUpdateHandler(object sender, bool changed);
        public static event FileChangedStateUpdateHandler FileChangedStateUpdate;

        public delegate void FileSavingHandler(object sender, string targetPath);
        public static event FileSavingHandler FileSaving;

        internal static void ActivateFileSaving(object sender, string targetPath) => FileSaving(sender, targetPath);
        internal static void ActivateFileChangedStateUpdate(object sender, bool changed) => FileChangedStateUpdate(sender, changed);
    }
}
