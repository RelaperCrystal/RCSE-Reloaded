// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

using System;
using System.Windows.Forms;
using CrystalEngine.Logging;

namespace RCSE_Reloaded
{
    static class Program
    {
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
            RcseApplication app = new RcseApplication();
            el.Info("RCSE - Application Created", "");
            app.Launching(args);
            el.Info("RCSE - Application Running", "");
        }

        private static string Common_VersionNeeded() => CommonValues.VerNumber;

        private static bool Common_IsSnapshotNeeded() => CommonValues.IsSnapshot;

        private static string Common_LegacyFormVersionNeeded() => CommonValues.LegacyFormVersion;

        private static string Common_SnapshotNumberNeeded() => CommonValues.Snapshot;
    }
}
