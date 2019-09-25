using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE_Reloaded.API
{
    public class Events
    {
        public event EventHandler ProgramStartHandlingEvent;

        public delegate void FileChangedStateUpdateHandler(object sender, bool changed);
        public event FileChangedStateUpdateHandler FileChangedStateUpdate;

        public delegate void FileSavingHandler(object sender, string targetPath);
        public event FileSavingHandler FileSaving;
    }
}
