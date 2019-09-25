namespace RCSE_Reloaded
{
    partial class DebugForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugForm));
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.buttonShowErrorFrm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(2, 2);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(186, 274);
            this.propertyGrid1.TabIndex = 0;
            // 
            // buttonShowErrorFrm
            // 
            this.buttonShowErrorFrm.Location = new System.Drawing.Point(194, 2);
            this.buttonShowErrorFrm.Name = "buttonShowErrorFrm";
            this.buttonShowErrorFrm.Size = new System.Drawing.Size(184, 23);
            this.buttonShowErrorFrm.TabIndex = 1;
            this.buttonShowErrorFrm.Text = "显示错误窗口";
            this.buttonShowErrorFrm.UseVisualStyleBackColor = true;
            this.buttonShowErrorFrm.Click += new System.EventHandler(this.buttonShowErrorFrm_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 279);
            this.Controls.Add(this.buttonShowErrorFrm);
            this.Controls.Add(this.propertyGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugForm";
            this.Text = "调试工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button buttonShowErrorFrm;
    }
}