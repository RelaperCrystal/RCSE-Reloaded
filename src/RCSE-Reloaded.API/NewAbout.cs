using CrystalEngine.Simple.Dialogs;
using System;
using System.Net;
using System.Windows.Forms;
using RCSE_Reloaded.API.Resources;

namespace RCSE_Reloaded.API
{
    public partial class NewAbout : Form
    {
        public NewAbout()
        {
            InitializeComponent();
        }

        private void NewAbout_Load(object sender, EventArgs e)
        {
	        // ReSharper disable once LocalizableElement
	        label3.Text = $"{APITexts.Version}: {Version}\r\n\r\n{APITexts.NoWarranty}";
        }

        private string Version
        {
            get
            {
                string result;
                if (Common.IsSnapshot)
                {
                    result = Common.SnapshotNumber + "(for " + Common.Version + ")\r\n主窗口版本: " + Common.LegacyFormVersion;
                }
                else
                {
                    result = Common.Version;
                }
                return result;
            }
        }

        private void ButtonThanks_Click(object sender, EventArgs e)
        {
	        // ReSharper disable once LocalizableElement
	        MessageBox.Show("https://www.cnblogs.com/swjian/p/9540682.html \r\n打印功能\r\n\r\n还有无数个叫不上来的名字...");
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonLicense_Click(object sender, EventArgs e)
        {
            new TextDialog(Properties.Resources.SimpleEditor_License, "License").ShowDialog();
        }

        private void ButtonChangelog_Click(object sender, EventArgs e)
        {
            string change = new WebClient().DownloadString("https://pastebin.com/raw/qi35gsuP");
            new TextDialog(change, "修改日志").Show();
        }
    }
}
