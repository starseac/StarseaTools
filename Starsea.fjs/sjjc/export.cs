using BSI.Utility.DB.Builder;
using BSI.Utility.DB.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Egov.sjjc
{
   public class export
    {

        public  DataTable getCheckType()
        {
            string sqlcmd = @"SELECT * FROM CHECKTYPE ORDER BY WFID,ID";

            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }


        public DataTable getCheckConfig()
        {
            string sqlcmd = @"SELECT * FROM CHECKCONFIG";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }


        public DataTable getCheckMethod()
        {

            string sqlcmd = @"SELECT * FROM CHECKMETHOD ORDER BY ID";
            QueryBuilder qb = new QueryBuilder(sqlcmd);
            DataTable dt = DatabaseEngine.Default.Db.GetSelectTable(qb);
            return dt;
        }



    }
}
