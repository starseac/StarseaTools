using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace egovtools.forms.roleUser
{
    public partial class PartManage : Form
    {
        public PartManage()
        {
            InitializeComponent();
        }

        private void PartManage_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“t_BASE_DEPARTMENT._T_BASE_DEPARTMENT”中。您可以根据需要移动或移除它。
            this.t_BASE_DEPARTMENTTableAdapter.Fill(this.t_BASE_DEPARTMENT._T_BASE_DEPARTMENT);

        }

        private void depList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

      
    }
}
