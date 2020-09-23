// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit;

namespace RCSE_Reloaded
{
	public partial class DebugForm : Form
	{
		public DebugForm(TextEditor editor)
		{
			InitializeComponent();
			propertyGrid1.SelectedObject = editor;
		}

		private void ButtonShowErrorFrm_Click(object sender, EventArgs e)
		{
			throw new ArgumentException();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(textBox1.Text);
		}

		private void DebugForm_Load(object sender, EventArgs e)
		{

		}
	}
}
