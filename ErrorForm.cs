// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RCSE_Reloaded
{
    internal class ErrorForm : Form
    {
        private Label label1;
        private TextBox textErrorDescription;
        private Button buttonOK;
        private Button buttonGithub;
        private Button buttonSave;
        private readonly Exception ex;

        public ErrorForm(Exception ex)
        {
            InitializeComponent();
            this.ex = ex;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textErrorDescription = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonGithub = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textErrorDescription
            // 
            resources.ApplyResources(this.textErrorDescription, "textErrorDescription");
            this.textErrorDescription.Name = "textErrorDescription";
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonGithub
            // 
            resources.ApplyResources(this.buttonGithub, "buttonGithub");
            this.buttonGithub.Name = "buttonGithub";
            this.buttonGithub.UseVisualStyleBackColor = true;
            this.buttonGithub.Click += new System.EventHandler(this.ButtonGithub_Click);
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // ErrorForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonGithub);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textErrorDescription);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ButtonGithub_Click(object sender, EventArgs e) => Process.Start("https://github.com/RelaperCrystal/RCSE-Reloaded/issues/new");
        private void ButtonOK_Click(object sender, EventArgs e) => Close();

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            textErrorDescription.Text = $"=========== 报告开始 ===========\r\n时间：{DateTime.Now}\r\n异常名称：{nameof(ex)}\r\n异常信息：" +
                $"{ex.Message}\r\n异常 StackTrace：\r\n{ex.StackTrace}\r\n\r\n造成异常的方法：{ex.TargetSite}\r\n造成异常的类：{ex.Source}\r\nHRESULT：{ex.HResult}\r\n" +
                $"=========== 报告结束 ===========";
        }
    }
}