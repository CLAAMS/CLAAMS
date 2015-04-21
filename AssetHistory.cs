using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace CD6 {
    public class AssetHistory {
        public int assetID { get; set; }
        public String CLATag { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public String Description { get; set; }
        public String SerialNumber { get; set; }
        public String Status { get; set; }
        public String Notes { get; set; }
        public DateTime recordCreated { get; set; }
        public DateTime recordModified { get; set; }
        public int assetHistoryID { get; set; }
        public DateTime ChangeTimeStamp { get; set; }
        public int sosID { get; set; }
        public String editorID { get; set; }

        public static AssetHistory getAssetHistory(int assetHistoryID) {
            string SqlConnectString = Global.Connection_String;

            DBConnect dbConnect = new DBConnect(SqlConnectString);
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "getAssetHistory";

            SqlParameter inputAssetHistoryID = new SqlParameter("@historyID", assetHistoryID);

            inputAssetHistoryID.Direction = ParameterDirection.Input;
            inputAssetHistoryID.SqlDbType = SqlDbType.Int;
            inputAssetHistoryID.Size = 50;

            myCommand.Parameters.Add(inputAssetHistoryID);

            try{
                DataSet myDS = dbConnect.GetDataSetUsingCmdObj(myCommand);
                AssetHistory assetHistory = new AssetHistory();
                assetHistory.assetID = (int)myDS.Tables[0].Rows[0].ItemArray[0];
                assetHistory.CLATag = myDS.Tables[0].Rows[0].ItemArray[1].ToString();
                assetHistory.Make = myDS.Tables[0].Rows[0].ItemArray[2].ToString();
                assetHistory.Model = myDS.Tables[0].Rows[0].ItemArray[3].ToString();
                assetHistory.Description = myDS.Tables[0].Rows[0].ItemArray[4].ToString();
                assetHistory.SerialNumber = myDS.Tables[0].Rows[0].ItemArray[5].ToString();
                assetHistory.Status = myDS.Tables[0].Rows[0].ItemArray[6].ToString();
                assetHistory.Notes = myDS.Tables[0].Rows[0].ItemArray[7].ToString();
                assetHistory.assetHistoryID = (int)myDS.Tables[0].Rows[0].ItemArray[8];

                return assetHistory;
            } catch {
                return null;
            }
        }

        public static Dictionary<int, DateTime> getAssetHistories(int assetID) {
            string SqlConnectString = Global.Connection_String;

            DBConnect dbConnect = new DBConnect(SqlConnectString);
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "GetHistoriesForAsset";

            SqlParameter inputAssetID = new SqlParameter("@assetID", assetID);

            inputAssetID.Direction = ParameterDirection.Input;
            inputAssetID.SqlDbType = SqlDbType.Int;
            inputAssetID.Size = 50;

            myCommand.Parameters.Add(inputAssetID);

            try{
                DataSet myDS = dbConnect.GetDataSetUsingCmdObj(myCommand);
                Dictionary<int, DateTime> histories = new Dictionary<int, DateTime>();

                foreach (DataRow row in myDS.Tables[0].Rows) {
                    histories.Add((int)row.ItemArray[0], (DateTime)row.ItemArray[1]);
                }

                return histories;
            } catch {
                return null;
            }
        }
    }
}