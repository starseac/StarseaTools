using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starsea.Egov.Tools
{
    public partial class DB_CHECK_ORACLE : Form
    {
        public DB_CHECK_ORACLE()
        {
            InitializeComponent();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            DB_CHECK_OBJECT_EXPORT dbexp = new DB_CHECK_OBJECT_EXPORT();
            dbexp.Show();
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            //选择文件框 对象
            OpenFileDialog ofd = new OpenFileDialog();
            //打开时指定默认路径
            ofd.InitialDirectory = @"C:\";
            //如果用户点击确定
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //将用户选择的文件路径 显示 在文本框中
                this.txtURL.Text = ofd.FileName;
                string[] pam = this.txtURL.Text.Split('.');
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

        private void btn_check_Click(object sender, EventArgs e)
        {
            if (this.txtURL.Text == "")
            {
                MessageBox.Show("请指定配置文件!");
            }

            string filename = "imp.xml";
            string fileurl = AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\" + filename;
            File.Copy(this.txtURL.Text, fileurl);
            DataSet ds = new DataSet();
            ds.ReadXml(fileurl);
            db.check check = new db.check();
            List<string> array = new List<string>();
            string username = System.Configuration.ConfigurationSettings.AppSettings["username"].ToString();
            check.checkDbinfoXML(username, ds, array);

            console console = new console();
            this.consoleBox.Text += console.getMessage(array);

        }

        private void btnLogExp_Click(object sender, EventArgs e)
        {
            string filename = "oracle_check" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "log.txt";
            string url = AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\" + filename;
            FileStream MyFileStream1 = new FileStream(url , FileMode.Create);
            StreamWriter sw = new StreamWriter(MyFileStream1, Encoding.UTF8);
            sw.Write(this.consoleBox.Text);
            sw.Flush();
            sw.Close();

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt日志文件(*.txt)|*.txt";
            saveFile.Title = "导出附件树配置文件";
            saveFile.FileName = filename;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //将用户选择的文件路径 显示 在文本框中
                // MessageBox.Show(saveFile.FileName);
                File.Copy(url, saveFile.FileName);
            }
        }
    }
}
