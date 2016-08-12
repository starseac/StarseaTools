using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace Starsea.Egov.db
{
   public class dbdata
    {
         public DataTable getAllTable(string username)
        {

            string sqlcmd = @"select * from dba_tables WHERE OWNER='" + username.ToUpper() + "'  ORDER BY TABLE_NAME";


            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;

            }
            else
            {
                return null;
            }

        }


          public DataTable getColumsInfo(string username,string tablename)
         {
             string sqlcmd = @"select * from dba_tab_cols WHERE OWNER='" + username.ToUpper() + "' and table_name='" + tablename.ToUpper() + "' ORDER BY column_id";


            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;

            }
            else
            {
                return null;
            }
         }

          public DataTable getColumsInfoByColumnName(string username, string tablename, string column_name)
          {
              string sqlcmd = @"select * from dba_tab_cols WHERE OWNER='" + username.ToUpper() + "' and table_name='" + tablename.ToUpper() + "' AND COLUMN_NAME='"+column_name.ToUpper()+"' ORDER BY column_id";


              QueryBuilder qb = new QueryBuilder(sqlcmd);
              DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
              if (dt != null && dt.Rows.Count > 0)
              {
                  return dt;

              }
              else
              {
                  return null;
              }
          }

          public DataTable getTableComments(string username, string tablename)
         {
             string sqlcmd = @"select * from dba_TAB_COMMENTS WHERE OWNER='" + username.ToUpper() + "' and table_name='" + tablename.ToUpper() + "'";


             QueryBuilder qb = new QueryBuilder(sqlcmd);
             DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
             if (dt != null && dt.Rows.Count > 0)
             {
                 return dt;

             }
             else
             {
                 return null;
             }
         }

          public DataTable getColumnComments(string username, string tablename,string columnname)
          {
              string sqlcmd = @"select * from  dba_COL_COMMENTS WHERE OWNER='" + username.ToUpper() + "' AND TABLE_NAME='" + tablename.ToUpper() + "' and column_name='" + columnname.ToUpper()+ "'";
              
              QueryBuilder qb = new QueryBuilder(sqlcmd);
              DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
              if (dt != null && dt.Rows.Count > 0)
              {
                  return dt;
              }
              else
              {
                  return null;
              }
          }


         public void exportXML(XmlTextWriter xw, string username,List<string> tables)
         {

             try
             {
                 xw.Formatting = Formatting.Indented;

                 xw.WriteStartDocument();
                 xw.WriteStartElement("dbinfo");

                 if (tables != null && tables.Count >= 1)
                 {
                     for (int i = 0; i < tables.Count; i++)
                     {
                         xw.WriteStartElement("table");
                         //--获取tvclass属性值        
                         string tablename=tables[i].ToString();
                         xw.WriteAttributeString("tablename", tablename);
                         if (getTableComments(username, tablename) != null)
                         {
                             xw.WriteAttributeString("comments", getTableComments(username, tablename).Rows[0]["comments"].ToString());
                         }
                         else
                         {
                             xw.WriteAttributeString("comments", "");
                         }


                         DataTable dt_columns = this.getColumsInfo(username,tablename);
                         if (dt_columns != null && dt_columns.Rows.Count >= 1)
                         {

                             for (int j = 0; j < dt_columns.Rows.Count; j++)
                             {
                                 //父级节点
                                 xw.WriteStartElement("columns");
                                 string columnname = dt_columns.Rows[j]["column_name"].ToString();
                                 xw.WriteAttributeString("column_name", columnname);
                                 xw.WriteAttributeString("data_type", dt_columns.Rows[j]["data_type"].ToString());
                                 xw.WriteAttributeString("data_length", dt_columns.Rows[j]["data_length"].ToString());
                                 xw.WriteAttributeString("data_precision", dt_columns.Rows[j]["data_precision"].ToString());
                                 xw.WriteAttributeString("data_scale", dt_columns.Rows[j]["data_scale"].ToString());
                                 xw.WriteAttributeString("nullable", dt_columns.Rows[j]["nullable"].ToString());
                                 if (getColumnComments(username, tablename, columnname)!=null)
                                 {
                                    xw.WriteAttributeString("comments", getColumnComments(username, tablename, columnname).Rows[0]["comments"].ToString());  
                                 }else{
                                     xw.WriteAttributeString("comments", "");  
                                 }
                                // xw.WriteAttributeString("column_id", dt_columns.Rows[j]["column_id"].ToString());                              
                                 xw.WriteEndElement();
                             }
                         }
                         
                         xw.WriteEndElement();
                     }
                 }
                 xw.WriteEndElement();
                 xw.WriteEndDocument();

                 xw.Flush();
                 xw.Close();

             }
             catch (Exception EG)
             {

               //  array.Add(EG.ToString() + "\r\n");

             }

         }



       
    }
}
