namespace Starsea.egovfjexport
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_caseno = new System.Windows.Forms.TextBox();
            this.txt_filepath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "导出路径";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "案卷编号";
            // 
            // txt_caseno
            // 
            this.txt_caseno.Location = new System.Drawing.Point(139, 123);
            this.txt_caseno.Margin = new System.Windows.Forms.Padding(4);
            this.txt_caseno.Name = "txt_caseno";
            this.txt_caseno.Size = new System.Drawing.Size(380, 25);
            this.txt_caseno.TabIndex = 7;
            // 
            // txt_filepath
            // 
            this.txt_filepath.Location = new System.Drawing.Point(139, 211);
            this.txt_filepath.Margin = new System.Windows.Forms.Padding(4);
            this.txt_filepath.Name = "txt_filepath";
            this.txt_filepath.Size = new System.Drawing.Size(380, 25);
            this.txt_filepath.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 304);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "导出附件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 457);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_caseno);
            this.Controls.Add(this.txt_filepath);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_caseno;
        private System.Windows.Forms.TextBox txt_filepath;
        private System.Windows.Forms.Button button1;
    }
}

