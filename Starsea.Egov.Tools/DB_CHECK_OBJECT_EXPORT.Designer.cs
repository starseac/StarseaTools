namespace Starsea.Egov.Tools
{
    partial class DB_CHECK_OBJECT_EXPORT
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
            this.btnExportTable = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnExportView = new System.Windows.Forms.Button();
            this.btnExportFunction = new System.Windows.Forms.Button();
            this.btnExportChoose = new System.Windows.Forms.Button();
            this.btnExportProcedure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExportTable
            // 
            this.btnExportTable.Location = new System.Drawing.Point(370, 24);
            this.btnExportTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportTable.Name = "btnExportTable";
            this.btnExportTable.Size = new System.Drawing.Size(123, 49);
            this.btnExportTable.TabIndex = 4;
            this.btnExportTable.Text = "导出选中项";
            this.btnExportTable.UseVisualStyleBackColor = true;
            this.btnExportTable.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 24);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(318, 540);
            this.treeView1.TabIndex = 5;
            this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
            // 
            // btnExportView
            // 
            this.btnExportView.Location = new System.Drawing.Point(370, 80);
            this.btnExportView.Name = "btnExportView";
            this.btnExportView.Size = new System.Drawing.Size(123, 43);
            this.btnExportView.TabIndex = 7;
            this.btnExportView.Text = "导出所有视图";
            this.btnExportView.UseVisualStyleBackColor = true;
            this.btnExportView.Visible = false;
            this.btnExportView.Click += new System.EventHandler(this.btnExportView_Click);
            // 
            // btnExportFunction
            // 
            this.btnExportFunction.Location = new System.Drawing.Point(370, 129);
            this.btnExportFunction.Name = "btnExportFunction";
            this.btnExportFunction.Size = new System.Drawing.Size(123, 48);
            this.btnExportFunction.TabIndex = 8;
            this.btnExportFunction.Text = "导出function";
            this.btnExportFunction.UseVisualStyleBackColor = true;
            this.btnExportFunction.Visible = false;
            // 
            // btnExportChoose
            // 
            this.btnExportChoose.Location = new System.Drawing.Point(370, 322);
            this.btnExportChoose.Name = "btnExportChoose";
            this.btnExportChoose.Size = new System.Drawing.Size(123, 45);
            this.btnExportChoose.TabIndex = 9;
            this.btnExportChoose.Text = "导出选中项";
            this.btnExportChoose.UseVisualStyleBackColor = true;
            this.btnExportChoose.Visible = false;
            this.btnExportChoose.Click += new System.EventHandler(this.btnExportChoose_Click);
            // 
            // btnExportProcedure
            // 
            this.btnExportProcedure.Location = new System.Drawing.Point(370, 183);
            this.btnExportProcedure.Name = "btnExportProcedure";
            this.btnExportProcedure.Size = new System.Drawing.Size(123, 49);
            this.btnExportProcedure.TabIndex = 10;
            this.btnExportProcedure.Text = "导出proceduce";
            this.btnExportProcedure.UseVisualStyleBackColor = true;
            this.btnExportProcedure.Visible = false;
            // 
            // DB_CHECK_OBJECT_EXPORT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 576);
            this.Controls.Add(this.btnExportProcedure);
            this.Controls.Add(this.btnExportChoose);
            this.Controls.Add(this.btnExportFunction);
            this.Controls.Add(this.btnExportView);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnExportTable);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DB_CHECK_OBJECT_EXPORT";
            this.Text = "数据库对象配置导出";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportTable;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnExportView;
        private System.Windows.Forms.Button btnExportFunction;
        private System.Windows.Forms.Button btnExportChoose;
        private System.Windows.Forms.Button btnExportProcedure;
    }
}