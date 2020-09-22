// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

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
using System.Net;
using System.Web.Script.Serialization;
using RCSE_Reloaded.LocalizedRes;
using System.Threading;
using System.Globalization;

namespace RCSE_Reloaded
{
	public partial class MainFrm : Form, ILaunchForm
	{
		internal ICSharpCode.AvalonEdit.TextEditor Editor { get; }

		internal string loadedContentPath;
		internal bool isLoaded;
		internal bool Changed;
		private bool powerSaving;
		internal static readonly log4net.ILog log = LogManager.GetLogger(typeof(MainFrm));
		internal static readonly log4net.ILog logc = LogManager.GetLogger(typeof(CompilerManager));

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
			Editor = new ICSharpCode.AvalonEdit.TextEditor();
			elementHost1.Child = Editor;
			log.Info("编辑器加载完成");
			this.SizeChanged += MainFrm_SizeChanged;
			CompilerManager.CompilerLog += CompilerManager_CompilerLog;
			Editor.TextChanged += Editor_TextChanged;

			log.Info("正在尝试解析命令行参数");
			if(options != null && string.IsNullOrWhiteSpace(options.File))
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

		private void CompilerManager_CompilerLog(Type sender, string message) => logc.Info(message);

		private void OpenFileWithOptions(CommandLineOptions options)
		{
			isLoaded = true;
			loadedContentPath = options.File;
			Editor.Load(options.File);
		}

		private void MainFrm_SizeChanged(object sender, EventArgs e) { }

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
			Properties.Settings.Default.SearchURL = settings.SearchURL;
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
			nativeSettings.Click += ItemSetting_Click;
			nativeSaveTo.Click += ItemSaveTo_Click;
			nativeSave.Click += ItemSave_Click;
			nativePrint.Click += ItemPrint_Click;
			nativeExit.Click += ItemQuit_Click;
			nativeNewWindow.Click += ItemNewWindow_Click;

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
			nativeBingSearch.Text = itemSearch.Text;

			nativeSplit2 = new MenuItem
			{
				Text = "-"
			};

			nativeEdit.MenuItems.Add(nativeCopy);
			nativeEdit.MenuItems.Add(nativeCut);
			nativeEdit.MenuItems.Add(nativeSplit2);
			nativeEdit.MenuItems.Add(nativePaste);
			nativeEdit.MenuItems.Add(nativeUndo);
			nativeEdit.MenuItems.Add(nativeRedo);
			nativeEdit.MenuItems.Add(nativeSelectAll);
			nativeEdit.MenuItems.Add(nativeDateTime);
			nativeEdit.MenuItems.Add(nativeBingSearch);

			nativeCopy.Click += ItemCopy_Click;
			nativeCut.Click += ItemCut_Click;
			nativePaste.Click += ItemPaste_Click;
			nativeUndo.Click += ItemUndo_Click;
			nativeRedo.Click += ItemRedo_Click;
			nativeSelectAll.Click += ItemSelectAll_Click;
			nativeDateTime.Click += ItemInsertDateTime_Click;
			nativeBingSearch.Click += ItemSearch_Click;

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
			nativeCSharp = new MenuItem
			{
				Text = itemCSharp.Text
			};
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

			nativeOpenInBrowser.Click += ItemOpenInBrowser_Click;
			nativeCSharp.Click += ItemCSharp_Click;
			nativeHTML.Click += ItemHTML_Click;
			nativeXAML.Click += ItemXAML_Click;
			nativeVB.Click += ItemXAML_Click;

			nativeHelp.Text = itemHelp.Text;
			nativeAbout.Text = itemAbout.Text;

			nativeAbout.Click += ItemAbout_Click;
			nativeHelp.MenuItems.Add(nativeAbout);

			nativeMenu.MenuItems.Add(nativeFile);
			nativeMenu.MenuItems.Add(nativeEdit);
			nativeMenu.MenuItems.Add(nativeDebug);
			nativeMenu.MenuItems.Add(nativeFormat);
			nativeMenu.MenuItems.Add(nativeHelp);
			Menu = nativeMenu;
		}

		private void NativeNew_Click(object sender, EventArgs e) => ItemNew_Click(sender, e);
		private void NativeOpen_Click(object sender, EventArgs e) => ItemOpen_Click(sender, e);

		#endregion

		public static void ParseArgsAndRun(string[] args)
		{
			ParserResult<CommandLineOptions> Option;
			try
			{
				Option = Parser.Default.ParseArguments<CommandLineOptions>(args);
				Option.WithParsed(RunParsed);
			}
#pragma warning disable CA1031 // Do not catch general exception types
			catch (Exception ex)
			{
				log.Fatal("在运行时发生错误。消息: " + ex.Message + "，来源: " + ex.Source, ex);
				Application.Run(new ErrorForm(ex));
			}
#pragma warning restore CA1031 // Do not catch general exception types
		}

