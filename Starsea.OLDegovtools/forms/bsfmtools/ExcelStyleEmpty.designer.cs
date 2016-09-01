namespace egovtools.forms.bsfmtools
{
    partial class ExcelSytleEmpty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelSytleEmpty));
            this.clean = new System.Windows.Forms.Button();
            this.styleClean = new System.Windows.Forms.Button();
            this.delSpace = new System.Windows.Forms.Button();
            this.tableText = new System.Windows.Forms.TextBox();
            this.toText = new System.Windows.Forms.Button();
            this.richText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // clean
            // 
            this.clean.Location = new System.Drawing.Point(540, 351);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(75, 23);
            this.clean.TabIndex = 0;
            this.clean.Text = "清空";
            this.clean.UseVisualStyleBackColor = true;
            // 
            // styleClean
            // 
            this.styleClean.Location = new System.Drawing.Point(540, 57);
            this.styleClean.Name = "styleClean";
            this.styleClean.Size = new System.Drawing.Size(75, 23);
            this.styleClean.TabIndex = 1;
            this.styleClean.Text = "清空样式";
            this.styleClean.UseVisualStyleBackColor = true;
            this.styleClean.Click += new System.EventHandler(this.styleClean_Click);
            // 
            // delSpace
            // 
            this.delSpace.Location = new System.Drawing.Point(540, 105);
            this.delSpace.Name = "delSpace";
            this.delSpace.Size = new System.Drawing.Size(75, 23);
            this.delSpace.TabIndex = 10;
            this.delSpace.Text = "缩进";
            this.delSpace.UseVisualStyleBackColor = true;
            // 
            // tableText
            // 
            this.tableText.Location = new System.Drawing.Point(621, -1);
            this.tableText.Multiline = true;
            this.tableText.Name = "tableText";
            this.tableText.Size = new System.Drawing.Size(533, 485);
            this.tableText.TabIndex = 14;
            // 
            // toText
            // 
            this.toText.Location = new System.Drawing.Point(540, 12);
            this.toText.Name = "toText";
            this.toText.Size = new System.Drawing.Size(75, 23);
            this.toText.TabIndex = 15;
            this.toText.Text = ">>>>";
            this.toText.UseVisualStyleBackColor = true;
            this.toText.Click += new System.EventHandler(this.toText_Click);
            // 
            // richText
            // 
            this.richText.Location = new System.Drawing.Point(-2, -1);
            this.richText.Multiline = true;
            this.richText.Name = "richText";
            this.richText.Size = new System.Drawing.Size(536, 485);
            this.richText.TabIndex = 16;
            // 
            // ExcelSytleEmpty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 486);
            this.Controls.Add(this.richText);
            this.Controls.Add(this.toText);
            this.Controls.Add(this.tableText);
            this.Controls.Add(this.delSpace);
            this.Controls.Add(this.styleClean);
            this.Controls.Add(this.clean);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelSytleEmpty";
            this.Text = "样式清空器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clean;
        private System.Windows.Forms.Button styleClean;
        private System.Windows.Forms.Button delSpace;
        private System.Windows.Forms.TextBox tableText;
        private System.Windows.Forms.Button toText;
        private System.Windows.Forms.TextBox richText;
    }
}

