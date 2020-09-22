using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalEngine.Simple.Dialogs
{
    public partial class InputBox : Form
    {
        public InputBox(string description = "请输入文本: ", string title = "")
        {
            InitializeComponent();
            this.Text = title;
            this.Description = description;
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        public string Description
        {
            get
            {
                return labelDescription.Text;
            }
            set
            {
                labelDescription.Text = value;
            }
        }

        public string ResultText
        {
            get
            {
                return textInput.Text;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
