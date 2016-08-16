using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Starsea.PDF_HB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] pdflist = new string[2];
            pdflist[0] = "temp1.pdf";
            pdflist[1] = "temp2.pdf";
            mergePDFFiles(pdflist, "newpdf1.pdf"); 

        }


        /// <summary> 合併PDF檔(集合) </summary> 
        /// <param name="fileList">欲合併PDF檔之集合(一筆以上)</param>
        /// <param name="outMergeFile">合併後的檔名</param> 
        private void mergePDFFiles(string[] fileList, string outMergeFile)
        {
            // outMergeFile = Server.MapPath(outMergeFile);

            string url = AppDomain.CurrentDomain.BaseDirectory + @"TEMP\";
            outMergeFile = url + outMergeFile;
            PdfReader reader;
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            PdfImportedPage newPage;
            for (int i = 0; i < fileList.Length; i++)
            {
                reader = new PdfReader(url + fileList[i]);
                int iPageNum = reader.NumberOfPages;
                for (int j = 1; j <= iPageNum; j++)
                {
                    document.NewPage();
                    newPage = writer.GetImportedPage(reader, j);
                    cb.AddTemplate(newPage, 0, 0);
                }
            }
            document.Close();
        }

    }
}
