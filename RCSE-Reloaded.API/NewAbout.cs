﻿using CrystalEngine.Simple.Dialogs;
using RCSE_Reloaded.API.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(System.Threading.Thread.CurrentThread.CurrentCulture.Name != "en_US")
            {
                label3.Text = $"版本: {Version}\r\n\r\n本软件希望其对您可能有用，但不负有任何担保责任。";
            }
            else
            {
                label3.Text = $"Version: {Version}\r\n\r\n This program is distributed in the hope that it will be useful, but without any warranty.";
            }
            
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

        private void buttonThanks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("https://www.cnblogs.com/swjian/p/9540682.html \r\n打印功能\r\n\r\n还有无数个叫不上来的名字...");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLicense_Click(object sender, EventArgs e)
        {
            new TextDialog(Properties.Resources.SimpleEditor_License, "License").ShowDialog();
        }
    }
}
