using CrystalEngine.Launcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE_Reloaded
{
    public class RCSEApplication : IApplication
    {
        public IMainForm StartForm { get; set; }

        public RCSEApplication()
        {
            
        }

        public void End()
        {
            
        }

        public void Launching(string[] args)
        {
            MainFrm.ParseArgsAndRun(args);
        }

        public void Start()
        {
            
        }
    }
}
