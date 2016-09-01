using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using egovtools.forms;
using egovtools.forms.sqlCreate;
using egovtools.forms.bsfmtools;
using egovtools.forms.roleUser;

namespace egovtools
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void gaintSQL_Click(object sender, EventArgs e)
        {
           
           Grant g = new Grant();
            g.Visible = true;
        }

        private void 版本号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版本时间:2010-11-5 12:00");
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dataSet1.T_BASE_USER”中。您可以根据需要移动或移除它。
          //  this.t_BASE_USERTableAdapter.Fill(this.dataSet1.T_BASE_USER);

        }

        private void styleClean_Click(object sender, EventArgs e)
        {
            egovtools.forms.bsfmtools.ExcelSytleEmpty ese = new ExcelSytleEmpty();           
            ese.Visible = true;
        }

        private void part_Click(object sender, EventArgs e)
        {
            PartManage pm = new PartManage();
            pm.Visible = true;
        }

        private void dataClean_Click(object sender, EventArgs e)
        {
            workflowDataClean wfClean = new workflowDataClean();
            wfClean.Visible = true;
        }

        private void desktipSet_Click(object sender, EventArgs e)
        {
            SetDesktop sd = new SetDesktop();
            sd.Visible = true;
        }

        private void dataCleanSql_Click(object sender, EventArgs e)
        {
            workflowDataClean clean = new workflowDataClean();
            clean.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddFunction af = new AddFunction();
            af.Visible = true;
        }

        private void tBASEUSERBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnGWSPY_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

      
      
    }
}
