using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace Starsea.Database.Access
{
    public class ScannMdb
    {

        int count = 0;

        List<string> temppath = new List<string>();
        List<string> finallypath = new List<string>();
        List<string> lastpath = new List<string>();


        public List<string> getMdbList(string mdbDirectory)
        {

            DirectoryInfo theFolder = new DirectoryInfo(mdbDirectory);

            // DirectoryInfo[] dirInfo= theFolder.GetDirectories();

            FileInfo[] fileInfo = theFolder.GetFiles();

            foreach (FileInfo NextFile in fileInfo)  //遍历文件 
            {

                if (Path.GetExtension(NextFile.ToString()) == ".mdb")
                {
                    temppath.Add(NextFile.FullName);
                    count++;
                }

            }

            return temppath;

        }




        public DataTable getTableList(string filepath)
        {
            //获取Connection
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            Connection accessConn = new Connection();
            OleDbConnection conn = accessConn.GetConnection(strConnection, filepath);
            //获取数据库结构
            DataTable table = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            DataTable Droptable = table.Clone();
            //表类型//
            foreach (System.Data.DataRow drow in table.Rows)
            {
                if (drow["TABLE_type"].ToString().ToUpper() == "TABLE")
                {
                    Droptable.ImportRow(drow);

                }
                conn.Dispose();
            }
            return Droptable;
        }

        public DataTable getTableColumnList(string filepath, string tableName)
        {
            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            Connection accessConn = new Connection();
            //获取Connection
            OleDbConnection conn = accessConn.GetConnection(strConnection,filepath);

            //获取数据库结构
            DataTable table = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new Object[] { null, null, tableName, null });
            
            conn.Dispose();
            return table;
        }

        public bool isMDBExist(string mdbpath)
        {

            string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
            Connection accessConn = new Connection();
            OleDbConnection conn = null;
            //获取Connection
            try {
            
                  conn = accessConn.GetConnection(strConnection, mdbpath);
            }catch(Exception eg){
                return false;
            
            }

            if (conn == null)
            {
                return false;
            }

            return true;
        }

        public bool isTableExist(string mdbpath, string tablename)
        {
          
            return true;
        }

       



        public bool isColumnExist(string mdbpath, string tablename, string columnname) {

            return false;
        }

      
    }
}
