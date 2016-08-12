using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.db
{
    public class check
    {
        dbdata db = new dbdata();

        public void checkDbinfoXML(string username, DataSet ds, List<string> array)
        {
            DataTable xml_tables = ds.Tables["table"];
            DataTable xml_columns = ds.Tables["columns"];

            for (int i = 0; i < xml_tables.Rows.Count; i++)
            {

                string tablename = xml_tables.Rows[i]["tablename"].ToString();
                string tablecomments = xml_tables.Rows[i]["comments"].ToString();
                string table_id = xml_tables.Rows[i]["table_id"].ToString();


                // 判断表 是否存在, 
                if (checkTable(username, tablename))
                {
                    //是否有表注释 没有表  则继续下一个表的检查
                    if (!checkTableComments(username, tablename, tablecomments))
                    {
                        array.Add("表" + tablename + "的注释与检查xml的注释不一致！，xml的注释为【" + tablecomments + "】,数据库里的注释为【" + db.getTableComments(username, tablename).Rows[0]["comments"].ToString() + "】");

                    }

                }
                else
                {

                    array.Add("表" + tablename + "不存在！");
                    continue;
                }

                DataTable dt_columns = new DataTable();
                dt_columns = xml_columns.Clone();
                System.Data.DataRow[] dt_columns_row = xml_columns.Select("table_id=" + table_id);
                for (int j = 0; j < dt_columns_row.Length; j++)
                {
                    dt_columns.ImportRow((System.Data.DataRow)dt_columns_row[j]);
                }

                for (int j = 0; j < dt_columns.Rows.Count; j++)
                {
                    string column_name = dt_columns.Rows[j]["column_name"].ToString();
                    string data_type = dt_columns.Rows[j]["data_type"].ToString();
                    string data_length = dt_columns.Rows[j]["data_length"].ToString();
                    string data_precision = dt_columns.Rows[j]["data_precision"].ToString();
                    string data_scale = dt_columns.Rows[j]["data_scale"].ToString();
                    string nullable = dt_columns.Rows[j]["nullable"].ToString();
                    string comments = dt_columns.Rows[j]["comments"].ToString();


                    //检查 字段是否存在, 没有则下一个 字段检查
                    if (checkColumn(username, tablename, column_name))
                    {
                        //检查 字符类型 长度  和是否允许为空 // 检查注释
                        DataTable db_columnsinfo = db.getColumsInfoByColumnName(username, tablename, column_name);

                        string db_data_type = db_columnsinfo.Rows[0]["data_type"].ToString();
                        string db_data_length = db_columnsinfo.Rows[0]["data_length"].ToString();
                        string db_data_precision = db_columnsinfo.Rows[0]["data_precision"].ToString();
                        string db_data_scale = db_columnsinfo.Rows[0]["data_scale"].ToString();
                        string db_nullable = db_columnsinfo.Rows[0]["nullable"].ToString();
                        string db_comments = "";
                        if (db.getColumnComments(username, tablename, db_columnsinfo.Rows[0]["column_name"].ToString()) != null)
                        {
                             db_comments = db.getColumnComments(username, tablename, db_columnsinfo.Rows[0]["column_name"].ToString()).Rows[0]["comments"].ToString();
                        }
                       
                        if (db_data_type != data_type)
                        {
                            array.Add("表" + tablename + "中字段【" + column_name + "】！数据类型与xml配置不一致, 数据库中为【" + db_data_type + "】，xml配置中为【" + data_type + "】");

                        }
                        if (db_data_length != data_length)
                        {
                            array.Add("表" + tablename + "中字段【" + column_name + "】！数据长度与xml配置不一致, 数据库中为【" + db_data_length + "】，xml配置中为【" + data_length + "】");

                        }
                        if (data_type == "NUMBER")
                        {
                            if (db_data_precision != data_precision)
                            {

                                array.Add("表" + tablename + "中字段【" + column_name + "】！数据总长度与xml配置不一致, 数据库中为【" + db_data_precision + "】，xml配置中为【" + data_precision + "】");

                            }
                            if (db_data_precision != data_precision)
                            {

                                array.Add("表" + tablename + "中字段【" + column_name + "】！数据小数点长度与xml配置不一致, 数据库中为【" + db_data_precision + "】，xml配置中为【" + data_precision + "】");

                            }

                        }
                        if (db_nullable != nullable)
                        {
                            array.Add("表" + tablename + "中字段【" + column_name + "】！是否为空设置与xml配置不一致, 数据库中为【" + db_nullable + "】，xml配置中为【" + nullable + "】");

                        }

                        if (db_comments != comments)
                        {
                            array.Add("表" + tablename + "中字段【" + column_name + "】！注释内容与xml配置不一致, 数据库中为【" + db_comments + "】，xml配置中为【" + comments + "】");

                        }


                    }
                    else
                    {
                        array.Add("表" + tablename + "中不存在字段【" + column_name + "】！");
                        continue;

                    }
                   // array.Add("--------表" + tablename + "中字段【" + column_name + "】检查完毕--------！");

                }
                array.Add("------------------------------表" + tablename + "检查完毕！------------------------------");


            }




        }
        /// <summary>
        /// 判断字段是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="tablename"></param>
        /// <param name="column_name"></param>
        /// <returns></returns>
        private bool checkColumn(string username, string tablename, string column_name)
        {
            string sqlcmd = @"select * from dba_tab_cols WHERE OWNER='" + username.ToUpper() + "' and table_name='" + tablename.ToUpper() + "' and column_name='"+column_name+"' ORDER BY column_id";


            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断 表注释是否一样
        /// </summary>
        /// <param name="username"></param>
        /// <param name="tablename"></param>
        /// <param name="tablecomments"></param>
        /// <returns></returns>
        private bool checkTableComments(string username, string tablename, string tablecomments)
        {
            string sqlcmd = @"select * from dba_TAB_COMMENTS WHERE OWNER='" + username.ToUpper() + "' and table_name='" + tablename.ToUpper() + "'";


            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                string comments = dt.Rows[0]["comments"].ToString();

                if (comments == tablecomments)
                {
                    return true;
                }
                else {
                    return false;
                }
               

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        private bool checkTable(string username, string tablename)
        {
            string sqlcmd = @"select * from dba_tables WHERE OWNER='" + username.ToUpper() + "' and table_name='"+tablename.ToUpper()+"'";


            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
