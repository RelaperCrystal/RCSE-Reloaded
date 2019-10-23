namespace RCSE_Reloaded.API
{
    partial class ErrorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubTitle = new System.Windows.Forms.Label();
            this.labelActions = new System.Windows.Forms.Label();
            this.actionRepository = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink();
            this.actionGenReport = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textErr = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTitle.Location = new System.Drawing.Point(66, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(251, 21);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "非常抱歉，但 RCSE 引发了错误。";
            // 
            // labelSubTitle
            // 
            this.labelSubTitle.AutoSize = true;
            this.labelSubTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSubTitle.Location = new System.Drawing.Point(67, 33);
            this.labelSubTitle.Name = "labelSubTitle";
            this.labelSubTitle.Size = new System.Drawing.Size(289, 17);
            this.labelSubTitle.TabIndex = 2;
            this.labelSubTitle.Text = "您可以考虑在 Github Repo 上的 Issues 进行反馈。";
            // 
            // labelActions
            // 
            this.labelActions.AutoSize = true;
            this.labelActions.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelActions.Location = new System.Drawing.Point(11, 62);
            this.labelActions.Name = "labelActions";
            this.labelActions.Size = new System.Drawing.Size(176, 17);
            this.labelActions.TabIndex = 3;
            this.labelActions.Text = "您可以考虑在下列选项中选择：";
            // 
            // actionRepository
            // 
            this.actionRepository.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.actionRepository.Location = new System.Drawing.Point(14, 80);
            this.actionRepository.Name = "actionRepository";
            this.actionRepository.NoteText = "";
            this.actionRepository.Size = new System.Drawing.Size(309, 45);
            this.actionRepository.TabIndex = 4;
            this.actionRepository.Text = "前往 Issues";
            this.actionRepository.UseVisualStyleBackColor = true;
            this.actionRepository.Click += new System.EventHandler(this.actionRepository_Click);
            // 
            // actionGenReport
            // 
            this.actionGenReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.actionGenReport.Location = new System.Drawing.Point(14, 118);
            this.actionGenReport.Name = "actionGenReport";
            this.actionGenReport.NoteText = "";
            this.actionGenReport.Size = new System.Drawing.Size(309, 41);
            this.actionGenReport.TabIndex = 5;
            this.actionGenReport.Text = "生成报告";
            this.actionGenReport.UseVisualStyleBackColor = true;
            this.actionGenReport.Click += new System.EventHandler(this.actionGenReport_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(244, 290);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(112, 24);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "关闭应用程序";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textErr
            // 
            this.textErr.Location = new System.Drawing.Point(23, 165);
            this.textErr.Multiline = true;
            this.textErr.Name = "textErr";
            this.textErr.Size = new System.Drawing.Size(333, 119);
            this.textErr.TabIndex = 7;
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 326);
            this.Controls.Add(this.textErr);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.actionGenReport);
            this.Controls.Add(this.actionRepository);
            this.Controls.Add(this.labelActions);
            this.Controls.Add(this.labelSubTitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
            this.Text = "错误";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ErrorForm_FormClosed);
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubTitle;
        private System.Windows.Forms.Label labelActions;
        private Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink actionRepository;
        private Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink actionGenReport;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textErr;
    }
}