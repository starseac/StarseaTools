using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace TableToXML.DATA
{
    class Database
    {
        OracleConnection connection;
     //   string connStr = "Password=sa;User ID=hs;Data Source=HSEGOV;Persist Security Info=True";

       // string connStr = "Password=sa;User ID=hs;Data Source=HSEGOV;Persist Security Info=True";

        string connStr = Properties.Settings.Default.ConnectionString.ToString();

        public OracleConnection getConnection()
        {
            try
            {

                if (connection == null)
                    connection = new OracleConnection(connStr);
                if (connection.State == ConnectionState.Open)
                    connection.Open();
                return connection;
            }
            catch (OracleException e)
            {
                throw e;
            }
        }

        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

    }
}
