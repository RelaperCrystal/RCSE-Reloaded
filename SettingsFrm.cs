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
    public partial class SettingsFrm : Form
    {
        MainFrm frm;
        public SettingsFrm(MainFrm yourself)
        {
            InitializeComponent();
            frm = yourself;
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            this.checkUseMainMenu.Checked = Properties.Settings.Default.UseMainMenu;
            this.checkLightColor.Checked = Properties.Settings.Default.UseLightTheme;
            this.checkBox1.Checked = Properties.Settings.Default.UseFluentDesign;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Setting set = new Setting();
            set.UseMainMenu = checkUseMainMenu.Checked;
            set.UseWhiteColor = checkLightColor.Checked;
            set.UseFluentDesign = checkBox1.Checked;
            frm.ApplyAndSaveConfiguration(set);
        }
    }
}
