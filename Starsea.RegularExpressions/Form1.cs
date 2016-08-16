using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starsea.RegularExpressions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            //^[-]?[1-9]{1}\d*$|^[0]{1}$
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(this.txt_reg.Text);
            bool ismatch = reg1.IsMatch(this.txt_value.Text);
            if (!ismatch)
                MessageBox.Show("您输入的值不符合正则表达式规则！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("验证通过！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
