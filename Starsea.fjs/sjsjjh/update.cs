using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.sjsjjh
{
    public class update
    {

        console console = new console();
        check check = new check();
        

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

        public string getOutputtypeString(List<string> type)
        {
            string types = "";
            foreach (string aa in type)
            {
                if (types == "")
                {
                    types = aa;
                }
                else
                {
                    types += "," + aa;
                }
            }

            return types;
        
        
        }


        protected Boolean deleteSbsqlByWfid(string wfid,string  types,List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();
           

            sqlcmdLst.Add(@"delete from t_bj_uploadinfos where wfid=" + wfid + " and outputtype in('" + types + "')");
            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);

                array.Add("wfid为:" + wfid + ",删除掉原有outputtype='" + types + "'上报sql成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("wfid为:" + wfid + ",删除掉原有outputtype='" + types + "'上报sql失败" + "\r\n");
                return false;
            }

        }

        protected void insertNewSbsql(DataTable xml_sqlnode, string wfid ,string types,List<string> array)
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
                    array.Add("wfid为:" + wfid + ",更新了outputtype='" + types + "'上报sql成功" + "\r\n");


                }
                catch
                {
                    array.Add("wfid为:" + wfid + ",更新了outputtype='" + types + "'上报sql失败" + "\r\n");

                }

            }

        }



        public void readXMLandUpdate(DataSet ds,List<string> array) {
            DataTable xml_sbsql = ds.Tables["sbsql"]; 
            DataTable xml_wfnode = ds.Tables["wfnode"];
            DataTable xml_sqlnode = ds.Tables["sqlnode"];

           
                //按流程处理   1 找到对应的wf,没有对应的wf，则提示并不处理，有的话，
                // 在检查 t_bj_casewf表是否有对应的配置 没有的话 添加一条 ,有的话 更新对应的 flowid
                //删掉原来对应传送类型类型的sql，更新xml上的sql到数据库
                if (xml_wfnode != null && xml_wfnode.Rows.Count > 0)
                {

                    for (int i = 0; i < xml_wfnode.Rows.Count; i++)
                    {
                        string wfnode_id = xml_wfnode.Rows[i]["wfnode_id"].ToString();
                        string wfname = xml_wfnode.Rows[i]["name"].ToString();
                        string prefixno = xml_wfnode.Rows[i]["prefixno"].ToString();
                        string bjtype = xml_wfnode.Rows[i]["bjtype"].ToString();
                        string flowid = xml_wfnode.Rows[i]["flowid"].ToString();

                        if (this.isWfExist(prefixno))
                        {
                            string wfid = this.getWfid(prefixno);

                            if (isCaseWfExistByWfid(wfid))
                            {
                                addCaseWf(wfid, wfname, bjtype, flowid,array);

                            }
                            else {
                                updateCaseWf(wfid,wfname, bjtype, flowid,array);
                            
                            }

                            
                            DataTable dv_sqlnode = new DataTable();
                            dv_sqlnode = xml_sqlnode.Clone();

                            System.Data.DataRow[] dv_sqlnode_row = xml_sqlnode.Select("wfnode_id=" + wfnode_id);
                            for (int j = 0; j < dv_sqlnode_row.Length; j++)
                            {
                                dv_sqlnode.ImportRow((System.Data.DataRow)dv_sqlnode_row[j]);
                            }

                            List<string> sbsql_type = new List<string>();
                            for (int k = 0; k < dv_sqlnode.Rows.Count; k++)
                            {
                                if (!sbsql_type.Contains(dv_sqlnode.Rows[k]["outputtype"].ToString()))
                                {
                                    sbsql_type.Add(dv_sqlnode.Rows[k]["outputtype"].ToString());
                                }
                            }

                            string types=getOutputtypeString(sbsql_type);

                            //删除原有 导出类型的sql语句
                            deleteSbsqlByWfid(wfid, types, array);

                            insertNewSbsql(dv_sqlnode, wfid, types, array);
                            array.Add("wfid为" + wfid + ",流程名称为\"" + wfname + "\"处理上报类型outputtype为" + types + "完成" + "\r\n");
                            array.Add("------------------------------------------------------------------------------------------" + "\r\n");

                        }
                        else
                        {
                           array.Add("xml中流程前缀编码为" + prefixno + "的流程在数据库中没找到" + "\r\n");
                        }

                    }            

            }      
        
        
        }

        private void updateCaseWf(string wfid, string wfname,string bjtype, string flowid,List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();
            sqlcmdLst.Add(@"update t_bj_casewf set bjtype='"+bjtype+"',flowid='"+flowid+"'  where wfid=" + wfid + "'");
            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("wfid为:" + wfid + ",流程名称为"+wfname+",更新t_bj_casewf原有bjtype为" + bjtype + "',flowid为'" + flowid + "'配置成功" + "\r\n");
            }
            catch
            {
                array.Add("wfid为:" + wfid + "流程名称为" + wfname + ",更新t_bj_casewf原有bjtype为" + bjtype + "',flowid为'" + flowid + "'配置成功" + "\r\n");                
            } 
        }

        private void addCaseWf(string wfid, string wfname, string bjtype, string flowid, List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"insert into t_bj_casewf (wfid,wfname,bjtype,flowid)values('"+wfid+"','"+wfname+"','"+bjtype+"','"+flowid+"')");
            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("wfid为:" + wfid + ",流程名称为" + wfname + ",在t_bj_casewf插入bjtype为" + bjtype + "',flowid为'" + flowid + "'配置成功" + "\r\n");
           
            }
            catch
            {
                array.Add("wfid为:" + wfid + ",流程名称为" + wfname + ",在t_bj_casewf插入bjtype为" + bjtype + "',flowid为'" + flowid + "'配置失败" + "\r\n");              
            }
        }

        private bool isCaseWfExistByWfid(string wfid)
        {
            string sqlcmd = @"select wfid from t_bj_casewf where wfid = '" + wfid + "'";

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


        public void readAndCheck(DataSet ds, List<string> array)
        {
            DataTable xml_sbsql = ds.Tables["sbsql"];
            DataTable xml_wfnode = ds.Tables["wfnode"];
            DataTable xml_sqlnode = ds.Tables["sqlnode"];            

            //按流程处理   1 找到对应的wf,没有对应的wf，则提示并不处理，有的话，
            // 在检查 t_bj_casewf表是否有对应的配置 检查wfid bjtype flowid
            //检查对应的 sql记录  每条 检查 output 下的operater 有没有  在检查 对应记录的 sqlcontent operatefileid sqlparameters excenoquerysql
            if (xml_wfnode != null && xml_wfnode.Rows.Count > 0)
            {
                for (int i = 0; i < xml_wfnode.Rows.Count; i++)
                {
                    string wfnode_id = xml_wfnode.Rows[i]["wfnode_id"].ToString();
                    string wfname = xml_wfnode.Rows[i]["name"].ToString();
                    string prefixno = xml_wfnode.Rows[i]["prefixno"].ToString();
                    string bjtype = xml_wfnode.Rows[i]["bjtype"].ToString();
                    string flowid = xml_wfnode.Rows[i]["flowid"].ToString();

                    if (this.isWfExist(prefixno))
                    {
                        string wfid = this.getWfid(prefixno);

                        if (!isCaseWfExistByWfid(wfid))
                        {                        
                            array.Add("xml中流程前缀编码为" + prefixno + "的流程"+wfname+"在数据库t_bj_casewf中没找到配置记录" + "\r\n");
                        }


                        DataTable dv_sqlnode = new DataTable();
                        dv_sqlnode = xml_sqlnode.Clone();

                        System.Data.DataRow[] dv_sqlnode_row = xml_sqlnode.Select("wfnode_Id=" + wfnode_id);
                        for (int j = 0; j < dv_sqlnode_row.Length; j++)
                        {
                            dv_sqlnode.ImportRow((System.Data.DataRow)dv_sqlnode_row[j]);
                        }

                        List<string> sbsql_type = new List<string>();
                        for (int k = 0; k < dv_sqlnode.Rows.Count; k++)
                        {
                            if (!sbsql_type.Contains(dv_sqlnode.Rows[k]["outputtype"].ToString()))
                            {
                                sbsql_type.Add(dv_sqlnode.Rows[k]["outputtype"].ToString());
                            }
                        }

                        string types = getOutputtypeString(sbsql_type);

                        //删除原有 导出类型的sql语句
                        check.checkSbsqlByWfid(wfid,wfname, dv_sqlnode, array);
                        
                        array.Add("wfid为" + wfid + ",流程名称为\"" + wfname + "\"处理上报类型outputtype为" + types + "检查完成" + "\r\n");
                        array.Add("------------------------------------------------------------------------------------------" + "\r\n");

                    }
                    else
                    {
                        array.Add("xml中流程前缀编码为" + prefixno + "的流程在数据库中没找到" + "\r\n");
                    }

                }

            }      
         
        }

      
    }
}
