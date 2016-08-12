using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.scpz
{
    public class check
    {       

        public bool checkSQL(List<string> exportlist,List<string> array)
        {
            export ex = new export();
            DataTable wfdt = ex.getExportwf(exportlist);
            if(wfdt!=null&&wfdt.Rows.Count>0){
                for(int i=0;i<wfdt.Rows.Count;i++){

                    string wfid = wfdt.Rows[0]["wfid"].ToString();
                     string wfname = wfdt.Rows[0]["wfid"].ToString();
                    string ret = getWFsqlCount(wfid);
                    if(ret=="0"){
                        array.Add("wfid 为 "+wfid+"的流程 "+wfname+"没有配置删除sql语句!");
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
        /// <summary>
        /// 获取流程的删除sql个数
        /// </summary>
        /// <param name="wfid"></param>
        /// <returns></returns>
        public string getWFsqlCount(string wfid) {
            string ret = "0";
            string sqlcmd = @"select count(*) num from t_wf_casetable where wfid='"+wfid+"'";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0) {
                ret = dt.Rows[0]["num"].ToString();
            }
            return ret;
        
        }

        public  void checkSQLcount(string wfid,string wfname,DataTable dv_sqlnode,List<string> array)
        {
            int pz_count = dv_sqlnode.Rows.Count;
            int sql_count = Convert.ToInt32(getWFsqlCount(wfid));
            if(sql_count==0){
                array.Add("wfid 为 "+wfid+"，流程名称为 "+wfname+"的流程 没有配置删除sql语句！");
            
            }else if(sql_count<pz_count){
                array.Add("wfid 为 " + wfid + "，流程名称为 " + wfname + "的流程 有删除sql语句为配置！");            
            }

        }

        public void checkSQL(string wfid,string wfname, DataTable dv_sqlnode,List<string> array)
        {
            if (dv_sqlnode!=null&&dv_sqlnode.Rows.Count>0)
            {
                for (int i = 0; i < dv_sqlnode.Rows.Count;i++ )
                {
                    string casetableid = dv_sqlnode.Rows[i]["casetableid"].ToString();
                    string sqlcontent = dv_sqlnode.Rows[i]["sqlcontent"].ToString();
                    string sqlcmd = @"select * num from t_wf_casetable where wfid='"+wfid+"' and  sqlcontent='" + sqlcontent + "'";
                    QueryBuilder qb = new QueryBuilder(sqlcmd);
                    DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
                    if (dt != null && dt.Rows.Count > 0)
                    {

                    }
                    else {
                        array.Add("wfid 为 " + wfid + ",流程名称为" + wfname + "的流程没有配置----" + sqlcontent + "---的sql语句");
                    }

                }               
            
            }           
           
        }
    }
}
