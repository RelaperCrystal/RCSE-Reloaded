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
        private static readonly log4net.ILog log = LogManager.GetLogger(typeof(MainFrm));
        private static readonly log4net.ILog logc = LogManager.GetLogger(typeof(CompilerManager));

        

        public MainFrm(CommandLineOptions options)
        {
            InitializeComponent();
            log.Info("主窗口组件加载完成");
            editor = new ICSharpCode.AvalonEdit.TextEditor();
            elementHost1.Child = editor;
            log.Info("编辑器加载完成");
            ResetSize();
            this.SizeChanged += MainFrm_SizeChanged;
            CompilerManager.CompilerLog += CompilerManager_CompilerLog;

            log.Info("正在尝试解析命令行参数");
            if(options != null && options.File != null && options.File != "")
            {
                if(File.Exists(options.File))
                {
                    log.Info("文件存在，正在打开");
                    OpenFileWithOptions(options);
                }
                else
                {
                    log.Error("无法解析命令行参数");
                    MessageBox.Show("无法从命令行解析文件。文件未找到。", "命令行错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CompilerManager_CompilerLog(Type sender, string message)
        {
            logc.Info(message);
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

        public static void ParseArgsAndRun(string[] args, Logger logger)
        {
            ParserResult<CommandLineOptions> Option;
            try
            {
                Option = Parser.Default.ParseArguments<CommandLineOptions>(args);
                Option.WithParsed(RunParsed);
            }
            catch(Exception ex)
            {
                log.Fatal("在运行时发生错误。消息: " + ex.Message + "，来源: " + ex.Source, ex);
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
            log.Info("正在准备打开新文件");
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = CommonVals.filters;
            ofd.Title = "打开文件";
            ofd.CheckFileExists = true;
            log.Info("正在弹出选择文件对话框");
            DialogResult dr = ofd.ShowDialog();
            log.Info("文件选择对话框显示完成");
            if(dr == DialogResult.OK && File.Exists(ofd.FileName))
            {
                log.Info("用户选择确定，文件存在");
                isLoaded = true;
                loadedContentPath = ofd.FileName;
                editor.Load(ofd.FileName);
                editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(ofd.FileName));
                log.Info("成功加载文件");
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
            log.Info("正在准备另存为");
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = CommonVals.filters;
            sfd.Title = "另存为";
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            log.Info("正在弹出另存为对话框");
            DialogResult dr = sfd.ShowDialog();
            log.Info("另存为对话框弹出完毕");
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
            log.Info("保存文件中");
            if (isLoaded && loadedContentPath != null && loadedContentPath != String.Empty)
            {
                log.Info("文件已被保存过，正在覆盖");
                editor.Save(loadedContentPath);
            }
            else
            {
                log.Info("文件未被保存过，正在执行另存为");
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
            SaveFile();
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
            log.Info("编译程序启动");
            if (editor.Text == "")
            {
                log.Info("编辑框为空");
                MessageBox.Show("错误：编辑框为空。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            log.Info("正在进行编译");
            CompilerResults cr = CompilerManager.CompileFromString(editor.Text);
            log.Info("输出框弹出");
            OutputForm of = new OutputForm();
            of.Owner = this;
            string tempcr = "=================== 编译器输出 ===================";
            foreach(string str in cr.Output)
            {
                tempcr = tempcr + "\r\n" + str;
            }
            of.OutputText = tempcr;
            of.Show();

            log.Info("正在检查操作");
            if (!File.Exists("rcse_compiled.cache.lk"))
            {
                log.Info("返回: 未能找到被编译文件");
                MessageBox.Show("无法找到编译文件: 是否编译错误?", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            log.Info("编译成功，正在重命名文件");
            File.Move("rcse_compiled.cache.lk", "dbgcache.exe");
        }

        private void strpbtnNew_Click(object sender, EventArgs e) => NewFile();
        private void strpbtnSave_Click(object sender, EventArgs e) => DetectAndSaveFile();

        private void strpbtnRun_Click(object sender, EventArgs e)
        {
            CompileWithErrorHandler();
            if (!File.Exists("rcse_compiled.cache.lk"))
            {
                log.Info("运行状态: 运行失败");
                tlabelStatus.Text = "运行失败";
                return;
            }
            log.Info("编译成功，启动程序");
            Process.Start("dbgcache.exe");
        }
    }
}
