using System.Data.SqlClient;
using System.Data.OleDb;
using egovtools;

namespace egovtools.database
{
    class DBConnectin
    {

        public void getConn()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString =egovtools.Properties.Settings.Default.ConnectionString;
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from t_base_func where functype=2", con);
                
                
            }
            catch { 
            
            }
        }

    }
}