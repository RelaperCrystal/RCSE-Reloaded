using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinimalUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 2)
            {
                MessageBox.Show("更新时发生错误。请卸载并重新安装最新版本。\r\n错误详细信息：未能接受正确传参。", "最小更新系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        static void UpdateNow(string url, string path)
        {
            if(url == null || path == null || url == "" || path == "")
            {
                MessageBox.Show("更新时发生错误。请卸载并重新安装最新版本。\r\n错误详细信息：UpdateNow 未能接受正确传参。", "最小更新系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Process[] processes = Process.GetProcessesByName("RCSE-Reloaded.exe");
            foreach(Process proc in processes)
            {
                proc.Close();
            }
        }
    }
}
