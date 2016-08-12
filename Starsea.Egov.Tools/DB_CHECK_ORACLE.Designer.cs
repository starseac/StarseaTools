namespace Starsea.Egov.Tools
{
    partial class DB_CHECK_ORACLE
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
            this.btn_check = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_choose = new System.Windows.Forms.Button();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.btnLogExp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(932, 89);
            this.btn_check.Margin = new System.Windows.Forms.Padding(4);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(100, 29);
            this.btn_check.TabIndex = 0;
            this.btn_check.Text = "检查";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(141, 89);
            this.txtURL.Margin = new System.Windows.Forms.Padding(4);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(755, 25);
            this.txtURL.TabIndex = 1;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(16, 29);
            this.btn_export.Margin = new System.Windows.Forms.Padding(4);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(100, 29);
            this.btn_export.TabIndex = 2;
            this.btn_export.Text = "导出配置";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_choose
            // 
            this.btn_choose.Location = new System.Drawing.Point(17, 86);
            this.btn_choose.Margin = new System.Windows.Forms.Padding(4);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(100, 29);
            this.btn_choose.TabIndex = 3;
            this.btn_choose.Text = "选着配置文件";
            this.btn_choose.UseVisualStyleBackColor = true;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(13, 156);
            this.consoleBox.Margin = new System.Windows.Forms.Padding(4);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(1013, 435);
            this.consoleBox.TabIndex = 4;
            // 
            // btnLogExp
            // 
            this.btnLogExp.Location = new System.Drawing.Point(932, 29);
            this.btnLogExp.Name = "btnLogExp";
            this.btnLogExp.Size = new System.Drawing.Size(94, 29);
            this.btnLogExp.TabIndex = 5;
            this.btnLogExp.Text = "导出日志";
            this.btnLogExp.UseVisualStyleBackColor = true;
            this.btnLogExp.Click += new System.EventHandler(this.btnLogExp_Click);
            // 
            // DB_CHECK_ORACLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 622);
            this.Controls.Add(this.btnLogExp);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btn_check);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DB_CHECK_ORACLE";
            this.Text = "ORACLE_CHECK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.TextBox consoleBox;
        private System.Windows.Forms.Button btnLogExp;
    }
}