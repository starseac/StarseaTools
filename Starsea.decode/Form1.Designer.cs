namespace decode
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
            this.encryptBtn = new System.Windows.Forms.Button();
            this.cleanBtn = new System.Windows.Forms.Button();
            this.inText = new System.Windows.Forms.TextBox();
            this.outText = new System.Windows.Forms.TextBox();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.type1 = new System.Windows.Forms.RadioButton();
            this.type2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // encryptBtn
            // 
            this.encryptBtn.Location = new System.Drawing.Point(322, 262);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(75, 23);
            this.encryptBtn.TabIndex = 0;
            this.encryptBtn.Text = "加密";
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // cleanBtn
            // 
            this.cleanBtn.Location = new System.Drawing.Point(241, 262);
            this.cleanBtn.Name = "cleanBtn";
            this.cleanBtn.Size = new System.Drawing.Size(75, 23);
            this.cleanBtn.TabIndex = 1;
            this.cleanBtn.Text = "清空";
            this.cleanBtn.UseVisualStyleBackColor = true;
            this.cleanBtn.Click += new System.EventHandler(this.cleanBtn_Click);
            // 
            // inText
            // 
            this.inText.Location = new System.Drawing.Point(61, 20);
            this.inText.Multiline = true;
            this.inText.Name = "inText";
            this.inText.Size = new System.Drawing.Size(447, 74);
            this.inText.TabIndex = 2;
            // 
            // outText
            // 
            this.outText.Location = new System.Drawing.Point(61, 108);
            this.outText.Multiline = true;
            this.outText.Name = "outText";
            this.outText.Size = new System.Drawing.Size(447, 143);
            this.outText.TabIndex = 3;
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(412, 262);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(75, 23);
            this.decryptBtn.TabIndex = 4;
            this.decryptBtn.Text = "解密";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "字符";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "处理结果";
            // 
            // type1
            // 
            this.type1.AutoSize = true;
            this.type1.Location = new System.Drawing.Point(61, 265);
            this.type1.Name = "type1";
            this.type1.Size = new System.Drawing.Size(41, 16);
            this.type1.TabIndex = 7;
            this.type1.Text = "ECB";
            this.type1.UseVisualStyleBackColor = true;
            // 
            // type2
            // 
            this.type2.AutoSize = true;
            this.type2.Checked = true;
            this.type2.Location = new System.Drawing.Point(119, 265);
            this.type2.Name = "type2";
            this.type2.Size = new System.Drawing.Size(41, 16);
            this.type2.TabIndex = 8;
            this.type2.TabStop = true;
            this.type2.Text = "MD5";
            this.type2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 319);
            this.Controls.Add(this.type2);
            this.Controls.Add(this.type1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decryptBtn);
            this.Controls.Add(this.outText);
            this.Controls.Add(this.inText);
            this.Controls.Add(this.cleanBtn);
            this.Controls.Add(this.encryptBtn);
            this.Name = "Form1";
            this.Text = "解密";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Button cleanBtn;
        private System.Windows.Forms.TextBox inText;
        private System.Windows.Forms.TextBox outText;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton type1;
        private System.Windows.Forms.RadioButton type2;
    }
}

