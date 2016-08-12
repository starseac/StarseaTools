namespace Starsea.Egov.Tools
{
    partial class UpdateLogInfo
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
            this.txt_loginfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_loginfo
            // 
            this.txt_loginfo.Location = new System.Drawing.Point(0, 2);
            this.txt_loginfo.Multiline = true;
            this.txt_loginfo.Name = "txt_loginfo";
            this.txt_loginfo.Size = new System.Drawing.Size(638, 481);
            this.txt_loginfo.TabIndex = 0;
            // 
            // UpdateLogInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 484);
            this.Controls.Add(this.txt_loginfo);
            this.Name = "UpdateLogInfo";
            this.Text = "更新日志";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_loginfo;
    }
}