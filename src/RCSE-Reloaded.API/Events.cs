using System;

namespace RCSE_Reloaded.API
{
    public delegate void LogEventHandler(Type sender, string message);
    
    public static class Events
    {
	    public delegate void FileChangedStateUpdateHandler(object sender, bool changed);
        public static event FileChangedStateUpdateHandler FileChangedStateUpdate;

        public delegate void FileSavingHandler(object sender, string targetPath);
        public static event FileSavingHandler FileSaving;

        internal static void ActivateFileSaving(object sender, string targetPath) => FileSaving(sender, targetPath);
        internal static void ActivateFileChangedStateUpdate(object sender, bool changed) => FileChangedStateUpdate(sender, changed);
    }
}
