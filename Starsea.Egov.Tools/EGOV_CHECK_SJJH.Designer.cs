namespace Starsea.Egov.Tools
{
    partial class EGOV_CHECK_SJJH
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
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_backup = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.cb_exportType = new System.Windows.Forms.CheckedListBox();
            this.cb_outputType = new System.Windows.Forms.CheckedListBox();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(307, 105);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 0;
            this.btn_export.Text = "导出";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_backup
            // 
            this.btn_backup.Location = new System.Drawing.Point(429, 105);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(75, 23);
            this.btn_backup.TabIndex = 3;
            this.btn_backup.Text = "备份";
            this.btn_backup.UseVisualStyleBackColor = true;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(24, 142);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 25);
            this.btn_open.TabIndex = 4;
            this.btn_open.Text = "选着配置文件";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(117, 144);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(403, 21);
            this.txtURL.TabIndex = 5;
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(527, 141);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(75, 25);
            this.btn_check.TabIndex = 6;
            this.btn_check.Text = "检查";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(619, 142);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 25);
            this.btn_update.TabIndex = 7;
            this.btn_update.Text = "更新";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // cb_exportType
            // 
            this.cb_exportType.FormattingEnabled = true;
            this.cb_exportType.Items.AddRange(new object[] {
            "建设用地",
            "矿业权",
            "土整"});
            this.cb_exportType.Location = new System.Drawing.Point(24, 12);
            this.cb_exportType.Name = "cb_exportType";
            this.cb_exportType.Size = new System.Drawing.Size(103, 52);
            this.cb_exportType.TabIndex = 8;
            // 
            // cb_outputType
            // 
            this.cb_outputType.FormattingEnabled = true;
            this.cb_outputType.Items.AddRange(new object[] {
            "BSIBJXOUTPUT",
            "BSIBJXINPUT",
            "JG",
            "JGINPUT",
            "BA",
            "BAINPUT",
            "ZDBJXOUTPUT"});
            this.cb_outputType.Location = new System.Drawing.Point(160, 12);
            this.cb_outputType.Name = "cb_outputType";
            this.cb_outputType.Size = new System.Drawing.Size(120, 116);
            this.cb_outputType.TabIndex = 9;
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(24, 174);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(670, 313);
            this.consoleBox.TabIndex = 10;
            // 
            // EGOV_CHECK_SJJH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 489);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.cb_outputType);
            this.Controls.Add(this.cb_exportType);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.btn_backup);
            this.Controls.Add(this.btn_export);
            this.Name = "EGOV_CHECK_SJJH";
            this.Text = "EGOV_CHEKC_SJJH";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.CheckedListBox cb_exportType;
        private System.Windows.Forms.CheckedListBox cb_outputType;
        private System.Windows.Forms.TextBox consoleBox;
    }
}