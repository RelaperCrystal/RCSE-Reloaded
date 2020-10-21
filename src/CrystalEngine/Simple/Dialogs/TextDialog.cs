using System;
using System.Windows.Forms;

namespace CrystalEngine.Simple.Dialogs
{
    public partial class TextDialog : Form
    {
        public TextDialog(string content, string title)
        {
            InitializeComponent();
            Text = title;
            Content = content;
            textContent.Text = Content;
        }

        public sealed override string Text
        {
	        get => base.Text;
	        set => base.Text = value;
        }

        public string Content { get; private set; }

        private void TextDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
