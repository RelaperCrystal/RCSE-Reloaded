// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

using System;
using System.Windows.Forms;

namespace RCSE_Reloaded
{
	public partial class SettingsFrm : Form
	{
		readonly MainFrm frm;
		public SettingsFrm(MainFrm yourself)
		{
			InitializeComponent();
			frm = yourself;
		}

		private void SettingsFrm_Load(object sender, EventArgs e)
		{
			this.checkLightColor.Checked = Properties.Settings.Default.UseLightTheme;
			this.checkBox1.Checked = Properties.Settings.Default.UseFluentDesign;
			this.textSearchEngine.Text = Properties.Settings.Default.SearchURL;
		}

		private void ButtonOK_Click(object sender, EventArgs e)
		{
			Setting set = new Setting
			{
				UseWhiteColor = checkLightColor.Checked,
				UseFluentDesign = checkBox1.Checked
			};
			frm.ApplyAndSaveConfiguration(set);
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ButtonSaveProfile_Click(object sender, EventArgs e)
		{
			//DialogResult dr = MessageBox.Show("这将保存您的用户资料。该资料包含能识别您计算机的信息，请勿外泄。", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			//if(dr == DialogResult.OK)
			//{
			//	Setting set = new Setting();
			//	set.UseWhiteColor = checkLightColor.Checked;
			//	set.UseFluentDesign = checkBox1.Checked;
			//	set.SearchURL = textSearchEngine.Text;
			//	Profile p = new Profile(set);
				
			//}
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

		public override bool Equals(object obj)
		{
			throw new NotImplementedException();
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(Profile left, Profile right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Profile left, Profile right)
		{
			return !(left == right);
		}
	}
}
