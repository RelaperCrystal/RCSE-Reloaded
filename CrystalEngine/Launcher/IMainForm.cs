using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalEngine.Launcher
{
    public interface IMainForm
    {
        void Start();
        bool CanExit { get; }
        void Exit();
        void LaunchWithArgs(string[] args);
        void ExceptionOccoured(Exception ex);
        
    }
}
