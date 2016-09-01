namespace egovtools
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGWSPY = new System.Windows.Forms.Button();
            this.dataCleanSql = new System.Windows.Forms.Button();
            this.desktipSet = new System.Windows.Forms.Button();
            this.gaintSQL = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.role = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.Button();
            this.part = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button7 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataClean = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.styleClean = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataSet1 = new egovtools.DataSet1();
            this.toolHelp = new System.Windows.Forms.HelpProvider();
            this.bsfmHelp = new System.Windows.Forms.HelpProvider();
            this.menu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Silver;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1125, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.手册ToolStripMenuItem,
            this.版本号ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 手册ToolStripMenuItem
            // 
            this.手册ToolStripMenuItem.Name = "手册ToolStripMenuItem";
            this.手册ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.手册ToolStripMenuItem.Text = "使用说明";
            // 
            // 版本号ToolStripMenuItem
            // 
            this.版本号ToolStripMenuItem.Name = "版本号ToolStripMenuItem";
            this.版本号ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.版本号ToolStripMenuItem.Text = "版本号";
            this.版本号ToolStripMenuItem.Click += new System.EventHandler(this.版本号ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(66, 24);
            this.tabControl1.Location = new System.Drawing.Point(0, 34);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1125, 472);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.btnGWSPY);
            this.tabPage1.Controls.Add(this.dataCleanSql);
            this.tabPage1.Controls.Add(this.desktipSet);
            this.tabPage1.Controls.Add(this.gaintSQL);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1117, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "sql生成器";
            // 
            // btnGWSPY
            // 
            this.btnGWSPY.Location = new System.Drawing.Point(749, 24);
            this.btnGWSPY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGWSPY.Name = "btnGWSPY";
            this.btnGWSPY.Size = new System.Drawing.Size(147, 51);
            this.btnGWSPY.TabIndex = 6;
            this.btnGWSPY.Text = "审批语块数设置";
            this.btnGWSPY.UseVisualStyleBackColor = true;
            this.btnGWSPY.Click += new System.EventHandler(this.btnGWSPY_Click);
            // 
            // dataCleanSql
            // 
            this.dataCleanSql.Location = new System.Drawing.Point(201, 26);
            this.dataCleanSql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataCleanSql.Name = "dataCleanSql";
            this.dataCleanSql.Size = new System.Drawing.Size(124, 44);
            this.dataCleanSql.TabIndex = 5;
            this.dataCleanSql.Text = "数据清理sql";
            this.dataCleanSql.UseVisualStyleBackColor = true;
            this.dataCleanSql.Click += new System.EventHandler(this.dataCleanSql_Click);
            // 
            // desktipSet
            // 
            this.desktipSet.Location = new System.Drawing.Point(569, 29);
            this.desktipSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.desktipSet.Name = "desktipSet";
            this.desktipSet.Size = new System.Drawing.Size(127, 41);
            this.desktipSet.TabIndex = 2;
            this.desktipSet.Text = "桌面设置sql";
            this.desktipSet.UseVisualStyleBackColor = true;
            this.desktipSet.Click += new System.EventHandler(this.desktipSet_Click);
            // 
            // gaintSQL
            // 
            this.gaintSQL.Location = new System.Drawing.Point(11, 24);
            this.gaintSQL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gaintSQL.Name = "gaintSQL";
            this.gaintSQL.Size = new System.Drawing.Size(127, 46);
            this.gaintSQL.TabIndex = 0;
            this.gaintSQL.Text = "功能赋权sql";
            this.gaintSQL.UseVisualStyleBackColor = true;
            this.gaintSQL.Click += new System.EventHandler(this.gaintSQL_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Silver;
            this.tabPage2.Controls.Add(this.role);
            this.tabPage2.Controls.Add(this.user);
            this.tabPage2.Controls.Add(this.part);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1117, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "机构角色";
            // 
            // role
            // 
            this.role.Location = new System.Drawing.Point(37, 142);
            this.role.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(120, 52);
            this.role.TabIndex = 2;
            this.role.Text = "角色管理";
            this.role.UseVisualStyleBackColor = true;
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(37, 84);
            this.user.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(120, 51);
            this.user.TabIndex = 1;
            this.user.Text = "人员管理";
            this.user.UseVisualStyleBackColor = true;
            // 
            // part
            // 
            this.part.Location = new System.Drawing.Point(37, 30);
            this.part.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.part.Name = "part";
            this.part.Size = new System.Drawing.Size(120, 46);
            this.part.TabIndex = 0;
            this.part.Text = "部门管理";
            this.part.UseVisualStyleBackColor = true;
            this.part.Click += new System.EventHandler(this.part_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Silver;
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.checkedListBox1);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(1117, 440);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "功能菜单";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(244, 216);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 29);
            this.button10.TabIndex = 6;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(895, 294);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 125);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Location = new System.Drawing.Point(239, 269);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 125);
            this.panel2.TabIndex = 4;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(5, 80);
            this.button13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(100, 29);
            this.button13.TabIndex = 2;
            this.button13.Text = "button13";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(5, 42);
            this.button12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(100, 29);
            this.button12.TabIndex = 1;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(5, 5);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(100, 29);
            this.button11.TabIndex = 0;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(239, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 162);
            this.panel1.TabIndex = 3;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(5, 80);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 29);
            this.button9.TabIndex = 2;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(5, 42);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 29);
            this.button4.TabIndex = 1;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 29);
            this.button3.TabIndex = 0;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 20);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(321, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(23, 20);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(159, 384);
            this.checkedListBox1.TabIndex = 1;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(944, 8);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(117, 49);
            this.button7.TabIndex = 0;
            this.button7.Text = "添加功能";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Silver;
            this.tabPage4.Controls.Add(this.dataClean);
            this.tabPage4.Controls.Add(this.button6);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Size = new System.Drawing.Size(1117, 440);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "流程配置";
            // 
            // dataClean
            // 
            this.dataClean.Location = new System.Drawing.Point(33, 115);
            this.dataClean.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataClean.Name = "dataClean";
            this.dataClean.Size = new System.Drawing.Size(124, 44);
            this.dataClean.TabIndex = 4;
            this.dataClean.Text = "数据清理sql";
            this.dataClean.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(33, 39);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 52);
            this.button6.TabIndex = 1;
            this.button6.Text = "清除数据配置";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Silver;
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.styleClean);
            this.tabPage5.Location = new System.Drawing.Point(4, 28);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Size = new System.Drawing.Size(1117, 440);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "表单工具";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 119);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "表单版本升级";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // styleClean
            // 
            this.styleClean.Location = new System.Drawing.Point(37, 28);
            this.styleClean.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.styleClean.Name = "styleClean";
            this.styleClean.Size = new System.Drawing.Size(128, 38);
            this.styleClean.TabIndex = 0;
            this.styleClean.Text = "excel样式清除";
            this.styleClean.UseVisualStyleBackColor = true;
            this.styleClean.Click += new System.EventHandler(this.styleClean_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Silver;
            this.tabPage6.Controls.Add(this.button8);
            this.tabPage6.Controls.Add(this.button5);
            this.tabPage6.Location = new System.Drawing.Point(4, 28);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1117, 440);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "帮助手册";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(43, 118);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(137, 39);
            this.button8.TabIndex = 4;
            this.button8.Text = "数据库表列表";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(43, 36);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(137, 44);
            this.button5.TabIndex = 3;
            this.button5.Text = "表单使用说明书";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1125, 509);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(300, 300);
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "egov工具箱";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 手册ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本号ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button desktipSet;
        private System.Windows.Forms.Button gaintSQL;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button styleClean;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.HelpProvider toolHelp;
        private System.Windows.Forms.HelpProvider bsfmHelp;
        private DataSet1 dataSet1;
        private System.Windows.Forms.Button role;
        private System.Windows.Forms.Button user;
        private System.Windows.Forms.Button part;
        private System.Windows.Forms.Button dataClean;
        private System.Windows.Forms.Button dataCleanSql;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnGWSPY;
    }
}

