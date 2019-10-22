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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("协议", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("GPL v3");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.itemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSaveTo = new System.Windows.Forms.ToolStripMenuItem();
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabctrlOpreation = new System.Windows.Forms.TabControl();
            this.pageDebug = new System.Windows.Forms.TabPage();
            this.buttonCompileNowCs = new System.Windows.Forms.Button();
            this.pageToolbox = new System.Windows.Forms.TabPage();
            this.lstvewToolbox = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.strpbtnNew = new System.Windows.Forms.ToolStripButton();
            this.strpbtnSave = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabctrlOpreation.SuspendLayout();
            this.pageDebug.SuspendLayout();
            this.pageToolbox.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(602, 397);
            this.elementHost1.TabIndex = 1;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost1_ChildChanged);
            this.elementHost1.Child = null;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFile,
            this.itemEdit,
            this.itemDebug,
            this.itemFormat,
            this.itemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(974, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // itemFile
            // 
            this.itemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemOpen,
            this.itemNew,
            this.itemSave,
            this.itemSaveTo,
            this.split1,
            this.itemQuit});
            this.itemFile.ForeColor = System.Drawing.Color.White;
            this.itemFile.Name = "itemFile";
            this.itemFile.Size = new System.Drawing.Size(58, 21);
            this.itemFile.Text = "文件(&F)";
            this.itemFile.Click += new System.EventHandler(this.itemFile_Click);
            // 
            // itemOpen
            // 
            this.itemOpen.Name = "itemOpen";
            this.itemOpen.Size = new System.Drawing.Size(128, 22);
            this.itemOpen.Text = "打开(&P)";
            this.itemOpen.Click += new System.EventHandler(this.itemOpen_Click);
            // 
            // itemNew
            // 
            this.itemNew.Name = "itemNew";
            this.itemNew.Size = new System.Drawing.Size(128, 22);
            this.itemNew.Text = "新建(&N)";
            this.itemNew.Click += new System.EventHandler(this.itemNew_Click);
            // 
            // itemSave
            // 
            this.itemSave.Name = "itemSave";
            this.itemSave.Size = new System.Drawing.Size(128, 22);
            this.itemSave.Text = "保存(&S)";
            this.itemSave.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // itemSaveTo
            // 
            this.itemSaveTo.Name = "itemSaveTo";
            this.itemSaveTo.Size = new System.Drawing.Size(128, 22);
            this.itemSaveTo.Text = "另存为(&A)";
            this.itemSaveTo.Click += new System.EventHandler(this.itemSaveTo_Click);
            // 
            // split1
            // 
            this.split1.Name = "split1";
            this.split1.Size = new System.Drawing.Size(125, 6);
            // 
            // itemQuit
            // 
            this.itemQuit.Name = "itemQuit";
            this.itemQuit.Size = new System.Drawing.Size(128, 22);
            this.itemQuit.Text = "退出(&Q)";
            this.itemQuit.Click += new System.EventHandler(this.itemQuit_Click);
            // 
            // itemEdit
            // 
            this.itemEdit.ForeColor = System.Drawing.Color.White;
            this.itemEdit.Name = "itemEdit";
            this.itemEdit.Size = new System.Drawing.Size(59, 21);
            this.itemEdit.Text = "编辑(&E)";
            // 
            // itemDebug
            // 
            this.itemDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemOpenInBrowser});
            this.itemDebug.ForeColor = System.Drawing.Color.White;
            this.itemDebug.Name = "itemDebug";
            this.itemDebug.Size = new System.Drawing.Size(61, 21);
            this.itemDebug.Text = "调试(&D)";
            // 
            // itemOpenInBrowser
            // 
            this.itemOpenInBrowser.Name = "itemOpenInBrowser";
            this.itemOpenInBrowser.Size = new System.Drawing.Size(169, 22);
            this.itemOpenInBrowser.Text = "在浏览器中打开...";
            this.itemOpenInBrowser.Click += new System.EventHandler(this.itemOpenInBrowser_Click);
            // 
            // itemFormat
            // 
            this.itemFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCSharp,
            this.itemHTML,
            this.itemXAML,
            this.itemVB,
            this.itemCSeries});
            this.itemFormat.ForeColor = System.Drawing.Color.White;
            this.itemFormat.Name = "itemFormat";
            this.itemFormat.Size = new System.Drawing.Size(62, 21);
            this.itemFormat.Text = "格式(&O)";
            // 
            // itemCSharp
            // 
            this.itemCSharp.Name = "itemCSharp";
            this.itemCSharp.Size = new System.Drawing.Size(144, 22);
            this.itemCSharp.Text = "C#";
            this.itemCSharp.Click += new System.EventHandler(this.itemCSharp_Click);
            // 
            // itemHTML
            // 
            this.itemHTML.Name = "itemHTML";
            this.itemHTML.Size = new System.Drawing.Size(144, 22);
            this.itemHTML.Text = "HTML";
            this.itemHTML.Click += new System.EventHandler(this.itemHTML_Click);
            // 
            // itemXAML
            // 
            this.itemXAML.Name = "itemXAML";
            this.itemXAML.Size = new System.Drawing.Size(144, 22);
            this.itemXAML.Text = "XAML";
            this.itemXAML.Click += new System.EventHandler(this.itemXAML_Click);
            // 
            // itemVB
            // 
            this.itemVB.Name = "itemVB";
            this.itemVB.Size = new System.Drawing.Size(144, 22);
            this.itemVB.Text = "Visual Basic";
            this.itemVB.Click += new System.EventHandler(this.itemVB_Click);
            // 
            // itemCSeries
            // 
            this.itemCSeries.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemPlainC,
            this.itemCPP});
            this.itemCSeries.Name = "itemCSeries";
            this.itemCSeries.Size = new System.Drawing.Size(144, 22);
            this.itemCSeries.Text = "C";
            // 
            // itemPlainC
            // 
            this.itemPlainC.Name = "itemPlainC";
            this.itemPlainC.Size = new System.Drawing.Size(112, 22);
            this.itemPlainC.Text = "普通 C";
            this.itemPlainC.Click += new System.EventHandler(this.itemPlainC_Click);
            // 
            // itemCPP
            // 
            this.itemCPP.Name = "itemCPP";
            this.itemCPP.Size = new System.Drawing.Size(112, 22);
            this.itemCPP.Text = "C++";
            this.itemCPP.Click += new System.EventHandler(this.itemCPP_Click);
            // 
            // itemHelp
            // 
            this.itemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAbout});
            this.itemHelp.ForeColor = System.Drawing.Color.White;
            this.itemHelp.Name = "itemHelp";
            this.itemHelp.Size = new System.Drawing.Size(61, 21);
            this.itemHelp.Text = "帮助(&H)";
            this.itemHelp.Click += new System.EventHandler(this.itemHelp_Click);
            // 
            // itemAbout
            // 
            this.itemAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itemAbout.Name = "itemAbout";
            this.itemAbout.Size = new System.Drawing.Size(116, 22);
            this.itemAbout.Text = "关于(&A)";
            this.itemAbout.Click += new System.EventHandler(this.itemAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlabelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(974, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlabelStatus
            // 
            this.tlabelStatus.ForeColor = System.Drawing.Color.White;
            this.tlabelStatus.Name = "tlabelStatus";
            this.tlabelStatus.Size = new System.Drawing.Size(32, 17);
            this.tlabelStatus.Text = "就绪";
            this.tlabelStatus.Click += new System.EventHandler(this.tlabelStatus_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Location = new System.Drawing.Point(0, 50);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabctrlOpreation);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.elementHost1);
            this.splitContainer.Panel2.SizeChanged += new System.EventHandler(this.splitContainer_Panel2_SizeChanged);
            this.splitContainer.Size = new System.Drawing.Size(800, 397);
            this.splitContainer.SplitterDistance = 194;
            this.splitContainer.TabIndex = 4;
            this.splitContainer.Resize += new System.EventHandler(this.splitContainer_Resize);
            // 
            // tabctrlOpreation
            // 
            this.tabctrlOpreation.Controls.Add(this.pageDebug);
            this.tabctrlOpreation.Controls.Add(this.pageToolbox);
            this.tabctrlOpreation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabctrlOpreation.Location = new System.Drawing.Point(0, 0);
            this.tabctrlOpreation.Multiline = true;
            this.tabctrlOpreation.Name = "tabctrlOpreation";
            this.tabctrlOpreation.SelectedIndex = 0;
            this.tabctrlOpreation.Size = new System.Drawing.Size(194, 397);
            this.tabctrlOpreation.TabIndex = 0;
            // 
            // pageDebug
            // 
            this.pageDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pageDebug.Controls.Add(this.buttonCompileNowCs);
            this.pageDebug.Location = new System.Drawing.Point(4, 22);
            this.pageDebug.Name = "pageDebug";
            this.pageDebug.Padding = new System.Windows.Forms.Padding(3);
            this.pageDebug.Size = new System.Drawing.Size(186, 371);
            this.pageDebug.TabIndex = 0;
            this.pageDebug.Text = "调试";
            // 
            // buttonCompileNowCs
            // 
            this.buttonCompileNowCs.Location = new System.Drawing.Point(3, 3);
            this.buttonCompileNowCs.Name = "buttonCompileNowCs";
            this.buttonCompileNowCs.Size = new System.Drawing.Size(161, 21);
            this.buttonCompileNowCs.TabIndex = 0;
            this.buttonCompileNowCs.Text = "编译 C#";
            this.buttonCompileNowCs.UseVisualStyleBackColor = true;
            this.buttonCompileNowCs.Click += new System.EventHandler(this.buttonCompileNowCs_Click);
            // 
            // pageToolbox
            // 
            this.pageToolbox.Controls.Add(this.lstvewToolbox);
            this.pageToolbox.Location = new System.Drawing.Point(4, 22);
            this.pageToolbox.Name = "pageToolbox";
            this.pageToolbox.Padding = new System.Windows.Forms.Padding(3);
            this.pageToolbox.Size = new System.Drawing.Size(186, 371);
            this.pageToolbox.TabIndex = 1;
            this.pageToolbox.Text = "工具箱";
            this.pageToolbox.UseVisualStyleBackColor = true;
            // 
            // lstvewToolbox
            // 
            this.lstvewToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "协议";
            listViewGroup1.Name = "lvgroupLicenses";
            this.lstvewToolbox.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lstvewToolbox.HideSelection = false;
            listViewItem1.Group = listViewGroup1;
            this.lstvewToolbox.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstvewToolbox.Location = new System.Drawing.Point(3, 3);
            this.lstvewToolbox.Name = "lstvewToolbox";
            this.lstvewToolbox.Size = new System.Drawing.Size(180, 365);
            this.lstvewToolbox.TabIndex = 0;
            this.lstvewToolbox.UseCompatibleStateImageBehavior = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpbtnNew,
            this.strpbtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(974, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // strpbtnNew
            // 
            this.strpbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.strpbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("strpbtnNew.Image")));
            this.strpbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.strpbtnNew.Name = "strpbtnNew";
            this.strpbtnNew.Size = new System.Drawing.Size(23, 22);
            this.strpbtnNew.Text = "toolStripButton1";
            this.strpbtnNew.Click += new System.EventHandler(this.strpbtnNew_Click);
            // 
            // strpbtnSave
            // 
            this.strpbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.strpbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("strpbtnSave.Image")));
            this.strpbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.strpbtnSave.Name = "strpbtnSave";
            this.strpbtnSave.Size = new System.Drawing.Size(23, 22);
            this.strpbtnSave.Text = "toolStripButton2";
            this.strpbtnSave.Click += new System.EventHandler(this.strpbtnSave_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(974, 527);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::RCSE_Reloaded.Properties.Resources.rcse;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.Text = "RCSE v0.4 Beta";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.SizeChanged += new System.EventHandler(this.MainFrm_SizeChanged_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabctrlOpreation.ResumeLayout(false);
            this.pageDebug.ResumeLayout(false);
            this.pageToolbox.ResumeLayout(false);
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
    }
}

