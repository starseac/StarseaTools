using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Starsea.Database.Access;
using System.IO;
using System.Xml;
using System.Collections;



namespace Starsea.Egov.Tools
{
    public partial class DB_CHECK_MDB : Form
    {
        public DB_CHECK_MDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取Connection
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            Connection accessConn = new Connection();
            OleDbConnection conn = accessConn.GetConnection(strConnection, @"F:\new_BSIEGOV\Solution1\Starse.Egov.Tools\bin\Debug\TempFile\CKBG_BSIBJXOUTPUT.mdb");
            //获取数据库结构
            DataTable table = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            DataTable Droptable = table.Clone();
            //表类型//
            foreach (System.Data.DataRow drow in table.Rows)
            {
                if (drow["TABLE_type"].ToString().ToUpper() == "TABLE")
                {
                    Droptable.ImportRow(drow);
                }
            }
            conn.Dispose();

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            Connection accessConn = new Connection();
            //获取Connection
            OleDbConnection conn = accessConn.GetConnection(strConnection, @"F:\new_BSIEGOV\Solution1\Starse.Egov.Tools\bin\Debug\TempFile\CKBG_BSIBJXOUTPUT.mdb");

            //获取数据库结构
            DataTable table = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new Object[] { null, null, "表1", null });

            conn.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            Connection accessConn = new Connection();
            //获取Connection
            string sql = "";
            bool tempvalue = false;
            try
            {
                OleDbConnection conn = accessConn.GetConnection(strConnection, @"F:\new_BSIEGOV\Solution1\Starse.Egov.Tools\bin\Debug\TempFile\CKBG_BSIBJXOUTPUT.mdb");

                sql = "alter table 表1 add hehe char(20)";
                OleDbCommand myCommand = new OleDbCommand(sql, conn);
                myCommand.ExecuteNonQuery();
                conn.Close();
                tempvalue = true;
                //return(tempvalue);
            }
            catch (Exception eg)
            {
                throw (new Exception("数据库更新出错:" + sql + "\r" + eg.Message));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            Connection accessConn = new Connection();
            //获取Connection
            string sql = "";
            bool tempvalue = false;
            try
            {
                OleDbConnection conn = accessConn.GetConnection(strConnection, @"F:\new_BSIEGOV\Solution1\Starse.Egov.Tools\bin\Debug\TempFile\CKBG_BSIBJXOUTPUT.mdb");

                sql = "create table 表2 (col1 Text,hehe Binary )";
                OleDbCommand myCommand = new OleDbCommand(sql, conn);
                myCommand.ExecuteNonQuery();
                conn.Close();
                tempvalue = true;
                //return(tempvalue);
            }
            catch (Exception eg)
            {
                throw (new Exception("数据库更新出错:" + sql + "\r" + eg.Message));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ScannMdb scann = new ScannMdb();
            scann.getMdbList(@"F:\new_BSIEGOV\Solution1\Starse.Egov.Tools\bin\Debug\TempFile\");
        }

        private void btn_chooseDir_Click(object sender, EventArgs e)
        {
            //选择文件框 对象
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.SelectedPath= @"F:\new_BSIEGOV\Solution1\Starse.Egov.Tools\bin\Debug\TempFile\";
            //打开时指定默认路径
            ofd.Description = "请选择文件路径"; 
            //如果用户点击确定
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //将用户选择的文件路径 显示 在文本框中
                this.txt_dir.Text = ofd.SelectedPath;
              

            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            

            if (this.txt_dir.Text =="")
            {
                MessageBox.Show("请选择mdb所在文件夹!");
            }
            List<string> outputType = new List<string>();
           

            //验证有问题，停止导出xml
            List<string> array = new List<string>();
            console console = new console();
            //sjsjjh.check check = new sjsjjh.check();
            //if (!check.checkSQL(exportType, array))
            //{
            //    this.consoleBox.Text += console.getMessage(array);
            //    this.consoleBox.Text += "数据库三级交换配置有问题，停止导出" + "\r\n";
            //    return;
            //}

            string filename = "sjsjjh_mdb_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".xml";
            string url = AppDomain.CurrentDomain.BaseDirectory + @"TempFile/" + filename + "";

            XmlTextWriter xw = new XmlTextWriter(url, Encoding.UTF8);

            sjsjjh.export export = new sjsjjh.export();
            
            export.exportMDBXML(xw, this.txt_dir.Text, array);

           
           // this.consoleBox.Text += console.getMessage(array);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "xml配置文件(*.xml)|*.xml";
            saveFile.Title = "导出附件树配置文件";
            saveFile.FileName = filename;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //将用户选择的文件路径 显示 在文本框中
                // MessageBox.Show(saveFile.FileName);
                File.Copy(url, saveFile.FileName);
            }
        }

        private void btn_chooseXml_Click(object sender, EventArgs e)
        {
            //选择文件框 对象
            OpenFileDialog ofd = new OpenFileDialog();
            //打开时指定默认路径
            ofd.InitialDirectory = @"C:\";
            //如果用户点击确定
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //将用户选择的文件路径 显示 在文本框中
                this.txt_fileURL.Text = ofd.FileName;
                string[] pam = this.txt_fileURL.Text.Split('.');
                if ((pam[1] == "xml") || (pam[1] == "XML"))
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\imp.xml");
                    // File.Copy(ofd.FileName, AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\imp.xml");

                }
                else
                {
                    MessageBox.Show("文件必须是xml文件");

                }

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.txt_fileURL.Text == "")
            {
                MessageBox.Show("请选择检查配置文件!");
                return;
            }
            string filename = "imp.xml";
            string fileurl = AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\" + filename;
            File.Copy(this.txt_fileURL.Text, fileurl);
            DataSet ds = new DataSet();
            ds.ReadXml(fileurl);
            sjsjjh.check check = new sjsjjh.check();
            List<string> array = new List<string>();
            check.readMDBXMLAndCheck(ds,this.txt_dir.Text, array);
            console console = new console();
            this.consoleBox.Text += console.getMessage(array);
            File.Delete(fileurl);
        }


    }
}
