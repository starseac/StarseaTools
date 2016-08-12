using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace Starsea.Egov.scpz
{
   public class export
    {
        public DataTable getExportwf(List<string> list)
        {
            string typestr = "";
            foreach (string type in list)
            {
                if (type == "建设用地")
                {
                    if (typestr == "")
                    {
                        typestr = "'FPC','PCGG','DDXZ','XZGG','DQHP'";
                    }
                    else
                    {
                        typestr += ",'FPC','PCGG','DDXZ','XZGG','DQHP'";
                    }

                }
                else if (type == "矿业权")
                {
                    if (typestr == "")
                    {
                        typestr = "'CKHK','CKXL','CKYS','CKBG','CKYX','CKZR','CKZX','TKKCFW','TKXL','TKBGYS','TKBG','TKBL','TKYX','TKZR','TKZX'";
                    }
                    else
                    {
                        typestr += ",'CKHK','CKXL','CKYS','CKBG','CKYX','CKZR','CKZX','TKKCFW','TKXL','TKBGYS','TKBG','TKBL','TKYX','TKZR','TKZX'";
                    }

                }
                else if (type == "土整")
                {
                    if (typestr == "")
                    {
                        typestr = "'LX','YS'";
                    }
                    else
                    {
                        typestr += "'LX','YS'";
                    }
                }
            }

            string sqlcmd = @"SELECT wfid,name,prefixno FROM T_wf_wfinfo WHERE prefixno in  (" + typestr + ")";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;

        }


        public DataTable getScSql(string wfid)
        {
            string sqlcmd = @"select  *   from t_wf_casetable  where wfid=" + wfid + " order by casetableid ";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;

        }

        public void exportSQLxml(List<string> exportList, XmlTextWriter xw, List<string> array)
        {
            try
            {
                xw.Formatting = Formatting.Indented;

                xw.WriteStartDocument();
                xw.WriteStartElement("scsql");
              
                DataTable dt_wf = this.getExportwf(exportList);
                if (dt_wf != null && dt_wf.Rows.Count >= 1)
                {
                    for (int i = 0; i < dt_wf.Rows.Count; i++)
                    {
                        xw.WriteStartElement("wfnode");
                        //--获取tvclass属性值
                        xw.WriteAttributeString("wfname", dt_wf.Rows[i]["name"].ToString());
                        xw.WriteAttributeString("prefixno", dt_wf.Rows[i]["prefixno"].ToString());

                        DataTable dt_sbsql = this.getScSql(dt_wf.Rows[i]["wfid"].ToString());
                        if (dt_sbsql != null && dt_sbsql.Rows.Count >= 1)
                        {

                            for (int j = 0; j < dt_sbsql.Rows.Count; j++)
                            {
                                //父级节点
                                xw.WriteStartElement("sqlnode");
                                xw.WriteAttributeString("casetableid", dt_sbsql.Rows[j]["casetableid"].ToString());
                                xw.WriteAttributeString("sqlcontent", dt_sbsql.Rows[j]["sqlcontent"].ToString());                            
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
                array.Add(EG.ToString() + "\r\n");
            }
        
        }

    }
}
