namespace Starsea.RegularExpressions
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.txt_reg = new System.Windows.Forms.TextBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "^[1-9]{1}\\d*$|^[1-9]{1}\\d*\\.[0-9]+$|^[0]{1}$|^[0]{1}\\.[0-9]+$"});
            this.comboBox1.Location = new System.Drawing.Point(169, 370);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(564, 23);
            this.comboBox1.TabIndex = 13;
           // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 370);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "验证库";
             // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "正则表达式代码";
          // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "待验证值";
          // 
            // txt_value
            // 
            this.txt_value.Location = new System.Drawing.Point(169, 6);
            this.txt_value.Margin = new System.Windows.Forms.Padding(4);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(564, 25);
            this.txt_value.TabIndex = 9;
           // 
            // txt_reg
            // 
            this.txt_reg.Location = new System.Drawing.Point(169, 105);
            this.txt_reg.Margin = new System.Windows.Forms.Padding(4);
            this.txt_reg.Multiline = true;
            this.txt_reg.Name = "txt_reg";
            this.txt_reg.Size = new System.Drawing.Size(564, 219);
            this.txt_reg.TabIndex = 8;
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(169, 512);
            this.btn_check.Margin = new System.Windows.Forms.Padding(4);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(163, 70);
            this.btn_check.TabIndex = 7;
            this.btn_check.Text = "验证";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 588);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.txt_reg);
            this.Controls.Add(this.btn_check);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.TextBox txt_reg;
        private System.Windows.Forms.Button btn_check;
    }
}

