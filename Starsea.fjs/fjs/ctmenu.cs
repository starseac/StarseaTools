using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System.Data;
using System.Collections;

namespace Starsea.Egov.fjs
{
    public class ctmenu
    {
        public DataTable getCtmenu(string ctmenuid)
        {
            string sqlcmd = @"SELECT * FROM T_CASECONTENT_CTMENU WHERE CTMENUID='" + ctmenuid + "'";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);

            return dt;
        }


        public DataTable getReapetCtmenuToTvclass()
        {
            string sqlcmd = @"select t.*,substr(ctparem,
                              instr(ctparem, ';', 1, 5) + 1,
                              length(ctparem) - instr(ctparem, ';', 1, 5)) tvnodetypeid from t_casecontent_ctmenuitem t where ctnodeid=1";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        
        }

        public DataTable getCtmenuitem(string ctmenuid)
        {
            string sqlcmd = @"SELECT * FROM T_CASECONTENT_CTMENUITEM WHERE CTMENUID='" + ctmenuid + "'  order by cttpindex";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }

        public string[] getCtmenuChildNodeParamare(string ctmenuid)
        {
            string sqlcmd = @"SELECT ctparem FROM T_CASECONTENT_CTMENUITEM WHERE CTMENUID='" + ctmenuid + "' AND CTNODEID=1";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            string eventString = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                eventString = dt.Rows[0]["ctparem"].ToString();
            }
            string[] eventParam = new string[6];
            if (eventString.Length > 0)
            {

                eventParam = eventString.Split(';');
            }
            return eventParam;
        }


        /// <summary>
        /// 获取 要点击添加的附件树
        /// </summary>
        /// <param name="menuid"></param>
        /// <returns></returns>
        public DataTable getChildNodeTvclass(string menuid)
        {

            string[] eventParam = this.getCtmenuChildNodeParamare(menuid);
            string childNodeid = eventParam[5];
            tvclass tvclass = new tvclass();
            DataTable childNodeTvclass = tvclass.getTvclassByTvnodetypeid(childNodeid);
            return childNodeTvclass;

        }

        List<int> list = new List<int>();

        public List<int> getAllChildNodeidList()
        {
            return list;

        }

        public DataTable getAllChildNodeid(string tvnodetypeid)
        {
            //如果已近包含了该附件树id就跳过
            if (list.Contains(Convert.ToInt32(tvnodetypeid)))
            {
                return null;
            }

            string sqlcmd = @"select substr(ctparem,
                              instr(ctparem, ';', 1, 5) + 1,
                              length(ctparem) - instr(ctparem, ';', 1, 5)) tvnodetypeid
                              from t_casecontent_ctmenuitem
                             where ctnodeid = 1
                               and ctmenuid in (select distinct contextmenuid
                                                  from t_casecontent_nodes
                                                 where tvnodetypeid = '" + tvnodetypeid + @"'
                                                   and contextmenuid is not null
                                                   and contextmenuid != 3                    
                                                )
                             order by ctmenuid, cttpindex";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (list.Contains( Convert.ToInt32( dt.Rows[i]["tvnodetypeid"])))
                    {
                        continue;
                    }
                    getAllChildNodeid(dt.Rows[i]["tvnodetypeid"].ToString());
                    list.Add(Convert.ToInt32(dt.Rows[i]["tvnodetypeid"]));
                }
            }

            return dt;

        }
        /// <summary>
        /// 按extend nodetype的依赖先后顺序排列
        /// </summary>
        /// <param name="old"></param>
        /// <param name="export"></param>
        public void setUpdateNotetypeExtendOrder(List<int> old, List<int> export)
        { 
                //先 把要导出的nodetype中 没有子ctemenu的加到 导出序列export中
            List<int> tempList = new List<int>();  

                foreach(int oldobj in old){
                    if(!hasChildNode(oldobj)){
                        export.Add(oldobj);
                        tempList.Add(oldobj);
                    }                
                }
                foreach(int obj in tempList){
                    old.Remove(obj);                
                }
                tempList.Clear();

             // 把剩下的有子ctemenu的 加到export中，保证其插入的位置之前 其所有的子节点都在前面
                while (old.Count > 0) {
                    foreach (int oldobj in old)
                    {
                        List<int> extendNodeList = getChildNodeList(oldobj);
                         int hasContainNum = 0;
                         for (int i = 0; i < extendNodeList.Count;i++ )
                         {
                             if (export.Contains(extendNodeList.ToArray()[i])){
                                 hasContainNum += 1;
                             }
                             else
                             {
                                 break;
                             }

                         }
                 
                          if(hasContainNum ==extendNodeList.Count) {
                             export.Add(oldobj);
                             tempList.Add(oldobj);            
                         }             
                     }
                    foreach (int obj in tempList)
                    {
                        old.Remove(obj);
                    }
                    tempList.Clear();

                }

        
        }
       /// <summary>
       /// 获取该节点的子节点
       /// </summary>
       /// <param name="tvnodetypeid"></param>
       /// <returns></returns>
        private List<int> getChildNodeList(int tvnodetypeid){
            List<int> childNodes = new List<int>(); 

            string sqlcmd = @"select substr(ctparem,
                              instr(ctparem, ';', 1, 5) + 1,
                              length(ctparem) - instr(ctparem, ';', 1, 5)) tvnodetypeid
                              from t_casecontent_ctmenuitem
                             where ctnodeid = 1
                               and ctmenuid in (select distinct contextmenuid
                                                  from t_casecontent_nodes
                                                 where tvnodetypeid = '" + tvnodetypeid + @"'
                                                   and contextmenuid is not null
                                                   and contextmenuid != 3                    
                                                )
                             order by ctmenuid, cttpindex";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    childNodes.Add(Convert.ToInt32(dt.Rows[i]["tvnodetypeid"].ToString()));
                }
            }

            return childNodes;
        }
        /// <summary>
        /// 看节点是否有子节点
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <returns></returns>
        private bool hasChildNode(int tvnodetypeid)
        {
           List<int> allChildNodes= getChildNodeList(tvnodetypeid);
           if (allChildNodes.Count == 0)
           {
               return false;
           }
           else {
               return true;
           }
        }


        /// <summary>
        /// 导出是替换后的参数
        /// </summary>
        /// <param name="menuid"></param>
        /// <returns></returns>
        public string getChildNodeExportString(string menuid)
        {
            string[] eventParam = this.getCtmenuChildNodeParamare(menuid);
            string childnodeTvclass = this.getChildNodeTvclass(menuid).Rows[0]["tvclass"].ToString();
            //替换tvnodetypeid为tvclass name
            string newString = eventParam[0] + ";" + eventParam[1] + ";" + eventParam[2] + ";" + eventParam[3] + ";" + eventParam[4] + ";" + childnodeTvclass;

            return newString;
        }



        public string getCtmenuIDbyTargetTvnodetypeid(string tvnodetypeid)
        {
            string sqlcmd = @"select ctmenuid from (
                                select t.*,
                                       substr(ctparem,
                                              instr(ctparem, ';', 1, 5) + 1,
                                              length(ctparem) - instr(ctparem, ';', 1, 5)) tvnodetypeid
                                  from t_casecontent_ctmenuitem t
                                 where ctnodeid = 1) t
                                 where t.tvnodetypeid = "+tvnodetypeid;

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ctmenuid"].ToString();

            }
            else {
                return "";
            }
        }

        public DataTable getCtmenuTargetTvclass(string ctmenuid)
        {
           return this.getChildNodeTvclass(ctmenuid);
        }
        /// <summary>
        /// 看 tvclass 是否已近有对应的ctemenu
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <returns></returns>
        public bool isCtmenuForTvclassExist(string tvnodetypeid)
        {
            return false;
        }


        public string getMaxCtmenuid() {
            string sqlcmd = @"select nvl(max(ctmenuid),0) ctmenuid from  t_casecontent_ctmenu";
            string ctmenuid = "0";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                ctmenuid=dt.Rows[0]["ctmenuid"].ToString();

            }

            return ctmenuid;          
        
        }
        public string getNewCtmenuid() {
            return Convert.ToInt32(getMaxCtmenuid()) + 1+"";
        
        }

        public void addCtmenuAndItemForTvclass(string tvnodetypeid, DataTable dv_ctmenu, DataTable dv_ctmenuitem,List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();
            string ctmenuid=getNewCtmenuid();
            string menuname=dv_ctmenu.Rows[0]["menuname"].ToString();
            string targettvclass=dv_ctmenu.Rows[0]["tartgettvclass"].ToString();
            //添加ctmenu 名称
            sqlcmdLst.Add(@"insert into T_CASECONTENT_ctmenu(ctmenuid,menuname) values('"+ctmenuid+"','"+menuname+"'");

            if(dv_ctmenuitem!=null&&dv_ctmenuitem.Rows.Count>0){

                for (int i = 0; i < dv_ctmenuitem.Rows.Count;i++ )
                {
                    string ctnodeid = dv_ctmenuitem.Rows[i]["ctnodeid"].ToString();
                    string ctname = dv_ctmenuitem.Rows[i]["ctname"].ToString();
                    string enable = dv_ctmenuitem.Rows[i]["enable"].ToString();
                    string cttpindex = dv_ctmenuitem.Rows[i]["cttpindex"].ToString();
                    string ctparem = dv_ctmenuitem.Rows[i]["ctparem"].ToString();
                    //插入菜单记录
                    sqlcmdLst.Add(@"insert into t_casecontent_ctmenuitem(ctmenuid,ctnodeid,ctname,enable,cttpindex,ctparem)values('"+ctmenuid+"','"+ctnodeid+"','"+ctname+"','"+enable+"','"+cttpindex+"','"+ctparem+"')");

                }
            
            }
            //替换tvclass 为 tvnodetypeid
            sqlcmdLst.Add(@"update t_casecontent_ctmenuitem set ctparem=replace(ctparem,'" + targettvclass + "','" + tvnodetypeid + "') where ctmenuid='" + ctmenuid + "' ");
            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodetypeid为:" + tvnodetypeid + "tvclass为" + targettvclass + ",添加ctmenu ctmenuitem成功" + "\r\n");
                

            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + "tvclass为" + targettvclass + ",添加ctmenu ctmenuitem失败" + "\r\n");
                
            }
            
        }

        public void updateCtmenuAndItemForTvclass(string tvnodetypeid, DataTable dv_ctmenu, DataTable dv_ctmenuitem,List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();
            string ctmenuid = getCtmenuIDbyTargetTvnodetypeid(tvnodetypeid);
            string menuname = dv_ctmenu.Rows[0]["menuname"].ToString();
            string targettvclass = dv_ctmenu.Rows[0]["tartgettvclass"].ToString();
            //更新ctmenu 名称
            sqlcmdLst.Add(@"update  T_CASECONTENT_ctmenu set menuname='" + menuname + "' where ctmenuid='"+ctmenuid+"' ");

            if (dv_ctmenuitem != null && dv_ctmenuitem.Rows.Count > 0)
            {

                for (int i = 0; i < dv_ctmenuitem.Rows.Count; i++)
                {
                   
                    string ctnodeid = dv_ctmenuitem.Rows[i]["ctnodeid"].ToString();
                    string ctname = dv_ctmenuitem.Rows[i]["ctname"].ToString();
                    string enable = dv_ctmenuitem.Rows[i]["enable"].ToString();
                    string cttpindex = dv_ctmenuitem.Rows[i]["cttpindex"].ToString();
                    string ctparem = dv_ctmenuitem.Rows[i]["ctparem"].ToString();

                    sqlcmdLst.Add(@"update t_casecontent_ctmenuitem set ctnodeid='"+ctnodeid+"',ctname='"+ctname+"',enable='"+enable+"',ctparem='"+ctparem+"' where  cttpindex='"+cttpindex+"' and ctmenuid='"+ctmenuid+"'");

                }

            }
            //替换tvclass 为 tvnodetypeid
            sqlcmdLst.Add(@"update t_casecontent_ctmenuitem set ctparem=replace(ctparem,'" + targettvclass + "','" + tvnodetypeid + "') where ctmenuid='" + ctmenuid + "' ");
            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodetypeid为:" + tvnodetypeid + "tvclass为" + targettvclass + ",更新ctmenu ctmenuitem成功" + "\r\n");


            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + "tvclass为" + targettvclass + ",更新ctmenu ctmenuitem失败" + "\r\n");

            }

           
        }
    }
}
