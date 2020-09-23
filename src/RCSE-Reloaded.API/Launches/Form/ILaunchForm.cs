using CrystalEngine.Launcher;

namespace RCSE_Reloaded.API.Launches.Form
{
    public interface ILaunchForm : IMainForm
    {
        void DetectAndSaveFile();
        void SaveFile();
    }
}
