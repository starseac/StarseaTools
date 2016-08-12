using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.scpz
{
    public class update
    {
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

        public void readAndUpdate(DataSet ds, List<string> array)
        {
            DataTable xml_scsql = ds.Tables["scsql"];
            DataTable xml_wfnode = ds.Tables["wfnode"];
            DataTable xml_sqlnode = ds.Tables["sqlnode"];


            // 找到系统对应的流程id,删除原有的sql配置 在插入配置里的sql语句
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

                        DataTable dv_sqlnode = new DataTable();
                        dv_sqlnode = xml_sqlnode.Clone();

                        System.Data.DataRow[] dv_sqlnode_row = xml_sqlnode.Select("wfnode_id=" + wfnode_id);
                        for (int j = 0; j < dv_sqlnode_row.Length; j++)
                        {
                            dv_sqlnode.ImportRow((System.Data.DataRow)dv_sqlnode_row[j]);
                        }
                        //删除原有的sql 配置
                        this.deleteSCPZbyWfid(wfid,wfname,array);
                        //更新配置文件中的sql配置
                        this.updateSCPZbyWfid(wfid, wfname, dv_sqlnode, array);                        

                        array.Add("wfid为" + wfid + ",流程名称为\"" + wfname + "\"删除sql语句更新完成" + "\r\n");
                        array.Add("------------------------------------------------------------------------------------------" + "\r\n");

                    }
                    else
                    {
                        array.Add("xml中流程前缀编码为" + prefixno + "的流程在数据库中没找到" + "\r\n");

                    }

                }

            }

            
        }

        private void deleteSCPZbyWfid(string wfid, string wfname, List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"delete from t_wf_casetable where wfid=" + wfid + "'");
            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);

                array.Add("wfid为:" + wfid + ",流程名称为 "+wfname+"删除掉原有流程删除sql成功" + "\r\n");
                
            }
            catch
            {
                array.Add("wfid为:" + wfid + ",流程名称为 " + wfname + "删除掉原有流程删除sql失败" + "\r\n");
                
            }
        }

        private void updateSCPZbyWfid(string wfid, string wfname,DataTable dv_sqlnode ,List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();
            if (dv_sqlnode != null && dv_sqlnode.Rows.Count > 0)
            {
                for (int i = 0; i < dv_sqlnode.Rows.Count; i++)
                {
                    string casetableid = dv_sqlnode.Rows[i]["casetableid"].ToString();
                    string sqlcontent = dv_sqlnode.Rows[i]["sqlcontent"].ToString();


                    sqlcmdLst.Add(@"insert into t_wf_casetable(wfid,casetableid,sqlcontent)values(" + wfid + ",'" + casetableid + "','" + sqlcontent + "')");

                }

                try
                {
                    DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                    array.Add("wfid为:" + wfid + "流程名称为"+wfname+",更新了删除sql语句成功" + "\r\n");


                }
                catch
                {
                    array.Add("wfid为:" + wfid + "流程名称为" + wfname + ",更新了删除sql语句失败" + "\r\n");

                }

            }
        }

        public void readAndCheck(DataSet ds, List<string> array)
        {
            DataTable xml_scsql = ds.Tables["scsql"];
            DataTable xml_wfnode = ds.Tables["wfnode"];
            DataTable xml_sqlnode = ds.Tables["sqlnode"];


            // 找到系统对应的流程id,先看 删除语句sql个数是否匹配中 在检查配置中每条sql语句是否都有 检查
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

                        DataTable dv_sqlnode = new DataTable();
                        dv_sqlnode = xml_sqlnode.Clone();

                        System.Data.DataRow[] dv_sqlnode_row = xml_sqlnode.Select("wfnode_id=" + wfnode_id);
                        for (int j = 0; j < dv_sqlnode_row.Length; j++)
                        {
                            dv_sqlnode.ImportRow((System.Data.DataRow)dv_sqlnode_row[j]);
                        }
                        //检查sql配置条数是否一致
                        check.checkSQLcount(wfid, wfname, dv_sqlnode, array);
                        //检查配置里的sql语句是否存在
                        check.checkSQL(wfid, wfname, dv_sqlnode, array);

                        array.Add("wfid为" + wfid + ",流程名称为\"" + wfname + "\"删除sql语句检查完成" + "\r\n");
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
