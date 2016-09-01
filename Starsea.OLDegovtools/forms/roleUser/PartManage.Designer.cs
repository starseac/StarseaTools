namespace egovtools.forms.roleUser
{
    partial class PartManage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartManage));
            this.tBASEDEPARTMENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.t_BASE_DEPARTMENT = new egovtools.T_BASE_DEPARTMENT();
            this.t_BASE_DEPARTMENTTableAdapter = new egovtools.T_BASE_DEPARTMENTTableAdapters.T_BASE_DEPARTMENTTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dep_index = new System.Windows.Forms.Label();
            this.dep_id = new System.Windows.Forms.TextBox();
            this.dep_name = new System.Windows.Forms.TextBox();
            this.dep_preid = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.tBASEDEPARTMENTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_BASE_DEPARTMENT)).BeginInit();
            this.SuspendLayout();
            // 
            // tBASEDEPARTMENTBindingSource
            // 
            this.tBASEDEPARTMENTBindingSource.DataMember = "T_BASE_DEPARTMENT";
            this.tBASEDEPARTMENTBindingSource.DataSource = this.t_BASE_DEPARTMENT;
            // 
            // t_BASE_DEPARTMENT
            // 
            this.t_BASE_DEPARTMENT.DataSetName = "T_BASE_DEPARTMENT";
            this.t_BASE_DEPARTMENT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // t_BASE_DEPARTMENTTableAdapter
            // 
            this.t_BASE_DEPARTMENTTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "向上移";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 39);
            this.button2.TabIndex = 2;
            this.button2.Text = "向下移";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "部门id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "部门名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "父节点";
            // 
            // dep_index
            // 
            this.dep_index.AutoSize = true;
            this.dep_index.Location = new System.Drawing.Point(384, 151);
            this.dep_index.Name = "dep_index";
            this.dep_index.Size = new System.Drawing.Size(53, 12);
            this.dep_index.TabIndex = 6;
            this.dep_index.Text = "节点序号";
            // 
            // dep_id
            // 
            this.dep_id.Location = new System.Drawing.Point(454, 28);
            this.dep_id.Name = "dep_id";
            this.dep_id.Size = new System.Drawing.Size(130, 21);
            this.dep_id.TabIndex = 9;
            // 
            // dep_name
            // 
            this.dep_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tBASEDEPARTMENTBindingSource, "DEPTNAME", true));
            this.dep_name.Location = new System.Drawing.Point(454, 69);
            this.dep_name.Name = "dep_name";
            this.dep_name.Size = new System.Drawing.Size(130, 21);
            this.dep_name.TabIndex = 10;
            // 
            // dep_preid
            // 
            this.dep_preid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tBASEDEPARTMENTBindingSource, "PREDEPTID", true));
            this.dep_preid.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.tBASEDEPARTMENTBindingSource, "DEPTNAME", true));
            this.dep_preid.Location = new System.Drawing.Point(454, 110);
            this.dep_preid.Name = "dep_preid";
            this.dep_preid.Size = new System.Drawing.Size(130, 21);
            this.dep_preid.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tBASEDEPARTMENTBindingSource, "DEPTINDEX", true));
            this.textBox4.Location = new System.Drawing.Point(454, 151);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(130, 21);
            this.textBox4.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(386, 213);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "修改";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.AllowDrop = true;
            this.checkedListBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tBASEDEPARTMENTBindingSource, "DEPTNAME", true));
            this.checkedListBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.tBASEDEPARTMENTBindingSource, "DEPTID", true));
            this.checkedListBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.tBASEDEPARTMENTBindingSource, "DEPTINDEX", true));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(142, 324);
            this.checkedListBox1.TabIndex = 14;
            // 
            // PartManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 383);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.dep_preid);
            this.Controls.Add(this.dep_name);
            this.Controls.Add(this.dep_id);
            this.Controls.Add(this.dep_index);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PartManage";
            this.Text = "部门管理";
            this.Load += new System.EventHandler(this.PartManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tBASEDEPARTMENTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_BASE_DEPARTMENT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private T_BASE_DEPARTMENT t_BASE_DEPARTMENT;
        private System.Windows.Forms.BindingSource tBASEDEPARTMENTBindingSource;
        private egovtools.T_BASE_DEPARTMENTTableAdapters.T_BASE_DEPARTMENTTableAdapter t_BASE_DEPARTMENTTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dep_index;
        private System.Windows.Forms.TextBox dep_id;
        private System.Windows.Forms.TextBox dep_name;
        private System.Windows.Forms.TextBox dep_preid;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}