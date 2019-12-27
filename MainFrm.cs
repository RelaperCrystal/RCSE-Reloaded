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
using RCSE_Reloaded.API.Localization;
using CommandLine;
using System.CodeDom.Compiler;
using System.Drawing.Printing;

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

        Language CurrentLanguage { get; set; }

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

            if(Properties.Settings.Default.Language == "none")
            {
                CurrentLanguage = LangIDHelper.GetLanguage();
                Properties.Settings.Default.Language = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            }
            else
            {
                CurrentLanguage = LangIDHelper.GetLanguage(Properties.Settings.Default.Language);
            }

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
                    if(System.Threading.Thread.CurrentThread.CurrentCulture.Name == "zh-CN")
                    {
                        MessageBox.Show("Cannot parse & open file from console, \r\nbecause there's error on console.", "Console Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("无法从命令行解析文件。文件未找到。", "命令行错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            RefreshSettings();
        }

        public void ApplyAndSaveConfiguration(Setting settings)
        {
            Properties.Settings.Default.UseMainMenu = settings.UseMainMenu;
            Properties.Settings.Default.UseLightTheme = settings.UseWhiteColor;
            Properties.Settings.Default.Save();
            RefreshSettings();
        }

        public void RefreshSettings()
        {
            if(Properties.Settings.Default.UseMainMenu)
            {
                CreateMainMenu();
            }
        }

        #region MainMenu

        MainMenu nativeMenu;
        private MenuItem nativeFile;
        MenuItem nativeNew;
        MenuItem nativeOpen;
        MenuItem nativeSettings;
        MenuItem nativeSaveTo;
        MenuItem nativeSave;
        MenuItem nativePrint;
        MenuItem nativeSplit1;
        MenuItem nativeExit;

        MenuItem nativeEdit;

        MenuItem nativeDebug;
        MenuItem nativeOpenInBrowser;

        MenuItem nativeFormat;
        MenuItem nativeHTML;
        MenuItem nativeXAML;
        MenuItem nativeVB;
        MenuItem nativeC;

        MenuItem nativeHelp;
        MenuItem nativeAbout;
        private MenuItem nativeCSharp;

        public void CreateMainMenu()
        {
            nativeMenu = new MainMenu();

            nativeFile = new MenuItem();

            nativeOpen = new MenuItem();
            nativeNew = new MenuItem();
            nativeSettings = new MenuItem();
            nativeSaveTo = new MenuItem();
            nativeSave = new MenuItem();
            nativePrint = new MenuItem();
            nativeExit = new MenuItem();
            nativeSplit1 = new MenuItem();

            nativeOpen.Text = "打开(&P)";
            nativeNew.Text = "新建(&N)";
            nativeSettings.Text = "设置";
            nativeSaveTo.Text = "另存为(&A)";
            nativePrint.Text = itemPrint.Text;
            nativeSave.Text = "保存(&S)";
            nativeSplit1.Text = "-";
            nativeExit.Text = "退出(&Q)";
            nativeFile.Text = "文件(&F)";

            nativeOpen.Click += NativeOpen_Click;
            nativeNew.Click += NativeNew_Click;
            nativeSettings.Click += itemSetting_Click;
            nativeSaveTo.Click += itemSaveTo_Click;
            nativeSave.Click += 保存SToolStripMenuItem_Click;
            nativePrint.Click += itemPrint_Click;
            nativeExit.Click += itemQuit_Click;

            menuStrip1.Visible = false;

            nativeFile.MenuItems.Add(nativeNew);
            nativeFile.MenuItems.Add(nativeSettings);
            nativeFile.MenuItems.Add(nativeSaveTo);
            nativeFile.MenuItems.Add(nativeSave);
            nativeFile.MenuItems.Add(nativePrint);
            nativeFile.MenuItems.Add(nativeSettings);
            nativeFile.MenuItems.Add(nativeSplit1);
            nativeFile.MenuItems.Add(nativeExit);

            nativeEdit = new MenuItem();
            nativeEdit.Text = "编辑(&E)";

            nativeDebug = new MenuItem();
            nativeOpenInBrowser = new MenuItem();

            nativeDebug.Text = "调试(&D)";
            nativeOpenInBrowser.Text = itemOpenInBrowser.Text;
            nativeDebug.MenuItems.Add(nativeOpenInBrowser);

            nativeFormat = new MenuItem();
            nativeHTML = new MenuItem();
            nativeXAML = new MenuItem();
            nativeVB = new MenuItem();
            nativeC = new MenuItem();

            nativeFormat.Text = itemFormat.Text;
            nativeCSharp = new MenuItem();
            nativeCSharp.Text = itemCSharp.Text;
            nativeHTML.Text = itemHTML.Text;
            nativeXAML.Text = itemXAML.Text;
            nativeVB.Text = itemVB.Text;
            nativeC.Text = itemCSeries.Text;

            nativeFormat.MenuItems.Add(nativeCSharp);
            nativeFormat.MenuItems.Add(nativeHTML);
            nativeFormat.MenuItems.Add(nativeXAML);
            nativeFormat.MenuItems.Add(nativeVB);
            nativeFormat.MenuItems.Add(nativeC);

            nativeHelp = new MenuItem();
            nativeAbout = new MenuItem();

            nativeOpenInBrowser.Click += itemOpenInBrowser_Click;
            nativeCSharp.Click += itemCSharp_Click;
            nativeHTML.Click += itemHTML_Click;
            nativeXAML.Click += itemXAML_Click;
            nativeVB.Click += itemXAML_Click;

            nativeHelp.Text = itemHelp.Text;
            nativeAbout.Text = itemAbout.Text;

            nativeAbout.Click += itemAbout_Click;
            nativeHelp.MenuItems.Add(nativeAbout);

            nativeMenu.MenuItems.Add(nativeFile);
            nativeMenu.MenuItems.Add(nativeEdit);
            nativeMenu.MenuItems.Add(nativeDebug);
            nativeMenu.MenuItems.Add(nativeFormat);
            nativeMenu.MenuItems.Add(nativeHelp);
            Menu = nativeMenu;
        }

        private void NativeNew_Click(object sender, EventArgs e) => itemNew_Click(sender, e);
        private void NativeOpen_Click(object sender, EventArgs e) => itemOpen_Click(sender, e);

        #endregion

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
        private void itemAbout_Click(object sender, EventArgs e) => new NewAbout().ShowDialog();
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
                if(System.Threading.Thread.CurrentThread.CurrentCulture.Name == "zh-CN")
                {
                    MessageBox.Show("错误：您必须先保存文件至少一次。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("You must save this file as least once.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
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
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name == "zh-CN")
                {
                    MessageBox.Show("错误：不是 HTML 或 XML 文件。\r\n如果确实是上述文件，请将其后缀名变为对应的后缀名。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: Not HTML or XML file. \r\nIf the file you wanna open in browser, are HTML or XAML files, please\r\nrename the extension to .htm, .html, or .xml", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if(System.Threading.Thread.CurrentThread.CurrentCulture.Name == "zh-CN")
                {
                    MessageBox.Show("错误：编辑框为空。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("The textbox is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            log.Info("正在进行编译");
            CompilerResults cr = CompilerManager.CompileFromString(editor.Text);
            log.Info("输出框弹出");
            OutputForm of = new OutputForm();
            of.Owner = this;
            string tempcr = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "zh-CN"
                ? "================ Compiler Output ================"
                : "=================== 编译器输出 ===================";
            foreach (string str in cr.Output)
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

        private void itemSetting_Click(object sender, EventArgs e)
        {
            SettingsFrm settingsFrm = new SettingsFrm(this);
            settingsFrm.Show();
        }

        private void itemPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = "RCSE Text";
            pd.PrintPage += printDocument_PrintA4Page;
            PrintDialog pdi = new PrintDialog();
            if(pdi.ShowDialog() == DialogResult.OK)
            {
                log.Info("用户确定进行打印");
                pd.PrinterSettings = pdi.PrinterSettings;
                
                pd.Print();
            }
            else
            {
                log.Info("用户取消打印，正在强制清理对象");
                GC.Collect();
            }
        }

        private void printDocument_PrintA4Page(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("黑体", 11, System.Drawing.FontStyle.Bold);//标题字体           
            Font fntTxt = new Font("宋体", 10, System.Drawing.FontStyle.Regular);//正文文字         
            Font fntTxt1 = new Font("宋体", 8, System.Drawing.FontStyle.Regular);//正文文字           
            System.Drawing.Brush brush = new SolidBrush(System.Drawing.Color.Black);//画刷           
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black);           //线条颜色         

            try
            {
                e.Graphics.DrawString(editor.Text, fntTxt, brush, 0, 0);

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public static void SetFormLanguage(MainFrm form)
        {
            Language lang = form.CurrentLanguage;
            if(form.CurrentLanguage != Language.English && form.CurrentLanguage != Language.SimpChinese)
            {

            }
        }
    }
}
