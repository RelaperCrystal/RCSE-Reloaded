using CrystalEngine.Launcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE_Reloaded.API.Launches.Form
{
    public interface ILaunchForm : IMainForm
    {
        void DetectAndSaveFile();
        void SaveFile();
    }
}
