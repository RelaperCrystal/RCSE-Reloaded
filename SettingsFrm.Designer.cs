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
            this.groupDisplay = new System.Windows.Forms.GroupBox();
            this.checkUseMainMenu = new System.Windows.Forms.CheckBox();
            this.labelMainMenu = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkLightColor = new System.Windows.Forms.CheckBox();
            this.groupDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDisplay
            // 
            this.groupDisplay.Controls.Add(this.checkLightColor);
            this.groupDisplay.Controls.Add(this.labelMainMenu);
            this.groupDisplay.Controls.Add(this.checkUseMainMenu);
            this.groupDisplay.Location = new System.Drawing.Point(12, 12);
            this.groupDisplay.Name = "groupDisplay";
            this.groupDisplay.Size = new System.Drawing.Size(287, 233);
            this.groupDisplay.TabIndex = 0;
            this.groupDisplay.TabStop = false;
            this.groupDisplay.Text = "外观";
            // 
            // checkUseMainMenu
            // 
            this.checkUseMainMenu.AutoSize = true;
            this.checkUseMainMenu.Location = new System.Drawing.Point(6, 20);
            this.checkUseMainMenu.Name = "checkUseMainMenu";
            this.checkUseMainMenu.Size = new System.Drawing.Size(120, 16);
            this.checkUseMainMenu.TabIndex = 1;
            this.checkUseMainMenu.Text = "使用仿原生菜单栏";
            this.checkUseMainMenu.UseVisualStyleBackColor = true;
            // 
            // labelMainMenu
            // 
            this.labelMainMenu.Location = new System.Drawing.Point(23, 39);
            this.labelMainMenu.Name = "labelMainMenu";
            this.labelMainMenu.Size = new System.Drawing.Size(258, 32);
            this.labelMainMenu.TabIndex = 1;
            this.labelMainMenu.Text = "使用 MainMenu 替代 MenuStrip 作为 RCSE 的菜单栏控件。";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(305, 12);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // checkLightColor
            // 
            this.checkLightColor.AutoSize = true;
            this.checkLightColor.Location = new System.Drawing.Point(6, 74);
            this.checkLightColor.Name = "checkLightColor";
            this.checkLightColor.Size = new System.Drawing.Size(96, 16);
            this.checkLightColor.TabIndex = 2;
            this.checkLightColor.Text = "使用亮色主题";
            this.checkLightColor.UseVisualStyleBackColor = true;
            // 
            // SettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 253);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "设置";
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
    }
}