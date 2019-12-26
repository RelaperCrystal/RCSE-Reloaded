namespace RCSE_Reloaded
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabctrlOpreation = new System.Windows.Forms.TabControl();
            this.pageDebug = new System.Windows.Forms.TabPage();
            this.buttonCompileNowCs = new System.Windows.Forms.Button();
            this.pageToolbox = new System.Windows.Forms.TabPage();
            this.lstvewToolbox = new System.Windows.Forms.ListView();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.itemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSaveTo = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.split1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOpenInBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.itemFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.itemXAML = new System.Windows.Forms.ToolStripMenuItem();
            this.itemVB = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPlainC = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCPP = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.strpbtnNew = new System.Windows.Forms.ToolStripButton();
            this.strpbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.strpbtnRun = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabctrlOpreation.SuspendLayout();
            this.pageDebug.SuspendLayout();
            this.pageToolbox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.splitContainer.Panel1.Controls.Add(this.tabctrlOpreation);
            // 
            // splitContainer.Panel2
            // 
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.Panel2.Controls.Add(this.elementHost1);
            this.splitContainer.Panel2.SizeChanged += new System.EventHandler(this.splitContainer_Panel2_SizeChanged);
            this.splitContainer.Resize += new System.EventHandler(this.splitContainer_Resize);
            // 
            // tabctrlOpreation
            // 
            resources.ApplyResources(this.tabctrlOpreation, "tabctrlOpreation");
            this.tabctrlOpreation.Controls.Add(this.pageDebug);
            this.tabctrlOpreation.Controls.Add(this.pageToolbox);
            this.tabctrlOpreation.Multiline = true;
            this.tabctrlOpreation.Name = "tabctrlOpreation";
            this.tabctrlOpreation.SelectedIndex = 0;
            // 
            // pageDebug
            // 
            resources.ApplyResources(this.pageDebug, "pageDebug");
            this.pageDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pageDebug.Controls.Add(this.buttonCompileNowCs);
            this.pageDebug.Name = "pageDebug";
            // 
            // buttonCompileNowCs
            // 
            resources.ApplyResources(this.buttonCompileNowCs, "buttonCompileNowCs");
            this.buttonCompileNowCs.Name = "buttonCompileNowCs";
            this.buttonCompileNowCs.UseVisualStyleBackColor = true;
            this.buttonCompileNowCs.Click += new System.EventHandler(this.buttonCompileNowCs_Click);
            // 
            // pageToolbox
            // 
            resources.ApplyResources(this.pageToolbox, "pageToolbox");
            this.pageToolbox.Controls.Add(this.lstvewToolbox);
            this.pageToolbox.Name = "pageToolbox";
            this.pageToolbox.UseVisualStyleBackColor = true;
            // 
            // lstvewToolbox
            // 
            resources.ApplyResources(this.lstvewToolbox, "lstvewToolbox");
            this.lstvewToolbox.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstvewToolbox.Groups")))});
            this.lstvewToolbox.HideSelection = false;
            this.lstvewToolbox.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstvewToolbox.Items")))});
            this.lstvewToolbox.Name = "lstvewToolbox";
            this.lstvewToolbox.UseCompatibleStateImageBehavior = false;
            // 
            // elementHost1
            // 
            resources.ApplyResources(this.elementHost1, "elementHost1");
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost1_ChildChanged);
            this.elementHost1.Child = null;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFile,
            this.itemEdit,
            this.itemDebug,
            this.itemFormat,
            this.itemHelp});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // itemFile
            // 
            resources.ApplyResources(this.itemFile, "itemFile");
            this.itemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemOpen,
            this.itemNew,
            this.itemSave,
            this.itemSaveTo,
            this.itemPrint,
            this.itemSetting,
            this.split1,
            this.itemQuit});
            this.itemFile.ForeColor = System.Drawing.Color.White;
            this.itemFile.Name = "itemFile";
            this.itemFile.Click += new System.EventHandler(this.itemFile_Click);
            // 
            // itemOpen
            // 
            resources.ApplyResources(this.itemOpen, "itemOpen");
            this.itemOpen.Name = "itemOpen";
            this.itemOpen.Click += new System.EventHandler(this.itemOpen_Click);
            // 
            // itemNew
            // 
            resources.ApplyResources(this.itemNew, "itemNew");
            this.itemNew.Name = "itemNew";
            this.itemNew.Click += new System.EventHandler(this.itemNew_Click);
            // 
            // itemSave
            // 
            resources.ApplyResources(this.itemSave, "itemSave");
            this.itemSave.Name = "itemSave";
            this.itemSave.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // itemSaveTo
            // 
            resources.ApplyResources(this.itemSaveTo, "itemSaveTo");
            this.itemSaveTo.Name = "itemSaveTo";
            this.itemSaveTo.Click += new System.EventHandler(this.itemSaveTo_Click);
            // 
            // itemPrint
            // 
            resources.ApplyResources(this.itemPrint, "itemPrint");
            this.itemPrint.Name = "itemPrint";
            this.itemPrint.Click += new System.EventHandler(this.itemPrint_Click);
            // 
            // itemSetting
            // 
            resources.ApplyResources(this.itemSetting, "itemSetting");
            this.itemSetting.Name = "itemSetting";
            this.itemSetting.Click += new System.EventHandler(this.itemSetting_Click);
            // 
            // split1
            // 
            resources.ApplyResources(this.split1, "split1");
            this.split1.Name = "split1";
            // 
            // itemQuit
            // 
            resources.ApplyResources(this.itemQuit, "itemQuit");
            this.itemQuit.Name = "itemQuit";
            this.itemQuit.Click += new System.EventHandler(this.itemQuit_Click);
            // 
            // itemEdit
            // 
            resources.ApplyResources(this.itemEdit, "itemEdit");
            this.itemEdit.ForeColor = System.Drawing.Color.White;
            this.itemEdit.Name = "itemEdit";
            // 
            // itemDebug
            // 
            resources.ApplyResources(this.itemDebug, "itemDebug");
            this.itemDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemOpenInBrowser});
            this.itemDebug.ForeColor = System.Drawing.Color.White;
            this.itemDebug.Name = "itemDebug";
            // 
            // itemOpenInBrowser
            // 
            resources.ApplyResources(this.itemOpenInBrowser, "itemOpenInBrowser");
            this.itemOpenInBrowser.Name = "itemOpenInBrowser";
            this.itemOpenInBrowser.Click += new System.EventHandler(this.itemOpenInBrowser_Click);
            // 
            // itemFormat
            // 
            resources.ApplyResources(this.itemFormat, "itemFormat");
            this.itemFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCSharp,
            this.itemHTML,
            this.itemXAML,
            this.itemVB,
            this.itemCSeries});
            this.itemFormat.ForeColor = System.Drawing.Color.White;
            this.itemFormat.Name = "itemFormat";
            // 
            // itemCSharp
            // 
            resources.ApplyResources(this.itemCSharp, "itemCSharp");
            this.itemCSharp.Name = "itemCSharp";
            this.itemCSharp.Click += new System.EventHandler(this.itemCSharp_Click);
            // 
            // itemHTML
            // 
            resources.ApplyResources(this.itemHTML, "itemHTML");
            this.itemHTML.Name = "itemHTML";
            this.itemHTML.Click += new System.EventHandler(this.itemHTML_Click);
            // 
            // itemXAML
            // 
            resources.ApplyResources(this.itemXAML, "itemXAML");
            this.itemXAML.Name = "itemXAML";
            this.itemXAML.Click += new System.EventHandler(this.itemXAML_Click);
            // 
            // itemVB
            // 
            resources.ApplyResources(this.itemVB, "itemVB");
            this.itemVB.Name = "itemVB";
            this.itemVB.Click += new System.EventHandler(this.itemVB_Click);
            // 
            // itemCSeries
            // 
            resources.ApplyResources(this.itemCSeries, "itemCSeries");
            this.itemCSeries.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemPlainC,
            this.itemCPP});
            this.itemCSeries.Name = "itemCSeries";
            // 
            // itemPlainC
            // 
            resources.ApplyResources(this.itemPlainC, "itemPlainC");
            this.itemPlainC.Name = "itemPlainC";
            this.itemPlainC.Click += new System.EventHandler(this.itemPlainC_Click);
            // 
            // itemCPP
            // 
            resources.ApplyResources(this.itemCPP, "itemCPP");
            this.itemCPP.Name = "itemCPP";
            this.itemCPP.Click += new System.EventHandler(this.itemCPP_Click);
            // 
            // itemHelp
            // 
            resources.ApplyResources(this.itemHelp, "itemHelp");
            this.itemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAbout});
            this.itemHelp.ForeColor = System.Drawing.Color.White;
            this.itemHelp.Name = "itemHelp";
            this.itemHelp.Click += new System.EventHandler(this.itemHelp_Click);
            // 
            // itemAbout
            // 
            resources.ApplyResources(this.itemAbout, "itemAbout");
            this.itemAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.itemAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itemAbout.ForeColor = System.Drawing.Color.White;
            this.itemAbout.Name = "itemAbout";
            this.itemAbout.Click += new System.EventHandler(this.itemAbout_Click);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlabelStatus});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // tlabelStatus
            // 
            resources.ApplyResources(this.tlabelStatus, "tlabelStatus");
            this.tlabelStatus.ForeColor = System.Drawing.Color.White;
            this.tlabelStatus.Name = "tlabelStatus";
            this.tlabelStatus.Click += new System.EventHandler(this.tlabelStatus_Click);
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpbtnNew,
            this.strpbtnSave,
            this.toolStripSeparator1,
            this.strpbtnRun});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // strpbtnNew
            // 
            resources.ApplyResources(this.strpbtnNew, "strpbtnNew");
            this.strpbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.strpbtnNew.Name = "strpbtnNew";
            this.strpbtnNew.Click += new System.EventHandler(this.strpbtnNew_Click);
            // 
            // strpbtnSave
            // 
            resources.ApplyResources(this.strpbtnSave, "strpbtnSave");
            this.strpbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.strpbtnSave.Name = "strpbtnSave";
            this.strpbtnSave.Click += new System.EventHandler(this.strpbtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // strpbtnRun
            // 
            resources.ApplyResources(this.strpbtnRun, "strpbtnRun");
            this.strpbtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.strpbtnRun.Name = "strpbtnRun";
            this.strpbtnRun.Click += new System.EventHandler(this.strpbtnRun_Click);
            // 
            // MainFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = global::RCSE_Reloaded.Properties.Resources.rcse;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.SizeChanged += new System.EventHandler(this.MainFrm_SizeChanged_1);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabctrlOpreation.ResumeLayout(false);
            this.pageDebug.ResumeLayout(false);
            this.pageToolbox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemFile;
        private System.Windows.Forms.ToolStripMenuItem itemEdit;
        private System.Windows.Forms.ToolStripMenuItem itemFormat;
        private System.Windows.Forms.ToolStripMenuItem itemHelp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemOpen;
        private System.Windows.Forms.ToolStripMenuItem itemNew;
        private System.Windows.Forms.ToolStripSeparator split1;
        private System.Windows.Forms.ToolStripMenuItem itemQuit;
        private System.Windows.Forms.ToolStripMenuItem itemCSharp;
        private System.Windows.Forms.ToolStripMenuItem itemSave;
        private System.Windows.Forms.ToolStripStatusLabel tlabelStatus;
        private System.Windows.Forms.ToolStripMenuItem itemSaveTo;
        private System.Windows.Forms.ToolStripMenuItem itemAbout;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem itemHTML;
        private System.Windows.Forms.ToolStripMenuItem itemXAML;
        private System.Windows.Forms.ToolStripMenuItem itemVB;
        private System.Windows.Forms.ToolStripMenuItem itemCSeries;
        private System.Windows.Forms.ToolStripMenuItem itemPlainC;
        private System.Windows.Forms.ToolStripMenuItem itemCPP;
        private System.Windows.Forms.ToolStripMenuItem itemDebug;
        private System.Windows.Forms.ToolStripMenuItem itemOpenInBrowser;
        private System.Windows.Forms.TabControl tabctrlOpreation;
        private System.Windows.Forms.TabPage pageDebug;
        private System.Windows.Forms.TabPage pageToolbox;
        private System.Windows.Forms.ListView lstvewToolbox;
        private System.Windows.Forms.Button buttonCompileNowCs;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton strpbtnNew;
        private System.Windows.Forms.ToolStripButton strpbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton strpbtnRun;
        private System.Windows.Forms.ToolStripMenuItem itemSetting;
        private System.Windows.Forms.ToolStripMenuItem itemPrint;
    }
}

