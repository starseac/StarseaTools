namespace Starsea.Egov.Tools
{
    partial class Starsea
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
            this.btn_check_fjs = new System.Windows.Forms.Button();
            this.btn_check_del = new System.Windows.Forms.Button();
            this.btn_check_sjjh = new System.Windows.Forms.Button();
            this.btn_check_mdb = new System.Windows.Forms.Button();
            this.btn_check_oracle = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.btn_set = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_check_sjjc = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_updatelog = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_check_fjs
            // 
            this.btn_check_fjs.Location = new System.Drawing.Point(6, 29);
            this.btn_check_fjs.Name = "btn_check_fjs";
            this.btn_check_fjs.Size = new System.Drawing.Size(75, 46);
            this.btn_check_fjs.TabIndex = 0;
            this.btn_check_fjs.Text = "附件树配置";
            this.btn_check_fjs.UseVisualStyleBackColor = true;
            this.btn_check_fjs.Click += new System.EventHandler(this.btn_check_fjs_Click);
            // 
            // btn_check_del
            // 
            this.btn_check_del.Location = new System.Drawing.Point(87, 29);
            this.btn_check_del.Name = "btn_check_del";
            this.btn_check_del.Size = new System.Drawing.Size(75, 46);
            this.btn_check_del.TabIndex = 1;
            this.btn_check_del.Text = "流程删除语句配置";
            this.btn_check_del.UseVisualStyleBackColor = true;
            this.btn_check_del.Click += new System.EventHandler(this.btn_check_del_Click);
            // 
            // btn_check_sjjh
            // 
            this.btn_check_sjjh.Location = new System.Drawing.Point(6, 30);
            this.btn_check_sjjh.Name = "btn_check_sjjh";
            this.btn_check_sjjh.Size = new System.Drawing.Size(75, 45);
            this.btn_check_sjjh.TabIndex = 2;
            this.btn_check_sjjh.Text = "sql配置";
            this.btn_check_sjjh.UseVisualStyleBackColor = true;
            this.btn_check_sjjh.Click += new System.EventHandler(this.btn_check_sjjh_Click);
            // 
            // btn_check_mdb
            // 
            this.btn_check_mdb.Location = new System.Drawing.Point(87, 30);
            this.btn_check_mdb.Name = "btn_check_mdb";
            this.btn_check_mdb.Size = new System.Drawing.Size(75, 45);
            this.btn_check_mdb.TabIndex = 3;
            this.btn_check_mdb.Text = "mdb模板检查";
            this.btn_check_mdb.UseVisualStyleBackColor = true;
            this.btn_check_mdb.Click += new System.EventHandler(this.btn_check_mdb_Click);
            // 
            // btn_check_oracle
            // 
            this.btn_check_oracle.Location = new System.Drawing.Point(6, 20);
            this.btn_check_oracle.Name = "btn_check_oracle";
            this.btn_check_oracle.Size = new System.Drawing.Size(75, 47);
            this.btn_check_oracle.TabIndex = 4;
            this.btn_check_oracle.Text = "数据库表检查";
            this.btn_check_oracle.UseVisualStyleBackColor = true;
            this.btn_check_oracle.Click += new System.EventHandler(this.btn_check_oracle_Click);
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(6, 20);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(75, 38);
            this.btn_set.TabIndex = 6;
            this.btn_set.Text = "设置";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_check_sjjh);
            this.groupBox1.Controls.Add(this.btn_check_mdb);
            this.groupBox1.Location = new System.Drawing.Point(12, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 83);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "三级交换";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_check_sjjc);
            this.groupBox2.Controls.Add(this.btn_check_fjs);
            this.groupBox2.Controls.Add(this.btn_check_del);
            this.groupBox2.Location = new System.Drawing.Point(12, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 83);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "电子政务配置";
            // 
            // btn_check_sjjc
            // 
            this.btn_check_sjjc.Location = new System.Drawing.Point(168, 29);
            this.btn_check_sjjc.Name = "btn_check_sjjc";
            this.btn_check_sjjc.Size = new System.Drawing.Size(75, 46);
            this.btn_check_sjjc.TabIndex = 2;
            this.btn_check_sjjc.Text = "数据检查";
            this.btn_check_sjjc.UseVisualStyleBackColor = true;
            this.btn_check_sjjc.Click += new System.EventHandler(this.btn_check_sjjc_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_check_oracle);
            this.groupBox3.Location = new System.Drawing.Point(12, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 75);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据库";
            // 
            // btn_updatelog
            // 
            this.btn_updatelog.Location = new System.Drawing.Point(87, 20);
            this.btn_updatelog.Name = "btn_updatelog";
            this.btn_updatelog.Size = new System.Drawing.Size(75, 38);
            this.btn_updatelog.TabIndex = 10;
            this.btn_updatelog.Text = "更新日志";
            this.btn_updatelog.UseVisualStyleBackColor = true;
            this.btn_updatelog.Click += new System.EventHandler(this.btn_updatelog_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_updatelog);
            this.groupBox4.Controls.Add(this.btn_set);
            this.groupBox4.Location = new System.Drawing.Point(12, 270);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(259, 76);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "其他";
            // 
            // Starsea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 358);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Starsea";
            this.Text = "检查配置工具箱";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_check_fjs;
        private System.Windows.Forms.Button btn_check_del;
        private System.Windows.Forms.Button btn_check_sjjh;
        private System.Windows.Forms.Button btn_check_mdb;
        private System.Windows.Forms.Button btn_check_oracle;
        private System.Windows.Forms.HelpProvider helpProvider1;
     
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_check_sjjc;
        private System.Windows.Forms.Button btn_updatelog;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}