using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BSI.Utility.DB.Provider;
using BSI.Utility.DB.Builder;

namespace Starsea.egovfjexport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable list = GetAccessoryList();
            if (list != null && list.Rows.Count > 0)
            {
                for (int i = 0; i < list.Rows.Count; i++)
                {

                    string fileid = list.Rows[i]["fileid"].ToString();
                    CreateFile(fileid);
                }

            }
            MessageBox.Show("导出完成!");

        }

        private DataTable GetAccessoryList()
        {
            string strsql = "select Caseid,fileid"
                          + " from t_pj_accessory where  caseid='" + this.txt_caseno.Text + "'";

            QueryBuilder quy = new QueryBuilder(strsql);

            return DatabaseEngine.Default.Db.GetSelectTable(quy);
        }


        private DataTable GetAccessory(string fileid)
        {
            string strsql = "select Caseid,fileid,filecontent,filetype,filename,reamrk,fileexact"
                          + " from t_pj_accessory where  caseid='" + this.txt_caseno.Text + "' and fileid='" + fileid + "' ";

            QueryBuilder quy = new QueryBuilder(strsql);

            return DatabaseEngine.Default.Db.GetSelectTable(quy);
        }

        private void CreateFile(string fileid)
        {
            DataTable dt = this.GetAccessory(fileid);

            if (dt != null && dt.Rows.Count > 0)
            {
                string fileName = this.txt_filepath.Text;
                fileName += "\\" + dt.Rows[0]["filename"].ToString();
                byte[] bytes = dt.Rows[0]["filecontent"] as byte[];
                FileStream fs = new FileStream(fileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(bytes);
                bw.Close();
                fs.Close();

            }
        }
    }
}
