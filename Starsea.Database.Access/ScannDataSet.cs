using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Starsea.Database.Access
{
   public class ScannDataSet
    {

        public List<string> getDatasetTables(DataSet ds) {
            List<string> res = new List<string>();
            for (int i = 0; i < ds.Tables.Count;i++ )
            {
                string tableName = ds.Tables[i].TableName.ToString();
                res.Add(tableName);
            }
            return res;
        
        
        }

        public string getDatasetColumns(DataSet ds, string tableName) {
            string res = "";
            DataTable dt=ds.Tables[tableName];
            for(int i=0;i<dt.Columns.Count;i++){
               string colName=dt.Columns[i].ColumnName.ToString();
               if (i == 0)
               {
                   res = colName;
               }
               else {
                   res +=","+colName ;
               }
        
            }
            return res;
           
        }

        public void DataSetExportMdb(DataSet ds, string mdbPath) {
            List<string> tables = getDatasetTables(ds);
            List<string> table_cols = new List<string>();
            for (int i = 0; i < tables.Count;i++ )
            {
                string cols = getDatasetColumns(ds,tables.ToArray()[i]);
                table_cols.Add(cols);
            }

            CreateMdb cmdb = new CreateMdb();
            cmdb.CreateAccessDatabase(mdbPath);
            cmdb.creatMdbTables(mdbPath, tables, table_cols);
        }

    }
}
