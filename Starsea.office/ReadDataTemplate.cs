using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace StarSea.office
{
   public class ReadDataTemplate
    {

       public ArrayList getTemplate(string fileName)
       {
           StreamReader reader = new StreamReader(fileName, Encoding.UTF8);
           string str = "";

           ArrayList list = new ArrayList();

           ArrayList sheets = new ArrayList();

           int sheetIndex = 0;

           ArrayList data = new ArrayList();

           int isSheet = 0;
           int isBlock = 0;
           int isSql = 0;
           int isWrite = 0;

           string tempSql = "";
           string tempWrite = "";

           ArrayList block = new ArrayList();
          
           while ((str = reader.ReadLine()) != null)
           {
               str = str.Trim();              

               // 开启sheet 读取属性
               if ((str.Length >= 1) && (str.IndexOf("[sheet]") == 0) && isSheet==0)
               {
                   isSheet = 1;
               }
               else if ((str.Length >= 1) && isSheet == 1)
               {
                   sheets.Add(str);
                   isSheet = 2;
               }
               //结束一个sheet
               if ((str.Length >= 1) && (str.IndexOf("[endsheet]") == 0) && isSheet == 2)
               {
                   sheetIndex += 1;
                   isSheet = 0;
               }

               //获取 写入类型  和sql   singleRow
               if ((str.Length >= 1) && (str.IndexOf("[singleRow]") == 0) &&isBlock==0 )
               {
                   block.Add(sheetIndex);
                   block.Add("singleRow");
                   isBlock = 1;
               }              
               else if ((str.Length >= 1) && isBlock == 1 && (str.IndexOf("[endsingleRow]") == 0))
               {
                   data.Add(block);
                   block = new ArrayList();
                   isBlock =0;               
               }

               // table
               if ((str.Length >= 1) && (str.IndexOf("[table]") == 0) && isBlock == 0)
               {
                   block.Add(sheetIndex);
                   block.Add("table");
                   isBlock = 1;
               }              
               else if ((str.Length >= 1) && isBlock == 1 && (str.IndexOf("[endtable]") == 0))
               {
                   data.Add(block);
                   block = new ArrayList();
                   isBlock = 0;
               }

               // 获取sql 和 写入
               if ((str.Length >= 1) && isBlock == 1)
               {              
             
                   if ((str.Length >= 1) && (str.IndexOf("[sql]") == 0) && isSql == 0)
                   {
                       isSql = 1;
                   }
                   else if ((str.Length >= 1) && isSql == 1 && (str.IndexOf("[endsql]") != 0))
                   {
                       tempSql += str+" ";
                   }
                   else if ((str.Length >= 1) && isSql == 1 && (str.IndexOf("[endsql]") == 0))
                   {
                       block.Add(tempSql);
                       tempSql = "";
                       isSql = 0;
                   }

                   if ((str.Length >= 1) && (str.IndexOf("[write]") == 0) && isWrite == 0)
                   {
                       isWrite = 1;
                   }
                   else if ((str.Length >= 1) && isWrite == 1 && (str.IndexOf("[endwrite]") != 0))
                   {
                       tempWrite += str;
                   }
                   else if ((str.Length >= 1) && isWrite == 1 && (str.IndexOf("[endwrite]") == 0))
                   {
                       block.Add(tempWrite);                     
                       tempWrite = "";
                       isWrite = 0;
                   }
               }

              
           }
           reader.Close();
           list.Add(sheets);
           list.Add(data);          
           return list;
       }

    }
}
