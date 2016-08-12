using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Starsea.Database.Access
{
    public class Connection
    {

        public OleDbConnection getConn(String provider,String datasource)
        {
            string connstr = "Provider="+provider+" ;Data Source="+datasource+"";
            OleDbConnection tempconn = new OleDbConnection(connstr);
            return (tempconn);
        }


        public OleDbConnection GetConnection(string driver,string path)
        {
           // string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            string strConnection = driver;
            strConnection += @"Data Source=" + path;
            OleDbConnection conn = new OleDbConnection(strConnection);
            try
            {
                if (conn.State == ConnectionState.Closed) { conn.Open(); }
            }
            catch (Exception es)
            {
                return null;
            }
            return conn;
        }
       

    }
}
