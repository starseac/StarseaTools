using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Aspose.Words;
using Aspose.Words.Saving;
using System.IO;


namespace WordToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //读取doc文档
            //要是物理路径
           
            Aspose.Words.Document doc = new Aspose.Words.Document(@"F:\new_BSIEGOV\WordToPDF\WordToPDF\temp.doc");
            DocumentBuilder builder = new DocumentBuilder(doc);
            //设置页边距
            builder.PageSetup.RightMargin = 1;
            //保存为PDF文件，此处的SaveFormat支持很多种格式，如图片，epub,rtf 等等
            doc.Save(@"F:\new_BSIEGOV\WordToPDF\WordToPDF\temp.pdf", SaveFormat.Pdf);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string spath = @"F:\new_BSIEGOV\WordToPDF\WordToPDF\test.doc";
            string tpath = @"F:\new_BSIEGOV\WordToPDF\WordToPDF\temp_com.pdf";
            ConvertToPDF(spath,tpath);
        }


        public bool ConvertToPDF(object sourcePath, object targetPath)
        {
            bool result = false;
            Object missing = System.Reflection.Missing.Value;
            //创建一个名为WordApp的组件对象   
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = null;
            try
            {
                //创建一个名为WordDoc的文档对象并打开  
                doc = wordApp.Documents.Open(ref sourcePath, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                //设置保存的格式   
                object filefarmat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                //保存为PDF   
                doc.SaveAs(ref targetPath, ref filefarmat, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
               string _ErrMess = "\r\nError:" + ex.Message +
                           "\r\nSource:" + ex.Source +
                           "\r\nStackTrace:" + ex.StackTrace;
            }
            finally
            {
                //关闭文档对象 
                if (doc != null)
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    doc = null;
                }
                //推出组建   
                if (wordApp != null)
                {
                    wordApp.Quit(ref missing, ref missing, ref missing);
                    wordApp = null;
                }
            }
            return result;
        }  

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
