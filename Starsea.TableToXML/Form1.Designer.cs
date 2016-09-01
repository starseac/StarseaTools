namespace TableToXML
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.xmlText = new System.Windows.Forms.TextBox();
            this.CasenoText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lczt = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Done = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.address = new System.Windows.Forms.ComboBox();
            this.wsURL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteFuction = new System.Windows.Forms.RadioButton();
            this.updateFuction = new System.Windows.Forms.RadioButton();
            this.addFuction = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "生成xml";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // xmlText
            // 
            this.xmlText.Location = new System.Drawing.Point(158, 99);
            this.xmlText.Multiline = true;
            this.xmlText.Name = "xmlText";
            this.xmlText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.xmlText.Size = new System.Drawing.Size(557, 361);
            this.xmlText.TabIndex = 2;
            // 
            // CasenoText
            // 
            this.CasenoText.Location = new System.Drawing.Point(6, 81);
            this.CasenoText.Name = "CasenoText";
            this.CasenoText.Size = new System.Drawing.Size(126, 21);
            this.CasenoText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "案卷编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "字段个数:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 34);
            this.button2.TabIndex = 6;
            this.button2.Text = "复制";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "图形状态";
            // 
            // lczt
            // 
            this.lczt.FormattingEnabled = true;
            this.lczt.Items.AddRange(new object[] {
            "create",
            "update1",
            "update2",
            "failure"});
            this.lczt.Location = new System.Drawing.Point(6, 142);
            this.lczt.Name = "lczt";
            this.lczt.Size = new System.Drawing.Size(126, 68);
            this.lczt.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "坐标点个数:";
            // 
            // Done
            // 
            this.Done.Location = new System.Drawing.Point(638, 55);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(75, 30);
            this.Done.TabIndex = 11;
            this.Done.Text = "执行";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 352);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 36);
            this.button4.TabIndex = 12;
            this.button4.Text = "清空";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // address
            // 
            this.address.FormattingEnabled = true;
            this.address.Items.AddRange(new object[] {
            "黄石",
            "大冶"});
            this.address.Location = new System.Drawing.Point(47, 8);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(104, 20);
            this.address.TabIndex = 15;
            this.address.SelectedIndexChanged += new System.EventHandler(this.address_SelectedIndexChanged);
            // 
            // wsURL
            // 
            this.wsURL.Location = new System.Drawing.Point(237, 8);
            this.wsURL.Name = "wsURL";
            this.wsURL.Size = new System.Drawing.Size(478, 21);
            this.wsURL.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "地域";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "服务地址";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteFuction);
            this.groupBox1.Controls.Add(this.updateFuction);
            this.groupBox1.Controls.Add(this.addFuction);
            this.groupBox1.Location = new System.Drawing.Point(265, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 33);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "调用方式";
            // 
            // deleteFuction
            // 
            this.deleteFuction.AutoSize = true;
            this.deleteFuction.Location = new System.Drawing.Point(236, 13);
            this.deleteFuction.Name = "deleteFuction";
            this.deleteFuction.Size = new System.Drawing.Size(47, 16);
            this.deleteFuction.TabIndex = 2;
            this.deleteFuction.TabStop = true;
            this.deleteFuction.Text = "删除";
            this.deleteFuction.UseVisualStyleBackColor = true;
            // 
            // updateFuction
            // 
            this.updateFuction.AutoSize = true;
            this.updateFuction.Location = new System.Drawing.Point(127, 13);
            this.updateFuction.Name = "updateFuction";
            this.updateFuction.Size = new System.Drawing.Size(47, 16);
            this.updateFuction.TabIndex = 1;
            this.updateFuction.TabStop = true;
            this.updateFuction.Text = "更新";
            this.updateFuction.UseVisualStyleBackColor = true;
            // 
            // addFuction
            // 
            this.addFuction.AutoSize = true;
            this.addFuction.Location = new System.Drawing.Point(18, 13);
            this.addFuction.Name = "addFuction";
            this.addFuction.Size = new System.Drawing.Size(47, 16);
            this.addFuction.TabIndex = 0;
            this.addFuction.TabStop = true;
            this.addFuction.Text = "新增";
            this.addFuction.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(725, 472);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.wsURL);
            this.Controls.Add(this.address);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lczt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CasenoText);
            this.Controls.Add(this.xmlText);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "一张图接口调用";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox xmlText;
    
        private System.Windows.Forms.TextBox CasenoText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox lczt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox address;
        private System.Windows.Forms.TextBox wsURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton deleteFuction;
        private System.Windows.Forms.RadioButton updateFuction;
        private System.Windows.Forms.RadioButton addFuction;
    }
}

