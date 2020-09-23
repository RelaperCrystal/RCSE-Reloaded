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
    public partial class TextDialog : Form
    {
        public TextDialog(string content, string title)
        {
            InitializeComponent();
            Text = title;
            Content = content;
            textContent.Text = Content;
        }

        public string Content { get; private set; }

        private void TextDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
