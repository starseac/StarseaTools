using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace Starsea.sjsjjh
{
    public class export
    {
        console console = new console();
        protected DataTable getWfinfo()
        {

            string sqlcmd = @"SELECT WFID,NAME,PREFIXNO FROM T_WF_WFINFO WHERE PREFIXNO LIKE '_K%' AND PREFIXNO NOT  LIKE '%SJ' ORDER BY PREFIXNO";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;

        }



        protected DataTable getSbsqlBySbsqltype(string sbsqltype, string wfid)
        {

            string sqlcmd = @"select   infoid,
                                    sqlcontent,
                                   operatefield,
                                   operatetable,
                                   fcaseidname,
                                   outputtype,
                                   sqlparameters,
                                   excenoquerysql
                          from t_bj_uploadinfos 
                              where outputtype = '" + sbsqltype + "' and wfid=" + wfid + " order by infoid";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }



        public void exportXML(XmlTextWriter xw, string sbsqltype)
        {

            try
            {
                xw.Formatting = Formatting.Indented;

                xw.WriteStartDocument();
                xw.WriteStartElement("sbsql");
                xw.WriteAttributeString("outputtype", sbsqltype);

                DataTable dt_wf = this.getWfinfo();
                if (dt_wf != null && dt_wf.Rows.Count >= 1)
                {
                    for (int i = 0; i < dt_wf.Rows.Count; i++)
                    {
                        xw.WriteStartElement("wfnode");
                        //--获取tvclass属性值
                        xw.WriteAttributeString("prefixno", dt_wf.Rows[i]["prefixno"].ToString());
                        xw.WriteAttributeString("name", dt_wf.Rows[i]["name"].ToString());

                        DataTable dt_sbsql = this.getSbsqlBySbsqltype(sbsqltype, dt_wf.Rows[i]["wfid"].ToString());
                        if (dt_sbsql != null && dt_sbsql.Rows.Count >= 1)
                        {

                            for (int j = 0; j < dt_sbsql.Rows.Count; j++)
                            {
                                //父级节点
                                xw.WriteStartElement("sqlnode");
                                xw.WriteAttributeString("infoid", dt_sbsql.Rows[j]["infoid"].ToString());
                                xw.WriteAttributeString("sqlcontent", dt_sbsql.Rows[j]["sqlcontent"].ToString());
                                xw.WriteAttributeString("operatefield", dt_sbsql.Rows[j]["operatefield"].ToString());
                                xw.WriteAttributeString("operatetable", dt_sbsql.Rows[j]["operatetable"].ToString());
                                xw.WriteAttributeString("fcaseidname", dt_sbsql.Rows[j]["fcaseidname"].ToString());
                                xw.WriteAttributeString("outputtype", dt_sbsql.Rows[j]["outputtype"].ToString());
                                xw.WriteAttributeString("sqlparameters", dt_sbsql.Rows[j]["sqlparameters"].ToString());
                                xw.WriteAttributeString("excenoquerysql", dt_sbsql.Rows[j]["excenoquerysql"].ToString());
                                xw.WriteEndElement();
                            }
                        }



                        xw.WriteEndElement();
                    }
                }
                xw.WriteEndElement();
                xw.WriteEndDocument();

                xw.Flush();
                xw.Close();

            }
            catch (Exception EG)
            {

               console.consoleStr = EG.ToString() + "\r\n";

            }
        
        }
    }
}
