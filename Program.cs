using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Log;
using CommandLine;
using CommandLine.Text;
using CrystalEngine.Logging;

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

            EngineLog el = new EngineLog();
            el.Info("RCSE - Intergrated Application Routine", "");
            el.Info("RCSE - Starting", "");
            RCSEApplication app = new RCSEApplication();
            el.Info("RCSE - Application Created", "");
            app.Launching(args);
            el.Info("RCSE - Application Running", "");
        }

    }
}
