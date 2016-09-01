using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace StarSea.ExcelTools
{
  public  class ReadAndWrite
    {

        public ReadAndWrite(string templatePath,string dataTemplatePath,string savePath,string [,] parmas) {
            StarSea.ExcelTools.ExcelApp app = new StarSea.ExcelTools.ExcelApp();
            StarSea.ExcelTools.WorkSheetTools workSheetTools = new StarSea.ExcelTools.WorkSheetTools();
            //读取数据模板填充数据
            StarSea.ExcelTools.ReadDataTemplate rt = new StarSea.ExcelTools.ReadDataTemplate();
            ArrayList alist = rt.getTemplate(dataTemplatePath);
            WriteData wd = new WriteData(app.getWorkBook(templatePath),alist, parmas);
            app.WorkBookSave(savePath);
            app.ExcelDispose();
        }
    }
}
