using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Utilities;

namespace CD6 {
    public class Asset {
        public int assetID { get; set; }
        //public int assetHisotryId { get; set; }
        public string CLATag { get; set; }
        public string Make { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime recordModified { get; set; }
        public DateTime recordCreated { get; set; }
        public int sosID { get; set; }
        public string editorID { get; set; }
        String SqlConnectString = Global.Connection_String;

        public DataSet GetAssetForSelectedRecord(int assetId) {
            DBConnect theDB = new DBConnect(SqlConnectString);
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand6 = new SqlCommand();
            myConnection.Open();
            myCommand6.Connection = myConnection;
            myCommand6.CommandType = CommandType.StoredProcedure;
            myCommand6.CommandText = "SelectAllByAssetID";

            SqlParameter inputParameter1 = new SqlParameter("assetID",assetId);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.Int;
            inputParameter1.Size = 50;

            myCommand6.Parameters.Add(inputParameter1);
            DataSet myDS = theDB.GetDataSetUsingCmdObj(myCommand6);
            return myDS;
        }

        public void archiveAndModify(Asset objAsset) {
            AssetFunctions AF = new AssetFunctions();
            AF.ModifyAsset(objAsset);
        }

        public static ArrayList getHistoriesByID(int assetID){
            ArrayList histories = new ArrayList();

            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateSosStatus";

            SqlParameter assetIdParam = new SqlParameter("@sosID", assetID);
            assetIdParam.Direction = ParameterDirection.Input;
            assetIdParam.SqlDbType = SqlDbType.Int;
            assetIdParam.Size = 100;
            objCommand.Parameters.Add(assetIdParam);

            try {
                objDB.DoUpdateUsingCmdObj(objCommand);
                objDB.CloseConnection();
                return true;
            } catch {
                objDB.CloseConnection();
                return false;
            }

            return histories;
        }
    }
}