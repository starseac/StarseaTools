using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.fjs
{
  public  class update
    {
      tvnode tvnodeT = new tvnode();
      pretvnode pretvnodeT = new pretvnode();
      tvclass tvclassT = new tvclass();
      ctmenu ctmenu = new ctmenu();


        protected Boolean updateFJtoNewTvnodeid(string oldtvnodeid, string newtvnodeid,List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"update t_casecontent_caseitem set tvnodeid='" + newtvnodeid + "' where tvnodeid =" + oldtvnodeid + "");

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("t_casecontent_caseitem里 tvnodeid为:" + oldtvnodeid + ",更新为" + newtvnodeid + "成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("t_casecontent_caseitem里 tvnodeid为:" + oldtvnodeid + ",更新为" + newtvnodeid + "失败" + "\r\n");
                return false;
            }

        }





        /// <summary>
        /// 先找出重复的annexno，然后删掉，在更新对应的t_casecontent_caseitem
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <returns></returns>
        protected Boolean deleteReapetAnnexnoAndUpdateFJ(string tvnodetypeid,List<string> array)
        {

            string sqlcmd = " SELECT ANNEXNO  FROM (SELECT annexno, COUNT(ANNEXNO) NUM   FROM T_CASECONTENT_NODES t   WHERE TVNODETYPEID = " + tvnodetypeid + "   and eventtype = 1    and contextmenuid = 3   GROUP BY annexno) T  WHERE T.NUM > 1";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string annexno = dt.Rows[0]["annexno"].ToString();
                    sqlcmd = "SELECT TVNODEID,ANNEXNO FROM  T_CASECONTENT_NODES   WHERE TVNODETYPEID =" + tvnodetypeid + " AND ANNEXNO=" + annexno + " ORDER BY TVNODEID";
                    qb = new QueryBuilder(sqlcmd);
                    dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string tvnodid = dt.Rows[0]["tvnodeid"].ToString();
                        for (int j = 1; j < dt.Rows.Count; j++)
                        {
                            string oldtvnodeid = dt.Rows[j]["tvnodeid"].ToString();
                           tvnodeT.deleteTvnode(oldtvnodeid,array);
                            this.updateFJtoNewTvnodeid(oldtvnodeid, tvnodid,array);

                        }
                    }
                }
            }

            return false;

        }
        /// <summary>
        /// 先找出废除的annexno 和多余空白的annexno，然后删掉，在更新对应的t_casecontent_caseitem
        /// </summary>
        /// <param name="tvnodetypeid"></param>
        /// <returns></returns>
        protected void deleteUselessAnnexnoAndUpdateFJ(DataTable xml_tvnode, string tvnodetypeid,List<string> array)
        {
            string userless_annexno = "";
            if (xml_tvnode.Rows.Count > 0)
            {
                for (int i = 0; i < xml_tvnode.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        userless_annexno = xml_tvnode.Rows[i]["annexno"].ToString();
                    }
                    else
                    {
                        userless_annexno += "," + xml_tvnode.Rows[i]["annexno"].ToString();
                    }

                }

                string sqlcmd = "select tvnodeid,annexno from t_casecontent_nodes where tvnodetypeid=" + tvnodetypeid + "   and contextmenuid=3 and eventtype=1   and ( annexno not in (" + userless_annexno + ")  or  annexno is null ) order by tvnodeid";
                QueryBuilder qb = new QueryBuilder(sqlcmd);
                DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
                if (dt != null && dt.Rows.Count > 0)
                {

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string oldtvnodeid = dt.Rows[j]["tvnodeid"].ToString();
                        tvnodeT.deleteTvnode(oldtvnodeid,array);
                        //获取要更新到的附件目录tvnodeid
                        string tvnodeid = tvnodeT.getMaxAnnexnoTvnodeid(tvnodetypeid);
                        if (tvnodeid != "")
                        {
                            this.updateFJtoNewTvnodeid(oldtvnodeid, tvnodeid,array);

                        }

                    }
                }


            }


        }

        /// <summary>
        /// 清空多余的annexno
        /// </summary>
        /// <param name="xml_tvnode"></param>
        /// <param name="tvnodetypeid"></param>
        protected void cleanUselessAnnexno(DataTable xml_tvnode, string tvnodetypeid,List<string> array)
        {
            string userless_annexno = "";
            if (xml_tvnode.Rows.Count > 0)
            {
                for (int i = 0; i < xml_tvnode.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        userless_annexno = xml_tvnode.Rows[i]["annexno"].ToString();
                    }
                    else
                    {
                        userless_annexno += "," + xml_tvnode.Rows[i]["annexno"].ToString();
                    }

                }

                string sqlcmd = "select tvnodeid,annexno from t_casecontent_nodes where tvnodetypeid=" + tvnodetypeid + "   and contextmenuid=3 and eventtype=1   and  annexno not in (" + userless_annexno + ")   order by tvnodeid";
                QueryBuilder qb = new QueryBuilder(sqlcmd);
                DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
                if (dt != null && dt.Rows.Count > 0)
                {

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string oldtvnodeid = dt.Rows[j]["tvnodeid"].ToString();
                        //清空annexno
                        tvnodeT.cleanTvnode(oldtvnodeid,array);


                    }
                }


            }


        }


        //清空 树节点 父节点为空
        private Boolean cleanAllAnnexnoPretvnodid(string tvnodetypeid,List<string> array)
        {


            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"update t_casecontent_nodes set prenodeid='' where tvnodetypeid =" + tvnodetypeid + "  and contextmenuid=3 and eventtype=1   ");

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("t_casecontent_nodes里 附件节点 prenodeid为: 设置为空成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("t_casecontent_nodes里 附件节点 prenodeid为: 设置为空失败" + "\r\n");
                return false;
            }



        }


        //清空 多余的重复annexno树节点  annexno为空,
        private Boolean cleanRepeatAnnexno(string tvnodetypeid, string annexno,List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"update t_casecontent_nodes set  annexno='' where tvnodetypeid =" + tvnodetypeid + " and annexno='" + annexno + "' and prenodeid is null  and contextmenuid=3 and eventtype=1   ");

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("t_casecontent_nodes里重复的附件节点" + annexno + " 设置为空成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("t_casecontent_nodes里重复的附件节点" + annexno + "设置为空失败" + "\r\n");
                return false;
            }



        }

        //获取数据库 annnexno 的个数
        private int getTvnodeRepeatCount(string tvnodetypeid, string annexno)
        {
            int i = 0;
            string sqlcmd = "select count(annexno) num from t_casecontent_nodes where tvnodetypeid=" + tvnodetypeid + " and annexno =" + annexno + " and  contextmenuid=3 and eventtype=1    order by tvnodeid";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            if (dt != null && dt.Rows.Count > 0)
            {

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    i = Convert.ToInt32(dt.Rows[j]["num"].ToString());

                }
            }
            return i;

        }

        //清空多余的annexno  的 父节点  annexno 
        private void cleanRepeatAnnnexnoValue(string tvnodetypeid, string annexno,List<string> array)
        {
            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"update T_CASECONTENT_NODES
   set prenodeid = '', annexno = ''
 where tvnodeid = (select max(tvnodeid)
                     from T_CASECONTENT_NODES
                    where tvnodetypeid =" + tvnodetypeid + " and annexno =" + annexno + "  and contextmenuid = 3   and eventtype = 1) ");

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add(" T_CASECONTENT_NODES里 附件节点 annexno为: 设置为空成功" + "\r\n");


            }
            catch
            {
                array.Add(" T_CASECONTENT_NODES里 附件节点 annexno为: 设置为空失败" + "\r\n");

            }



        }

        //设这annexno的 父节点  和排序
        private void setAnnexnoPretvnodeidAndIndex(string tvnodetypeid, string xml_annexno, string pretvnodeid, string xml_tvnodeindex,List<string> array)
        {

            List<string> sqlcmdLst = new List<string>();

            sqlcmdLst.Add(@"update T_CASECONTENT_NODES
                      set prenodeid = " + pretvnodeid + ", tvnodeindex = " + xml_tvnodeindex +
                          " where tvnodeid = (select max(tvnodeid)  from T_CASECONTENT_NODES" +
                        " where tvnodetypeid =" + tvnodetypeid + " and annexno =" + xml_annexno + " and prenodeid is null  and contextmenuid = 3   and eventtype = 1) ");

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add(" T_CASECONTENT_NODES里 附件节点 annexno为" + xml_annexno + ": 设置父节点、排序成功" + "\r\n");


            }
            catch
            {
                array.Add(" T_CASECONTENT_NODES里 附件节点 annexno为" + xml_annexno + ": 设置父节点、排序失败" + "\r\n");

            }



        }



        //补全annexno
        protected void bqAnnexno(DataTable xml_tvnode, string tvnodetypeid,List<string> array)
        {

            //清空所有annexno 节点的父节点id
            this.cleanAllAnnexnoPretvnodid(tvnodetypeid,array);

            int xml_count = xml_tvnode.Rows.Count;

            for (int j = 0; j < xml_count; j++)
            {
                string xml_annexno = xml_tvnode.Rows[j]["annexno"].ToString();
                string xml_pretvnodeindex = xml_tvnode.Rows[j]["pretvnodeindex"].ToString();
                string xml_tvnodeindex = xml_tvnode.Rows[j]["tvnodeindex"].ToString();
                DataTable pre_dt = pretvnodeT.getPreTvnodeByTvnodeindex(tvnodetypeid, xml_pretvnodeindex);
                string pretvnodeid = pre_dt.Rows[0]["tvnodeid"].ToString();


                //是   对比个数  
                DataTable dv_tvnode = new DataTable();
                dv_tvnode = xml_tvnode.Clone();
                System.Data.DataRow[] dv_tvnode_row = xml_tvnode.Select("annexno='" + xml_annexno + "'");
                for (int m = 0; m < dv_tvnode_row.Length; m++)
                {
                    dv_tvnode.ImportRow((System.Data.DataRow)dv_tvnode_row[m]);
                }
                //xml里 annexno重复的个数
                int dv_tvnode_count = dv_tvnode.Rows.Count;


                if (tvnodeT.isAnnexnoExist(tvnodetypeid, xml_annexno))
                {


                    //是否是重复的annexno
                    if (dv_tvnode_count > 1)
                    {

                        //数据库中 annexno的重复个数
                        int dt_tvnode_count = getTvnodeRepeatCount(tvnodetypeid, xml_annexno);

                        //少重复节点
                        if (dv_tvnode_count - dt_tvnode_count >= 1)
                        {
                            int less_count = dv_tvnode_count - dt_tvnode_count;
                            //补充重复节点
                            for (int n = 0; n < less_count; n++)
                            {
                                if (tvnodeT.isBlankAnnexnoExist(tvnodetypeid) == "")
                                {
                                    // 没有空白的 annexno 添加新的 annexno  空白父节点                                        
                                    tvnodeT.addNewTvnodeWithAnnexnoInBlankPretvnodeid(tvnodetypeid, xml_annexno,array);
                                }
                                else if (tvnodeT.isBlankAnnexnoExist(tvnodetypeid) != "")
                                {
                                    // 设置空白的annexno为 annexno，设置空父节点，空排序
                                    tvnodeT.editBlankAnnexno(tvnodeT.isBlankAnnexnoExist(tvnodetypeid), xml_annexno, "", "",array);
                                }
                            }

                        }
                        //有多余的重复节点 清空annexno
                        else if (dv_tvnode_count - dt_tvnode_count < 0)
                        {
                            int less_count = dt_tvnode_count - dv_tvnode_count;
                            //清空 多余重复annexno的 annexno
                            for (int p = 0; p < less_count; p++)
                            {
                                this.cleanRepeatAnnnexnoValue(tvnodetypeid, xml_annexno,array);

                            }
                        }

                        // 剩下的都是 一样的个数

                        // 设置第一个该annexno 空父节点的  设置 改父节点id，和排序
                        this.setAnnexnoPretvnodeidAndIndex(tvnodetypeid, xml_annexno, pretvnodeid, xml_tvnodeindex,array);


                    }
                    //否 更新 父节点  排序
                    else
                    {
                        this.setAnnexnoPretvnodeidAndIndex(tvnodetypeid, xml_annexno, pretvnodeid, xml_tvnodeindex,array);

                        // 数据库有重复的annexno,清楚 重复多余的annexno的 annexno
                        cleanRepeatAnnexno(tvnodetypeid, xml_annexno,array);

                    }



                }
                //没有有空白的annexno，设置annexno为现在匹配的annexno
                else if (tvnodeT.isBlankAnnexnoExist(tvnodetypeid) == "")
                {
                    // 添加新的 annexno，设置 父节点，排序
                    tvnodeT.addNewTvnodeWithAnnexno(tvnodetypeid, xml_annexno, pretvnodeid, xml_tvnodeindex,array);
                }
                else if (tvnodeT.isBlankAnnexnoExist(tvnodetypeid) != "")
                {
                    // 设置空白的annexno为 annexno，设置父节点，排序
                    tvnodeT.editBlankAnnexno(tvnodeT.isBlankAnnexnoExist(tvnodetypeid), xml_annexno, pretvnodeid, xml_tvnodeindex,array);
                }


            }

        }







        protected Boolean updateTvnode(DataTable xml_tvnode, string tvnodetypeid,List<string> array)
        {
            int xml_count = xml_tvnode.Rows.Count;
            List<string> sqlcmdLst = new List<string>();
            for (int j = 0; j < xml_count; j++)
            {
                string annexno = xml_tvnode.Rows[j]["annexno"].ToString();
                string tvnodename = xml_tvnode.Rows[j]["name"].ToString();
                string pretvnodeindex = xml_tvnode.Rows[j]["pretvnodeindex"].ToString();
                string tvnodeindex = xml_tvnode.Rows[j]["tvnodeindex"].ToString();
                string uptvnodeid = xml_tvnode.Rows[j]["uptvnodeid"].ToString();
                // sqlcmdLst.Add(@"update t_casecontent_nodes set tvnodename  ='" + tvnodename + "', tvnodeindex = " + tvnodeindex + " , uptvnodeid=" + uptvnodeid + " where tvnodetypeid =" + tvnodetypeid + "    and annexno = " + annexno + "  and  prenodeid  =(select tvnodeid   from t_casecontent_nodes    where tvnodetypeid = " + tvnodetypeid + "  and eventtype = 0  and prenodeid = -1  and tvnodeindex = " + pretvnodeindex + ")   ");
                sqlcmdLst.Add(@"update t_casecontent_nodes set tvnodename  ='" + tvnodename + "',  uptvnodeid=" + uptvnodeid + " where tvnodetypeid =" + tvnodetypeid + "    and annexno = " + annexno + "  and  prenodeid  =(select tvnodeid   from t_casecontent_nodes    where tvnodetypeid = " + tvnodetypeid + "  and eventtype = 0  and prenodeid = -1  and tvnodeindex = " + pretvnodeindex + ")   ");

            }

            try
            {
                DatabaseEngine.Default.Db.ExecuteTrans(sqlcmdLst);
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",更新附录名称、上报上级节点成功" + "\r\n");
                return true;

            }
            catch
            {
                array.Add("tvnodetypeid为:" + tvnodetypeid + ",更新附录名称、上报上级节点失败" + "\r\n");
                return false;
            }

        }
        /// <summary>
        /// 更新附件树
        /// </summary>
        /// <param name="xml_nodetype">附件树 nodetype datatable</param>
        /// <param name="type">type为1  为流程附件树   2为子级附件数</param>
        /// <param name="xml_pretvnode">xml_pretvnode 为要更新的父节点</param>
        /// <param name="xml_ctmenu">xml_ctmenu 为要更新的父节点弹出菜单</param>
        /// <param name="xml_tvnodepage">xml_tvnodepage 为要更新子节点上的 页面栏目</param>
        /// <param name="xml_tvnode">xml_tvnode 为要更新子节点上的 附件栏目</param>
        protected void UpdateFJS(DataTable xml_nodetype, string type, DataTable xml_pretvnode, DataTable xml_ctmenu, DataTable xml_ctmenuitem, DataTable xml_tvnodepage, DataTable xml_tvnode, List<string> array)
        {
            if (xml_nodetype != null && xml_nodetype.Rows.Count >= 1)
            {

                for (int i = 0; i < xml_nodetype.Rows.Count; i++)
                {
                    //获取tvclass
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
                        //找不到对应的tvclass 就在数据库中添加一条该类型的tvclass
                        array.Add("数据库t_casecontent_nodetype表里找不到tvclass为:" + tvclass + "附件类型名称为:" + tvclassname + "的附件目录" + "\r\n");
                        array.Add("新建tvclass为:" + tvclass + "的附件目录" + "\r\n");
                        if (tvclassT.addNewTvclass(tvclass, tvclassname,array))
                        {
                            dt_tvclass =tvclassT.getTvclassByTvclassName(tvclass);
                            if (dt_tvclass != null && dt_tvclass.Rows.Count == 1)
                            {
                                tvnodetypeid = dt_tvclass.Rows[0]["tvnodetypeid"].ToString();
                            }

                        }

                    }
                    //附件类型名称 更新 上报对应节点 uptvnodetypeid
                    tvclassT.updateTvclassUptvnodetypeid(tvnodetypeid, tvclassname,tvclassuptvnodetypeid, array);

                    // 3查找父目录
                    DataTable dt_pretvnode = pretvnodeT.getPreTvnode(tvnodetypeid);
                    int dt_pretvnode_count = dt_pretvnode.Rows.Count;

                    //4 比较父级目录  添加 缺少的父级目录个数，删除多余的父级目录

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
                        //补充父目录
                        for (int j = 0; j < less_count; j++)
                        {
                            //添加一个 空eventype的 父节点
                            pretvnodeT.addNewPreTvnode(tvnodetypeid, "",array);
                        }

                    }
                    else if (dv_pretvnode_count - dt_pretvnode_count < 0)
                    {
                        int less_count = dt_pretvnode_count - dv_pretvnode_count;
                        //删除父目录
                        for (int j = 0; j < less_count; j++)
                        {
                            pretvnodeT.deletePreTvnode(tvnodetypeid,array);

                        }
                    }

                    //6 给父级目录排序 更新名称, 设置 eventtype,url
                    dt_pretvnode =pretvnodeT.getPreTvnode(tvnodetypeid);
                    dt_pretvnode_count = dt_pretvnode.Rows.Count;

                    if (dv_pretvnode_count - dt_pretvnode_count == 0)
                    {
                        pretvnodeT.sortPretvnodeAndRename(dv_pretvnode, tvnodetypeid,array);
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

                    //-------获取 对应的ctmenu ctmenuitem
                    DataTable dv_ctmenu = new DataTable();
                    dv_ctmenu = xml_ctmenu.Clone();
                    System.Data.DataRow[] dv_ctmenu_row = xml_ctmenu.Select("targettvclass=" + tvclass);
                    for (int j = 0; j < dv_pretvnod_row.Length; j++)
                    {
                        dv_ctmenu.ImportRow((System.Data.DataRow)dv_ctmenu_row[j]);
                    }
                    string dv_ctmenuid=dv_ctmenu.Rows[0]["ctmenu_Id"].ToString();

                    DataTable dv_ctmenuitem = new DataTable();
                    dv_ctmenuitem = xml_ctmenuitem.Clone();
                    System.Data.DataRow[] dv_ctmenuitem_row = xml_ctmenuitem.Select("ctmenu_Id=" + dv_ctmenuid);
                    for (int j = 0; j < dv_ctmenuitem_row.Length; j++)
                    {
                        dv_ctmenuitem.ImportRow((System.Data.DataRow)dv_ctmenuitem_row[j]);
                    }

                    //设置对改 类型的ctmenu  如果 extend_tvclas 没有对应的ctmenu 就按照
                    if(type=="1"){
                        if (!ctmenu.isCtmenuForTvclassExist(tvnodetypeid))
                        {
                            ctmenu.addCtmenuAndItemForTvclass(tvnodetypeid, dv_ctmenu, dv_ctmenuitem,array);
                        }
                        else {
                            ctmenu.updateCtmenuAndItemForTvclass(tvnodetypeid, dv_ctmenu, dv_ctmenuitem,array);
                        
                        }

                    }
                   

                    //处理申请书、子级页面栏目
                    DataTable dt_tvnodepage =tvnodeT.getTvnodePage(tvnodetypeid);
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
                       tvnodeT.addNewTvnodePage(tvnodetypeid,array);
                    }
                    //更新申请表数据
                    tvnodeT.editTvnodePage(dv_tvnodepage, tvnodetypeid,array);

                    //8 比较附件目录，annexno空白的先补上，然后添加缺少的， 重复的更新为新的缺少的annexno，annexno有值,
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
                        //清空多余的annexno
                        this.cleanUselessAnnexno(dv_tvnode, tvnodetypeid,array);
                        this.bqAnnexno(dv_tvnode, tvnodetypeid,array);
                    }


                    //13 去除 多余的空白的annexno和没用的annexno 节点，检查附件库里有该节点下的附件，删除该节点 更新到 annexno为999的节点下面下面去    
                   // this.deleteUselessAnnexnoAndUpdateFJ(dv_tvnode, tvnodetypeid,array);
                    // 14   更新 附件节点 名称  
                    this.updateTvnode(dv_tvnode, tvnodetypeid,array);
                    array.Add("tvnodetypeid为:" + tvnodetypeid + "附件类型名称为\"" + tvclassname + "\"的数配置更新完" + "\r\n");
                    array.Add("-------------------------------------------------" + "\r\n");

                }

            }

        }


        public void readAndUpdate(DataSet ds,List<string> array) {

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
                UpdateFJS(xml_nodetype_extend, "", xml_pretvnode, xml_ctmenu,xml_ctmenuitem, xml_tvnodepage, xml_tvnode, array);       
               
            }

            //更新附件树节点
            if (xml_nodetype != null && xml_nodetype.Rows.Count >= 1)
            {

                //for (int i = 0; i < xml_nodetype.Rows.Count; i++)
                //{
                UpdateFJS(xml_nodetype, "1", xml_pretvnode, xml_ctmenu, xml_ctmenuitem, xml_tvnodepage, xml_tvnode, array);

                #region 之前的代码
                //        //获取tvclass
            //        string tvclass = xml_nodetype.Rows[i]["tvclass"].ToString();
            //        string tvclassname = xml_nodetype.Rows[i]["name"].ToString();
            //        string tvclassuptvnodetypeid = xml_nodetype.Rows[i]["uptvnodetypeid"].ToString();
            //        string tvnodetypeid = "";
            //        string nodetype_id = xml_nodetype.Rows[i]["nodetype_id"].ToString();


            //        DataTable dt_tvclass = tvclassF.getTvclassByTvclassName(tvclass);
            //        if (dt_tvclass != null && dt_tvclass.Rows.Count == 1)
            //        {
            //            tvnodetypeid = dt_tvclass.Rows[0]["tvnodetypeid"].ToString();
            //        }
            //        else
            //        {
            //            array.Add("数据库里找不到tvclass为:" + tvclass + "附件类型名称为:" + tvclassname + "的附件目录" + "\r\n");
            //            array.Add("新建tvclass为:" + tvclass + "的附件目录" + "\r\n");
            //            if (tvclassT.addNewTvclass(tvclass, tvclassname,array))
            //            {
            //                dt_tvclass = tvclassF.getTvclassByTvclassName(tvclass);
            //                if (dt_tvclass != null && dt_tvclass.Rows.Count == 1)
            //                {
            //                    tvnodetypeid = dt_tvclass.Rows[0]["tvnodetypeid"].ToString();

            //                }

            //            }

            //        }
            //        //附件类型更新 uptvnodetypeid
            //        tvclassF.updateTvclassUptvnodetypeid(tvnodetypeid,tvclassname,tvclassuptvnodetypeid,array);

            //        // 3查找父目录
            //        DataTable dt_pretvnode = pretvnodeF.getPreTvnode(tvnodetypeid);
            //        int dt_pretvnode_count = dt_pretvnode.Rows.Count;

            //        //4 比较父级目录  排除 申请书父级目录（如果没有父级目录 则不管）//, 添加 缺少的父级目录个数，删除多余的父级目录

            //        DataTable dv_pretvnode = new DataTable();
            //        dv_pretvnode = xml_pretvnode.Clone();
            //        System.Data.DataRow[] dv_pretvnod_row = xml_pretvnode.Select("nodetype_id=" + nodetype_id);
            //        for (int j = 0; j < dv_pretvnod_row.Length; j++)
            //        {
            //            dv_pretvnode.ImportRow((System.Data.DataRow)dv_pretvnod_row[j]);
            //        }
            //        int dv_pretvnode_count = dv_pretvnode.Rows.Count;

            //        //少父目录
            //        if (dv_pretvnode_count - dt_pretvnode_count >= 1)
            //        {
            //            int less_count = dv_pretvnode_count - dt_pretvnode_count;
            //            //补充父目录
            //            for (int j = 0; j < less_count; j++)
            //            {
            //                pretvnodeT.addNewPreTvnode(tvnodetypeid,"0",array);

            //            }

            //        }
            //        else if (dv_pretvnode_count - dt_pretvnode_count < 0)
            //        {
            //            int less_count = dt_pretvnode_count - dv_pretvnode_count;
            //            //删除父目录
            //            for (int j = 0; j < less_count; j++)
            //            {
            //                pretvnodeF.deletePreTvnode(tvnodetypeid,array);

            //            }
            //        }

            //        //6 给父级目录排序 更新名称
            //        dt_pretvnode = pretvnodeF.getPreTvnode(tvnodetypeid);
            //        dt_pretvnode_count = dt_pretvnode.Rows.Count;

            //        if (dv_pretvnode_count - dt_pretvnode_count == 0)
            //        {

            //            pretvnodeF.sortPretvnodeAndRename(dv_pretvnode, tvnodetypeid,array);

            //        }

            //        //处理申请书
            //        DataTable dt_tvnodepage = tvnodeF.getTvnodePage(tvnodetypeid);
            //        DataTable dv_tvnodepage = new DataTable();
            //        dv_tvnodepage = xml_tvnodepage.Clone();
            //        System.Data.DataRow[] dv_tvnodepage_row = xml_tvnodepage.Select("nodetype_id=" + nodetype_id);
            //        for (int j = 0; j < dv_tvnodepage_row.Length; j++)
            //        {
            //            dv_tvnodepage.ImportRow((System.Data.DataRow)dv_tvnodepage_row[j]);
            //        }

            //        int dv_tvnodepage_count = dv_tvnodepage.Rows.Count;

            //        //没有申请表则添加，
            //        if (!tvnodeF.isTvnodePageExist(tvnodetypeid))
            //        {
            //            tvnodeF.addNewTvnodePage(tvnodetypeid,array);
            //        }
            //        //更新申请表数据
            //        tvnodeF.editTvnodePage(dv_tvnodepage, tvnodetypeid,array);


            //        //8 比较附件目录，annexno空白的先补上，然后添加缺少的， 重复的更新为新的缺少的annexno，annexno有值,
            //        DataTable dv_tvnode = new DataTable();
            //        dv_tvnode = xml_tvnode.Clone();
            //        System.Data.DataRow[] dv_tvnode_row = xml_tvnode.Select("nodetype_id=" + nodetype_id);
            //        for (int j = 0; j < dv_tvnode_row.Length; j++)
            //        {
            //            dv_tvnode.ImportRow((System.Data.DataRow)dv_tvnode_row[j]);
            //        }

            //        int dv_tvnode_count = dv_tvnode.Rows.Count;

            //        if (dv_tvnode != null && dv_tvnode_count > 0)
            //        {
            //            //清空多余的annexno
            //            this.cleanUselessAnnexno(dv_tvnode, tvnodetypeid,array);
            //            this.bqAnnexno(dv_tvnode, tvnodetypeid,array);
            //        }


            //        //13 去除 多余的空白的annexno和没用的annexno 节点，检查附件库里有该节点下的附件，删除该节点 更新到 annexno为999的节点下面下面去    
            //        this.deleteUselessAnnexnoAndUpdateFJ(dv_tvnode, tvnodetypeid,array);
            //        // 14   更新 附件节点 名称  
            //        this.updateTvnode(dv_tvnode, tvnodetypeid,array);
            //        array.Add("tvnodetypeid为:" + tvnodetypeid + "附件类型名称为\"" + tvclassname + "\"的数配置更新完" + "\r\n");
            //        array.Add( "-------------------------------------------------" + "\r\n");

                //   }
                #endregion

            }       
        
        
        }



    }
}
