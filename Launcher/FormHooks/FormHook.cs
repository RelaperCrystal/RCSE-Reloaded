using RCSE_Reloaded.API.Launches.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCSE_Reloaded.Launcher.FormHooks
{
    public class FormHook
    {
        private MainFrm form;
        public FormHook(MainFrm launchForm)
        {
            form = launchForm;
        }

        public void HookSaveFile()
        {
            MainFrm.log.Info("正在准备另存为");
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = CommonVals.filters;
            sfd.Title = "另存为";
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            MainFrm.log.Info("正在弹出另存为对话框");
            DialogResult dr = sfd.ShowDialog();
            MainFrm.log.Info("另存为对话框弹出完毕");
            if (dr == DialogResult.OK)
            {
                form.Editor.Save(sfd.FileName);
                form.isLoaded = true;
                form.loadedContentPath = sfd.FileName;
            }
        }
    }
}
