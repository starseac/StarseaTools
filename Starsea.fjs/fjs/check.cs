using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.fjs
{
    public class check
    {
        tvclass tvclassT = new tvclass();
        pretvnode pretvnodeT = new pretvnode();
        tvnode tvnodeT = new tvnode();
        public Boolean checkFJS(string exportType,List<string> array)
        {
            Boolean res = true;
            tvclass tvclass = new tvclass();
            pretvnode pretvnode = new pretvnode();
            DataTable dt_tvclass = tvclass.getTvclass(exportType);
            int count = dt_tvclass.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                string tvnodetypeid = dt_tvclass.Rows[i]["tvnodetypeid"].ToString();
                string typename = dt_tvclass.Rows[i]["typename"].ToString();
                // 检查 父目录  排序 是否为空 有重复的
                DataTable dt_prenode = pretvnode.getPreTvnode(tvnodetypeid);
                if (isPreNodeIndexRepeat(tvnodetypeid,array))
                {
                    res = false;
                }
                //检查父目录 eventype类型是否正确
                if (isPreNodeEventtypeRight(tvnodetypeid,array))
                {
                    res = false;
                }

                for (int j = 0; j < dt_prenode.Rows.Count; j++)
                {
                    // 检查 每隔父目录下 是否有重复的annexno，或空的annexno
                    if (this.isAnnexnoUnderPreNodeRepeat(tvnodetypeid, dt_prenode.Rows[j]["tvnodeid"].ToString(),array))
                    {
                        res = false;
                    }
                }

            }
            return res;


        }


        protected void CheckFJS(DataTable xml_nodetype, string type, DataTable xml_pretvnode, DataTable xml_ctmenu, DataTable xml_ctmenuitem, DataTable xml_tvnodepage, DataTable xml_tvnode, List<string> array)
        {
            if (xml_nodetype != null && xml_nodetype.Rows.Count >= 1)
            {

                for (int i = 0; i < xml_nodetype.Rows.Count; i++)
                {
                    //获取xml tvclass
                    string tvclass = xml_nodetype.Rows[i]["tvclass"].ToString();
                    string tvclassname = xml_nodetype.Rows[i]["name"].ToString();
                    string tvclassuptvnodetypeid = xml_nodetype.Rows[i]["uptvnodetypeid"].ToString();
                    string tvnodetypeid = "";

                    string selectType = "";
                    if (type == "1")
                    {
                        selectType = "nodetype_id";

                    }
                    else
                    {
                        selectType = "nodetype_extend_id";
                    }

                    string nodetype_id = xml_nodetype.Rows[i][selectType].ToString();


                    DataTable dt_tvclass = tvclassT.getTvclassByTvclassName(tvclass);
                    if (dt_tvclass != null && dt_tvclass.Rows.Count == 1)
                    {
                        tvnodetypeid = dt_tvclass.Rows[0]["tvnodetypeid"].ToString();
                    }
                    else
                    {
                        //找不到对应的tvclass 就在数据库中添加一条该类型的tvclass,然后退出该tvclas的检查
                        array.Add("数据库t_casecontent_nodetype表里找不到tvclass为:" + tvclass + "附件类型名称为:" + tvclassname + "的附件目录" + "\r\n");
                        array.Add("数据库t_casecontent_nodetype表里tvclass为:" + tvclass + "附件类型名称为:" + tvclassname + "的附件目录" + "检查结束!\r\n");
                        return;
                       

                    }                  

                    // 3查找父目录
                    DataTable dt_pretvnode = pretvnodeT.getPreTvnode(tvnodetypeid);
                    int dt_pretvnode_count = dt_pretvnode.Rows.Count;

                    //4 比较父级目录  检查 父目录的个数  名称  排序 

                    DataTable dv_pretvnode = new DataTable();
                    dv_pretvnode = xml_pretvnode.Clone();
                    System.Data.DataRow[] dv_pretvnod_row = xml_pretvnode.Select(selectType + "=" + nodetype_id);
                    for (int j = 0; j < dv_pretvnod_row.Length; j++)
                    {
                        dv_pretvnode.ImportRow((System.Data.DataRow)dv_pretvnod_row[j]);
                    }
                    int dv_pretvnode_count = dv_pretvnode.Rows.Count;

                    //少父目录
                    if (dv_pretvnode_count - dt_pretvnode_count >= 1)
                    {
                        int less_count = dv_pretvnode_count - dt_pretvnode_count;
                        //少了几个
                        array.Add("数据库tvclass为:" + tvclass + "附件父目录少了:" + less_count + "个!\r\n");
                        array.Add("数据库t_casecontent_nodetype表里tvclass为:" + tvclass + "附件类型名称为:" + tvclassname + "的附件目录" + "检查结束!\r\n");
                        return;

                    }
                    else if (dv_pretvnode_count - dt_pretvnode_count < 0)
                    {
                        int less_count = dt_pretvnode_count - dv_pretvnode_count;
                       
                        //多了几个
                        array.Add("数据库tvclass为:" + tvclass + "附件父目录多了:" + less_count + "个!\r\n");
                        array.Add("数据库t_casecontent_nodetype表里tvclass为:" + tvclass + "附件类型名称为:" + tvclassname + "的附件目录" + "检查结束!\r\n");
                        return;
                    }

                    //6 检查父级目录排序 、名称、eventtype、url
                    dt_pretvnode = pretvnodeT.getPreTvnode(tvnodetypeid);
                    dt_pretvnode_count = dt_pretvnode.Rows.Count;

                    if (dv_pretvnode_count - dt_pretvnode_count == 0)
                    {
                       // 检查父级目录排序 、名称
                       bool res1= pretvnodeT.checkPretvnodeIndexAndName(dv_pretvnode, tvnodetypeid, array);
                       if (res1 == false)
                       {
                           return;
                       }
                       else {
                           //eventtype、url
                           pretvnodeT.checkPretvnodeEventtype(dv_pretvnode, tvnodetypeid, array);
                       }
                       
                        
                    }

                    //处理contextmenuid
                    // 没有带 contentxmenuid的 父目录的 则跳过此步骤
                    if (!pretvnodeT.isAllPretvnodeWithNoEventtype(tvnodetypeid))
                    {
                        // 获取要设置 contenntxmenuid 的 pretvnode 
                        // 检查是否有 该类型的 ctmenu，没有则提示错误，跳过 改pretvnode，继续下一个，有就获取改ctemuid的id，并更新上去
                        //设置 弹出菜单
                        pretvnodeT.setContentmenu(tvnodetypeid, dv_pretvnode);
                    }

                    ////-------获取 对应的ctmenu ctmenuitem
                    //DataTable dv_ctmenu = new DataTable();
                    //dv_ctmenu = xml_ctmenu.Clone();
                    //System.Data.DataRow[] dv_ctmenu_row = xml_ctmenu.Select("targettvclass=" + tvclass);
                    //for (int j = 0; j < dv_pretvnod_row.Length; j++)
                    //{
                    //    dv_ctmenu.ImportRow((System.Data.DataRow)dv_ctmenu_row[j]);
                    //}
                    //string dv_ctmenuid = dv_ctmenu.Rows[0]["ctmenu_Id"].ToString();

                    //DataTable dv_ctmenuitem = new DataTable();
                    //dv_ctmenuitem = xml_ctmenuitem.Clone();
                    //System.Data.DataRow[] dv_ctmenuitem_row = xml_ctmenuitem.Select("ctmenu_Id=" + dv_ctmenuid);
                    //for (int j = 0; j < dv_ctmenuitem_row.Length; j++)
                    //{
                    //    dv_ctmenuitem.ImportRow((System.Data.DataRow)dv_ctmenuitem_row[j]);
                    //}

                    ////设置对改 类型的ctmenu  如果 extend_tvclas 没有对应的ctmenu 就按照
                    //if (type == "1")
                    //{
                    //    if (!ctmenu.isCtmenuForTvclassExist(tvnodetypeid))
                    //    {
                    //        ctmenu.addCtmenuAndItemForTvclass(tvnodetypeid, dv_ctmenu, dv_ctmenuitem, array);
                    //    }
                    //    else
                    //    {
                    //        ctmenu.updateCtmenuAndItemForTvclass(tvnodetypeid, dv_ctmenu, dv_ctmenuitem, array);

                    //    }

                    //}


                    //处理申请书、子级页面栏目
                    DataTable dt_tvnodepage = tvnodeT.getTvnodePage(tvnodetypeid);
                    DataTable dv_tvnodepage = new DataTable();
                    dv_tvnodepage = xml_tvnodepage.Clone();
                    System.Data.DataRow[] dv_tvnodepage_row = xml_tvnodepage.Select("nodetype_id=" + nodetype_id);
                    for (int j = 0; j < dv_tvnodepage_row.Length; j++)
                    {
                        dv_tvnodepage.ImportRow((System.Data.DataRow)dv_tvnodepage_row[j]);
                    }

                    int dv_tvnodepage_count = dv_tvnodepage.Rows.Count;

                    //没有申请表则添加，
                    if (!tvnodeT.isTvnodePageExist(tvnodetypeid))
                    {
                       // tvnodeT.addNewTvnodePage(tvnodetypeid, array);
                    }
                  

                    //8 检查自对应父母下的 子目录  检查 annexno  name 顺序 ,
                    DataTable dv_tvnode = new DataTable();
                    dv_tvnode = xml_tvnode.Clone();
                    System.Data.DataRow[] dv_tvnode_row = xml_tvnode.Select(selectType + "=" + nodetype_id);
                    for (int j = 0; j < dv_tvnode_row.Length; j++)
                    {
                        dv_tvnode.ImportRow((System.Data.DataRow)dv_tvnode_row[j]);
                    }

                    int dv_tvnode_count = dv_tvnode.Rows.Count;

                    if (dv_tvnode != null && dv_tvnode_count > 0)
                    {
                        this.checkTvnode(dv_tvnode, tvnodetypeid, array);
                    }


                   
                    array.Add("tvnodetypeid为:" + tvnodetypeid + "附件类型名称为\"" + tvclassname + "\"的数配置检查完成" + "\r\n");
                    array.Add("-------------------------------------------------" + "\r\n");

                }

            }

        }

        private void checkTvnode(DataTable dv_tvnode, string tvnodetypeid, List<string> array)
        {
           
        }


        public void checkFJSbyXML(DataSet ds,List<string>array) {
            DataTable xml_nodetype = ds.Tables["nodetype"];
            DataTable xml_pretvnode = ds.Tables["pretvnode"];
            DataTable xml_tvnodepage = ds.Tables["tvnodepage"];
            DataTable xml_tvnode = ds.Tables["tvnode"];

            DataTable xml_nodetype_extend = ds.Tables["nodetype_extend"];
            DataTable xml_ctmenu = ds.Tables["ctmenu"];
            DataTable xml_ctmenuitem = ds.Tables["ctmenuitem"];


            tvclass tvclassF = new tvclass();
            pretvnode pretvnodeF = new pretvnode();
            tvnode tvnodeF = new tvnode();
            //更新 子附件数     
            if (xml_nodetype_extend != null && xml_nodetype_extend.Rows.Count >= 1)
            {
                //  按顺序更新                
                CheckFJS(xml_nodetype_extend, "", xml_pretvnode, xml_ctmenu, xml_ctmenuitem, xml_tvnodepage, xml_tvnode, array);

            }

            //更新附件树节点
            if (xml_nodetype != null && xml_nodetype.Rows.Count >= 1)
            {

                //for (int i = 0; i < xml_nodetype.Rows.Count; i++)
                //{
                CheckFJS(xml_nodetype, "1", xml_pretvnode, xml_ctmenu, xml_ctmenuitem, xml_tvnodepage, xml_tvnode, array);

              

            }     
        
        }


        // 父节点的 排序好 有重复的
        private Boolean isPreNodeIndexRepeat(string tvnodetypeid,List<string> array)
        {

            string sqlcmd = "SELECT * FROM T_CASECONTENT_NODES  WHERE TVNODETYPEID =" + tvnodetypeid + " AND PRENODEID =-1    AND EVENTTYPE =0   AND TVNODEINDEX IN  (SELECT TVNODEINDEX    FROM (SELECT TVNODEINDEX, COUNT(TVNODEINDEX) NUM  FROM T_CASECONTENT_NODES  WHERE TVNODETYPEID = " + tvnodetypeid + " AND PRENODEID = -1   AND EVENTTYPE =0  GROUP BY TVNODEINDEX)  T WHERE T.NUM > 1)";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                array.Add("tvnodetypeid为" + tvnodetypeid + "的父目录排序号有重复的");
                return true;

            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 看父节点 的 context 不为空的 eventtype是否为1 ，0的是否为空，，为2的 url是否有值
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <returns></returns>
        private Boolean isPreNodeEventtypeRight(string tvnodetypeid,List<string> array)
        {
            string sqlcmd = @"select *
                          from (SELECT tvnodeid,
                                       tvnodename,
                                       contextmenuid,
                                       tvnodeindex,
                                       eventtype,
                                       tvnodeurl,
                                       case
                                         when t.eventtype = 0 and t.contextmenuid is null then
                                          0
                                         when t.eventtype = 1 and t.contextmenuid is not null then
                                          0
                                         when t.eventtype = 2 and t.contextmenuid is null and
                                              t.tvnodeurl is not null then
                                          0
                                         else
                                          1
                                       end checkans
        
                                  FROM T_CASECONTENT_NODES t
                                 WHERE TVNODETYPEID =" + tvnodetypeid + @"
                                   and prenodeid = '-1'
                                 ORDER BY TVNODEINDEX)
                         where checkans = 1 ";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    array.Add("tvnodeid为" + dt.Rows[i]["tvnodeid"].ToString() + "名称为<font color='red'>" + dt.Rows[i]["tvnodename"].ToString() + "</font>的父目录eventtype和实际值不匹配" + "\r\n");
                }

                return true;
            }
            else
            {
                return false;
            }

        }


        //父节点下的 annexno 有 空的，或 重复的
        private Boolean isAnnexnoUnderPreNodeRepeat(string tvnodetypeid, string prenodeid,List<string> array)
        {

            string sqlcmd = @"SELECT *
                          FROM T_CASECONTENT_NODES
                         WHERE TVNODETYPEID =" + tvnodetypeid +
                              " AND PRENODEID =" + prenodeid +
                             " and contextmenuid = 3   AND EVENTTYPE = 1" +
                             " AND (annexno is null or annexno IN (SELECT annexno" +
                                              "   FROM (SELECT annexno, count(annexno) num " +
                                                    "     FROM T_CASECONTENT_NODES " +
                                                      "  WHERE TVNODETYPEID = " + tvnodetypeid +
                                                        "  AND PRENODEID = " + prenodeid +
                                                        "  and contextmenuid = 3   AND EVENTTYPE = 1   GROUP BY annexno) T  WHERE T.NUM != 1))";


            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {
                array.Add("tvnodetypeid为" + tvnodetypeid + "的父目录prenodeid为" + prenodeid + "的树目录annexno有重复的或有为空的");
                return true;

            }
            else
            {
                return false;
            }

        }

    }
}
