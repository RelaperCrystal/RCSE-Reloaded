using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Log;
using CommandLine;
using CommandLine.Text;
using CrystalEngine.Logging;
using RCSE_Reloaded.API;

namespace RCSE_Reloaded
{
    static class Program
    {
        static Logger logger;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            log4net.Config.XmlConfigurator.Configure();

            API.Common.LegacyFormVersionNeeded += Common_LegacyFormVersionNeeded;
            API.Common.IsSnapshotNeeded += Common_IsSnapshotNeeded;
            API.Common.VersionNeeded += Common_VersionNeeded;
            API.Common.SnapshotNumberNeeded += Common_SnapshotNumberNeeded;

            EngineLog el = new EngineLog();
            el.Info("RCSE - Intergrated Application Routine", "");
            el.Info("RCSE - Starting", "");
            RCSEApplication app = new RCSEApplication();
            el.Info("RCSE - Application Created", "");
            app.Launching(args);
            el.Info("RCSE - Application Running", "");
        }

        private static string Common_VersionNeeded() => CommonVals.verNumber;

        private static bool Common_IsSnapshotNeeded() => CommonVals.isSnapshot;

        private static string Common_LegacyFormVersionNeeded() => CommonVals.legacyFormVersion;

        private static string Common_SnapshotNumberNeeded() => CommonVals.snapshot;
    }
}
