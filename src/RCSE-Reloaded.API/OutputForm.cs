using System;
using System.Windows.Forms;

namespace RCSE_Reloaded.API
{
    public partial class OutputForm : Form
    {
        public OutputForm()
        {
            InitializeComponent();
        }

        private void OutputForm_Load(object sender, EventArgs e)
        {

        }

        public string OutputText
        {
            get
            {
                return textOutput.Text;
            }
            set
            {
                textOutput.Text = value;
            }
        }
    }
}
