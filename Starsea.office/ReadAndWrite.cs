using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarSea.office;
using System.Collections;

namespace Starsea.office
{
    public class ReadAndWrite
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateFilePath">excel 模板位置</param>
        /// <param name="dataFilePath">txt 数据模板位置 utf-8字符的</param>
        /// <param name="objectExcelFileName">文件存放位置</param>
        /// <param name="prams">传递到txt里的变量参数</param>
          public  ReadAndWrite(string templateFilePath, string dataFilePath, string saveFileName, string [,] prams){
          
           //读取数据模板填充数据
            ExcelTools et=new ExcelTools();
            et.GetWorkbookPart(templateFilePath, saveFileName);
            ReadDataTemplate rt = new ReadDataTemplate();
            ArrayList alist = rt.getTemplate(dataFilePath);
            WriteData wd = new WriteData(et, alist, prams);
            et.close();
       }
       
    }
}
