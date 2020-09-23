// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

using System;
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

		private void ButtonCancel_Click(object sender, EventArgs e) => Close();

		private void ButtonOK_Click(object sender, EventArgs e)
		{
			// string oper = radioC.Checked ? "//" : ";";
			switch(comboBox1.SelectedIndex)
			{
				case 0:
					break;
			}
		}
	}
}
