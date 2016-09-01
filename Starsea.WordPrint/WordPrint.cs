using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Handler;
using BSI.Utility.DB.Provider;

namespace WordPrint
{
    public class Print
    {
        private string [] getSQL(string sqlPath,string [,] parms){
        
           StreamReader reader = new StreamReader(sqlPath, Encoding.UTF8);
           string str = "";
           string sqlstr = "";

           while ((str = reader.ReadLine()) != null)
           {
               sqlstr += str.Trim() + " ";
           }
           reader.Close();
           string[] array = null;

           if (sqlstr.Split(';').Length > 0)
           {
               array = sqlstr.Split(';');              
           }
           for (int i = 0; i < array.Length;i++ )
           {
               array[i] = replaceSqlParams(array[i], parms);

           }
           return array;

        
        }

        private String replaceSqlParams(string sql, string[,] parms)
        {
            string str = sql;
            for (int i = 0; i < parms.GetLength(0); i++)
            {
                str = str.Replace(":" + parms[i, 0], parms[i, 1]);
            }

            return str;
        }


        public void WorldPrint(string docPath,string [,] param,string pathname)
        {
            QueryBuilder qb = new QueryBuilder();
            List<DataTable> dBase = new List<DataTable>();

            DataTable dt = new DataTable();
            string sqlcmd = "";

            string[] sqls = getSQL(docPath.Replace(".doc", ".txt"), param);

            for (int i = 0; i < sqls.Length-1;i++ )
            {

                sqlcmd = @"" + sqls[i];
                qb = new QueryBuilder(sqlcmd);
                dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dBase.Add(dt);
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    dBase.Add(dt);
                }
            }
            if (dBase.Count > 0)
            {

                try
                {

                    File.Copy(docPath, pathname);
                    StreamWriter sw = File.CreateText(pathname.Replace(".doc", ".txt"));
                    foreach (DataTable dtTemp in dBase)
                    {
                        for (int i = 0; i < dtTemp.Columns.Count; i++)
                        {
                            //写配置文件
                            sw.WriteLine(dtTemp.Columns[i].ColumnName + "=" + dtTemp.Rows[0][i].ToString().Replace("\r\n", "$"));
                        }
                    }
                    sw.Close();
                }

                catch
                {

                   
                }
            }
            else
            {
               
            }
        }



    }
}
