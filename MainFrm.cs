using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RCSE_Reloaded.API;
using RCSE_Reloaded.API.Localization;
using CommandLine;
using System.CodeDom.Compiler;
using System.Drawing.Printing;
using RCSE_Reloaded.API.FluentService;
using RCSE_Reloaded.API.Launches.Form;
using CrystalEngine.Simple.Dialogs;
using Neon.Downloader;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using RCSE_Reloaded.LocalizedRes;
using System.Threading;
using System.Globalization;

namespace RCSE_Reloaded
{
    public partial class MainFrm : Form, ILaunchForm
    {
        internal ICSharpCode.AvalonEdit.TextEditor Editor
        {
            get
            {
                return editor;
            }
        }

        ICSharpCode.AvalonEdit.TextEditor editor;
        internal string loadedContentPath;
        internal bool isLoaded;
        internal bool Changed;
        private bool powerSaving;
        internal static readonly log4net.ILog log = LogManager.GetLogger(typeof(MainFrm));
        internal static readonly log4net.ILog logc = LogManager.GetLogger(typeof(CompilerManager));

        Language CurrentLanguage { get; set; }

        public bool CanExit => throw new NotImplementedException();

        public MainFrm(CommandLineOptions options)
        {
            if(options.Culture != "default")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(options.Culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(options.Culture);
            }
            log.Info("Legacy Form 版本 " + CommonVals.legacyFormVersion);
            InitializeComponent();
            log.Info("主窗口组件加载完成");
            editor = new ICSharpCode.AvalonEdit.TextEditor();
            elementHost1.Child = editor;
            log.Info("编辑器加载完成");
            ResetSize();
            this.SizeChanged += MainFrm_SizeChanged;
            CompilerManager.CompilerLog += CompilerManager_CompilerLog;
            editor.TextChanged += Editor_TextChanged;

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

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*
        public Task<bool> IsVersionCurrent()
        {
            WebClient wc = new WebClient();
            Dictionary<string, string> d = new Dictionary<string, string>();
            string ver = wc.DownloadString("https://pastebin.com/raw/9T8ffyun");
            d = JsonConvert.DeserializeObject<Dictionary<string, string>>(ver);
            string thisVer = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return !string.IsNullOrEmpty(ver) && thisVer != ver ? Task.FromResult<bool>(false) : Task.FromResult<bool>(true);
        }
        */


        private void MainFrm_Load(object sender, EventArgs e)
        {
#if DEBUG
            DebugForm debug = new DebugForm(editor);
            debug.Show();
            editor.Text = "请注意，个别杀毒软件将本软件列为病毒。本人郑重宣布，此软件非病毒。\r\n" +
                "------------------------------------------\r\nAttention\r\n\r\nSome AntiVirus softwares mark" + CommonVals.programShortName +" as virus.\r\n" +
                "I declare this software is not a virus.";
            MessageBox.Show("载入测试");
           
#endif
            if(Properties.Settings.Default.UseFluentDesign)
            {
                MessageBox.Show(CommonVals.programName + MessageBoxes.FluentWarning);
                Transparent.SetBlur(this.Handle);
                this.TransparencyKey = Color.Black;
                LogManager.GetLogger(typeof(MainFrm)).Warn("正在使用亚克力特效");
            }

            if (!Properties.Settings.Default.UseFluentDesign)
            {
#pragma warning disable CS0162 // 检测到无法访问的代码
                // 无法访问是因为 isSnapshot 是常量，
                // 然而会被更改
                if (CommonVals.isSnapshot)
                {
                    Text = CommonVals.programName + " Snapshot - code version " + CommonVals.snapshot + " for " + CommonVals.verNumber;
                }
                else
                {

                    Text = CommonVals.programName + " " + CommonVals.verNumber;

                }
#pragma warning restore CS0162 // 检测到无法访问的代码
            }
            else
            {
                Text = "";
            }

            RefreshSettings(true);
        }

        public void ApplyAndSaveConfiguration(Setting settings)
        {
            Properties.Settings.Default.UseMainMenu = settings.UseMainMenu;
            Properties.Settings.Default.UseLightTheme = settings.UseWhiteColor;
            Properties.Settings.Default.UseFluentDesign = settings.UseFluentDesign;
            Properties.Settings.Default.Save();
            RefreshSettings();
        }

        public void RefreshSettings(bool start = false)
        {
            if(Properties.Settings.Default.UseMainMenu)
            {
                CreateMainMenu();
            }
            if(!start && !powerSaving)
            {
                MessageBox.Show(MessageBoxes.FluentSave.Replace("{nameShort}", CommonVals.programShortName));
            }
        }

        #region MainMenu

        MainMenu nativeMenu;
        private MenuItem nativeFile;
        MenuItem nativeNew;
        MenuItem nativeOpen;
        MenuItem nativeNewWindow;
        MenuItem nativeSettings;
        MenuItem nativeSaveTo;
        MenuItem nativeSave;
        MenuItem nativePrint;
        MenuItem nativeSplit1;
        MenuItem nativeExit;

        MenuItem nativeEdit;
        MenuItem nativeCopy;
        MenuItem nativeCut;
        MenuItem nativeSplit2;
        MenuItem nativePaste;
        MenuItem nativeUndo;
        MenuItem nativeRedo;
        MenuItem nativeSelectAll;
        MenuItem nativeSplit3;
        MenuItem nativeDateTime;
        MenuItem nativeBingSearch;

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
            nativeNewWindow = new MenuItem();
            nativeSettings = new MenuItem();
            nativeSaveTo = new MenuItem();
            nativeSave = new MenuItem();
            nativePrint = new MenuItem();
            nativeExit = new MenuItem();
            nativeSplit1 = new MenuItem();

            nativeOpen.Text = itemOpen.Text;
            nativeNew.Text = itemNew.Text;
            nativeNewWindow.Text = itemNewWindow.Text;
            nativeSettings.Text = itemSettings.Text;
            nativeSaveTo.Text = itemSaveTo.Text;
            nativePrint.Text = itemPrint.Text;
            nativeSave.Text = itemSave.Text;
            nativeSplit1.Text = "-";
            nativeExit.Text = itemQuit.Text;
            nativeFile.Text = itemFile.Text;

            nativeOpen.Click += NativeOpen_Click;
            nativeNew.Click += NativeNew_Click;
            nativeSettings.Click += itemSetting_Click;
            nativeSaveTo.Click += itemSaveTo_Click;
            nativeSave.Click += 保存SToolStripMenuItem_Click;
            nativePrint.Click += itemPrint_Click;
            nativeExit.Click += itemQuit_Click;
            nativeNewWindow.Click += itemNewWindow_Click;

            menuStrip1.Visible = false;

            nativeFile.MenuItems.Add(nativeNew);
            nativeFile.MenuItems.Add(nativeOpen);
            nativeFile.MenuItems.Add(nativeNewWindow);
            nativeFile.MenuItems.Add(nativeSettings);
            nativeFile.MenuItems.Add(nativeSaveTo);
            nativeFile.MenuItems.Add(nativeSave);
            nativeFile.MenuItems.Add(nativePrint);
            nativeFile.MenuItems.Add(nativeSettings);
            nativeFile.MenuItems.Add(nativeSplit1);
            nativeFile.MenuItems.Add(nativeExit);

            nativeEdit = new MenuItem();
            nativeCopy = new MenuItem();
            nativeCut = new MenuItem();
            nativePaste = new MenuItem();
            nativeUndo = new MenuItem();
            nativeRedo = new MenuItem();
            nativeSelectAll = new MenuItem();
            nativeDateTime = new MenuItem();
            nativeBingSearch = new MenuItem();

            nativeEdit.Text = "编辑(&E)";
            nativeCopy.Text = itemCopy.Text;
            nativeCut.Text = itemCut.Text;
            nativePaste.Text = itemPaste.Text;
            nativeUndo.Text = itemUndo.Text;
            nativeRedo.Text = itemRedo.Text;
            nativeSelectAll.Text = itemSelectAll.Text;
//            nativeDateTime.Text = itemInsert.Text;
            nativeBingSearch.Text = itemSearchWithBing.Text;

            nativeSplit2 = new MenuItem();
            nativeSplit2.Text = "-";

            nativeEdit.MenuItems.Add(nativeCopy);
            nativeEdit.MenuItems.Add(nativeCut);
            nativeEdit.MenuItems.Add(nativeSplit2);
            nativeEdit.MenuItems.Add(nativePaste);
            nativeEdit.MenuItems.Add(nativeUndo);
            nativeEdit.MenuItems.Add(nativeRedo);
            nativeEdit.MenuItems.Add(nativeSelectAll);

            nativeSplit3 = new MenuItem();
            nativeSplit3.Text = "-";

            nativeEdit.MenuItems.Add(nativeDateTime);
            nativeEdit.MenuItems.Add(nativeBingSearch);

            nativeCopy.Click += itemCopy_Click;
            nativeCut.Click += itemCut_Click;
            nativePaste.Click += itemPaste_Click;
            nativeUndo.Click += itemUndo_Click;
            nativeRedo.Click += itemRedo_Click;
            nativeSelectAll.Click += itemSelectAll_Click;
            nativeDateTime.Click += itemInsertDateTime_Click;
            nativeBingSearch.Click += itemSearchWithBing_Click;

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
                if (ofd.FileName.EndsWith(".pko"))
                {
                    HighlightingManager.Instance.GetDefinitionByExtension(".txt");
                    return;
                }
                editor.Load(ofd.FileName);
                if(!powerSaving)
                {
                    editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(ofd.FileName));
                }
                else
                {
                    log.Warn("节电模式，不开启语法高亮");
                }

