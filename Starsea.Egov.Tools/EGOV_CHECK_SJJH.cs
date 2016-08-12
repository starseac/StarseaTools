using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Starsea.Egov.Tools
{
    public partial class EGOV_CHECK_SJJH : Form
    {
        public EGOV_CHECK_SJJH()
        {
            InitializeComponent();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            List<string> exportType = new List<string>();
            for (int i = 0; i < this.cb_exportType.SelectedItems.Count; i++)
            {
                exportType.Add(this.cb_exportType.SelectedItems[i].ToString());
            }

            if (exportType.Count == 0)
            {
                MessageBox.Show("请选择导出业务类型!");
            }
            List<string> outputType = new List<string>();
            for (int i = 0; i < this.cb_outputType.SelectedItems.Count; i++)
            {
                outputType.Add(this.cb_outputType.SelectedItems[i].ToString());
            }
            
            if (outputType.Count == 0)
            {
                MessageBox.Show("请选择导出类型!");
            }

            //验证有问题，停止导出xml
            List<string> array = new List<string>();
            console console = new console();
            sjsjjh.check check = new sjsjjh.check();
            if (!check.checkSQL(exportType, array))
            {
                this.consoleBox.Text += console.getMessage(array);
                this.consoleBox.Text += "数据库三级交换配置有问题，停止导出" + "\r\n";
                return;
            }

            string filename = "sjsjjh_sql_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".xml";
            string url = AppDomain.CurrentDomain.BaseDirectory + @"TempFile/" + filename + "";

            XmlTextWriter xw = new XmlTextWriter(url, Encoding.UTF8);

            sjsjjh.export export = new sjsjjh.export();

            ArrayList list = new ArrayList();
            export.exportXML(xw, exportType, outputType, array);

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

        private void btn_backup_Click(object sender, EventArgs e)
        {
            string templateFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Report\sbsql.xls";
            //数据模板路径
            string dataFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Report\sbsql.txt";
            string ExcelFileName = "sjsjjh_sql_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".xls";
            //文件地址
            string FilePathName = AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\";
            //生成的Excel文件名
            string objectExcelFileName = Path.Combine(FilePathName, ExcelFileName);
            //设置参数
            string[,] prams = new string[1, 2];
            prams[0, 0] = "nian";
            prams[0, 1] = "2014";
            office.npoi.ReadAndWrite rw = new office.npoi.ReadAndWrite(templateFilePath, dataFilePath, objectExcelFileName, prams);
            string URL = ExcelFileName;

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XLS备份文件(*.xls)|*.xls";
            saveFile.Title = "导出三级交换配置文件";
            saveFile.FileName = ExcelFileName;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //将用户选择的文件路径 显示 在文本框中
                // MessageBox.Show(saveFile.FileName);
                File.Copy(objectExcelFileName, saveFile.FileName);
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
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
                MessageBox.Show("请选择检查配置文件!");
                return;
            }
            string filename = "imp.xml";
            string fileurl = AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\" + filename;
            File.Copy(this.txtURL.Text, fileurl);
            DataSet ds = new DataSet();
            ds.ReadXml(fileurl);
            sjsjjh.update update = new sjsjjh.update();
            List<string> array = new List<string>();
            update.readAndCheck(ds, array);

            console console = new console();
            this.consoleBox.Text += console.getMessage(array);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (this.txtURL.Text == "")
            {
                MessageBox.Show("请选择更新配置文件!");
                return;
            }
            string filename = "imp.xml";
            string fileurl = AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\" + filename;
            File.Copy(this.txtURL.Text, fileurl);
            DataSet ds = new DataSet();
            ds.ReadXml(fileurl);
            sjsjjh.update update = new sjsjjh.update();
            List<string> array = new List<string>();
            update.readXMLandUpdate(ds, array);

            console console = new console();
            this.consoleBox.Text += console.getMessage(array);
        }
    }
}
