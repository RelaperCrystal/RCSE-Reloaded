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
using MetroFramework;
using MetroFramework.Forms;
using RCSE_Reloaded.API;
using CommandLine;
using System.CodeDom.Compiler;

namespace RCSE_Reloaded
{
    public partial class MainFrm : Form
    {
        ICSharpCode.AvalonEdit.TextEditor editor;
        string loadedContentPath;
        bool isLoaded;
        bool Changed;
        public MainFrm(CommandLineOptions options)
        {
            InitializeComponent();
            editor = new ICSharpCode.AvalonEdit.TextEditor();
            elementHost1.Child = editor;
            ResetSize();
            this.SizeChanged += MainFrm_SizeChanged;

            if(options != null && options.File != null && options.File != "")
            {
                if(File.Exists(options.File))
                {
                    OpenFileWithOptions(options);
                }
                else
                {
                    MessageBox.Show("无法从命令行解析文件。文件未找到。", "命令行错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenFileWithOptions(CommandLineOptions options)
        {
            isLoaded = true;
            loadedContentPath = options.File;
            editor.Load(options.File);
        }

        private void OpenFileWithPath(string path)
        {
            isLoaded = true;
            Changed = false;
            loadedContentPath = path;
            editor.Load(path);
        }

        private void MainFrm_SizeChanged(object sender, EventArgs e) => ResetSize();

        private void ResetSize()
        {
            splitContainer.Height = this.Height - menuStrip1.Height;
            splitContainer.Height = splitContainer.Height - toolStrip1.Height - statusStrip1.Height;
            splitContainer.Width = this.Width;
            buttonCompileNowCs.Width = pageDebug.Width - 5;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
#if DEBUG
            DebugForm debug = new DebugForm(editor);
            debug.Show();
#endif
        }

        public static void ParseArgsAndRun(string[] args)
        {
            ParserResult<CommandLineOptions> Option;
            try
            {
                Option = Parser.Default.ParseArguments<CommandLineOptions>(args);
                Option.WithParsed(RunParsed);
            }
            catch(Exception ex)
            {
                Application.Run(new ErrorForm(ex));
            }
        }

        private void ribbon1_Click(object sender, EventArgs e)
        {

        }

        private static void RunParsed(CommandLineOptions cmdline)
        {
            Application.Run(new MainFrm(cmdline));
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

        private void rButtonOpen_Click(object sender, EventArgs e) => OpenFile();

        #region 菜单
        private void itemQuit_Click(object sender, EventArgs e) => Close();
        private void itemNew_Click(object sender, EventArgs e) => NewFile();

        private void NewFile()
        {
            editor.Text = "";
            editor.SyntaxHighlighting = null;
            isLoaded = false;
            loadedContentPath = "";
            Changed = false;
        }
        #endregion

        private void itemOpen_Click(object sender, EventArgs e) => OpenFile();

        private void itemCSharp_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".cs");

        private void itemFile_Click(object sender, EventArgs e)
        {

        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetectAndSaveFile();
        }

        private void DetectAndSaveFile()
        {
            if (isLoaded && loadedContentPath != null && loadedContentPath != String.Empty)
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
        private void itemAbout_Click(object sender, EventArgs e) => new About().ShowDialog();
        private void MainFrm_SizeChanged_1(object sender, EventArgs e) => ResetSize();

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

        private void itemHTML_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".html");
        private void itemXAML_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".xml");
        private void itemVB_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".vb");
        private void itemPlainC_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".c");
        private void itemCPP_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".cpp");

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

        private void buttonCompileNowCs_Click(object sender, EventArgs e)
        {
            CompileWithErrorHandler();
        }

        private void CompileWithErrorHandler()
        {
            if (editor.Text == "")
            {
                MessageBox.Show("错误：编辑框为空。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CompilerResults cr = CompilerManager.CompileFromString(editor.Text);
            OutputForm of = new OutputForm();
            of.Owner = this;
            string tempcr = "=================== 编译器输出 ===================";
            foreach(string str in cr.Output)
            {
                tempcr = tempcr + "\r\n" + str;
            }
            of.OutputText = tempcr;
            of.Show();

            if (!File.Exists("rcse_compiled.cache.lk"))
            {
                MessageBox.Show("无法找到编译文件: 是否编译错误?", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            File.Move("rcse_compiled.cache.lk", "dbgcache.exe");
        }

        private void strpbtnNew_Click(object sender, EventArgs e) => NewFile();
        private void strpbtnSave_Click(object sender, EventArgs e) => DetectAndSaveFile();
    }
}
