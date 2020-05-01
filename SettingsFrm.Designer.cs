namespace RCSE_Reloaded
{
    partial class SettingsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsFrm));
            this.groupDisplay = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkLightColor = new System.Windows.Forms.CheckBox();
            this.labelMainMenu = new System.Windows.Forms.Label();
            this.checkUseMainMenu = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveProfile = new System.Windows.Forms.Button();
            this.groupDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDisplay
            // 
            this.groupDisplay.Controls.Add(this.label1);
            this.groupDisplay.Controls.Add(this.checkBox1);
            this.groupDisplay.Controls.Add(this.checkLightColor);
            this.groupDisplay.Controls.Add(this.labelMainMenu);
            this.groupDisplay.Controls.Add(this.checkUseMainMenu);
            resources.ApplyResources(this.groupDisplay, "groupDisplay");
            this.groupDisplay.Name = "groupDisplay";
            this.groupDisplay.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkLightColor
            // 
            resources.ApplyResources(this.checkLightColor, "checkLightColor");
            this.checkLightColor.Checked = true;
            this.checkLightColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLightColor.Name = "checkLightColor";
            this.checkLightColor.UseVisualStyleBackColor = true;
            // 
            // labelMainMenu
            // 
            resources.ApplyResources(this.labelMainMenu, "labelMainMenu");
            this.labelMainMenu.Name = "labelMainMenu";
            // 
            // checkUseMainMenu
            // 
            resources.ApplyResources(this.checkUseMainMenu, "checkUseMainMenu");
            this.checkUseMainMenu.Name = "checkUseMainMenu";
            this.checkUseMainMenu.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSaveProfile
            // 
            resources.ApplyResources(this.buttonSaveProfile, "buttonSaveProfile");
            this.buttonSaveProfile.Name = "buttonSaveProfile";
            this.buttonSaveProfile.UseVisualStyleBackColor = true;
            this.buttonSaveProfile.Click += new System.EventHandler(this.buttonSaveProfile_Click);
            // 
            // SettingsFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSaveProfile);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SettingsFrm_Load);
            this.groupDisplay.ResumeLayout(false);
            this.groupDisplay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDisplay;
        private System.Windows.Forms.Label labelMainMenu;
        private System.Windows.Forms.CheckBox checkUseMainMenu;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkLightColor;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveProfile;
    }
}