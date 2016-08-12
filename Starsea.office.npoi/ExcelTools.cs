using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Starsea.office.npoi;
using System.Collections;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
namespace Starsea.office.npoi
{
    public class ExcelTools
    {

        public string[] getXY(string cellid)
        {
            string[] str = new string[2];
            string x = cellid.Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "")
                  .Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "");
            string y = cellid.Replace(x, "");
            str[0] = x;
            str[1] = y;
            return str;
        }
        public int[] getXYinNumber(string cellid)
        {
            int[] num = new int[2];
            string[] str = getXY(cellid);
            num[1] = Convert.ToInt32(str[1]);
            string x = str[0].ToUpper();
            int len = x.Length;

            int[] xx = new int[len];
            for (int i = 0; i < len; i++)
            {
                byte[] array = new byte[1];   //定义一组数组array
                array = System.Text.Encoding.ASCII.GetBytes(x.Substring(i, 1)); //string转换的字母
                xx[i] = (short)(array[0]) - 64;

            }

            num[0] = 0;
            for (int i = 0; i < len; i++)
            {
                num[0] += (xx[len - 1 - i]) * Convert.ToInt32(Math.Pow(26, i));
            }

            return num;
        }



        //复制模板
        public string CopyFile(string source, string dest)
        {
            string result = "Copied file";
            try
            {
                // Overwrites existing files
                File.Copy(source, dest, true);

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        static HSSFWorkbook hssfworkbook;
        static FileStream file;
        static ICellStyle cellBorder;
        public void InitializeWorkbook()
        {
            hssfworkbook = new HSSFWorkbook();
            cellBorder = setBorder();
            //create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "starsea";
            hssfworkbook.DocumentSummaryInformation = dsi;

            //create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "excle";
            hssfworkbook.SummaryInformation = si;
        }

        public void CreateCopy(string templtePath, string savePath)
        {
            CopyFile(templtePath, savePath);
            file = new FileStream(savePath, FileMode.Open, FileAccess.ReadWrite);
            hssfworkbook = new HSSFWorkbook(file);

            cellBorder = setBorder();

        }

        //public void Close() {

        //    file.Close();
        //}

        public void WriteToFile(string saveName)
        {
            //Write the stream data of workbook to the root directory
            file = new FileStream(saveName, FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }


        public void AddCell(string sheetName, int x, int y, string value)
        {

            ISheet sheet1 = hssfworkbook.GetSheet(sheetName) ?? hssfworkbook.CreateSheet(sheetName);

            IRow row = sheet1.GetRow(y - 1) ?? sheet1.CreateRow(y - 1);
            ICell cell = row.GetCell(x - 1) ?? row.CreateCell(x - 1);
            cell.SetCellValue(value);
            //set the style
            ICellStyle style = hssfworkbook.CreateCellStyle();
            cell.CellStyle = style;
            //increase x

        }
        public void AddCellByIndex(int sheetIndex, int x, int y, string value)
        {
            ISheet sheet1 = hssfworkbook.GetSheetAt(sheetIndex - 1);
            IRow row = sheet1.GetRow(y - 1) ?? sheet1.CreateRow(y - 1);
            ICell cell = row.GetCell(x - 1) ?? row.CreateCell(x - 1);
            cell.SetCellValue(value);

        }


        public ICellStyle setBorder()
        {
            ICellStyle borderStyle = hssfworkbook.CreateCellStyle();
            borderStyle.BorderBottom = BorderStyle.Thin;
            borderStyle.BorderLeft = BorderStyle.Thin;
            borderStyle.BorderRight = BorderStyle.Thin;
            borderStyle.BorderTop = BorderStyle.Thin;
            return borderStyle;
        }



        public void setCellBorder(int sheetIndex, int x, int y)
        {
            ISheet sheet1 = hssfworkbook.GetSheetAt(sheetIndex - 1);
            IRow row = sheet1.GetRow(y - 1) ?? sheet1.CreateRow(y - 1);
            ICell cell = row.GetCell(x - 1) ?? row.CreateCell(x - 1);
            cell.CellStyle = cellBorder;

        }

    }
}
