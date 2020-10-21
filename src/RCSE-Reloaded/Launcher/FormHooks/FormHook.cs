// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

using System.Windows.Forms;
using RCSE_Reloaded.LocalizedRes;

namespace RCSE_Reloaded.Launcher.FormHooks
{
	public class FormHook
	{
		private readonly MainFrm form;
		public FormHook(MainFrm launchForm)
		{
			form = launchForm;
		}

		public void HookSaveFile()
		{
			MainFrm.Log.Info("正在准备另存为");
			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter = CommonValues.Filters,
				Title = Dialogs.DialogSaveTo,
				CheckPathExists = true,
				AddExtension = true
			};
			MainFrm.Log.Info("正在弹出另存为对话框");
			DialogResult dr = sfd.ShowDialog();
			MainFrm.Log.Info("另存为对话框弹出完毕");
			if (dr == DialogResult.OK)
			{
				form.Editor.Save(sfd.FileName);
				form.IsLoaded = true;
				form.LoadedContentPath = sfd.FileName;
			}
		}
	}
}
