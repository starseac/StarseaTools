using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.fjs
{
    public class pretvnode
    {

        public DataTable getPreTvnode(string tvnodetypeid)
        {
            // string sqlcmd = @"SELECT tvnodeid,tvnodename,contextmenuid,tvnodeindex FROM T_CASECONTENT_NODES   WHERE TVNODETYPEID =" + tvnodetypeid + "  and eventtype=0  and prenodeid = '-1'  ORDER BY TVNODEINDEX";
            string sqlcmd = @"SELECT tvnodeid,tvnodename,contextmenuid,tvnodeindex,eventtype,tvnodeurl FROM T_CASECONTENT_NODES   WHERE TVNODETYPEID =" + tvnodetypeid + "   and prenodeid = '-1'  ORDER BY TVNODEINDEX";


            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }


        public DataTable getPreTvnodeByTvnodeindex(string tvnodetypeid, string tvnodeindex)
        {
            string sqlcmd = @"SELECT tvnodeid,tvnodename,tvnodeindex FROM T_CASECONTENT_NODES   WHERE TVNODETYPEID =" + tvnodetypeid + " and tvnodeindex='" + tvnodeindex + "'  and eventtype=0  and prenodeid = '-1'  ORDER BY TVNODEINDEX";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }

        /// <summary>
        /// 添加一个新的父节点
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <param name="eventtype"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public Boolean addNewPreTvnode(string tvnodetypeid, string eventtype, List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();
            sqlcmdLst.Add(@"insert into T_CASECONTENT_NODES (tvnodeid,tvnodename,eventtype,prenodeid,tvnodetypeid) values( (select nvl(max(tvnodeid),0)+1 from t_casecontent_nodes),''," + eventtype + ",-1," + tvnodetypeid + ")");


            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",添加新的附件父目录,类型为" + eventtype + "成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",添加新的附件父目录失败" + "\r\n");
                return false;
            }

        }
        /// <summary>
        /// 删除最大的父节点
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public Boolean deletePreTvnode(string tvnodetypeid, List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();

            // string sqlcmd = @"SELECT tvnodeid,tvnodename, tvnodeindex  FROM T_CASECONTENT_NODES WHERE TVNODETYPEID =" + tvnodetypeid + "    and prenodeid = '-1'   and tvnodeid not in (SELECT prenodeid  FROM T_CASECONTENT_NODES   WHERE TVNODETYPEID =" + tvnodetypeid + "  and eventtype = 2) ORDER BY tvnodeid desc";
            string sqlcmd = @"SELECT tvnodeid,tvnodename, tvnodeindex  FROM T_CASECONTENT_NODES WHERE TVNODETYPEID =" + tvnodetypeid + "    and prenodeid = '-1'   and tvnodeid = (SELECT max(tvnodeid)  FROM T_CASECONTENT_NODES   WHERE TVNODETYPEID =" + tvnodetypeid + "  and prenodeid = -1)";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            string del_tvnodeid = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                del_tvnodeid = dt.Rows[0]["tvnodeid"].ToString();
            }

            sqlcmdLst.Add(@"delete from T_CASECONTENT_NODES where tvnodeid='" + del_tvnodeid + "'");
            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",删除一个附件父目录tvnodeid=" + del_tvnodeid + "成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",删除一个附件父目录tvnodeid=" + del_tvnodeid + "失败" + "\r\n");
                return false;
            }

        }
        /// <summary>
        /// 给父级目录排序 更新名称, 设置 eventtype,url
        /// </summary>
        /// <param name="xml_dt"></param>
        /// <param name="tvnodetypeid"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public Boolean sortPretvnodeAndRename(DataTable xml_dt, string tvnodetypeid, List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            string sqlcmd = @"SELECT tvnodeid,tvnodename,eventtype,TVNODEURL,tvnodeindex  FROM T_CASECONTENT_NODES WHERE TVNODETYPEID =" + tvnodetypeid + "  and prenodeid = '-1'  ORDER BY tvnodeid";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            string update_tvnodeid = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                int i = dt.Rows.Count;
                for (int j = 0; j < i; j++)
                {
                    update_tvnodeid = dt.Rows[j]["tvnodeid"].ToString();
                    sqlcmdLst.Add(@"update T_CASECONTENT_NODES set tvnodename='" + xml_dt.Rows[j]["name"].ToString() + "'eventtype='" + xml_dt.Rows[j]["eventtype"].ToString() + "',TVNODEURL='" + xml_dt.Rows[j]["TVNODEURL"].ToString() + "' ,tvnodeindex='" + xml_dt.Rows[j]["tvnodeindex"].ToString() + "' where tvnodeid=" + update_tvnodeid + "");
                }
            }

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",更新附件父目录名称、eventtype、url和排序号成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",更新附件父目录名称、eventtype、url和排序号失败" + "\r\n");
                return false;
            }

        }
       /// <summary>
       /// 检查父目录的 序号和 名称
       /// </summary>
       /// <param name="xml_dt"></param>
       /// <param name="tvnodetypeid"></param>
       /// <param name="array"></param>
       /// <returns></returns>
        public Boolean checkPretvnodeIndexAndName(DataTable xml_dt, string tvnodetypeid, List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            int errNum = 0;

            if (xml_dt != null && xml_dt.Rows.Count > 0)
            {
                int i = xml_dt.Rows.Count;
                for (int j = 0; j < i; j++)
                {
                    string xml_tvnodeindex = xml_dt.Rows[j]["tvnodeindex"].ToString();
                    string xml_tvnodename = xml_dt.Rows[j]["tvnodename"].ToString();

                    string sqlcmd = @"SELECT count(*)  FROM T_CASECONTENT_NODES WHERE TVNODETYPEID =" + tvnodetypeid + "  and prenodeid = '-1' and tvnodeindex='" + xml_tvnodeindex + "' and  tvnodename='" + xml_tvnodename + "'  ORDER BY tvnodeid";

                    QueryBuilder qb = new QueryBuilder(sqlcmd);
                    DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        errNum += 1;
                        array.Add("tvnodetypeid为:" + tvnodetypeid + ",找不到tvnodeindex为" + xml_tvnodeindex + " 、名称为" + xml_tvnodename + "的父目录\r\n");
                    }

                }
            }
            if (errNum > 0)
            {
                return false;
            }

            else
            {
                return true;

            }

        }
        /// <summary>
        /// 检查 父目录的 eventtype  和 url
        /// </summary>
        /// <param name="xml_dt"></param>
        /// <param name="tvnodetypeid"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public Boolean checkPretvnodeEventtype(DataTable xml_dt, string tvnodetypeid, List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            int errNum = 0;

            if (xml_dt != null && xml_dt.Rows.Count > 0)
            {
                int i = xml_dt.Rows.Count;
                for (int j = 0; j < i; j++)
                {
                    string xml_tvnodeindex = xml_dt.Rows[j]["tvnodeindex"].ToString();
                    string xml_tvnodename = xml_dt.Rows[j]["tvnodename"].ToString();
                    string xml_eventtype = xml_dt.Rows[j]["eventtype"].ToString();
                    string xml_tvnodeurl = xml_dt.Rows[j]["tvnodeurl"].ToString();

                    string sqlcmd = @"SELECT count(*)  FROM T_CASECONTENT_NODES WHERE TVNODETYPEID =" + tvnodetypeid + "  and prenodeid = '-1' and tvnodeindex='" + xml_tvnodeindex + "' and  tvnodename='" + xml_tvnodename + "' and  eventtype='" + xml_eventtype + "' and  tvnodeurl='" + xml_tvnodeurl + "'  ORDER BY tvnodeid";

                    QueryBuilder qb = new QueryBuilder(sqlcmd);
                    DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        errNum += 1;
                        array.Add("tvnodetypeid为:" + tvnodetypeid + ",tvnodename为" + xml_tvnodename + " 的eventtype和tvnodeurl 设置有问题\r\n");
                    }

                }
            }
            if (errNum > 0)
            {
                return false;
            }

            else
            {
                return true;

            }



        }

        /// <summary>
        /// 获取纯父目录，没有时间的
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <returns></returns>
        public DataTable getPretvnodeWithNoEventtype(string tvnodetypeid)
        {
            string sqlcmd = @"SELECT tvnodeid,tvnodename,eventtype,url,tvnodeindex  FROM T_CASECONTENT_NODES WHERE TVNODETYPEID =" + tvnodetypeid + "  and prenodeid = '-1' and eventype='0' and url is null  ORDER BY tvnodeid";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }
        /// <summary>
        /// 获取带事件的父目录
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <returns></returns>
        public DataTable getPretvnodeWithEventtype(string tvnodetypeid)
        {
            string sqlcmd = @"SELECT tvnodeid,tvnodename,eventtype,url,tvnodeindex  FROM T_CASECONTENT_NODES WHERE TVNODETYPEID =" + tvnodetypeid + "  and prenodeid = '-1' and eventype!='0'   ORDER BY tvnodeid";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }
        /// <summary>
        /// 判断是否所有的父节点都是 纯父节点
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <returns></returns>
        public bool isAllPretvnodeWithNoEventtype(string tvnodetypeid)
        {
            int a = getPreTvnode(tvnodetypeid) != null ? getPreTvnode(tvnodetypeid).Rows.Count : 0;
            int b = getPretvnodeWithNoEventtype(tvnodetypeid) != null ? getPretvnodeWithNoEventtype(tvnodetypeid).Rows.Count : 0;

            if (a - b == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新父节点的contentmenuid
        /// </summary>
        /// <param name="tvnodetypeid">要处理的tvnodetypeid</param>
        /// <param name="dt_pretvnode">配置文件里的 父节点</param>
        public void setContentmenu(string tvnodetypeid, DataTable dt_pretvnode)
        {
            ctmenu ctmenu = new ctmenu();
            // 获取要设置 contenntxmenuid 的 pretvnode 
            // 检查是否有 对应到该类型的 ctmenu，没有则提示错误，跳过 改pretvnode，继续下一个，有就获取改ctemuid的id，并更新上去
            if (dt_pretvnode != null && dt_pretvnode.Rows.Count > 0)
            {
                for (int i = 0; i < dt_pretvnode.Rows.Count; i++)
                {
                    string tvnodeindex = dt_pretvnode.Rows[i]["tvnodeindex"].ToString();
                    string eventtype = dt_pretvnode.Rows[i]["eventtype"].ToString();
                    string targettvclass = dt_pretvnode.Rows[i]["targettvclass"].ToString();
                    if (targettvclass != "")
                    {
                        string updateCtmenuid = ctmenu.getCtmenuTargetTvclass(targettvclass).Rows[0]["tvclass"].ToString();

                        string sql = "update t_casecontent_nodes set CONTEXTMENUID=" + updateCtmenuid + " where tvnodetypeid='" + tvnodetypeid + "' and prenodeid='-1' and tvnodeindex='" + tvnodeindex + "' and eventtype='" + eventtype + "' ";
                    }
                }

            }


        }
    }
}
