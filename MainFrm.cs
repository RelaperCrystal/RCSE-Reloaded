using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RCSE_Reloaded
{
    public partial class MainFrm : Form
    {
        ICSharpCode.AvalonEdit.TextEditor editor;
        string loadedContentPath;
        bool isLoaded;
        bool Changed;
        public MainFrm()
        {
            InitializeComponent();
            editor = new ICSharpCode.AvalonEdit.TextEditor();
            elementHost1.Child = editor;
            
            this.SizeChanged += MainFrm_SizeChanged;
        }

        private void MainFrm_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }

        private void ribbon1_Click(object sender, EventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = CommonVals.filters;
            ofd.Title = "打开文件";
            ofd.CheckFileExists = true;
            DialogResult dr = ofd.ShowDialog();
            if(dr == DialogResult.OK && File.Exists(ofd.FileName))
            {
                isLoaded = true;
                loadedContentPath = ofd.FileName;
                editor.Load(ofd.FileName);
                editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(ofd.FileName));
            }
        }

        private void SaveFileAdjust()
        {
            if(!isLoaded || loadedContentPath == null || loadedContentPath == String.Empty)
            {
                SaveFile();
            }
            else
            {
                editor.Save(loadedContentPath);
            }
            Changed = false;
            editor.TextChanged += Editor_TextChanged;
        }

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            this.Changed = true;
            Text = "(已更改) " + this.Text;
        }

        private void SaveFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = CommonVals.filters;
            sfd.Title = "保存文件";
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            DialogResult dr = sfd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                editor.Save(sfd.FileName);
                isLoaded = true;
                loadedContentPath = sfd.FileName;
            }
        }

        private void rButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        #region 菜单
        private void itemQuit_Click(object sender, EventArgs e) => Close();

        private void itemNew_Click(object sender, EventArgs e)
        {
            editor.Text = "";
            editor.SyntaxHighlighting = null;
        }
        #endregion

        private void itemOpen_Click(object sender, EventArgs e) => OpenFile();

        private void itemCSharp_Click(object sender, EventArgs e)
        {
            editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".cs");
        }

        private void itemFile_Click(object sender, EventArgs e)
        {

        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(isLoaded && loadedContentPath != null && loadedContentPath != String.Empty)
            {
                editor.Save(loadedContentPath);
            }
            else
            {
                SaveFile();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tlabelStatus_Click(object sender, EventArgs e)
        {

        }

        private void itemSaveTo_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = CommonVals.filters;
            sfd.Title = "保存文件";
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                editor.Save(sfd.FileName);
                isLoaded = true;
                loadedContentPath = sfd.FileName;
            }
            
        }

        private void itemHelp_Click(object sender, EventArgs e)
        {

        }

        private void itemAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void MainFrm_SizeChanged_1(object sender, EventArgs e)
        {
            int ThisHeight = this.Height;
            int StatusHeight = this.statusStrip1.Height;
            int MenuHeight = this.menuStrip1.Height;
            int final = ThisHeight - StatusHeight;
            int DeScale = final - 40;
            int result = DeScale - MenuHeight;
            splitContainer.Width = this.Width - 5;
            splitContainer.Height = result;

            
        }

        private void splitContainer_Resize(object sender, EventArgs e)
        {
            elementHost1.Width = splitContainer.Panel2.Width;
            elementHost1.Height = splitContainer.Height;
        }

        private void splitContainer_Panel2_SizeChanged(object sender, EventArgs e)
        {
            elementHost1.Width = splitContainer.Panel2.Width;
            elementHost1.Height = splitContainer.Height;
        }

        private void itemHTML_Click(object sender, EventArgs e)
        {
            editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".html");
        }

        private void itemXAML_Click(object sender, EventArgs e)
        {
            editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".xml");
        }

        private void itemVB_Click(object sender, EventArgs e)
        {
            editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".vb");
        }

        private void itemPlainC_Click(object sender, EventArgs e)
        {
            editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".c");
        }

        private void itemCPP_Click(object sender, EventArgs e)
        {
            editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".cpp");
        }

        private void itemOpenInBrowser_Click(object sender, EventArgs e)
        {
            if(!isLoaded || loadedContentPath == null || loadedContentPath == "")
            {
                MessageBox.Show("错误：您必须先保存文件至少一次。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Changed)
            {
                SaveFileAdjust();
            }
            if(Path.GetExtension(loadedContentPath) == ".htm"|| Path.GetExtension(loadedContentPath) == ".html" || Path.GetExtension(loadedContentPath) == ".xml")
            {
                Process.Start(loadedContentPath);
            }
            else
            {
                MessageBox.Show("错误：不是 HTML 或 XAML 文件。\r\n如果确实是上述文件，请将其后缀名变为对应的后缀名。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
#if DEBUG
                MessageBox.Show(loadedContentPath + "\r\n" + Path.GetExtension(loadedContentPath));
#endif
                return;
            }


            
        }
    }
}
