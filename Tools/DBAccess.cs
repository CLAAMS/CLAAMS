using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Utilities;
using Tools;
namespace Tools {
    public class DBAccess {
        public static DataSet DBCall(string sql, string ConnectionString) {
            DBConnect database = new DBConnect(ConnectionString);
            DataSet dataset = database.GetDataSet(sql);
            database.CloseConnection();
            return dataset;
        }

        public static int DBUpdate(string sql, string ConnectionString) {
            DBConnect database = new DBConnect(ConnectionString);
            return database.DoUpdate(sql);
        }
    }
}
