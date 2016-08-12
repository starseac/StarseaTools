using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.sjsjjh
{
    public class update
    {

        console console = new console();

        protected Boolean isWfExist(string prefixno)
        {
            string sqlcmd = @"select * from t_wf_wfinfo where prefixno = '" + prefixno + "'";

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

        protected string getWfid(string prefixno)
        {
            string sqlcmd = @"select wfid from t_wf_wfinfo where prefixno = '" + prefixno + "'";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["wfid"].ToString();
            }
            else
            {
                return "";
            }

        }


        protected Boolean deleteSbsqlByWfid(string wfid,string type)
        {

            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"delete from t_bj_uploadinfos where wfid=" + wfid + " and outputtype='" + type + "'");
            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);

                console.consoleStr += "wfid为:" + wfid + ",删除掉原有outputtype='" + type + "'上报sql成功" + "\r\n";
                return true;

            }
            catch
            {
                console.consoleStr += "wfid为:" + wfid + ",删除掉原有outputtype='" + type + "'上报sql失败" + "\r\n";
                return false;
            }

        }

        protected void insertNewSbsql(DataTable xml_sqlnode, string wfid, string type)
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

                    sqlcmdLst.Add(@"insert into t_bj_uploadinfos(wfid,infoid,sqlcontent,operatefield,operatetable,fcaseidname,outputtype,sqlparameters,excenoquerysql)values(" + wfid + "," + infoid + ",'" + sqlcontent.Replace("'", "''") + "','" + operatefield + "','" + operatetable + "','" + fcaseidname + "','" + outputtype + "','" + sqlparameters + "','" + excenoquerysql.Replace("'", "''") + "')");

                }

                try
                {
                    DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                    console.consoleStr += "wfid为:" + wfid + ",更新了outputtype='" + type + "'上报sql成功" + "\r\n";


                }
                catch
                {
                    console.consoleStr += "wfid为:" + wfid + ",更新了outputtype='" + type + "'上报sql失败" + "\r\n";

                }

            }

        }



        public void readXMLandUpdate(DataSet ds,string sbsql_type) {
            DataTable xml_sbsql = ds.Tables["sbsql"];
            DataTable xml_wfnode = ds.Tables["wfnode"];
            DataTable xml_sqlnode = ds.Tables["sqlnode"];

            string outputtype = xml_sbsql.Rows[0]["outputtype"].ToString();
            if (outputtype == sbsql_type)
            {
                //按流程处理   1 找到对应的wf,没有对应的wf，则提示并不处理，有的话，删掉原来的sql，更新xml上的sql到数据库
                if (xml_wfnode != null && xml_wfnode.Rows.Count > 0)
                {

                    for (int i = 0; i < xml_wfnode.Rows.Count; i++)
                    {
                        string wfnode_id = xml_wfnode.Rows[i]["wfnode_id"].ToString();
                        string wfname = xml_wfnode.Rows[i]["name"].ToString();
                        string prefixno = xml_wfnode.Rows[i]["prefixno"].ToString();

                        if (this.isWfExist(prefixno))
                        {
                            string wfid = this.getWfid(prefixno);
                            deleteSbsqlByWfid(wfid,sbsql_type);

                            DataTable dv_sqlnode = new DataTable();
                            dv_sqlnode = xml_sqlnode.Clone();

                            System.Data.DataRow[] dv_sqlnode_row = xml_sqlnode.Select("wfnode_id=" + wfnode_id);
                            for (int j = 0; j < dv_sqlnode_row.Length; j++)
                            {
                                dv_sqlnode.ImportRow((System.Data.DataRow)dv_sqlnode_row[j]);
                            }
                            insertNewSbsql(dv_sqlnode, wfid,sbsql_type);
                            console.consoleStr += "wfid为" + wfid + ",流程名称为\"" + wfname + "\"处理上报类型outputtype为" + outputtype + "完成" + "\r\n";
                            console.consoleStr += "------------------------------------------------------------------------------------------" + "\r\n";

                        }
                        else
                        {
                            console.consoleStr += "xml中流程前缀编码为" + prefixno + "的流程在数据库中没找到" + "\r\n";


                        }

                    }

                }



            }
            else
            {
                console.consoleStr += "xml上报类型" + outputtype + "与要处理的上报类型" + sbsql_type + "不匹配" + "\r\n";

            }
        
        
        }

    }
}
