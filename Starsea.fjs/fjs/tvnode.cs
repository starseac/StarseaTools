using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.fjs
{
   public class tvnode
    {

        public DataTable getTvnodePage(string tvnodetypeid)
        {
            string sqlcmd = @"select tvnodename,tvnodeurl,(select tvnodeindex
                              from t_casecontent_nodes
                             where tvnodeid = t.prenodeid) pretvnodeindex,tvnodeindex  from t_casecontent_nodes t where tvnodetypeid = " + tvnodetypeid + " and eventtype=2 and prenodeid!=-1 ";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }


        public DataTable getTvnode(string tvnodetypeid)
        {
            string sqlcmd = @"SELECT tvnodeid,tvnodename,
                           (select tvnodeindex
                              from t_casecontent_nodes
                             where tvnodeid = t.prenodeid) pretvnodeindex,
                           tvnodeindex,
                           annexno
                      FROM T_CASECONTENT_NODES t
                     WHERE TVNODETYPEID = " + tvnodetypeid + " and eventtype = 1 and contextmenuid = 3  ORDER BY pretvnodeindex, tvnodeindex";


            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }


        public Boolean isTvnodePageExist(string tvnodetypeid)
        {
            string sqlcmd = @"SELECT tvnodeid, tvnodename,  annexno
                      FROM T_CASECONTENT_NODES t
                     WHERE TVNODETYPEID = " + tvnodetypeid + " and eventtype = 2 ";

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

        public Boolean addNewTvnodePage(string tvnodetypeid,List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"insert into T_CASECONTENT_NODES (tvnodeid,tvnodename,eventtype,tvnodetypeid) values( (select nvl(max(tvnodeid),0)+1 from t_casecontent_nodes),'',2," + tvnodetypeid + ")");


            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",添加申请书页面成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",添加申请书页面失败" + "\r\n");
                return false;
            }

        }

        public Boolean editTvnodePage(DataTable xml_tvnodepage, string tvnodetypeid,List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            string sqlcmd = @"SELECT tvnodeid,tvnodename, tvnodeindex  FROM T_CASECONTENT_NODES WHERE TVNODETYPEID =" + tvnodetypeid + "   and eventtype = 2 and rownum=1 ";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            string update_tvnodeid = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                int i = dt.Rows.Count;
                for (int j = 0; j < i; j++)
                {
                    update_tvnodeid = dt.Rows[j]["tvnodeid"].ToString();
                    sqlcmdLst.Add(@"update T_CASECONTENT_NODES set tvnodename='" + xml_tvnodepage.Rows[j]["name"].ToString() + "' ,tvnodeurl='" + xml_tvnodepage.Rows[j]["url"].ToString() + "' ,tvnodeindex='" + xml_tvnodepage.Rows[j]["tvnodeindex"].ToString() + "' ,prenodeid=(select tvnodeid from t_casecontent_nodes where  eventtype=0 and prenodeid=-1 and tvnodeindex='" + xml_tvnodepage.Rows[j]["pretvnodeindex"].ToString() + "' and tvnodetypeid=" + tvnodetypeid + " )  where tvnodeid=" + update_tvnodeid + "");
                }
            }

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                 array.Add("tvnodetypeid为:" + tvnodetypeid + ",更新申请书成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",更新申请书失败" + "\r\n");
                return false;
            }



        }

        public DataTable getTvnodeOrderByAnnexno(string tvnodetypeid)
        {
            string sqlcmd = @"SELECT tvnodeid, tvnodename,  annexno
                      FROM T_CASECONTENT_NODES t
                     WHERE TVNODETYPEID = " + tvnodetypeid + " and eventtype = 1 and contextmenuid = 3  ORDER BY annexno, tvnodeid";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }

        public Boolean isAnnexnoExist(string tvnodetypeid, string annexno)
        {

            string sqlcmd = @"SELECT tvnodeid, tvnodename,  annexno
                      FROM T_CASECONTENT_NODES t
                     WHERE TVNODETYPEID = " + tvnodetypeid + " and eventtype = 1 and contextmenuid = 3 and annexno='" + annexno + "'";

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

        public string isBlankAnnexnoExist(string tvnodetypeid)
        {
            string sqlcmd = @"SELECT tvnodeid, tvnodename,  annexno
                      FROM T_CASECONTENT_NODES t
                     WHERE TVNODETYPEID = " + tvnodetypeid + " and eventtype = 1 and contextmenuid = 3 and annexno is null ";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["tvnodeid"].ToString();
            }
            else
            {
                return "";
            }

        }
        /// <summary>
        /// 更新空白的annexno
        /// </summary>
        /// <param name="tvnodeid"></param>
        /// <param name="annexno">需要更新的annexno</param>
        /// <returns></returns>
        public Boolean editBlankAnnexno(string tvnodeid, string annexno, string pretvnodeid, string tvnodeindex,List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            string sqlcmd = @"SELECT tvnodeid,tvnodename, tvnodeindex  FROM T_CASECONTENT_NODES WHERE tvnodeid =" + tvnodeid;
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);

            if (dt != null && dt.Rows.Count > 0)
            {
                sqlcmdLst.Add(@"update  T_CASECONTENT_NODES set annexno='" + annexno + "',prenodeid='" + pretvnodeid + "',tvnodeindex=" + tvnodeindex + "  where tvnodeid='" + tvnodeid + "'");
            }

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodeid为:" + tvnodeid + ",更新了空白annexno为:" + annexno + ",设置父节点，排序 成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodeid为:" + tvnodeid + ",更新了空白annexno为:" + annexno + ",设置父节点，排序失败" + "\r\n");
                return false;
            }


        }

        //添加新的 annnexno节点，带父节点id 和  排序
        public Boolean addNewTvnodeWithAnnexno(string tvnodetypeid, string annexno, string prenodeid, string tvnodeindex,List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"insert into T_CASECONTENT_NODES (tvnodeid,tvnodename,contextmenuid,eventtype,tvnodetypeid,annexno,prenodeid,tvnodeindex) values ( (select nvl(max(tvnodeid),0)+1 from t_casecontent_nodes),'',3,1," + tvnodetypeid + "," + annexno + "," + prenodeid + "," + tvnodeindex + ")");

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",新增一个了annexno为:" + annexno + "的记录成功,并设置了父节点和排序" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",新增一个了annexno为:" + annexno + "的记录失败" + "\r\n");
                return false;
            }

        }

        //添加新的 annnexno节点，不带父节点id 和  排序
        public Boolean addNewTvnodeWithAnnexnoInBlankPretvnodeid(string tvnodetypeid, string annexno,List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"insert into T_CASECONTENT_NODES (tvnodeid,tvnodename,contextmenuid,eventtype,tvnodetypeid,annexno,prenodeid) values ( (select nvl(max(tvnodeid),0)+1 from t_casecontent_nodes),'',3,1," + tvnodetypeid + "," + annexno + ",'')");

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",新增一个了空白父节点的 annexno为:" + annexno + "的记录成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",新增一个了空白父节点的 annexno为:" + annexno + "的记录失败" + "\r\n");
                return false;
            }

        }

        public string getMaxAnnexnoTvnodeid(string tvnodetypeid)
        {
            string sqlcmd = @"SELECT tvnodeid,tvnodename, tvnodeindex  FROM T_CASECONTENT_NODES WHERE  tvnodetypeid=" + tvnodetypeid + " and annexno =999 ";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);

            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["tvnodeid"].ToString();
            }
            else
            {
                sqlcmd = @"SELECT tvnodeid,tvnodename, tvnodeindex  FROM T_CASECONTENT_NODES WHERE  tvnodetypeid=" + tvnodetypeid + " and annexno =(select max(annexno) from t_casecontent_nodes where tvnodetypeid=" + tvnodetypeid + ") ";
                qb = new QueryBuilder(sqlcmd);
                dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["tvnodeid"].ToString();
                }
                else
                {
                    return "";

                }
            }

        }

        public Boolean deleteTvnode(string tvnodeid,List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"delete from t_casecontent_nodes where tvnodeid=" + tvnodeid);

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodeid为:" + tvnodeid + ",删除成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodeid为:" + tvnodeid + ",删除失败" + "\r\n");
                return false;
            }

        }


        public Boolean cleanTvnode(string tvnodeid,List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"update t_casecontent_nodes set annexno=''  where tvnodeid=" + tvnodeid);

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodeid为:" + tvnodeid + ",清空成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodeid为:" + tvnodeid + ",清空失败" + "\r\n");
                return false;
            }

        }


    }
}
