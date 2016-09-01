using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace egovtools.forms.sqlCreate
{
    public partial class SetDesktop : Form
    {
        public SetDesktop()
        {
            InitializeComponent();
        }

        private void allUser_CheckedChanged(object sender, EventArgs e)
        {
            if (allUser.Checked == true)
            {
                userFrom.Enabled = false;
                userTo.Enabled = false;

            }
            else
            {
                //allUser.Checked = false;
                userFrom.Enabled = true;
                userTo.Enabled = true;

            }

        }

        private string setDesktop(int userid,int ascxid, int visible,int align,int tabindex,int createby ,String createtime) { 
           string AA="update t_lst_userhomepage set userid='"+userid+"',ascxid='"+ascxid+"',visible='"+visible+"',align='"+align+"',tabindex='"+visible+"',createby='"+createby+"',createtime=to_date('"+createtime+"','yyyy-mm-dd'))";
           return AA;
        }
    }
}
