using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCSE_Reloaded.API
{
    public partial class HtmlViewerForm : Form
    {
        public HtmlViewerForm(string url)
        {
            InitializeComponent();
            try
            {
                this.webBrowser1.Url = new Uri(url);
            }
            catch(FormatException)
            {
                MessageBox.Show("无法进行预览，因为 URL 无效。\r\n如果您是通过程序内部进入本窗口，您可以考虑发一个\r\nIssue 到 Github 上。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {

            }
        }

        private void HtmlViewerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
