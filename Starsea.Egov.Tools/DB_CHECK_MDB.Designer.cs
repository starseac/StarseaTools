namespace Starsea.Egov.Tools
{
    partial class DB_CHECK_MDB
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_chooseDir = new System.Windows.Forms.Button();
            this.txt_dir = new System.Windows.Forms.TextBox();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_chooseXml = new System.Windows.Forms.Button();
            this.txt_fileURL = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "获取所有表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "获取表字段";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(244, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "添加表";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(338, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "添加字段";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(434, 25);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "获取文件列表";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_chooseDir
            // 
            this.btn_chooseDir.Location = new System.Drawing.Point(10, 80);
            this.btn_chooseDir.Name = "btn_chooseDir";
            this.btn_chooseDir.Size = new System.Drawing.Size(120, 21);
            this.btn_chooseDir.TabIndex = 5;
            this.btn_chooseDir.Text = "选择mdb所在文件夹";
            this.btn_chooseDir.UseVisualStyleBackColor = true;
            this.btn_chooseDir.Click += new System.EventHandler(this.btn_chooseDir_Click);
            // 
            // txt_dir
            // 
            this.txt_dir.Location = new System.Drawing.Point(136, 80);
            this.txt_dir.Name = "txt_dir";
            this.txt_dir.Size = new System.Drawing.Size(490, 21);
            this.txt_dir.TabIndex = 6;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(632, 80);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 7;
            this.btn_export.Text = "生成配置";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_chooseXml
            // 
            this.btn_chooseXml.Location = new System.Drawing.Point(12, 125);
            this.btn_chooseXml.Name = "btn_chooseXml";
            this.btn_chooseXml.Size = new System.Drawing.Size(118, 23);
            this.btn_chooseXml.TabIndex = 8;
            this.btn_chooseXml.Text = "选着配置文件";
            this.btn_chooseXml.UseVisualStyleBackColor = true;
            this.btn_chooseXml.Click += new System.EventHandler(this.btn_chooseXml_Click);
            // 
            // txt_fileURL
            // 
            this.txt_fileURL.Location = new System.Drawing.Point(136, 126);
            this.txt_fileURL.Name = "txt_fileURL";
            this.txt_fileURL.Size = new System.Drawing.Size(490, 21);
            this.txt_fileURL.TabIndex = 9;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(632, 126);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "检查配置";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(13, 155);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(694, 292);
            this.consoleBox.TabIndex = 11;
            // 
            // DB_CHECK_MDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 459);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.txt_fileURL);
            this.Controls.Add(this.btn_chooseXml);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.txt_dir);
            this.Controls.Add(this.btn_chooseDir);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DB_CHECK_MDB";
            this.Text = "MDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox txt_fileURL;
        private System.Windows.Forms.Button btn_chooseXml;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.TextBox txt_dir;
        private System.Windows.Forms.Button btn_chooseDir;
        private System.Windows.Forms.TextBox consoleBox;
    }
}