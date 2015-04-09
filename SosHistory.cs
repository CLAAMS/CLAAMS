using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace CD6 {
    public class SosHistory {
        public int sosID { get; set; }
        public int sosHistoryID { get; set; }
        public String cladID { get; set; }
        public int arID { get; set; }
        public int assingmentPeriod { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public DateTime dateDue { get; set; }
        public String status { get; set; }
        public String imageFileName { get; set; }
        public DateTime recordModified { get; set; }
        public DateTime recordCreated { get; set; }
        public String editorID { get; set; }

        public static ArrayList getHistoryForSOS(int sosID) {
            ArrayList histories = new ArrayList();

            string SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";

            DataSet myDS = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand = new SqlCommand();
            myConnection.Open();

            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "getSosHistory";

            SqlParameter sosIDParam = new SqlParameter("@sosID", sosID);

            sosIDParam.Direction = ParameterDirection.Input;
            sosIDParam.SqlDbType = SqlDbType.Int;
            sosIDParam.Size = 50;

            myCommand.Parameters.Add(sosIDParam);

            myDS = myDbConnect.GetDataSetUsingCmdObj(myCommand);

            foreach (DataRow row in myDS.Tables[0].Rows) {
                SosHistory history = new SosHistory();
                history.sosID = Convert.ToInt32(row.ItemArray[0].ToString());
                history.sosHistoryID = Convert.ToInt32(row.ItemArray[1].ToString());
                history.cladID = row.ItemArray[2].ToString();
                history.arID = Convert.ToInt32(row.ItemArray[3].ToString());
                history.assingmentPeriod = Convert.ToInt32(row.ItemArray[4].ToString());
                history.dateCreated = (DateTime)row.ItemArray[5];
                history.dateModified = (DateTime)row.ItemArray[6];
                history.dateDue = (DateTime)row.ItemArray[7];
                history.status = row.ItemArray[8].ToString();
                history.imageFileName = row.ItemArray[9].ToString();
                history.recordModified = (DateTime)row.ItemArray[10];
                history.recordCreated = (DateTime)row.ItemArray[11];
                history.editorID = row.ItemArray[12].ToString();
                histories.Add(history);
            }

            return histories;
        }

        public static int getLastHistoryID(int sosID) {
            int historyID;

            string SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";

            DataSet myDS = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand = new SqlCommand();
            myConnection.Open();

            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "getLastSosHistoryIdBySos";

            SqlParameter sosIDParam = new SqlParameter("@sosID", sosID);

            sosIDParam.Direction = ParameterDirection.Input;
            sosIDParam.SqlDbType = SqlDbType.Int;
            sosIDParam.Size = 50;

            myCommand.Parameters.Add(sosIDParam);

            myDS = myDbConnect.GetDataSetUsingCmdObj(myCommand);
            
            if(myDS.Tables[0].Rows.Count == 0){
                historyID = 0;
            } else {
                historyID = Convert.ToInt32(myDS.Tables[0].Rows[0][0].ToString());
            }

            return historyID;
        }

        public static SosHistory getHistoryByID(int sosHistoryID) {
            SosHistory history = new SosHistory();

            string SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";

            DataSet myDS = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand = new SqlCommand();
            myConnection.Open();

            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "getSosHistoryById";

            SqlParameter sosIDParam = new SqlParameter("@sosHistoryID", sosHistoryID);

            sosIDParam.Direction = ParameterDirection.Input;
            sosIDParam.SqlDbType = SqlDbType.Int;
            sosIDParam.Size = 50;

            myCommand.Parameters.Add(sosIDParam);

            myDS = myDbConnect.GetDataSetUsingCmdObj(myCommand);

            history.sosID = Convert.ToInt32(myDS.Tables[0].Rows[0][0].ToString());
            history.sosHistoryID = Convert.ToInt32(myDS.Tables[0].Rows[0][1].ToString());
            history.cladID = myDS.Tables[0].Rows[0][2].ToString();
            history.arID = Convert.ToInt32(myDS.Tables[0].Rows[0][3].ToString());
            history.assingmentPeriod = Convert.ToInt32(myDS.Tables[0].Rows[0][4].ToString());
            history.dateCreated = (DateTime)myDS.Tables[0].Rows[0][5];
            history.dateModified = (DateTime)myDS.Tables[0].Rows[0][6];
            history.dateDue = (DateTime)myDS.Tables[0].Rows[0][7];
            history.status = myDS.Tables[0].Rows[0][8].ToString();
            history.imageFileName = myDS.Tables[0].Rows[0][9].ToString();
            history.recordModified = (DateTime)myDS.Tables[0].Rows[0][10];
            history.recordCreated = (DateTime)myDS.Tables[0].Rows[0][11];
            history.editorID = myDS.Tables[0].Rows[0][12].ToString();

            return history;
        }
    }
}