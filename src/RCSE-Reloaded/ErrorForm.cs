// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace RCSE_Reloaded
{
    internal class ErrorForm : Form
    {
        private Label label1;
        private TextBox textErrorDescription;
        private Button buttonOk;
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            label1 = new Label();
            textErrorDescription = new TextBox();
            buttonOk = new Button();
            buttonGithub = new Button();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // textErrorDescription
            // 
            resources.ApplyResources(textErrorDescription, "textErrorDescription");
            textErrorDescription.Name = "textErrorDescription";
            // 
            // buttonOK
            // 
            resources.ApplyResources(buttonOk, "buttonOk");
            buttonOk.Name = "buttonOk";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += ButtonOK_Click;
            // 
            // buttonGithub
            // 
            resources.ApplyResources(buttonGithub, "buttonGithub");
            buttonGithub.Name = "buttonGithub";
            buttonGithub.UseVisualStyleBackColor = true;
            buttonGithub.Click += ButtonGithub_Click;
            // 
            // buttonSave
            // 
            resources.ApplyResources(buttonSave, "buttonSave");
            buttonSave.Name = "buttonSave";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // ErrorForm
            // 
            resources.ApplyResources(this, "$this");
            Controls.Add(buttonSave);
            Controls.Add(buttonGithub);
            Controls.Add(buttonOk);
            Controls.Add(textErrorDescription);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ErrorForm";
            Load += ErrorForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        private void ButtonGithub_Click(object sender, EventArgs e) => Process.Start("https://github.com/RelaperCrystal/RCSE-Reloaded/issues/new");
        private void ButtonOK_Click(object sender, EventArgs e) => Close();

        [SuppressMessage("ReSharper", "LocalizableElement")]
        private void ErrorForm_Load(object sender, EventArgs e)
        {
	        // ReSharper disable once LocalizableElement
	        textErrorDescription.Text = $"=========== 报告开始 ===========\r\n时间：{DateTime.Now}\r\n异常名称：{nameof(ex)}\r\n异常信息：" +
	                                    $"{ex.Message}\r\n异常 StackTrace：\r\n{ex.StackTrace}\r\n\r\n造成异常的方法：{ex.TargetSite}\r\n造成异常的类：{ex.Source}\r\nHRESULT：{ex.HResult}\r\n" +
	                                    $"=========== 报告结束 ===========";
        }
    }
}