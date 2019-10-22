using Common.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RCSE_Reloaded
{
    public class Logger : ILog
    {
        public void Debug(string message)
        {
            LogToFile("RCSE", TodayWithChinaFormat, false, " [DEBUG] " + message);
        }

        public void Debug(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            LogToFile("RCSE", TodayWithChinaFormat, false, " [ERROR] " + message);
        }

        public void Error(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message)
        {
            LogToFile("RCSE", TodayWithChinaFormat, false, " [FATAL] " + message);
        }

        public void Fatal(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            LogToFile("RCSE", TodayWithChinaFormat, false, " [INFO] " + message);
        }

        private static string TodayWithChinaFormat => "RCSE-Log-" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
        public void Info(string format, params object[] args) => throw new NotImplementedException();
        public void Warn(string message) => LogToFile("RCSE", TodayWithChinaFormat, false, " [WARN] " + message);
        public void Warn(string format, params object[] args) => throw new NotImplementedException();

        public void LogToFile(string appName, string file, bool initialize, string content, string owner = "Unassigned")
        {
            List<string> strings;
            if(initialize)
            {
                strings = new List<string>();
                strings.Add(appName + " Log File");
                strings.Add("Log Started: " + DateTime.Now.ToString());
                strings.Add("========================================");
            }
            else
            {
                try
                {
                    strings = new List<string>(File.ReadAllLines(file));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("在试图读取时发生错误: \r\n" + ex.ToString());
                    return;
                }
                strings.Add("[" + owner + "] [" + DateTime.Now.ToString() + "]" + content);
                
            }
            File.WriteAllLines(file, strings.ToArray());
        }

        
    }
}
