﻿namespace RCSE_Reloaded
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.itemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.itemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSaveTo = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.split1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.itemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.itemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDateTime = new System.Windows.Forms.ToolStripMenuItem();
            this.itemInsertLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSearchWithBing = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemMeetFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.itemIssues = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSysInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.strpbtnNew = new System.Windows.Forms.ToolStripButton();
            this.strpbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.strpbtnRun = new System.Windows.Forms.ToolStripButton();
            this.toolCompile = new System.Windows.Forms.ToolStripButton();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFile,
            this.itemEdit,
            this.itemDebug,
            this.itemFormat,
            this.itemHelp});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // itemFile
            // 
            this.itemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemNew,
            this.itemOpen,
            this.itemNewWindow,
            this.toolStripMenuItem4,
            this.itemSave,
            this.itemSaveTo,
            this.itemPrint,
            this.itemSetting,
            this.split1,
            this.itemQuit});
            this.itemFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemFile.Name = "itemFile";
            resources.ApplyResources(this.itemFile, "itemFile");
            this.itemFile.Click += new System.EventHandler(this.itemFile_Click);
            // 
            // itemNew
            // 
            this.itemNew.Name = "itemNew";
            resources.ApplyResources(this.itemNew, "itemNew");
            this.itemNew.Click += new System.EventHandler(this.itemNew_Click);
            // 
            // itemOpen
            // 
            this.itemOpen.Name = "itemOpen";
            resources.ApplyResources(this.itemOpen, "itemOpen");
            this.itemOpen.Click += new System.EventHandler(this.itemOpen_Click);
            // 
            // itemNewWindow
            // 
            this.itemNewWindow.Name = "itemNewWindow";
            resources.ApplyResources(this.itemNewWindow, "itemNewWindow");
            this.itemNewWindow.Click += new System.EventHandler(this.itemNewWindow_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // itemSave
            // 
            this.itemSave.Name = "itemSave";
            resources.ApplyResources(this.itemSave, "itemSave");
            this.itemSave.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // itemSaveTo
            // 
            this.itemSaveTo.Name = "itemSaveTo";
            resources.ApplyResources(this.itemSaveTo, "itemSaveTo");
            this.itemSaveTo.Click += new System.EventHandler(this.itemSaveTo_Click);
            // 
            // itemPrint
            // 
            this.itemPrint.Name = "itemPrint";
            resources.ApplyResources(this.itemPrint, "itemPrint");
            this.itemPrint.Click += new System.EventHandler(this.itemPrint_Click);
            // 
            // itemSetting
            // 
            this.itemSetting.Name = "itemSetting";
            resources.ApplyResources(this.itemSetting, "itemSetting");
            this.itemSetting.Click += new System.EventHandler(this.itemSetting_Click);
            // 
            // split1
            // 
            this.split1.Name = "split1";
            resources.ApplyResources(this.split1, "split1");
            // 
            // itemQuit
            // 
            this.itemQuit.Name = "itemQuit";
            resources.ApplyResources(this.itemQuit, "itemQuit");
            this.itemQuit.Click += new System.EventHandler(this.itemQuit_Click);
            // 
            // itemEdit
            // 
            this.itemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCopy,
            this.itemCut,
            this.itemSeperator2,
            this.itemPaste,
            this.itemUndo,
            this.itemRedo,
            this.itemSelectAll,
            this.toolStripMenuItem3,
            this.toolInsert,
            this.itemSearchWithBing});
            this.itemEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemEdit.Name = "itemEdit";
            resources.ApplyResources(this.itemEdit, "itemEdit");
            this.itemEdit.Click += new System.EventHandler(this.itemEdit_Click);
            // 
            // itemCopy
            // 
            this.itemCopy.Name = "itemCopy";
            resources.ApplyResources(this.itemCopy, "itemCopy");
            this.itemCopy.Click += new System.EventHandler(this.itemCopy_Click);
            // 
            // itemCut
            // 
            this.itemCut.Name = "itemCut";
            resources.ApplyResources(this.itemCut, "itemCut");
            this.itemCut.Click += new System.EventHandler(this.itemCut_Click);
            // 
            // itemSeperator2
            // 
            this.itemSeperator2.Name = "itemSeperator2";
            resources.ApplyResources(this.itemSeperator2, "itemSeperator2");
            // 
            // itemPaste
            // 
            this.itemPaste.Name = "itemPaste";
            resources.ApplyResources(this.itemPaste, "itemPaste");
            this.itemPaste.Click += new System.EventHandler(this.itemPaste_Click);
            // 
            // itemUndo
            // 
            this.itemUndo.Name = "itemUndo";
            resources.ApplyResources(this.itemUndo, "itemUndo");
            this.itemUndo.Click += new System.EventHandler(this.itemUndo_Click);
            // 
            // itemRedo
            // 
            this.itemRedo.Name = "itemRedo";
            resources.ApplyResources(this.itemRedo, "itemRedo");
            this.itemRedo.Click += new System.EventHandler(this.itemRedo_Click);
            // 
            // itemSelectAll
            // 
            this.itemSelectAll.Name = "itemSelectAll";
            resources.ApplyResources(this.itemSelectAll, "itemSelectAll");
            this.itemSelectAll.Click += new System.EventHandler(this.itemSelectAll_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // toolInsert
            // 
            this.toolInsert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemDateTime,
            this.itemInsertLicense});
            this.toolInsert.Name = "toolInsert";
            resources.ApplyResources(this.toolInsert, "toolInsert");
            // 
            // itemDateTime
            // 
            this.itemDateTime.Name = "itemDateTime";
            resources.ApplyResources(this.itemDateTime, "itemDateTime");
            this.itemDateTime.Click += new System.EventHandler(this.itemInsertDateTime_Click);
            // 
            // itemInsertLicense
            // 
            this.itemInsertLicense.Name = "itemInsertLicense";
            resources.ApplyResources(this.itemInsertLicense, "itemInsertLicense");
            this.itemInsertLicense.Click += new System.EventHandler(this.itemInsertLicense_Click);
            // 
            // itemSearchWithBing
            // 
            this.itemSearchWithBing.Name = "itemSearchWithBing";
            resources.ApplyResources(this.itemSearchWithBing, "itemSearchWithBing");
            this.itemSearchWithBing.Click += new System.EventHandler(this.itemSearchWithBing_Click);
            // 
            // itemDebug
            // 
            this.itemDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemOpenInBrowser});
            this.itemDebug.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemDebug.Name = "itemDebug";
            resources.ApplyResources(this.itemDebug, "itemDebug");
            // 
            // itemOpenInBrowser
            // 
            this.itemOpenInBrowser.Name = "itemOpenInBrowser";
            resources.ApplyResources(this.itemOpenInBrowser, "itemOpenInBrowser");
            this.itemOpenInBrowser.Click += new System.EventHandler(this.itemOpenInBrowser_Click);
            // 
            // itemFormat
            // 
            this.itemFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCSharp,
            this.itemHTML,
            this.itemXAML,
            this.itemVB,
            this.itemCSeries,
            this.toolStripMenuItem1,
            this.itemMeetFile});
            this.itemFormat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemFormat.Name = "itemFormat";
            resources.ApplyResources(this.itemFormat, "itemFormat");
            // 
            // itemCSharp
            // 
            this.itemCSharp.Name = "itemCSharp";
            resources.ApplyResources(this.itemCSharp, "itemCSharp");
            this.itemCSharp.Click += new System.EventHandler(this.itemCSharp_Click);
            // 
            // itemHTML
            // 
            this.itemHTML.Name = "itemHTML";
            resources.ApplyResources(this.itemHTML, "itemHTML");
            this.itemHTML.Click += new System.EventHandler(this.itemHTML_Click);
            // 
            // itemXAML
            // 
            this.itemXAML.Name = "itemXAML";
            resources.ApplyResources(this.itemXAML, "itemXAML");
            this.itemXAML.Click += new System.EventHandler(this.itemXAML_Click);
            // 
            // itemVB
            // 
            this.itemVB.Name = "itemVB";
            resources.ApplyResources(this.itemVB, "itemVB");
            this.itemVB.Click += new System.EventHandler(this.itemVB_Click);
            // 
            // itemCSeries
            // 
            this.itemCSeries.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemPlainC,
            this.itemCPP});
            this.itemCSeries.Name = "itemCSeries";
            resources.ApplyResources(this.itemCSeries, "itemCSeries");
            // 
            // itemPlainC
            // 
            this.itemPlainC.Name = "itemPlainC";
            resources.ApplyResources(this.itemPlainC, "itemPlainC");
            this.itemPlainC.Click += new System.EventHandler(this.itemPlainC_Click);
            // 
            // itemCPP
            // 
            this.itemCPP.Name = "itemCPP";
            resources.ApplyResources(this.itemCPP, "itemCPP");
            this.itemCPP.Click += new System.EventHandler(this.itemCPP_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // itemMeetFile
            // 
            this.itemMeetFile.Name = "itemMeetFile";
            resources.ApplyResources(this.itemMeetFile, "itemMeetFile");
            this.itemMeetFile.Click += new System.EventHandler(this.itemMeetFile_Click);
            // 
            // itemHelp
            // 
            this.itemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAbout,
            this.toolStripMenuItem2,
            this.itemIssues,
            this.itemSysInfo});
            this.itemHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemHelp.Name = "itemHelp";
            resources.ApplyResources(this.itemHelp, "itemHelp");
            this.itemHelp.Click += new System.EventHandler(this.itemHelp_Click);
            // 
            // itemAbout
            // 
            this.itemAbout.BackColor = System.Drawing.SystemColors.Control;
            this.itemAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itemAbout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemAbout.Name = "itemAbout";
            resources.ApplyResources(this.itemAbout, "itemAbout");
            this.itemAbout.Click += new System.EventHandler(this.itemAbout_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Red;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // itemIssues
            // 
            this.itemIssues.BackColor = System.Drawing.SystemColors.Control;
            this.itemIssues.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemIssues.Name = "itemIssues";
            resources.ApplyResources(this.itemIssues, "itemIssues");
            // 
            // itemSysInfo
            // 
            this.itemSysInfo.BackColor = System.Drawing.SystemColors.Control;
            this.itemSysInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemSysInfo.Name = "itemSysInfo";
            resources.ApplyResources(this.itemSysInfo, "itemSysInfo");
            this.itemSysInfo.Click += new System.EventHandler(this.itemSysInfo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlabelStatus});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // tlabelStatus
            // 
            this.tlabelStatus.ForeColor = System.Drawing.Color.White;
            this.tlabelStatus.Name = "tlabelStatus";
            resources.ApplyResources(this.tlabelStatus, "tlabelStatus");
            this.tlabelStatus.Click += new System.EventHandler(this.tlabelStatus_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strpbtnNew,
            this.strpbtnSave,
            this.toolStripSeparator1,
            this.strpbtnRun,
            this.toolCompile});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // strpbtnNew
            // 
            this.strpbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.strpbtnNew, "strpbtnNew");
            this.strpbtnNew.Name = "strpbtnNew";
            this.strpbtnNew.Click += new System.EventHandler(this.strpbtnNew_Click);
            // 
            // strpbtnSave
            // 
            this.strpbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.strpbtnSave, "strpbtnSave");
            this.strpbtnSave.Name = "strpbtnSave";
            this.strpbtnSave.Click += new System.EventHandler(this.strpbtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // strpbtnRun
            // 
            this.strpbtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.strpbtnRun, "strpbtnRun");
            this.strpbtnRun.Name = "strpbtnRun";
            this.strpbtnRun.Click += new System.EventHandler(this.strpbtnRun_Click);
            // 
            // toolCompile
            // 
            this.toolCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolCompile, "toolCompile");
            this.toolCompile.Name = "toolCompile";
            this.toolCompile.Click += new System.EventHandler(this.toolCompile_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.elementHost1, "elementHost1");
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // MainFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = global::RCSE_Reloaded.Properties.Resources.rcse;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.SizeChanged += new System.EventHandler(this.MainFrm_SizeChanged_1);
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
        private System.Windows.Forms.ToolStripMenuItem itemHTML;
        private System.Windows.Forms.ToolStripMenuItem itemXAML;
        private System.Windows.Forms.ToolStripMenuItem itemVB;
        private System.Windows.Forms.ToolStripMenuItem itemCSeries;
        private System.Windows.Forms.ToolStripMenuItem itemPlainC;
        private System.Windows.Forms.ToolStripMenuItem itemCPP;
        private System.Windows.Forms.ToolStripMenuItem itemDebug;
        private System.Windows.Forms.ToolStripMenuItem itemOpenInBrowser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton strpbtnNew;
        private System.Windows.Forms.ToolStripButton strpbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton strpbtnRun;
        private System.Windows.Forms.ToolStripMenuItem itemSetting;
        private System.Windows.Forms.ToolStripMenuItem itemPrint;
        private System.Windows.Forms.ToolStripMenuItem itemCopy;
        private System.Windows.Forms.ToolStripMenuItem itemCut;
        private System.Windows.Forms.ToolStripSeparator itemSeperator2;
        private System.Windows.Forms.ToolStripMenuItem itemPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem itemMeetFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem itemIssues;
        private System.Windows.Forms.ToolStripMenuItem itemSysInfo;
        private System.Windows.Forms.ToolStripMenuItem itemUndo;
        private System.Windows.Forms.ToolStripMenuItem itemRedo;
        private System.Windows.Forms.ToolStripMenuItem itemSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem itemSearchWithBing;
        private System.Windows.Forms.ToolStripMenuItem itemNewWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.ToolStripButton toolCompile;
        private System.Windows.Forms.ToolStripMenuItem toolInsert;
        private System.Windows.Forms.ToolStripMenuItem itemDateTime;
        private System.Windows.Forms.ToolStripMenuItem itemInsertLicense;
    }
}