                log.Info("成功加载文件");
            }
        }

        void SaveFileAdjust()
        {
            if(!isLoaded || loadedContentPath == null || loadedContentPath == String.Empty)
            {
                InternalSaveFile();
            }
            else
            {
                editor.Save(loadedContentPath);
            }
            Changed = false;
            this.Text.Remove(0, 6);
        }

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            if(!Changed)
            {
                this.Changed = true;
                Text = "(已更改) " + this.Text;

            }
            
        }

        void ILaunchForm.SaveFile() => InternalSaveFile();

        private void InternalSaveFile()
        {
            log.Info("正在准备另存为");
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = CommonVals.filters;
            sfd.Title = MessageBoxes.SaveAsBoxTitle;
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            log.Info("正在弹出另存为对话框");
            DialogResult dr = sfd.ShowDialog();
            log.Info("另存为对话框弹出完毕");
            if (dr == DialogResult.OK)
            {
                editor.Save(sfd.FileName);
                isLoaded = true;
                loadedContentPath = sfd.FileName;
            }
            /* else if(sfd.FileName.EndsWith(".pko"))
            {
                try
                {
                    // Panko.SaveAsPanko(sfd.FileName, editor.Text);
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Panko 编码器错误: \r\n" + ex.ToString(), "Panko 编码器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
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
                InternalSaveFile();
            }
        }

        private void tlabelStatus_Click(object sender, EventArgs e)
        {

        }

        private void itemSaveTo_Click(object sender, EventArgs e)
        {
            InternalSaveFile();
        }

        private void itemHelp_Click(object sender, EventArgs e)
        {

        }
        private void itemAbout_Click(object sender, EventArgs e) => new NewAbout().ShowDialog();
        private void MainFrm_SizeChanged_1(object sender, EventArgs e) => ResetSize();

        private void splitContainer_Resize(object sender, EventArgs e)
        {
        }

        private void splitContainer_Panel2_SizeChanged(object sender, EventArgs e)
        {
        }

        private void itemHTML_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".html");
        private void itemXAML_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".xml");
        private void itemVB_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".vb");
        private void itemPlainC_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".c");
        private void itemCPP_Click(object sender, EventArgs e) => editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".cpp");

        private void itemOpenInBrowser_Click(object sender, EventArgs e)
        {
            if(powerSaving)
            {
                MessageBox.Show(MessageBoxes.PowerSavingPrint);
                return;
            }
            if(!isLoaded || loadedContentPath == null || loadedContentPath == "")
            {
                MessageBox.Show(MessageBoxes.PrintNotSaved);
                
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
                MessageBox.Show(MessageBoxes.NotMarkup);
#if DEBUG
                MessageBox.Show(loadedContentPath + "\r\n" + Path.GetExtension(loadedContentPath));
#endif
                return;
            }


            
        }

        private void CompileWithErrorHandler()
        {
            log.Info("编译程序启动");
            if (editor.Text == "")
            {
                log.Info("编辑框为空");
                MessageBox.Show(MessageBoxes.EmptyTextBox, MessageBoxes.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show(MessageBoxes.CompiledNotFound, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if(powerSaving)
            {
                MessageBox.Show(MessageBoxes.PowerSavingPrint);
                return;
            }
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = CommonVals.programShortName + " Text";
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

        private void itemCopy_Click(object sender, EventArgs e) => editor.Copy();
        private void itemCut_Click(object sender, EventArgs e) => editor.Cut();
        private void itemPaste_Click(object sender, EventArgs e) => editor.Paste();

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.Info("用户尝试退出");
            DialogResult result;
            if(Changed)
            {
                if(e.CloseReason == CloseReason.WindowsShutDown && !powerSaving)
                {
                    e.Cancel = true;
                    MessageBox.Show(MessageBoxes.CloseWindowsShutdown, MessageBoxes.TitleError);
                    return;
                }
                result = MessageBox.Show(MessageBoxes.CloseNotSaved, MessageBoxes.TitleWarning, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch(result)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        DetectAndSaveFile();
                        break;
                    default:
                    case DialogResult.No:
                        return;
                }
            }
        }

        private void itemMeetFile_Click(object sender, EventArgs e)
        {

        }

        void ILaunchForm.DetectAndSaveFile()
        {
            DetectAndSaveFile();
        }

        public void Start() => Show();
        public void Exit() => Close();

        public void LaunchWithArgs(string[] args)
        {
            ParseArgsAndRun(args, new Logger());
        }

        public void ExceptionOccoured(Exception ex)
        {
            throw new NotImplementedException();
        }

        private void itemSysInfo_Click(object sender, EventArgs e)
        {
            Process.Start("msinfo32");
        }

        #region 表达式事件处理器
        private void itemUndo_Click(object sender, EventArgs e) => editor.Undo();
        private void itemRedo_Click(object sender, EventArgs e) => editor.Redo();
        private void itemSelectAll_Click(object sender, EventArgs e) => editor.SelectAll();
        private void itemInsertDateTime_Click(object sender, EventArgs e) => editor.AppendText(DateTime.Now.ToString());
        #endregion

        private void itemSearchWithBing_Click(object sender, EventArgs e)
        {
            string text = editor.SelectedText;
            if (!string.IsNullOrWhiteSpace(text))
            {
                Process.Start("https://cn.bing.com/search?q=" + text);
            }
            else return;
        }

        private void itemNewWindow_Click(object sender, EventArgs e)
        {
            new MainFrm(new CommandLineOptions()).Show();
        }

        private void itemEdit_Click(object sender, EventArgs e)
        {

        }

        private void toolCompile_Click(object sender, EventArgs e) => CompileWithErrorHandler();

        private void itemInsertLicense_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MessageBoxes.NotImplemented);
        }

        private void itemSettings_Click(object sender, EventArgs e)
        {

            DialogResult dr = new SettingsFrm(this).ShowDialog();
        }

        private void itemSavePower_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MessageBoxes.PowerSavingON);
            log.Info("节电模式开");
            CrystalEngine.Logging.EngineLog loge = new CrystalEngine.Logging.EngineLog();
            loge.Info("Power Saving mode was turned ON. Some features will be disabled.", this);
            powerSaving = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            tlabelStatus.Text = "节电模式";
            statusStrip1.BackColor = SystemColors.Control;
            tlabelStatus.ForeColor = SystemColors.ControlText;
            Text = Text + " (节电模式)";
        }

        private void itemOpenFromWeb_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox();
            ib.Description = MessageBoxes.InputDownload;
            ib.Text = MessageBoxes.InputDownloadTitle;
            if (ib.ShowDialog() == DialogResult.OK)
            {
                tlabelStatus.Text = MessageBoxes.StatusDownload;
                WebClient dc = new WebClient();
                toolProgress.Style = ProgressBarStyle.Marquee;
                toolProgress.Visible = true;
                toolProgress.MarqueeAnimationSpeed = 50;
                try
                {
                    string str = dc.DownloadString(ib.ResultText);
                    editor.Text = str;
                    var serializer = new JavaScriptSerializer();
                    dynamic obj = serializer.Deserialize(str, typeof(object));
                    if(obj != null)
                    {
                        editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("JSON");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"{MessageBoxes.InputDownloadFailed}\r\n{ex.GetType().Name}: {ex.Message}\r\n{ex.StackTrace}");
                }
                finally
                {
                    toolProgress.Visible = false;
                    toolProgress.Style = ProgressBarStyle.Continuous;
                    tlabelStatus.Text = MessageBoxes.StatusReady;
                }
            }
            
        }

        private void itemAutoScroll_Click(object sender, EventArgs e)
        {
            editor.WordWrap = itemAutoScroll.Checked;
        }
    }
}
