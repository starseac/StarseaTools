using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Configuration;
namespace StarSea.ExcelTools
{
    public class ExcelApp
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        public String error = "";

        public Microsoft.Office.Interop.Excel.Application app = null; //EXCEL对象 
        Microsoft.Office.Interop.Excel.Workbooks workbooks; //工作簿集合 
        Microsoft.Office.Interop.Excel._Workbook workbook; //当前工作簿 
        Microsoft.Office.Interop.Excel.Sheets sheets; //SHEET页集合 

        public Microsoft.Office.Interop.Excel._Workbook getWorkBook(string tempEFilePath)
        {
            try
            {
                app = new Microsoft.Office.Interop.Excel.Application();
                if (app == null)
                {
                    error = "Excel进程启动出错,请确认是否引用EXCEL组件";
                }
                app.Visible = false;
                app.UserControl = true;
                app.DisplayAlerts = false;
                //加载读取模板 
                workbooks = app.Workbooks;
                if (tempEFilePath != "")
                {
                    workbook = workbooks.Add(tempEFilePath);
                }
                else
                {
                    workbook = workbooks.Add(true);
                }

            }
            catch (Exception ex)
            {
                error = ex.ToString();

            }


            return workbook;

        }

        public Microsoft.Office.Interop.Excel.Sheets getSheets(string tempEFilePath)
        {
            try
            {
                app = new Microsoft.Office.Interop.Excel.Application();
                if (app == null)
                {
                    error = "Excel进程启动出错,请确认是否引用EXCEL组件";
                }
                app.Visible = false;
                app.UserControl = true;
                app.DisplayAlerts = false;
                //加载读取模板 
                workbooks = app.Workbooks;
                if (tempEFilePath != "")
                {
                    workbook = workbooks.Add(tempEFilePath);
                }
                else
                {
                    workbook = workbooks.Add(true);
                }

                sheets = workbook.Worksheets;

            }
            catch (Exception ex)
            {
                error = ex.ToString();

            }


            return sheets;

        }

        public void WorkBookSave(string savaPath)
        {
            try
            {
                workbook.SaveAs(savaPath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch(Exception eg)
            {

            }
        }


        public void ExcelDispose()
        {
            try
            {
                if (app != null)
                {
                    app.Workbooks.Close();
                    app.Quit();

                    // 强行杀死打开的Excel进程 
                    IntPtr excelIPtr = new IntPtr(app.Hwnd); //得到这个句柄，具体作用是得到这块内存入口 
                    int proID = 0;
                    GetWindowThreadProcessId(excelIPtr, out proID); //得到本进程唯一标志k 
                    System.Diagnostics.Process pro = System.Diagnostics.Process.GetProcessById(proID); //得到对进程k的引用 pro.Kill(); 
                    //关闭进程k #endregion CurExcel = null; 
                }
            }
            catch //(Exception ex) 
            {
                //ShowMessage("在释放内存时发生错误：" + ex.ToString());
            }
        }
    }
}
