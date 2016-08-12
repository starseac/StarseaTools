namespace Starsea.Egov.Tools
{
    partial class EGOV_CHECK_DEL
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
            this.button1 = new System.Windows.Forms.Button();
            this.cl_exportType = new System.Windows.Forms.CheckedListBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.bt_backup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "导出删除sql配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cl_exportType
            // 
            this.cl_exportType.FormattingEnabled = true;
            this.cl_exportType.Items.AddRange(new object[] {
            "建设用地",
            "矿业权",
            "土整"});
            this.cl_exportType.Location = new System.Drawing.Point(12, 26);
            this.cl_exportType.Name = "cl_exportType";
            this.cl_exportType.Size = new System.Drawing.Size(120, 52);
            this.cl_exportType.TabIndex = 1;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(13, 98);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(94, 23);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "选着配置文件";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(125, 100);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(387, 21);
            this.txtURL.TabIndex = 3;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(536, 98);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "检查";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(636, 99);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "更新sql配置";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(13, 145);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(710, 243);
            this.consoleBox.TabIndex = 6;
            // 
            // bt_backup
            // 
            this.bt_backup.Location = new System.Drawing.Point(323, 26);
            this.bt_backup.Name = "bt_backup";
            this.bt_backup.Size = new System.Drawing.Size(115, 23);
            this.bt_backup.TabIndex = 7;
            this.bt_backup.Text = "备份sql配置";
            this.bt_backup.UseVisualStyleBackColor = true;
            this.bt_backup.Click += new System.EventHandler(this.bt_backup_Click);
            // 
            // EGOV_CHECK_DEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 400);
            this.Controls.Add(this.bt_backup);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.cl_exportType);
            this.Controls.Add(this.button1);
            this.Name = "EGOV_CHECK_DEL";
            this.Text = "删除sql语句配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox cl_exportType;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox consoleBox;
        private System.Windows.Forms.Button bt_backup;
    }
}