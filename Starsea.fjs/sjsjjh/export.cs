using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using Starsea.Database.Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace Starsea.Egov.sjsjjh
{
    public class export
    {
        console console = new console();
        public DataTable getWfinfo(List<string> list)
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
                        typestr = "'CKHK','CKXL','CKYS','CKBG','CKYX','CKZR','CKZX','TKKCFW','TKXL','TKHKBG','TKBG','TKBL','TKYX','TKZR','TKZX'";
                    }
                    else
                    {
                        typestr += ",'CKHK','CKXL','CKYS','CKBG','CKYX','CKZR','CKZX','TKKCFW','TKXL','TKHKBG','TKBG','TKBL','TKYX','TKZR','TKZX'";
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

            string sqlcmd = @"SELECT t.wfid,t.name,t.prefixno,b.bjtype,b.flowid FROM T_wf_wfinfo t left join t_bj_casewf b on t.wfid=b.wfid where T.prefixno in  (" + typestr + ")";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }


        protected DataTable getSbsqlBySbsqltype(List<string> sbsqltype, string wfid)
        {
            string types = "";
            foreach (string aa in sbsqltype) {
                if (types == "")
                {
                    types = aa;
                }
                else {
                    types += "," + aa;
                }
            
            }

            string sqlcmd = @"select   infoid,
                                    sqlcontent,
                                   operatefield,
                                   operatetable,
                                   fcaseidname,
                                   outputtype,
                                   sqlparameters,
                                   excenoquerysql
                          from t_bj_uploadinfos 
                              where outputtype in ('" + types + "') and wfid=" + wfid + " order by infoid";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }

      

        public void exportXML(XmlTextWriter xw, List<string> exporttype,List<string> outputtype,List<string> array)
        {

            try
            {
                xw.Formatting = Formatting.Indented;

                xw.WriteStartDocument();
                xw.WriteStartElement("sbsql");


                DataTable dt_wf = this.getWfinfo(exporttype);
                if (dt_wf != null && dt_wf.Rows.Count >= 1)
                {
                    for (int i = 0; i < dt_wf.Rows.Count; i++)
                    {
                        xw.WriteStartElement("wfnode");
                        //--获取tvclass属性值                        
                        xw.WriteAttributeString("prefixno", dt_wf.Rows[i]["prefixno"].ToString());
                        xw.WriteAttributeString("name", dt_wf.Rows[i]["name"].ToString());
                        xw.WriteAttributeString("bjtype", dt_wf.Rows[i]["bjtype"].ToString());
                        xw.WriteAttributeString("flowid", dt_wf.Rows[i]["flowid"].ToString());


                        DataTable dt_sbsql = this.getSbsqlBySbsqltype(outputtype, dt_wf.Rows[i]["wfid"].ToString());
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

              array.Add(EG.ToString() + "\r\n");

            }
        
        }

        public void exportMDBXML(XmlTextWriter xw, string folderpath, List<string> array)
        {
            ScannMdb scann = new ScannMdb();

            xw.Formatting = Formatting.Indented;

            xw.WriteStartDocument();
            xw.WriteStartElement("mdblist");


            List<string> filelist=scann.getMdbList(folderpath);
            foreach (string filepath in filelist)
            {

                string[] par = filepath.Split('\\');
                string filename = par[par.Length - 1];

                xw.WriteStartElement("mdb");
                //--获取tvclass属性值 

                xw.WriteAttributeString("filename", filename);
               

                DataTable dt_tables = scann.getTableList(filepath);
                if(dt_tables!=null&&dt_tables.Rows.Count>0){

                    for (int i = 0; i < dt_tables.Rows.Count;i++ )
                    {
                        string tableName = dt_tables.Rows[i]["TABLE_NAME"].ToString();

                        xw.WriteStartElement("table");
                        xw.WriteAttributeString("tablename", tableName);

                        DataTable dt_column = scann.getTableColumnList(filepath, tableName);  

                        if(dt_column!=null&&dt_column.Rows.Count>0){
                            for (int j = 0; j < dt_column.Rows.Count;j++ )
                            {
                                string column_name = dt_column.Rows[j]["column_name"].ToString();
                                string ordinal_position = dt_column.Rows[j]["ordinal_position"].ToString();
                                string column_hasdefault = dt_column.Rows[j]["column_hasdefault"].ToString();
                                string column_flags = dt_column.Rows[j]["column_flags"].ToString();
                                string is_nullable = dt_column.Rows[j]["is_nullable"].ToString();
                                string data_type = dt_column.Rows[j]["data_type"].ToString();
                                string character_maximum_length = dt_column.Rows[j]["character_maximum_length"].ToString();
                                string character_octet_length = dt_column.Rows[j]["character_octet_length"].ToString();

                                xw.WriteStartElement("column");
                                xw.WriteAttributeString("column_name", column_name);
                                xw.WriteAttributeString("ordinal_position", ordinal_position);
                                xw.WriteAttributeString("column_hasdefault", column_hasdefault);
                                xw.WriteAttributeString("column_flags", column_flags);
                                xw.WriteAttributeString("is_nullable", is_nullable);
                                xw.WriteAttributeString("data_type", data_type);
                                xw.WriteAttributeString("character_maximum_length", character_maximum_length);
                                xw.WriteAttributeString("character_octet_length", character_octet_length);
                                xw.WriteEndElement();

                            }
                            xw.WriteEndElement();
                        
                        }
                        
                    }
                }
                xw.WriteEndElement();
                
            }

            xw.WriteEndDocument();

            xw.Flush();
            xw.Close();
          

            
        }
    }
}