		private static void RunParsed(CommandLineOptions cmdline)
		{
			Application.Run(new MainFrm(cmdline));
		}

		private void OpenFile()
		{
			log.Info("正在准备打开新文件");
			OpenFileDialog ofd = new OpenFileDialog
			{
				Filter = CommonVals.filters,
				Title = "打开文件",
				CheckFileExists = true
			};
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
				Editor.Load(ofd.FileName);
				if(!powerSaving)
				{
					Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(ofd.FileName));
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
			if(!isLoaded || loadedContentPath == null || string.IsNullOrWhiteSpace(loadedContentPath))
			{
				InternalSaveFile();
			}
			else
			{
				Editor.Save(loadedContentPath);
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
			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter = CommonVals.filters,
				Title = MessageBoxes.SaveAsBoxTitle,
				CheckPathExists = true,
				AddExtension = true
			};
			log.Info("正在弹出另存为对话框");
			DialogResult dr = sfd.ShowDialog();
			log.Info("另存为对话框弹出完毕");
			if (dr == DialogResult.OK)
			{
				Editor.Save(sfd.FileName);
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

		private void RButtonOpen_Click(object sender, EventArgs e) => OpenFile();

		#region 菜单
		private void ItemQuit_Click(object sender, EventArgs e) => Close();
		private void ItemNew_Click(object sender, EventArgs e) => NewFile();

		private void NewFile()
		{
			Editor.Text = "";
			Editor.SyntaxHighlighting = null;
			isLoaded = false;
			loadedContentPath = "";
			Changed = false;
		}
		#endregion

		private void ItemOpen_Click(object sender, EventArgs e) => OpenFile();
		private void ItemCSharp_Click(object sender, EventArgs e) => Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".cs");
		private void ItemFile_Click(object sender, EventArgs e)
		{

		}

		private void ItemSave_Click(object sender, EventArgs e)
		{
			DetectAndSaveFile();
		}

		private void DetectAndSaveFile()
		{
			log.Info("保存文件中");
			if (isLoaded && !string.IsNullOrWhiteSpace(loadedContentPath))
			{
				log.Info("文件已被保存过，正在覆盖");
				Editor.Save(loadedContentPath);
			}
			else
			{
				log.Info("文件未被保存过，正在执行另存为");
				InternalSaveFile();
			}
		}

		private void TlabelStatus_Click(object sender, EventArgs e)
		{

		}

		private void ItemSaveTo_Click(object sender, EventArgs e) => InternalSaveFile();

		private void ItemHelp_Click(object sender, EventArgs e)
		{

		}
		private void ItemAbout_Click(object sender, EventArgs e) => new NewAbout().ShowDialog();
		private void MainFrm_SizeChanged_1(object sender, EventArgs e) { }

		private void ItemHTML_Click(object sender, EventArgs e) => Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".html");
		private void ItemXAML_Click(object sender, EventArgs e) => Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".xml");
		private void ItemVB_Click(object sender, EventArgs e) => Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".vb");
		private void ItemPlainC_Click(object sender, EventArgs e) => Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".c");
		private void ItemCPP_Click(object sender, EventArgs e) => Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(".cpp");

		private void ItemOpenInBrowser_Click(object sender, EventArgs e)
		{
			if (powerSaving)
			{
				MessageBox.Show(MessageBoxes.PowerSavingPrint);
				return;
			}
			if (!isLoaded || string.IsNullOrWhiteSpace(loadedContentPath))
			{
				MessageBox.Show(MessageBoxes.PrintNotSaved);
				
				return;
			}
			if (Changed)
			{
				SaveFileAdjust();
			}
			if (Path.GetExtension(loadedContentPath) == ".htm"|| Path.GetExtension(loadedContentPath) == ".html" || Path.GetExtension(loadedContentPath) == ".xml")
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
			if (string.IsNullOrWhiteSpace(Editor.Text))
			{
				log.Info("编辑框为空");
				MessageBox.Show(MessageBoxes.EmptyTextBox, MessageBoxes.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			log.Info("正在进行编译");
			CompilerResults cr = CompilerManager.CompileFromString(Editor.Text);
			log.Info("输出框弹出");
			OutputForm of = new OutputForm
			{
				Owner = this
			};
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

		private void StrpbtnNew_Click(object sender, EventArgs e) => NewFile();
		private void StrpbtnSave_Click(object sender, EventArgs e) => DetectAndSaveFile();

		private void StrpbtnRun_Click(object sender, EventArgs e)
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

		private void ItemSetting_Click(object sender, EventArgs e)
		{
			SettingsFrm settingsFrm = new SettingsFrm(this);
			settingsFrm.Show();
		}

		private void ItemPrint_Click(object sender, EventArgs e)
		{
			if(powerSaving)
			{
				MessageBox.Show(MessageBoxes.PowerSavingPrint);
				return;
			}
			PrintDocument pd = new PrintDocument
			{
				DocumentName = CommonVals.programShortName + " Text"
			};
			pd.PrintPage += PrintDocument_PrintA4Page;
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

		private void PrintDocument_PrintA4Page(object sender, PrintPageEventArgs e)
		{
#pragma warning disable IDE0059 // 不需要赋值
			Font titleFont = new Font("黑体", 11, System.Drawing.FontStyle.Bold);//标题字体           

			Font fntTxt = new Font("宋体", 10, System.Drawing.FontStyle.Regular);//正文文字         
			Font fntTxt1 = new Font("宋体", 8, System.Drawing.FontStyle.Regular);//正文文字           
			System.Drawing.Brush brush = new SolidBrush(System.Drawing.Color.Black);//画刷           
			System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black);           //线条颜色
#pragma warning restore IDE0059 // 不需要赋值

			try
			{
				e.Graphics.DrawString(Editor.Text, fntTxt, brush, 0, 0);

			}
#pragma warning disable CA1031 // Do not catch general exception types
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
#pragma warning restore CA1031 // Do not catch general exception types
		}

		private void ItemCopy_Click(object sender, EventArgs e) => Editor.Copy();
		private void ItemCut_Click(object sender, EventArgs e) => Editor.Cut();
		private void ItemPaste_Click(object sender, EventArgs e) => Editor.Paste();

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

		void ILaunchForm.DetectAndSaveFile()
		{
			DetectAndSaveFile();
		}

		public void Start() => Show();
		public void Exit() => Close();

		public void LaunchWithArgs(string[] args)
		{
			ParseArgsAndRun(args);
		}

		public void ExceptionOccoured(Exception ex)
		{
			throw new NotImplementedException();
		}

		private void ItemSysInfo_Click(object sender, EventArgs e)
		{
			Process.Start("msinfo32");
		}

		#region 表达式事件处理器
		private void ItemUndo_Click(object sender, EventArgs e) => Editor.Undo();
		private void ItemRedo_Click(object sender, EventArgs e) => Editor.Redo();
		private void ItemSelectAll_Click(object sender, EventArgs e) => Editor.SelectAll();
		private void ItemInsertDateTime_Click(object sender, EventArgs e) => Editor.AppendText(DateTime.Now.ToString());
		#endregion

		private void ItemSearch_Click(object sender, EventArgs e)
		{
			string text = Editor.SelectedText;
			string searcher = Properties.Settings.Default.SearchURL;
			if(string.IsNullOrWhiteSpace(searcher))
			{
				log.Warn("搜索引擎为空");
				searcher = "https://cn.bing.com/search?q=";
				Properties.Settings.Default.SearchURL = "https://cn.bing.com/search?q=";
				Properties.Settings.Default.Save();
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				Process.Start(searcher + text);
			}
			else return;
		}

		private void ItemNewWindow_Click(object sender, EventArgs e)
		{
			new MainFrm(new CommandLineOptions()).Show();
		}

		private void ToolCompile_Click(object sender, EventArgs e) => CompileWithErrorHandler();
		private void ItemInsertLicense_Click(object sender, EventArgs e) => MessageBox.Show(MessageBoxes.NotImplemented);
		private void ItemSettings_Click(object sender, EventArgs e) => new SettingsFrm(this).ShowDialog();

		private void ItemSavePower_Click(object sender, EventArgs e)
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
			Text += " (节电模式)";
		}

		private void ItemOpenFromWeb_Click(object sender, EventArgs e)
		{
			InputBox ib = new InputBox
			{
				Description = MessageBoxes.InputDownload,
				Text = MessageBoxes.InputDownloadTitle
			};
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
					Editor.Text = str;
					var serializer = new JavaScriptSerializer();
					dynamic obj = serializer.Deserialize(str, typeof(object));
					if(obj != null)
					{
						Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("JSON");
					}
				}
#pragma warning disable CA1031 // Do not catch general exception types
				catch (Exception ex)
				{
					MessageBox.Show($"{MessageBoxes.InputDownloadFailed}\r\n{ex.GetType().Name}: {ex.Message}\r\n{ex.StackTrace}");
				}
#pragma warning restore CA1031 // Do not catch general exception types
				finally
				{
					toolProgress.Visible = false;
					toolProgress.Style = ProgressBarStyle.Continuous;
					tlabelStatus.Text = MessageBoxes.StatusReady;
				}
			}
			
		}

		private void ItemAutoScroll_Click(object sender, EventArgs e) => Editor.WordWrap = itemAutoScroll.Checked;
	}
}
