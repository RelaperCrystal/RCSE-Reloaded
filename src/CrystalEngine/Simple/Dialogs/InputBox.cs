using System;
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

        public sealed override string Text
        {
	        get => base.Text;
	        set => base.Text = value;
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
