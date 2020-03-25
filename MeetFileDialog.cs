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
    public partial class MeetFileDialog : Form
    {
        MainFrm form;
        public MeetFileDialog(MainFrm frm)
        {
            InitializeComponent();
            form = frm;
        }

        private void MeetFileDialog_Load(object sender, EventArgs e)
        {

        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "MeetFile (*.mtf)|*.mtf|所有文件 (*.*)|*.*";
            sfd.Title = "保存为 MeetFile";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}
