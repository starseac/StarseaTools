using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Starsea.Egov;
using System.Collections;

namespace Starsea.Egov.Tools
{
    public partial class EGOV_CHECK_FJS : Form
    {
        public EGOV_CHECK_FJS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string exportType = this.cb_exportType.SelectedItem.ToString();
            if(exportType==""){
                MessageBox.Show("请选择导出类型!");
            }

            //验证有问题，停止导出xml
            List<string> array=new List<string>();
            console console=new console();
            fjs.check check = new fjs.check();
            if (!check.checkFJS( exportType,array))
            {
                this.consoleBox.Text+=console.getMessage(array);
                this.consoleBox.Text += "数据库树目录配置有问题，停止导出" + "\r\n";
                return;
            }

            string filename = "fjs_jsyd_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".xml";
            string url = AppDomain.CurrentDomain.BaseDirectory + @"TempFile/" + filename + "";

            XmlTextWriter xw = new XmlTextWriter(url, Encoding.UTF8);

            fjs.export export = new fjs.export();

            ArrayList list = new ArrayList();
            export.exportFJSXML(exportType,xw,array);
           
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

        private void button5_Click(object sender, EventArgs e)
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
                string [] pam=this.txtURL.Text.Split('.');
                if ((pam[1] == "xml") || (pam[1] == "XML"))
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\imp.xml");
                   // File.Copy(ofd.FileName, AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\imp.xml");
                    
                }
                else {
                    MessageBox.Show("文件必须是xml文件");

                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string templateFilePath =AppDomain.CurrentDomain.BaseDirectory +@"\Report\fjs.xls";
            //数据模板路径
            string dataFilePath = AppDomain.CurrentDomain.BaseDirectory +@"\Report\fjs.txt";
            string ExcelFileName = "fjs" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".xls";
            //文件地址
            string FilePathName =AppDomain.CurrentDomain.BaseDirectory +@"\TempFile\";
            //生成的Excel文件名
            string objectExcelFileName = Path.Combine(FilePathName, ExcelFileName);
            //设置参数
            string[,] prams = new string[1, 2];
            prams[0, 0] = "nian";
            prams[0, 1] = "2014";
            office.npoi.ReadAndWrite rw = new office.npoi.ReadAndWrite(templateFilePath, dataFilePath, objectExcelFileName, prams);
            string URL = ExcelFileName;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.txtURL.Text=="")
            {
                MessageBox.Show("请选择更新配置文件!");
                return;
            }
            string filename = "imp.xml";
            string fileurl=AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\"+filename;
            File.Copy(this.txtURL.Text,fileurl);
            DataSet ds = new DataSet();
            ds.ReadXml(fileurl);
            fjs.update update = new fjs.update();
            List<string> array = new List<string>();
            update.readAndUpdate(ds,array);

            console console=new console();
            this.consoleBox.Text += console.getMessage(array);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filename = "update" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "log.txt";
            string url =AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\" + filename;
            FileStream MyFileStream1 = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @" + url + ", FileMode.Create);
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
            fjs.check check = new fjs.check();
            List<string> array = new List<string>();
            check.checkFJSbyXML(ds, array);

            console console = new console();
            this.consoleBox.Text += console.getMessage(array);

           
        }

        
    }
}
