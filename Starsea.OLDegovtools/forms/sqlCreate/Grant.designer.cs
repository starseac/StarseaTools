namespace egovtools.forms.sqlCreate
{
    partial class Grant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grant));
            this.createSql = new System.Windows.Forms.Button();
            this.funcFrom = new System.Windows.Forms.TextBox();
            this.createUserid = new System.Windows.Forms.TextBox();
            this.sqlBox = new System.Windows.Forms.TextBox();
            this.roleFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.funcTo = new System.Windows.Forms.TextBox();
            this.roleTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.createDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cleanSql = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.Label();
            this.sqlCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createSql
            // 
            this.createSql.Location = new System.Drawing.Point(450, 38);
            this.createSql.Name = "createSql";
            this.createSql.Size = new System.Drawing.Size(75, 23);
            this.createSql.TabIndex = 0;
            this.createSql.Text = "生成sql";
            this.createSql.UseVisualStyleBackColor = true;
            this.createSql.Click += new System.EventHandler(this.createSql_Click);
            // 
            // funcFrom
            // 
            this.funcFrom.Location = new System.Drawing.Point(120, 3);
            this.funcFrom.Name = "funcFrom";
            this.funcFrom.Size = new System.Drawing.Size(62, 21);
            this.funcFrom.TabIndex = 1;
            // 
            // createUserid
            // 
            this.createUserid.Location = new System.Drawing.Point(381, 5);
            this.createUserid.Name = "createUserid";
            this.createUserid.Size = new System.Drawing.Size(77, 21);
            this.createUserid.TabIndex = 2;
            // 
            // sqlBox
            // 
            this.sqlBox.Location = new System.Drawing.Point(12, 77);
            this.sqlBox.Multiline = true;
            this.sqlBox.Name = "sqlBox";
            this.sqlBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sqlBox.Size = new System.Drawing.Size(664, 309);
            this.sqlBox.TabIndex = 3;
            // 
            // roleFrom
            // 
            this.roleFrom.Location = new System.Drawing.Point(120, 30);
            this.roleFrom.Name = "roleFrom";
            this.roleFrom.Size = new System.Drawing.Size(62, 21);
            this.roleFrom.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "需要赋权的funcid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "权限授予roleid";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "createid";
            // 
            // funcTo
            // 
            this.funcTo.Location = new System.Drawing.Point(222, 5);
            this.funcTo.Name = "funcTo";
            this.funcTo.Size = new System.Drawing.Size(77, 21);
            this.funcTo.TabIndex = 14;
            // 
            // roleTo
            // 
            this.roleTo.Location = new System.Drawing.Point(222, 33);
            this.roleTo.Name = "roleTo";
            this.roleTo.Size = new System.Drawing.Size(77, 21);
            this.roleTo.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(465, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "createTime";
            // 
            // createDate
            // 
            this.createDate.Location = new System.Drawing.Point(530, 6);
            this.createDate.Name = "createDate";
            this.createDate.Size = new System.Drawing.Size(146, 21);
            this.createDate.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "到";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "到";
            // 
            // cleanSql
            // 
            this.cleanSql.Location = new System.Drawing.Point(342, 38);
            this.cleanSql.Name = "cleanSql";
            this.cleanSql.Size = new System.Drawing.Size(75, 23);
            this.cleanSql.TabIndex = 21;
            this.cleanSql.Text = "清除sql";
            this.cleanSql.UseVisualStyleBackColor = true;
            this.cleanSql.Click += new System.EventHandler(this.cleanSql_Click);
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(220, 77);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(0, 12);
            this.message.TabIndex = 22;
            // 
            // sqlCopy
            // 
            this.sqlCopy.Location = new System.Drawing.Point(547, 38);
            this.sqlCopy.Name = "sqlCopy";
            this.sqlCopy.Size = new System.Drawing.Size(112, 23);
            this.sqlCopy.TabIndex = 23;
            this.sqlCopy.Text = "复制到剪贴板";
            this.sqlCopy.UseVisualStyleBackColor = true;
            this.sqlCopy.Click += new System.EventHandler(this.sqlCopy_Click);
            // 
            // Grant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 398);
            this.Controls.Add(this.sqlCopy);
            this.Controls.Add(this.message);
            this.Controls.Add(this.cleanSql);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.createDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.roleTo);
            this.Controls.Add(this.funcTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roleFrom);
            this.Controls.Add(this.sqlBox);
            this.Controls.Add(this.createUserid);
            this.Controls.Add(this.funcFrom);
            this.Controls.Add(this.createSql);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Grant";
            this.Text = "Gant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createSql;
        private System.Windows.Forms.TextBox funcFrom;
        private System.Windows.Forms.TextBox createUserid;
        private System.Windows.Forms.TextBox sqlBox;
        private System.Windows.Forms.TextBox roleFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox funcTo;
        private System.Windows.Forms.TextBox roleTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker createDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cleanSql;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Button sqlCopy;
    }
}

