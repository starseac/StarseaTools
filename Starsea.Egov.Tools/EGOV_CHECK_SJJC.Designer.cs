namespace Starsea.Egov.Tools
{
    partial class EGOV_CHECK_SJJC
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_choose = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(26, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 0;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(175, 24);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(94, 23);
            this.btn_export.TabIndex = 1;
            this.btn_export.Text = "导出配置";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_choose
            // 
            this.btn_choose.Location = new System.Drawing.Point(26, 75);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(69, 23);
            this.btn_choose.TabIndex = 2;
            this.btn_choose.Text = "选着文件";
            this.btn_choose.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(527, 21);
            this.textBox1.TabIndex = 3;
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(634, 77);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(75, 23);
            this.btn_check.TabIndex = 4;
            this.btn_check.Text = "检查";
            this.btn_check.UseVisualStyleBackColor = true;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(716, 77);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 5;
            this.btn_update.Text = "更新";
            this.btn_update.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(26, 117);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(778, 352);
            this.textBox2.TabIndex = 6;
            // 
            // EGOV_CHECK_SJJC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 481);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.comboBox1);
            this.Name = "EGOV_CHECK_SJJC";
            this.Text = "电子政务数据检查";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.TextBox textBox2;
    }
}