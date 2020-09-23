namespace RCSE_Reloaded
{
    partial class FrmInsertLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInsertLicense));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelInsertLicense = new System.Windows.Forms.Label();
            this.radioC = new System.Windows.Forms.RadioButton();
            this.radioVB = new System.Windows.Forms.RadioButton();
            this.labelAppName = new System.Windows.Forms.Label();
            this.textAppName = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.textAuthorName = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "GNU GPL v3",
            "GNU GPL v2",
            "GNU LGPL v3",
            "GNU LGPL v2",
            "MIT License"});
            this.comboBox1.Location = new System.Drawing.Point(16, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(545, 32);
            this.comboBox1.TabIndex = 0;
            // 
            // labelInsertLicense
            // 
            this.labelInsertLicense.AutoSize = true;
            this.labelInsertLicense.Location = new System.Drawing.Point(12, 9);
            this.labelInsertLicense.Name = "labelInsertLicense";
            this.labelInsertLicense.Size = new System.Drawing.Size(262, 24);
            this.labelInsertLicense.TabIndex = 1;
            this.labelInsertLicense.Text = "请选择你需要的许可证并插入。";
            // 
            // radioC
            // 
            this.radioC.AutoSize = true;
            this.radioC.Checked = true;
            this.radioC.Location = new System.Drawing.Point(16, 74);
            this.radioC.Name = "radioC";
            this.radioC.Size = new System.Drawing.Size(121, 28);
            this.radioC.TabIndex = 2;
            this.radioC.TabStop = true;
            this.radioC.Text = "C 方式 (//)";
            this.radioC.UseVisualStyleBackColor = true;
            // 
            // radioVB
            // 
            this.radioVB.AutoSize = true;
            this.radioVB.Location = new System.Drawing.Point(143, 74);
            this.radioVB.Name = "radioVB";
            this.radioVB.Size = new System.Drawing.Size(121, 28);
            this.radioVB.TabIndex = 3;
            this.radioVB.Text = "VB 方式 (\')";
            this.radioVB.UseVisualStyleBackColor = true;
            // 
            // labelAppName
            // 
            this.labelAppName.AutoSize = true;
            this.labelAppName.Location = new System.Drawing.Point(12, 108);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(82, 24);
            this.labelAppName.TabIndex = 4;
            this.labelAppName.Text = "软件名称";
            // 
            // textAppName
            // 
            this.textAppName.Location = new System.Drawing.Point(100, 105);
            this.textAppName.Name = "textAppName";
            this.textAppName.Size = new System.Drawing.Size(461, 30);
            this.textAppName.TabIndex = 5;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(12, 145);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(82, 24);
            this.labelAuthor.TabIndex = 6;
            this.labelAuthor.Text = "作者名称";
            // 
            // textAuthorName
            // 
            this.textAuthorName.Location = new System.Drawing.Point(100, 142);
            this.textAuthorName.Name = "textAuthorName";
            this.textAuthorName.Size = new System.Drawing.Size(461, 30);
            this.textAuthorName.TabIndex = 7;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(410, 184);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(151, 37);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(253, 184);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(151, 37);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FrmInsertLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 233);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textAuthorName);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.textAppName);
            this.Controls.Add(this.labelAppName);
            this.Controls.Add(this.radioVB);
            this.Controls.Add(this.radioC);
            this.Controls.Add(this.labelInsertLicense);
            this.Controls.Add(this.comboBox1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInsertLicense";
            this.Text = "插入许可证";
            this.Load += new System.EventHandler(this.FrmInsertLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelInsertLicense;
        private System.Windows.Forms.RadioButton radioC;
        private System.Windows.Forms.RadioButton radioVB;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.TextBox textAppName;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox textAuthorName;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}