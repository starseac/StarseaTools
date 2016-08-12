using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using Starsea.Database.Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.sjsjjh
{
    public class check
    {
        /// <summary>
        /// 获取流程的删除sql个数
        /// </summary>
        /// <param name="wfid"></param>
        /// <returns></returns>
        public string getWFsqlCount(string wfid)
        {
            string ret = "0";
            string sqlcmd = @"select count(*) num from t_bj_uploadinfos where wfid='" + wfid + "'";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                ret = dt.Rows[0]["num"].ToString();
            }
            return ret;

        }
        /// <summary>
        /// 检查三级交换表 t_bj_casewf表
        /// </summary>
        /// <param name="wfid"></param>
        /// <returns></returns>
        public string getCASWWF(string wfid)
        {
            string ret = "0";
            string sqlcmd = @"select count(*) num from t_bj_casewf where wfid='" + wfid + "'";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                ret = dt.Rows[0]["num"].ToString();
            }
            return ret;

        }

        public bool checkSQL(List<string> exportlist, List<string> array)
        {
            export ex = new export();
            DataTable wfdt = ex.getWfinfo(exportlist);
            if (wfdt != null && wfdt.Rows.Count > 0)
            {
                for (int i = 0; i < wfdt.Rows.Count; i++)
                {

                    string wfid = wfdt.Rows[0]["wfid"].ToString();
                    string wfname = wfdt.Rows[0]["wfid"].ToString();
                    string ret = getWFsqlCount(wfid);
                    string ret1 = getCASWWF(wfid);
                    if (ret == "0")
                    {
                        array.Add("wfid 为 " + wfid + "的流程 " + wfname + "没有配置三级交换sql语句!");
                    }
                    if (ret1 == "0")
                    {
                        array.Add("wfid 为 " + wfid + "的流程 " + wfname + "没有配置三级交换t_bj_casewf表!");
                    }

                }

            }
            if (array.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        public void checkSbsqlByWfid(string wfid, string wfname, DataTable xml_sqlnode, List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();


            if (xml_sqlnode != null && xml_sqlnode.Rows.Count > 0)
            {
                for (int i = 0; i < xml_sqlnode.Rows.Count; i++)
                {
                    string infoid = xml_sqlnode.Rows[i]["infoid"].ToString();
                    string sqlcontent = xml_sqlnode.Rows[i]["sqlcontent"].ToString();
                    string operatefield = xml_sqlnode.Rows[i]["operatefield"].ToString();
                    string operatetable = xml_sqlnode.Rows[i]["operatetable"].ToString();
                    string fcaseidname = xml_sqlnode.Rows[i]["fcaseidname"].ToString();
                    string outputtype = xml_sqlnode.Rows[i]["outputtype"].ToString();
                    string sqlparameters = xml_sqlnode.Rows[i]["sqlparameters"].ToString();
                    string excenoquerysql = xml_sqlnode.Rows[i]["excenoquerysql"].ToString();


                    string sqlcmd = @"select operatetable num from t_bj_uploadinfos where wfid='" + wfid + "' and outputtype='" + outputtype + "' and operatetable='"+operatetable+"' ";
                    QueryBuilder qb = new QueryBuilder(sqlcmd);
                    DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string sqlpar = @"select sqlcontent,operatefield,fcaseidname,sqlparameters,excenoquerysql  from t_bj_uploadinfos where wfid='" + wfid + "' and outputtype='" + outputtype + "' and operatetable='"+operatetable+"'";
                        QueryBuilder qbpar = new QueryBuilder(sqlpar);
                        DataTable dtpar = DatabaseEngine.Default.Db.GetSelectTable(qbpar);
                        if (dtpar != null && dtpar.Rows.Count > 0)
                        {
                            string cop_sqlcontent = dtpar.Rows[0]["sqlcontent"].ToString();
                            string cop_operatefield = dtpar.Rows[0]["operatefield"].ToString();
                            string cop_fcaseidname = dtpar.Rows[0]["fcaseidname"].ToString();
                            string cop_sqlparameters = dtpar.Rows[0]["sqlparameters"].ToString();
                            string cop_excenoquerysql = dtpar.Rows[0]["excenoquerysql"].ToString();

                            if (cop_sqlcontent != sqlcontent)
                            {
                                array.Add("wfid 为 " + wfid + "的流程 " + wfname + "在t_bj_uploadinfos表中outputtype为" + outputtype + "的三级交换类型中operatetable 为" + operatetable + "的配置中sqlcontent的配置与xml配置文件不一致!");

                            }
                            if (cop_operatefield != operatefield)
                            {
                                array.Add("wfid 为 " + wfid + "的流程 " + wfname + "在t_bj_uploadinfos表中outputtype为" + outputtype + "的三级交换类型中operatetable 为" + operatetable + "的配置中 operatefield的配置与xml配置文件不一致!");

                            }
                            if (cop_fcaseidname != fcaseidname)
                            {
                                array.Add("wfid 为 " + wfid + "的流程 " + wfname + "在t_bj_uploadinfos表中outputtype为" + outputtype + "的三级交换类型中operatetable 为" + operatetable + "的配置中 fcaseidname的配置与xml配置文件不一致!");

                            }
                            if (cop_sqlparameters != sqlparameters)
                            {
                                array.Add("wfid 为 " + wfid + "的流程 " + wfname + "在t_bj_uploadinfos表中outputtype为" + outputtype + "的三级交换类型中operatetable 为" + operatetable + "的配置中 sqlparameters的配置与xml配置文件不一致!");

                            }
                            if (cop_excenoquerysql != excenoquerysql)
                            {
                                array.Add("wfid 为 " + wfid + "的流程 " + wfname + "在t_bj_uploadinfos表中outputtype为" + outputtype + "的三级交换类型中operatetable 为" + operatetable + "的配置中 excenoquerysql的配置与xml配置文件不一致!");

                            }
                        }


                    }
                    else
                    {
                        array.Add("wfid 为 " + wfid + "的流程 " + wfname + "在t_bj_uploadinfos表中outputtype为" + outputtype + "的三级交换类型中找到表 " + operatetable + "的配置!");

                    }
                }
            }
        }



        public void checkTables(string mdbpath, DataTable xml_tables,DataTable xml_column,List<string> array)
        {
            ScannMdb scann = new ScannMdb();
            //获取要检查的mdb数据库表
            DataTable table = scann.getTableList(mdbpath);           

            //对比表
            for (int i = 0; i < xml_tables.Rows.Count; i++)
            {
                string xml_table = xml_tables.Rows[i]["tablename"].ToString();
                string xml_table_id = xml_tables.Rows[i]["table_Id"].ToString();

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    string cp_table = table.Rows[j]["TABLE_NAME"].ToString();

                    if (xml_table == cp_table)
                    {
                        //获取该mdb下的table
                        DataTable dv_column = new DataTable();
                        dv_column = xml_column.Clone();

                        System.Data.DataRow[] dv_table_row = xml_column.Select("table_Id=" + xml_table_id);
                        for (int k = 0; k < dv_table_row.Length; k++)
                        {
                            dv_column.ImportRow((System.Data.DataRow)dv_table_row[k]);
                        }
                        checkColumns(mdbpath, xml_table, dv_column, array);

                        break;
                    }

                    if (j == table.Rows.Count - 1 && xml_table != cp_table)
                    {
                        array.Add("在mdb [" + mdbpath + "]中没有找到表[" + xml_table+"]");
                    }
                }

            }
           
        }



        public void checkColumns(string mdbpath, string tablename, DataTable xml_columnname,List<string> array)
        {
            ScannMdb scann = new ScannMdb();
            DataTable columns = scann.getTableColumnList(mdbpath, tablename);

            List<string> no_columns = new List<string>();

            //对比表
            for (int i = 0; i < xml_columnname.Rows.Count; i++)
            {
                string xml_column_name = xml_columnname.Rows[i]["column_name"].ToString();
                string xml_ordinal_position = xml_columnname.Rows[i]["ordinal_position"].ToString();
                string xml_column_hasdefault = xml_columnname.Rows[i]["column_hasdefault"].ToString();
                string xml_column_flags = xml_columnname.Rows[i]["column_flags"].ToString();
                string xml_is_nullable = xml_columnname.Rows[i]["is_nullable"].ToString();
                string xml_data_type = xml_columnname.Rows[i]["data_type"].ToString();
                string xml_character_maximum_length = xml_columnname.Rows[i]["character_maximum_length"].ToString();
                string xml_character_octet_length = xml_columnname.Rows[i]["character_octet_length"].ToString();

                for (int j = 0; j < columns.Rows.Count; j++)
                {
                    string cp_column_name = columns.Rows[j]["column_name"].ToString();
                    string cp_ordinal_position = columns.Rows[j]["ordinal_position"].ToString();
                    string cp_column_hasdefault = columns.Rows[j]["column_hasdefault"].ToString();
                    string cp_column_flags = columns.Rows[j]["column_flags"].ToString();
                    string cp_is_nullable = columns.Rows[j]["is_nullable"].ToString();
                    string cp_data_type = columns.Rows[j]["data_type"].ToString();
                    string cp_character_maximum_length = columns.Rows[j]["character_maximum_length"].ToString();
                    string cp_character_octet_length = columns.Rows[j]["character_octet_length"].ToString();
                    

                    if (xml_column_name == cp_column_name)
                    {
                        if (xml_column_hasdefault != cp_column_hasdefault) {
                            array.Add("在mdb [" + mdbpath + "]中表[" + tablename + "]的字段[" + xml_column_name + "]默认值设置[" + cp_column_hasdefault + "]与xml配置[" + xml_column_hasdefault + "]不符合");
                        }
                        if (xml_is_nullable != cp_is_nullable)
                        {
                            array.Add("在mdb [" + mdbpath + "]中表[" + tablename + "]的字段[" + xml_column_name + "]是否为空设置[" + cp_is_nullable + "]与xml配置[" + xml_is_nullable + "]不符合");
                        }
                        if (xml_data_type != cp_data_type)
                        {
                            array.Add("在mdb [" + mdbpath + "]中表[" + tablename + "[的字段[" + xml_column_name + "]数据类型设置[" + cp_data_type + "]与xml配置[" + xml_data_type + "]不符合");
                        }


                        break;
                    }

                    if (j == columns.Rows.Count - 1 && xml_column_name != cp_column_name)
                    {
                        array.Add("在mdb [" + mdbpath + "]中表[" + tablename + "]没有找到字段[" + xml_column_name+"]");
                    }


                }

            }
          
        }


        public void readMDBXMLAndCheck(DataSet ds, string dirpath, List<string> array)
        {
            DataTable xml_mdb = ds.Tables["mdb"];
            DataTable xml_table = ds.Tables["table"];
            DataTable xml_column = ds.Tables["column"];

            Starsea.Database.Access.ScannMdb scann = new Starsea.Database.Access.ScannMdb();
            //先看 对于的mdb 有没有
            // 在看 mdb 下的表 手否有
            // 在看  表里的字段有没有

            if (xml_mdb != null && xml_mdb.Rows.Count > 0)
            {
                for (int i = 0; i < xml_mdb.Rows.Count; i++)
                {
                    string mdb_id = xml_mdb.Rows[i]["mdb_id"].ToString();
                    string mdbname = xml_mdb.Rows[i]["filename"].ToString();
                    string mdbpath = dirpath + "\\" + mdbname;



                    if (scann.isMDBExist(mdbpath))
                    {
                        //获取该mdb下的table
                        DataTable dv_table = new DataTable();
                        dv_table = xml_table.Clone();

                        System.Data.DataRow[] dv_table_row = xml_table.Select("mdb_Id=" + mdb_id);
                        for (int j = 0; j < dv_table_row.Length; j++)
                        {
                            dv_table.ImportRow((System.Data.DataRow)dv_table_row[j]);
                        }

                      

                        // 判断表是否在mdb里存在 在判断字段是否在表里

                        this.checkTables(mdbpath, dv_table, xml_column, array);
                            
                        
                      

                        array.Add("mdb[" + mdbpath + "],检查完成" + "\r\n");
                        array.Add("------------------------------------------------------------------------------------------" + "\r\n");

                    }
                    else
                    {
                        array.Add("在文件夹中没有找到名称为[" + mdbname + "]的mdb文件" + "\r\n");
                    }

                }

            }
        }



    }
}
