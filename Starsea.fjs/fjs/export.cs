using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace Starsea.Egov.fjs
{
    public class export
    {
        ctmenu ctmenu = new ctmenu();
        pretvnode pretvnode = new pretvnode();
        tvnode tvnode = new tvnode();
        tvclass tvclass = new tvclass();


        public void exportCtmenu(XmlTextWriter xw, string ctmenuid)
        {
            xw.WriteStartElement("ctmenu");
            xw.WriteAttributeString("menuname", ctmenu.getCtmenu(ctmenuid).Rows[0]["menuname"].ToString());
            xw.WriteAttributeString("tartgettvclass", ctmenu.getCtmenuTargetTvclass(ctmenuid).Rows[0]["tvclass"].ToString());
            DataTable dt = ctmenu.getCtmenuitem(ctmenuid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                xw.WriteStartElement("ctmenuitem");
                xw.WriteAttributeString("ctnodeid", dt.Rows[i]["ctnodeid"].ToString());
                xw.WriteAttributeString("ctname", dt.Rows[i]["ctname"].ToString());
                xw.WriteAttributeString("enable", dt.Rows[i]["enable"].ToString());
                xw.WriteAttributeString("cttpindex", dt.Rows[i]["cttpindex"].ToString());
                if (i == 0)
                {
                    xw.WriteAttributeString("ctparem", ctmenu.getChildNodeExportString(ctmenuid));
                }
                else
                {
                    xw.WriteAttributeString("ctparem", dt.Rows[i]["ctparem"].ToString());
                }

                xw.WriteEndElement();
            }

            xw.WriteEndElement();


        }
        

        /// <summary>
        /// 设置节点信息
        /// </summary>
        /// <param name="xw"></param>
        /// <param name="dt"></param>
        /// <param name="nodetype"> nodetype  nodetype_extend</param>
        public void exportNodetype(XmlTextWriter xw, DataTable dt, string nodetype)
        {
            DataTable dt_tvclass = dt;
            if (dt_tvclass != null && dt_tvclass.Rows.Count >= 1)
            {
                for (int i = 0; i < dt_tvclass.Rows.Count; i++)
                {
                    xw.WriteStartElement(nodetype);
                    //--获取tvclass属性值
                    xw.WriteAttributeString("tvclass", dt_tvclass.Rows[i]["tvclass"].ToString());
                    xw.WriteAttributeString("name", dt_tvclass.Rows[i]["typename"].ToString());
                    xw.WriteAttributeString("uptvnodetypeid", dt_tvclass.Rows[i]["tvnodetypeid"].ToString());
                    //获取该流程的所有子节点 nodetypeid nodetype_extend
                    ctmenu.getAllChildNodeid(dt_tvclass.Rows[i]["tvnodetypeid"].ToString());

                    DataTable dt_prenode = pretvnode.getPreTvnode(dt_tvclass.Rows[i]["tvnodetypeid"].ToString());
                    if (dt_prenode != null && dt_prenode.Rows.Count >= 1)
                    {

                        for (int j = 0; j < dt_prenode.Rows.Count; j++)
                        {
                            //父级节点
                            xw.WriteStartElement("pretvnode");
                            xw.WriteAttributeString("tvnodeindex", dt_prenode.Rows[j]["tvnodeindex"].ToString());
                            xw.WriteAttributeString("name", dt_prenode.Rows[j]["tvnodename"].ToString());
                            xw.WriteAttributeString("eventtype", dt_prenode.Rows[j]["eventtype"].ToString());
                            xw.WriteAttributeString("tvnodeurl", dt_prenode.Rows[j]["tvnodeurl"].ToString());
                            if (dt_prenode.Rows[j]["contextmenuid"].ToString() != "")
                            {
                                //插入ctmenu
                                // 
                                xw.WriteAttributeString("targettvclass", ctmenu.getChildNodeTvclass(dt_prenode.Rows[j]["contextmenuid"].ToString()).Rows[0]["tvclass"].ToString());
                            }
                            else {
                                xw.WriteAttributeString("targettvclass", "");
                            }
                            xw.WriteEndElement();
                        }
                    }

                    DataTable dt_tvnodepage = tvnode.getTvnodePage(dt_tvclass.Rows[i]["tvnodetypeid"].ToString());
                    if (dt_tvnodepage != null && dt_tvnodepage.Rows.Count >= 1)
                    {

                        for (int m = 0; m < dt_tvnodepage.Rows.Count; m++)
                        {
                            //申请书页面
                            xw.WriteStartElement("tvnodepage");
                            xw.WriteAttributeString("pretvnodeindex", dt_tvnodepage.Rows[m]["pretvnodeindex"].ToString());
                            xw.WriteAttributeString("tvnodeindex", dt_tvnodepage.Rows[m]["tvnodeindex"].ToString());
                            xw.WriteAttributeString("name", dt_tvnodepage.Rows[m]["tvnodename"].ToString());
                            xw.WriteAttributeString("url", dt_tvnodepage.Rows[m]["tvnodeurl"].ToString());
                            xw.WriteEndElement();
                        }
                    }


                    DataTable dt_tvnode = tvnode.getTvnode(dt_tvclass.Rows[i]["tvnodetypeid"].ToString());
                    if (dt_tvnode != null && dt_tvnode.Rows.Count >= 1)
                    {

                        for (int k = 0; k < dt_tvnode.Rows.Count; k++)
                        {
                            //子节点
                            xw.WriteStartElement("tvnode");
                            xw.WriteAttributeString("pretvnodeindex", dt_tvnode.Rows[k]["pretvnodeindex"].ToString());
                            xw.WriteAttributeString("tvnodeindex", dt_tvnode.Rows[k]["tvnodeindex"].ToString());
                            xw.WriteAttributeString("annexno", dt_tvnode.Rows[k]["annexno"].ToString());
                            xw.WriteAttributeString("uptvnodeid", dt_tvnode.Rows[k]["tvnodeid"].ToString());
                            xw.WriteAttributeString("name", dt_tvnode.Rows[k]["tvnodename"].ToString());
                            xw.WriteEndElement();
                        }
                    }

                    xw.WriteEndElement();
                }
            }
        }


        public void exportFJSXML(string exportType,XmlTextWriter xw,List<string> array)
        {
            try
            {
                xw.Formatting = Formatting.Indented;

                xw.WriteStartDocument();
                xw.WriteStartElement("fjs");

                // 要更新的附件树
                tvclass tvclass = new tvclass();
                this.exportNodetype(xw, tvclass.getTvclass(exportType), "nodetype");

                // 附件树要用到的 子 附件树               
               List<int> list = ctmenu.getAllChildNodeidList();

               List<int> oldlist = list;

               List<int> updatelist = new List<int>();
               //设置配置文件的顺序   
               // 先把 没有子附件数的添加到 新的 list里，按顺序加入 确保 所有的子节点都已近存在list中
               ctmenu.setUpdateNotetypeExtendOrder(oldlist, updatelist);

               if (updatelist.Count > 0)
                {
                    //string ids = "";
                    //for (int i = 0; i < updatelist.Count; i++)
                    //{
                    //    if (i == 0)
                    //    {
                    //        ids = updatelist.GetRange(i, 1)[0].ToString();
                    //    }
                    //    else
                    //    {
                    //        ids += "," + updatelist.GetRange(i, 1)[0].ToString();
                    //    }

                    //}
                    //this.exportNodetype(xw, tvclass.getTvclassById(ids), "nodetype_extend");
                    for (int i = 0; i < updatelist.Count; i++) {
                        this.exportNodetype(xw, tvclass.getTvclassById(updatelist.ToArray()[i].ToString()), "nodetype_extend");
                        this.exportCtmenu(xw, ctmenu.getCtmenuIDbyTargetTvnodetypeid(updatelist.ToArray()[i].ToString()));
                    }

                }

                xw.WriteEndElement();
                xw.WriteEndDocument();

                xw.Flush();
                xw.Close();

            }
            catch (Exception EG)
            {

               array.Add( EG.ToString() + "\r\n");

            }


        }
    }
}
