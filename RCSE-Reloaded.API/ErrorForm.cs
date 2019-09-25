using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCSE_Reloaded.API
{
    public partial class ErrorForm : Form
    {
        Exception exc;
        public ErrorForm(Exception ex)
        {
            InitializeComponent();
            exc = ex;
        }

        private void actionRepository_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/RelaperCrystal/RCSE-Reloaded/issues");
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ErrorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void actionGenReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("** 以下文本已被复制到剪贴板 **\r\n来源: " + exc.Source + "\r\n详细信息: "+ exc.Message);
            Clipboard.SetText("来源: " + exc.Source + "\r\n详细信息: " + exc.Message);
        }
    }
}
