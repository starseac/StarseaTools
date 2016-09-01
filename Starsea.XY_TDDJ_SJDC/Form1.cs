using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XY_TDDJ_SJDC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string templateFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Report\TDDJ.xls";
            //数据模板路径
            string dataFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Report\TDDJ.txt";
            string ExcelFileName = "TDDJ" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".xls";
            //文件地址
            string FilePathName = AppDomain.CurrentDomain.BaseDirectory + @"\TempFile\";
            //生成的Excel文件名
            string objectExcelFileName = Path.Combine(FilePathName, ExcelFileName);
            //设置参数
            string[,] prams = new string[1, 2];
            prams[0, 0] = "nian";
            prams[0, 1] = "2014";
            Starsea.office.npoi.ReadAndWrite rw = new Starsea.office.npoi.ReadAndWrite(templateFilePath, dataFilePath, objectExcelFileName, prams);
          
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "数据文件(*.xls)|*.xls";
            saveFile.Title = "登记数据导出";
            saveFile.FileName = ExcelFileName;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //将用户选择的文件路径 显示 在文本框中
                // MessageBox.Show(saveFile.FileName);
                File.Copy(objectExcelFileName, saveFile.FileName);
            }
        }
    }
}
