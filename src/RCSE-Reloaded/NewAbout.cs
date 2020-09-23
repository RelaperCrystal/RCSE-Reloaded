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
            label3.Text = "版本: " + Assembly.GetExecutingAssembly().GetName().Version.ToString()
                + "\r\n\r\n本软件希望其对您可能有用，但不负有任何担保责任。";
        }

        private void buttonThanks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("https://www.cnblogs.com/swjian/p/9540682.html \r\n打印功能\r\n\r\n还有无数个叫不上来的名字...");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
