using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Utilities;

namespace Tools {
    public class DBAccess {
        public static DataSet DBCall(string sql) {
            DBConnect database = new DBConnect();
            DataSet dataset = database.GetDataSet(sql);
            database.CloseConnection();
            return dataset;
        }

        public static int DBUpdate(string sql) {
            DBConnect database = new DBConnect();
            return database.DoUpdate(sql);
        }
    }
}
