using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCSE_Reloaded
{
    public partial class FrmInsertLicense : Form
    {
        public string outputString;

        public FrmInsertLicense()
        {
            InitializeComponent();
        }

        private void FrmInsertLicense_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string oper = radioC.Checked ? "//" : ";";
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    break;
            }
        }
    }
}
