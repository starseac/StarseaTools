using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Starsea.Egov.filespackage
{
   public class createpkg
    {

        public void createFiles(string tvnodetypeid, string createPath)        {

            string rootfilename = createPath + "root\\";

            string sql1 = @"SELECT tvnodename, annexid, tvnodeid
                              FROM T_CASECONTENT_NODES
                             WHERE TVNODETYPEID = '"+tvnodetypeid+@"'
                               and tvnodeid in (
                    
                                                SELECT prenodeid
                                                  FROM T_CASECONTENT_NODES
                                                 WHERE TVNODETYPEID ='"+tvnodetypeid+@"'
                                                   and contextmenuid = 3
                                                   and eventtype = 1)";

            QueryBuilder qb = new QueryBuilder(sql1);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string tvnodeid = dt.Rows[i]["tvnodeid"].ToString();
                    string annexid = dt.Rows[i]["annexid"].ToString();
                    string tvnodename = dt.Rows[i]["tvnodename"].ToString();
                    string filename = annexid + "、" + tvnodename;
                    string filepath = rootfilename + "\\" + filename;
                    Directory.CreateDirectory(filepath);

                    string sql2 = @"SELECT tvnodename,annexid FROM T_CASECONTENT_NODES WHERE TVNODETYPEID='"+tvnodetypeid+"' and contextmenuid=3 and eventtype=1 and prenodeid='" + tvnodeid + "' order by annexid";
                    QueryBuilder qb2 = new QueryBuilder(sql2);
                    DataTable dt2 = DatabaseEngine.Default.Db.GetSelectTable(qb2);
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            string sub_annexid = dt2.Rows[j]["annexid"].ToString();
                            string sub_tvnodename = dt2.Rows[j]["tvnodename"].ToString();
                            string sub_filename = annexid + "-" + sub_annexid + "、" + sub_tvnodename;
                            string sub_filepath = filepath + "\\" + sub_filename;
                            Directory.CreateDirectory(sub_filepath);
                        }

                    }
                }
            }

        }
    }


}
