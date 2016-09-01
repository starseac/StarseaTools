using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarSea.ExcelTools
{
   public class WorkSheetTools
    {

        public Microsoft.Office.Interop.Excel._Worksheet getWorkSheet(Microsoft.Office.Interop.Excel._Workbook workbook, string sheetIndex, String sheetName,String newSheetName)
        {
            Microsoft.Office.Interop.Excel._Worksheet worksheet =null;
            //如果表单名称为空,新加一个表单
            if (sheetIndex == "" && sheetName == "")
            {
                int index = workbook.Worksheets.Count;
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(Type.Missing,workbook.Worksheets.get_Item(index), Type.Missing, Type.Missing);  
               
            }
            else if (sheetIndex != "")
            {
                int index = Convert.ToInt32(sheetIndex);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(index);
            }
            //else if(sheetName!="") {
            //    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(sheetName);
            //}
            if(newSheetName!=""){
                worksheet.Name = newSheetName;            
            }
            return worksheet;        
        }


        //public Microsoft.Office.Interop.Excel._Worksheet getWorkSheet(Microsoft.Office.Interop.Excel.Sheets sheets, string sheetIndex, String sheetName, String newSheetName)
        //{
        //    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
        //    //如果表单名称为空,新加一个表单
        //    if (sheetIndex == "" && sheetName == "")
        //    {
        //        int num = sheets.Count;
        //        worksheet = (Microsoft.Office.Interop.Excel._Worksheet)sheets.get_Item(num + 1);
        //    }
        //    else if (sheetIndex != "")
        //    {
        //        // worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(Convert.ToInt32(sheetIndex));

        //        worksheet = (Microsoft.Office.Interop.Excel._Worksheet)sheets.get_Item(1);
        //    }
        //    else if (sheetName != "")
        //    {
        //        worksheet = (Microsoft.Office.Interop.Excel._Worksheet)sheets[sheetName];
        //    }

        //    if (newSheetName != "")
        //    {
        //        worksheet.Name = newSheetName;
        //    }
        //    return worksheet;
        //}


        public Microsoft.Office.Interop.Excel.Range getRange(Microsoft.Office.Interop.Excel._Worksheet worksheet,int rowNum,int colNum) {

            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowNum, colNum];
            return range;
        
        }

        //设置边框  和 颜色
        public void setRangeBorderColor(Microsoft.Office.Interop.Excel.Range range, System.Drawing.Color color)
        {
            range.Borders.Color = System.Drawing.ColorTranslator.ToOle(color);

            range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

        }

        //设置  水平对齐
        public void setHorizontalAlignment(Microsoft.Office.Interop.Excel.Range range)
        {
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//设置水平对齐方式
        }

        //设置 自动换行
        public void setWrapText(Microsoft.Office.Interop.Excel.Range range)
        {
            range.WrapText = true;  //自动换行
            range.EntireRow.AutoFit();//行高根据内容自动调整
        }

        //保存工作表
        public void save( Microsoft.Office.Interop.Excel._Worksheet worksheet,String exportPath,String error)
        {
            try
            {
                Object Nothing = Type.Missing;
                worksheet.SaveAs(exportPath, Nothing, Nothing, Nothing, Nothing, Nothing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Nothing, Nothing, Nothing);
            }
            catch //(Exception ex) 
            {
                error = "EXCEL文件已填充完毕,但在保存时发生错误";
            }        
        }
    }
}
