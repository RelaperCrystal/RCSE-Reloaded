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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSaveProfile_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("这将保存您的用户资料。该资料包含能识别您计算机的信息，请勿外泄。", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(dr == DialogResult.OK)
            {
                Setting set = new Setting();
                set.UseMainMenu = checkUseMainMenu.Checked;
                set.UseWhiteColor = checkLightColor.Checked;
                set.UseFluentDesign = checkBox1.Checked;
                Profile p = new Profile(set);
                
            }
        }
    }
    public struct Profile
    {
        public Profile(Setting set)
        {
            UserName = Environment.UserName;
            MachineName = Environment.MachineName;
            CurrentSettings = set;
            Version = CommonVals.verNumber;
            Snapshot = CommonVals.isSnapshot;
            SnapshotNumber = CommonVals.snapshot;
            ProgName = CommonVals.programName;
        }
        public string UserName;
        public string MachineName;
        public Setting CurrentSettings;
        public string Version;
        public bool Snapshot;
        public string SnapshotNumber;
        public string ProgName;
    }
}
