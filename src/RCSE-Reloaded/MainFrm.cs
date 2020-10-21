// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RCSE_Reloaded.API;
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
using log4net;
using RCSE_Reloaded.Util.Dialogs;

namespace RCSE_Reloaded
{
	public partial class MainFrm : Form, ILaunchForm
	{
		internal ICSharpCode.AvalonEdit.TextEditor Editor { get; }

		internal string LoadedContentPath;
		internal bool IsLoaded;
		private bool powerSaving;
		internal static readonly ILog Log = LogManager.GetLogger(typeof(MainFrm));
		private static readonly ILog CompilerLog = LogManager.GetLogger(typeof(CompilerManager));

		public bool CanExit => throw new NotImplementedException();

		private MainFrm(CommandLineOptions options)
		{
			if(options.Culture != "default")
			{
				Thread.CurrentThread.CurrentCulture = new CultureInfo(options.Culture);
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(options.Culture);
			}
			Log.Info("Legacy Form 版本 " + CommonValues.LegacyFormVersion);
			InitializeComponent();
			Log.Info("主窗口组件加载完成");
			Editor = new ICSharpCode.AvalonEdit.TextEditor();
			elementHost1.Child = Editor;
			Log.Info("编辑器加载完成");
			this.SizeChanged += MainFrm_SizeChanged;
			CompilerManager.CompilerLog += CompilerManager_CompilerLog;
			Editor.TextChanged += Editor_TextChanged;

			Log.Info("正在尝试解析命令行参数");
			if(string.IsNullOrWhiteSpace(options.File))
			{
				if(File.Exists(options.File))
				{
					Log.Info("文件存在，正在打开");
					OpenFileWithOptions(options);
				}
				else
				{
					Log.Error("无法解析命令行参数");
					MessageBox.Show(MessageBoxes.ErrorReadConsoleFile, MessageBoxes.ErrorReadConsoleFileTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void CompilerManager_CompilerLog(Type sender, string message) => CompilerLog.Info(message);

		private void OpenFileWithOptions(CommandLineOptions options)
		{
			IsLoaded = true;
			LoadedContentPath = options.File;
			Editor.Load(options.File);
		}

		private void MainFrm_SizeChanged(object sender, EventArgs e) { }

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
			DebugForm debug = new DebugForm(Editor);
			debug.Show();
			Editor.Text = "请注意，个别杀毒软件将本软件列为病毒。本人郑重宣布，此软件非病毒。\r\n" +
				"------------------------------------------\r\nAttention\r\n\r\nSome AntiVirus softwares mark" + CommonValues.ProgramShortName +" as virus.\r\n" +
				"I declare this software is not a virus.";

#endif
			if(Properties.Settings.Default.UseFluentDesign)
			{
				MessageBox.Show(CommonValues.ProgramName + MessageBoxes.FluentWarning);
				Transparent.SetBlur(this.Handle);
				this.TransparencyKey = Color.Black;
				LogManager.GetLogger(typeof(MainFrm)).Warn("正在使用亚克力特效");
			}

			if (!Properties.Settings.Default.UseFluentDesign)
			{
#pragma warning disable CS0162 // 检测到无法访问的代码
				// 无法访问是因为 isSnapshot 是常量，
				// 然而会被更改
				// ReSharper disable once ConditionIsAlwaysTrueOrFalse
				if (CommonValues.IsSnapshot)
				{
					Text = CommonValues.ProgramName + Dialogs.MainFrmTitleSnapshot+ CommonValues.Snapshot + Dialogs.CommonForIndented + CommonValues.VerNumber;
				}
				else
					// ReSharper disable once HeuristicUnreachableCode
				{

					// ReSharper disable once LocalizableElement
					Text = CommonValues.ProgramName + " " + CommonValues.VerNumber;

				}
#pragma warning restore CS0162 // 检测到无法访问的代码
			}
			else
			{
				Text = "";
			}

			RefreshSettings(true);
			Common.FormInstance = this;
		}

		public void ApplyAndSaveConfiguration(Setting settings)
		{
			Properties.Settings.Default.UseMainMenu = settings.UseMainMenu;
			Properties.Settings.Default.UseLightTheme = settings.UseWhiteColor;
			Properties.Settings.Default.UseFluentDesign = settings.UseFluentDesign;
			Properties.Settings.Default.SearchURL = settings.SearchUrl;
			Properties.Settings.Default.Save();
			RefreshSettings();
		}

		public void RefreshSettings(bool start = false)
		{
			// if(Properties.Settings.Default.UseMainMenu)
			// {
			// 	CreateMainMenu();
			// }
			if(!start && !powerSaving)
			{
				MessageBox.Show(MessageBoxes.FluentSave.Replace("{nameShort}", CommonValues.ProgramShortName));
			}
		}
		
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
				Log.Fatal("在运行时发生错误。消息: " + ex.Message + "，来源: " + ex.Source, ex);
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
			Log.Info("正在准备打开新文件");
			OpenFileDialog ofd = new OpenFileDialog
			{
				Filter = CommonValues.Filters,
				Title = Dialogs.DialogOpenFile,
				CheckFileExists = true
			};
			Log.Info("正在弹出选择文件对话框");
			DialogResult dr = ofd.ShowDialog();
			Log.Info("文件选择对话框显示完成");
			if(dr == DialogResult.OK && File.Exists(ofd.FileName))
			{
				Log.Info("用户选择确定，文件存在");
				IsLoaded = true;
				LoadedContentPath = ofd.FileName;
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
					Log.Warn("节电模式，不开启语法高亮");
				}

				Log.Info("成功加载文件");
			}
		}

		void SaveFileAdjust()
		{
			if(!IsLoaded || LoadedContentPath == null || string.IsNullOrWhiteSpace(LoadedContentPath))
			{
				InternalSaveFile();
			}
			else
			{
				Editor.Save(LoadedContentPath);
			}
			Changed = false;
			Text = Text.Remove(0, 6);
		}

		private void Editor_TextChanged(object sender, EventArgs e)
		{
			if(!Changed)
			{
				this.Changed = true;
				Text = Dialogs.MainFrmTitleChanged + this.Text;

			}
			
		}

		public bool Changed { get; set; }

		void ILaunchForm.SaveFile() => InternalSaveFile();

		private void InternalSaveFile()
		{
			Log.Info("正在准备另存为");
			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter = CommonValues.Filters,
				Title = MessageBoxes.SaveAsBoxTitle,
				CheckPathExists = true,
				AddExtension = true
			};
			Log.Info("正在弹出另存为对话框");
			DialogResult dr = sfd.ShowDialog();
			Log.Info("另存为对话框弹出完毕");
			if (dr == DialogResult.OK)
			{
				Editor.Save(sfd.FileName);
				IsLoaded = true;
				LoadedContentPath = sfd.FileName;
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

		#region 菜单
		private void ItemQuit_Click(object sender, EventArgs e) => Close();
		private void ItemNew_Click(object sender, EventArgs e) => NewFile();

		private void NewFile()
		{
			Editor.Text = "";
			Editor.SyntaxHighlighting = null;
			IsLoaded = false;
			LoadedContentPath = "";
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
			Log.Info("保存文件中");
			if (IsLoaded && !string.IsNullOrWhiteSpace(LoadedContentPath))
			{
				Log.Info("文件已被保存过，正在覆盖");
				Editor.Save(LoadedContentPath);
			}
			else
			{
				Log.Info("文件未被保存过，正在执行另存为");
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
			if (!IsLoaded || string.IsNullOrWhiteSpace(LoadedContentPath))
			{
				MessageBox.Show(MessageBoxes.PrintNotSaved);
				
				return;
			}
			if (Changed)
			{
				SaveFileAdjust();
			}
			if (Path.GetExtension(LoadedContentPath) == ".htm"|| Path.GetExtension(LoadedContentPath) == ".html" || Path.GetExtension(LoadedContentPath) == ".xml")
			{
				Process.Start(LoadedContentPath);
			}
			else
			{
				MessageBox.Show(MessageBoxes.NotMarkup);
#if DEBUG
				MessageBox.Show(LoadedContentPath + Environment.NewLine + Path.GetExtension(LoadedContentPath));
#endif
			}


			
		}

		private void CompileWithErrorHandler()
		{
			Log.Info("编译程序启动");
			if (string.IsNullOrWhiteSpace(Editor.Text))
			{
				Log.Info("编辑框为空");
				MessageBox.Show(MessageBoxes.EmptyTextBox, MessageBoxes.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			Log.Info("正在进行编译");
			CompilerResults cr = CompilerManager.CompileFromString(Editor.Text);
			Log.Info("输出框弹出");
			OutputForm of = new OutputForm
			{
				Owner = this
			};
			string temp = Thread.CurrentThread.CurrentCulture.Name == "zh-CN"
				? "================ Compiler Output ================"
				: "=================== 编译器输出 ===================";
			foreach (string str in cr.Output)
			{
				temp = temp + "\r\n" + str;
			}
			of.OutputText = temp;
			of.Show();

			Log.Info("正在检查操作");
			if (!File.Exists("rcse_compiled.cache.lk"))
			{
				Log.Info("返回: 未能找到被编译文件");
				MessageBox.Show(MessageBoxes.CompiledNotFound, MessageBoxes.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Log.Info("编译成功，正在重命名文件");
			File.Move("rcse_compiled.cache.lk", "dbgcache.exe");
		}

		private void StrpbtnNew_Click(object sender, EventArgs e) => NewFile();
		private void StrpbtnSave_Click(object sender, EventArgs e) => DetectAndSaveFile();

		private void StrpbtnRun_Click(object sender, EventArgs e)
		{
			CompileWithErrorHandler();
			if (!File.Exists("rcse_compiled.cache.lk"))
			{
				Log.Info("运行状态: 运行失败");
				tlabelStatus.Text = Dialogs.TextFailedToRun;
				return;
			}
			Log.Info("编译成功，启动程序");
			Process.Start("dbgcache.exe");
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
				DocumentName = CommonValues.ProgramShortName + " Text"
			};
			pd.PrintPage += PrintDocument_PrintA4Page;
			PrintDialog pdi = new PrintDialog();
			if(pdi.ShowDialog() == DialogResult.OK)
			{
				Log.Info("用户确定进行打印");
				pd.PrinterSettings = pdi.PrinterSettings;
				
				pd.Print();
			}
			else
			{
				Log.Info("用户取消打印，正在强制清理对象");
				GC.Collect();
			}
		}

		private void PrintDocument_PrintA4Page(object sender, PrintPageEventArgs e)
		{
#pragma warning disable IDE0059 // 不需要赋值
			// ReSharper disable once UnusedVariable
			Font titleFont = new Font("黑体", 11, FontStyle.Bold);//标题字体           

			Font fntTxt = new Font("宋体", 10, FontStyle.Regular);//正文文字         
			// ReSharper disable once UnusedVariable
			Font fntTxt1 = new Font("宋体", 8, FontStyle.Regular);//正文文字           
			Brush brush = new SolidBrush(Color.Black);//画刷           
			// ReSharper disable once UnusedVariable
			Pen pen = new Pen(Color.Black);           //线条颜色
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
			Log.Info("用户尝试退出");
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
		private void ItemInsertDateTime_Click(object sender, EventArgs e) => Editor.AppendText(DateTime.Now.ToString(CultureInfo.CurrentCulture));
		#endregion

		private void ItemSearch_Click(object sender, EventArgs e)
		{
			string text = Editor.SelectedText;
			string searcher = Properties.Settings.Default.SearchURL;
			if(string.IsNullOrWhiteSpace(searcher))
			{
				Log.Warn("搜索引擎为空");
				searcher = "https://cn.bing.com/search?q=";
				Properties.Settings.Default.SearchURL = "https://cn.bing.com/search?q=";
				Properties.Settings.Default.Save();
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				Process.Start(searcher + text);
			}
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
			Log.Info("节电模式开");
			CrystalEngine.Logging.EngineLog loge = new CrystalEngine.Logging.EngineLog();
			loge.Info("Power Saving mode was turned ON. Some features will be disabled.", "RCSE");
			powerSaving = true;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			tlabelStatus.Text = Dialogs.TextPowerSaving;
			statusStrip1.BackColor = SystemColors.Control;
			tlabelStatus.ForeColor = SystemColors.ControlText;
			Text += Dialogs.MainFrmTitlePowerSaving;
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
					// ReSharper disable once LocalizableElement
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
