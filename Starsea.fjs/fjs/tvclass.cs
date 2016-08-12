using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.fjs
{
    public class tvclass
    {



        public DataTable getTvclass(string exportType)
        {
            string sqlcmd = "";
            if(exportType=="建设用地"){
                 sqlcmd = @"select tvnodetypeid,typename,tvclass from t_casecontent_nodetype where tvclass IN ('JSYDFPC','JSYDDDXZ','JSYDPCGG','JSYDXZGG')  ORDER BY TVCLASS";
            
            
            }else if(exportType=="矿业权"){
                 sqlcmd = @"select tvnodetypeid,typename,tvclass from t_casecontent_nodetype where tvclass in ('CKQHK','CKQXL','CKQYS','CKQBG','CKQYX','CKQZR','CKQZX','TKKCFW','TKQHKBG','TKQXL','TKQBG','TKQYX','TKQBL','TKQZR','TKQZX') ORDER BY TVCLASS";
           
            }
            else if (exportType == "土整")
            {
                sqlcmd = @"select tvnodetypeid,typename,tvclass from t_casecontent_nodetype where tvclass IN ('TDKFZL_LX','TDKFZL_YS')  ORDER BY TVCLASS";
           
            }

           
           QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;

        }

        public DataTable getTvclassById(string ids)
        {

            string sqlcmd = @"select tvnodetypeid,typename,tvclass from t_casecontent_nodetype where tvnodetypeid IN (" + ids + ")  ";
            //string sqlcmd = @"select tvnodetypeid,typename,tvclass from t_casecontent_nodetype where tvclass like 'CKQBG%' ORDER BY TVCLASS";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;

        }


        /// <summary>
        /// 通过tvnodetypeid 获取相关tvclass 信息
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <returns></returns>
        public DataTable getTvclassByTvnodetypeid(string tvnodetypeid)
        {
            string sqlcmd = @"select tvnodetypeid,typename,tvclass from t_casecontent_nodetype where tvnodetypeid ='" + tvnodetypeid + "'";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;

        }


        public DataTable getTvclassByTvclassName(string tvclassName)
        {
            string sqlcmd = @"select tvnodetypeid,typename,tvclass from t_casecontent_nodetype where tvclass ='" + tvclassName + "'";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;


        }


        public Boolean addNewTvclass(string tvclass, string name,List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"insert into t_casecontent_nodetype(tvnodetypeid,typename,tvclass) values ( (select nvl(max(tvnodetypeid),0)+1 from t_casecontent_nodetype ),'" + name + "','" + tvclass + "')");


            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
               array.Add("tvclass为:" + tvclass + ",名称为:" + name + "的附件目录新增成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvclass为:" + tvclass + ",名称为:" + name + "的附件目录新增失败" + "\r\n");
                return false;
            }

        }

        /// <summary>
        /// 更新tvclas上报对应节点和类型名称
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <param name="tvclassname"></param>
        /// <param name="uptvnodetypeid"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public Boolean updateTvclassUptvnodetypeid(string tvnodetypeid,string tvclassname, string uptvnodetypeid,List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"update  t_casecontent_nodetype set name='"+tvclassname+"' uptvnodetypeid=" + uptvnodetypeid + " where tvnodetypeid=" + tvnodetypeid + "");


            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",设置tvclass名称为"+tvclassname+",设置uptvnodetypeid为" + uptvnodetypeid + "成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",设置tvclass名称为" + tvclassname + "设置uptvnodetypeid为" + uptvnodetypeid + "失败" + "\r\n");
                return false;
            }

        }



    }
}
