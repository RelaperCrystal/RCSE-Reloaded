using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalEngine.Launcher
{
    public interface IApplication
    {
        IMainForm StartForm { get; set; }
        void Start();
        void End();
        void Launching(string[] args);
    }
}
