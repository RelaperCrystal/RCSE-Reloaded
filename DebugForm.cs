using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit;
using RCSE_Reloaded.API;

namespace RCSE_Reloaded
{
    public partial class DebugForm : Form
    {
        public DebugForm(TextEditor editor)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = editor;
        }

        private void buttonShowErrorFrm_Click(object sender, EventArgs e)
        {
            ErrorForm errorForm = new ErrorForm(new Exception("使用调试工具生成"));
            errorForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(textBox1.Te);
        }
    }
}
