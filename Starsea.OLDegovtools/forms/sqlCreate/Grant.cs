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
    public partial class Grant : Form
    {
        public Grant()
        {
            InitializeComponent();
        }

        private void createSql_Click(object sender, EventArgs e)
        {
            string errStr = "";

            int funcFromId;
            int funcToId;
            int roleFromId;
            int roleToId;

            if (funcFrom.Text == "" || funcTo.Text == "")
            {
                errStr = errStr + "请填写好funcid" + "\r\n";
            }

                if (roleFrom.Text == "" || roleTo.Text == "")
                {
                    errStr = errStr + "请填写好roleid" + "\r\n";
                }

                if (createUserid.Text == "")
                {

                    errStr = errStr + "请填写好createuserid" + "\r\n";
                }
                if (funcFrom.Text != "" || funcTo.Text != "" || roleFrom.Text != "" || roleTo.Text != "")
                {

                    funcFromId = Convert.ToInt32(funcFrom.Text);
                    funcToId = Convert.ToInt32(funcTo.Text);
                    roleFromId = Convert.ToInt32(roleFrom.Text);
                    roleToId = Convert.ToInt32(roleTo.Text);

                    if (funcFromId > funcToId || roleFromId > roleToId)
                    {
                        errStr = errStr + "请按从小到大的顺序填写funcid和roleid" + "\r\n";

                    }
                }
                if (errStr == "")
                {
                    funcFromId = Convert.ToInt32(funcFrom.Text);
                    funcToId = Convert.ToInt32(funcTo.Text);
                    roleFromId = Convert.ToInt32(roleFrom.Text);
                    roleToId = Convert.ToInt32(roleTo.Text);


                    int userid = Convert.ToInt32(createUserid.Text);
                    String dateTime = createDate.Text.Replace("年", "-").Replace("月", "-").Replace("日", "").Replace("/", "-");
                    //Console.WriteLine(dateTime);

                    string sqlString = "";

                    for (int i = funcFromId; i <= funcToId; i++)
                    {
                        for (int j = roleFromId; j <= roleToId; j++)
                        {
                            sqlBox.Text += "insert into t_lst_purview values(" + i + "," + j + "," + userid + ",to_date('" + dateTime + "','yyyy-mm-dd'));" + "\r\n";
                        }

                    }
                    // message.Text = "请稍等！";
                    sqlString = sqlBox.Text;
                    // message.Text = "";
                }
                else
                {
                    MessageBox.Show(errStr);

                }

            
        }

        private void cleanSql_Click(object sender, EventArgs e)
        {
            sqlBox.Text = "";
        }

        private void sqlCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(sqlBox.Text, false);
            }
            catch (Exception exce)
            {
                MessageBox.Show("复制失败");
            }
            MessageBox.Show("已复制到粘贴板");
        }


    }
}
