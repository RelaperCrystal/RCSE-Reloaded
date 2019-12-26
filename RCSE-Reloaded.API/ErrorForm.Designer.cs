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
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTitle.Name = "labelTitle";
            // 
            // labelSubTitle
            // 
            resources.ApplyResources(this.labelSubTitle, "labelSubTitle");
            this.labelSubTitle.Name = "labelSubTitle";
            // 
            // labelActions
            // 
            resources.ApplyResources(this.labelActions, "labelActions");
            this.labelActions.Name = "labelActions";
            // 
            // actionRepository
            // 
            resources.ApplyResources(this.actionRepository, "actionRepository");
            this.actionRepository.Name = "actionRepository";
            this.actionRepository.NoteText = "";
            this.actionRepository.UseVisualStyleBackColor = true;
            this.actionRepository.Click += new System.EventHandler(this.actionRepository_Click);
            // 
            // actionGenReport
            // 
            resources.ApplyResources(this.actionGenReport, "actionGenReport");
            this.actionGenReport.Name = "actionGenReport";
            this.actionGenReport.NoteText = "";
            this.actionGenReport.UseVisualStyleBackColor = true;
            this.actionGenReport.Click += new System.EventHandler(this.actionGenReport_Click);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textErr
            // 
            resources.ApplyResources(this.textErr, "textErr");
            this.textErr.Name = "textErr";
            // 
            // ErrorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textErr);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.actionGenReport);
            this.Controls.Add(this.actionRepository);
            this.Controls.Add(this.labelActions);
            this.Controls.Add(this.labelSubTitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
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