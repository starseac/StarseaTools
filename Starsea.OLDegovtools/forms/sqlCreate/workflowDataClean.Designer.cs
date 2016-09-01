namespace egovtools.forms.sqlCreate
{
    partial class workflowDataClean
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
            this.flowList = new System.Windows.Forms.ComboBox();
            this.SqlCreate = new System.Windows.Forms.Button();
            this.cleanSql = new System.Windows.Forms.Button();
            this.sqlText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 0;
            // 
            // flowList
            // 
            this.flowList.FormattingEnabled = true;
            this.flowList.Items.AddRange(new object[] {
            "发文",
            "收文",
            "局内请示",
            "内部公告",
            "内部通知",
            "初始登记",
            "变更登记",
            "抵押登记",
            "划拨",
            "出让",
            "农民建房"});
            this.flowList.Location = new System.Drawing.Point(256, 12);
            this.flowList.Name = "flowList";
            this.flowList.Size = new System.Drawing.Size(121, 20);
            this.flowList.TabIndex = 1;
            // 
            // SqlCreate
            // 
            this.SqlCreate.Location = new System.Drawing.Point(423, 10);
            this.SqlCreate.Name = "SqlCreate";
            this.SqlCreate.Size = new System.Drawing.Size(75, 23);
            this.SqlCreate.TabIndex = 2;
            this.SqlCreate.Text = "生成sql";
            this.SqlCreate.UseVisualStyleBackColor = true;
            this.SqlCreate.Click += new System.EventHandler(this.SqlCreate_Click);
            // 
            // cleanSql
            // 
            this.cleanSql.Location = new System.Drawing.Point(12, 338);
            this.cleanSql.Name = "cleanSql";
            this.cleanSql.Size = new System.Drawing.Size(75, 23);
            this.cleanSql.TabIndex = 3;
            this.cleanSql.Text = "清除sql";
            this.cleanSql.UseVisualStyleBackColor = true;
            // 
            // sqlText
            // 
            this.sqlText.Location = new System.Drawing.Point(9, 51);
            this.sqlText.Multiline = true;
            this.sqlText.Name = "sqlText";
            this.sqlText.Size = new System.Drawing.Size(620, 281);
            this.sqlText.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "业务类别";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "业务流程";
            // 
            // sqlCopy
            // 
            this.sqlCopy.Location = new System.Drawing.Point(531, 10);
            this.sqlCopy.Name = "sqlCopy";
            this.sqlCopy.Size = new System.Drawing.Size(98, 23);
            this.sqlCopy.TabIndex = 7;
            this.sqlCopy.Text = "复制到粘贴板";
            this.sqlCopy.UseVisualStyleBackColor = true;
            this.sqlCopy.Click += new System.EventHandler(this.sqlCopy_Click);
            // 
            // workflowDataClean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 367);
            this.Controls.Add(this.sqlCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sqlText);
            this.Controls.Add(this.cleanSql);
            this.Controls.Add(this.SqlCreate);
            this.Controls.Add(this.flowList);
            this.Controls.Add(this.comboBox1);
            this.Name = "workflowDataClean";
            this.Text = "数据清除";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox flowList;
        private System.Windows.Forms.Button SqlCreate;
        private System.Windows.Forms.Button cleanSql;
        private System.Windows.Forms.TextBox sqlText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sqlCopy;
    }
}