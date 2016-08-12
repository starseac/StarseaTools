using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ADOX;
using System.IO;
using System.Data.OleDb;

namespace Starsea.Database.Access
{
   public  class CreateMdb
    {
        /// <summary>
        /// 创建Access数据库
        /// </summary>
        /// <param name="path">文件和文件路径</param>
        /// <returns>真为创建成功，假为创建失败或是文件已存在</returns>
        public bool CreateAccessDatabase(string path)
        {
            //如果文件存在反回假
            if (File.Exists(path))
                return false;

            try
            {
                //如果目录不存在，则创建目录
                string dirName = Path.GetDirectoryName(path);
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                //创建Catalog目录类
                ADOX.CatalogClass catalog = new ADOX.CatalogClass();


                String connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                        "Data Source=" + path +
                        ";Jet OLEDB:Engine Type=5";              
             
               
                //根据联结字符串使用Jet数据库引擎创建数据库
                catalog.Create(connectionStr);
                //得到当前活动连接对象接口
              //  ADODB.Connection adoconn = catalog.ActiveConnection as ADODB.Connection;
                OleDbConnection conn = new OleDbConnection();
                conn = catalog.ActiveConnection as OleDbConnection;
                //关闭活动连接
                conn.Close();
                //释放类资源
                catalog = null;

                return true;
            }
            catch (Exception)
            {
                throw new Exception("MDB数据库文件创建失败!");
            }
        }

        public void creatMdbTables(string mdbPath,List<string> tables,List<string> colums) {
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            Connection accessConn = new Connection();
            //获取Connection
            string sql = "";
            bool tempvalue = false;
            try
            {
                OleDbConnection conn = accessConn.GetConnection(strConnection, mdbPath);

                for (int i = 0; i < tables.Count;i++ )
                {
                    string tableName = tables.ToArray()[i].ToString();
                    string cols = colums.ToArray()[i].ToString();
                    string[] cols_array = cols.Split(',');
                    if (cols != "" && cols_array.Length > 0) {
                        string col_parms = "";
                        for (int j = 0; j < cols_array.Length;j++ )
                        {
                            if (j == 0)
                            {
                                col_parms = cols_array[j] + " Text ";
                            }
                            else {
                                col_parms += "," + cols_array[j] + " Text ";                            
                            }
                        }
                        sql = "create table  " + tableName + " (" + col_parms + ")";
                        OleDbCommand myCommand = new OleDbCommand(sql, conn);
                        myCommand.ExecuteNonQuery();                                          
                    
                    }

                }
                conn.Close();

                tempvalue = true;
                //return(tempvalue);
            }
            catch (Exception eg)
            {
                throw (new Exception("mdb数据库表结构创建出错:" + sql + "\r" + eg.Message));
            }
        
        }

        public void alterMdbColumn() {
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            Connection accessConn = new Connection();
            //获取Connection
            string sql = "";
            bool tempvalue = false;
            try
            {
                OleDbConnection conn = accessConn.GetConnection(strConnection, @"F:\new_BSIEGOV\Solution1\Starse.Egov.Tools\bin\Debug\TempFile\CKBG_BSIBJXOUTPUT.mdb");

                sql = "alter table 表1 add hehe char(20)";
                OleDbCommand myCommand = new OleDbCommand(sql, conn);
                myCommand.ExecuteNonQuery();
                conn.Close();
                tempvalue = true;
                //return(tempvalue);
            }
            catch (Exception eg)
            {
                throw (new Exception("数据库更新出错:" + sql + "\r" + eg.Message));
            }
        
        }

        public void insertDataIntoMdb() { 
        
        
        }



    }
}
