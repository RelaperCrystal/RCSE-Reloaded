using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public MainFrm()
        {
            InitializeComponent();
            editor = new ICSharpCode.AvalonEdit.TextEditor();
            elementHost1.Child = editor;
            
            this.SizeChanged += MainFrm_SizeChanged;
        }

        private void MainFrm_SizeChanged(object sender, EventArgs e)
        {
            elementHost1.Width = this.Width;
            elementHost1.Height = this.Height - 84;
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
            ofd.Filter = "C# 源代码 (*.cs)|*.cs|C++ 源代码 (*.cpp)|*.cpp|Visual Basic 源代码 (*.vb)|*.vb|所有文件 (*.*)|*.*";
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

        private void SaveFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "C# 源代码 (*.cs)|*.cs|C++ 源代码 (*.cpp)|*.cpp|Visual Basic 源代码 (*.vb)|*.vb|所有文件 (*.*)|*.*";
            sfd.Title = "保存文件";
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            DialogResult dr = sfd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                editor.Save(sfd.FileName);
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
            sfd.Filter = "C# 源代码 (*.cs)|*.cs|C++ 源代码 (*.cpp)|*.cpp|Visual Basic 源代码 (*.vb)|*.vb|所有文件 (*.*)|*.*";
            sfd.Title = "保存文件";
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                editor.Save(sfd.FileName);
            }
            isLoaded = true;
            loadedContentPath = sfd.FileName;
        }
    }
}
