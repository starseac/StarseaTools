﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;

namespace Starsea.office.npoi
{
    public class WriteData
    {
        public string errorString = "";


        private String replaceSqlParams(string sql, string[,] parms)
        {
            string str = sql;
            for (int i = 0; i < parms.GetLength(0); i++)
            {
                str = str.Replace(":" + parms[i, 0], parms[i, 1]);
            }

            return str;
        }


        private String[,] spliteWrite(string write)
        {
            string[,] str = null;

            //解析 坐标 格式 写入数据
            string[] rangeStr = write.Split(';');
            int rangeSize = rangeStr.Length - 1;
            str = new string[rangeSize, 2];
            for (int i = 0; i < rangeSize; i++)
            {
                str[i, 0] = rangeStr[i].Split(',')[0];
                str[i, 1] = rangeStr[i].Split(',')[1];
               
            }
            return str;
        }


        //向excel写一个单行数据
        public void writeSingeRow( ExcelTools et,string sheetId, string sql, string write, string[,] parms)
        {

            QueryBuilder qb = new QueryBuilder(replaceSqlParams(sql, parms));
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            string[,] ranges = spliteWrite(write);
            int row = ranges.GetLength(0); //行

            if(dt!=null&&dt.Rows.Count>0){
                //数据内容
                for (int i = 0; i < row; i++)
                {
                    et.AddCellByIndex(Convert.ToInt32(sheetId), et.getXYinNumber(ranges[i, 0])[0], et.getXYinNumber(ranges[i, 0])[1], dt.Rows[0][ranges[i, 1]].ToString());

                }
            }          


        }

        //写一个表格数据
        public void writeTable(ExcelTools et, string sheetId, string sql, string write, string[,] parms)
        {
           QueryBuilder qb = new QueryBuilder(replaceSqlParams(sql, parms).Trim());
            DataTable dt = null;
            try
            {
                 dt = DatabaseEngine.Default.Db.GetSelectTable(qb);

            }
            catch (Exception eg)
            {

            }
            if (dt != null && dt.Rows.Count> 0)
            {
                int datarow = dt.Rows.Count;

                string[,] ranges = spliteWrite(write);
                int row = ranges.GetLength(0); //行

                //数据内容
                for (int i = 0; i < datarow; i++)
                {

                    for (int j = 0; j < row; j++)
                    {
                        et.AddCellByIndex(Convert.ToInt32(sheetId), et.getXYinNumber(ranges[j, 0])[0], et.getXYinNumber(ranges[j, 0])[1] + i, dt.Rows[i][ranges[j, 1]].ToString());
                        et.setCellBorder(Convert.ToInt32(sheetId), et.getXYinNumber(ranges[j, 0])[0], et.getXYinNumber(ranges[j, 0])[1] + i);

                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templePath"></param>
        /// <param name="saveName"></param>
        /// <param name="list">解析数据模板后数组</param>
        /// <param name="parms">参数数组</param>
        public WriteData(ExcelTools et, ArrayList list, string[,] parms)
        {

            //解析 arraylist
          

            ArrayList allSheet = (ArrayList)list[0];
            int sheetIndex = allSheet.Count;

            ArrayList allBlock = (ArrayList)list[1];
            int blockIndex = allBlock.Count;

            for (int i = 0; i < sheetIndex; i++)
            {

                //获取表属性值
                string sheetPro = allSheet[i].ToString();
                string[] sheetProArray = sheetPro.Split(',');
              //  Microsoft.Office.Interop.Excel._Worksheet worksheet = workSheetTools.getWorkSheet(workbook, sheetProArray[0], sheetProArray[1], sheetProArray[2]);
               
                string sheetId=sheetProArray[0];
                
                //获取 sql  替换参数   写数据
                for (int j = 0; j < blockIndex; j++)
                {
                    ArrayList blockPro = (ArrayList)allBlock[j];
                    int sheetIndexStr = (int)blockPro[0];
                    string dataTypeStr = (string)blockPro[1];
                    string dataSqlStr = (string)blockPro[2];
                    string dataWriteStr = (string)blockPro[3];

                    if (sheetIndexStr == i)
                    {
                        if (dataTypeStr == "singleRow")
                        {
                            writeSingeRow(et, sheetId, dataSqlStr, dataWriteStr, parms);
                        }
                        else if (dataTypeStr == "table")
                        {
                            writeTable(et, sheetId, dataSqlStr, dataWriteStr, parms);
                        }
                    }

                }
            }
        }
    }
}
