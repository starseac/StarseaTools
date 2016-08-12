namespace Starsea.Egov.Tools
{
    partial class EGOV_FJ_FILES
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
            this.btn_files = new System.Windows.Forms.Button();
            this.txt_tvnodetypeid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_files
            // 
            this.btn_files.Location = new System.Drawing.Point(47, 128);
            this.btn_files.Name = "btn_files";
            this.btn_files.Size = new System.Drawing.Size(75, 23);
            this.btn_files.TabIndex = 0;
            this.btn_files.Text = "生成文件夹包";
            this.btn_files.UseVisualStyleBackColor = true;
            this.btn_files.Click += new System.EventHandler(this.btn_files_Click);
            // 
            // txt_tvnodetypeid
            // 
            this.txt_tvnodetypeid.Location = new System.Drawing.Point(47, 65);
            this.txt_tvnodetypeid.Name = "txt_tvnodetypeid";
            this.txt_tvnodetypeid.Size = new System.Drawing.Size(163, 21);
            this.txt_tvnodetypeid.TabIndex = 1;
            // 
            // EGOV_FJ_FILES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 332);
            this.Controls.Add(this.txt_tvnodetypeid);
            this.Controls.Add(this.btn_files);
            this.Name = "EGOV_FJ_FILES";
            this.Text = "EGOV_FJ_FILES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_files;
        private System.Windows.Forms.TextBox txt_tvnodetypeid;
    }
}