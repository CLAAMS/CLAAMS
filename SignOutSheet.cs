using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Utilities;
namespace CD6
{
    public class SignOutSheet
    {
        public int sosID { get; set; }
        public int sosHistoryID { get; set; }
        public int assetID { get; set; }
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
        public String assetDescription { get; set; }
        String SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";

        public DataSet returnSignSheetRecipients()
        {
            DataSet myDS = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand1 = new SqlCommand();
            myConnection.Open();

            myCommand1.Connection = myConnection;
            myCommand1.CommandType = CommandType.StoredProcedure;
            myCommand1.CommandText = "SelectNameandARID";

            myDS = myDbConnect.GetDataSetUsingCmdObj(myCommand1);
            return myDS;
        }

        public DataSet returnAssigner()
        {
            DataSet myDS = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand2 = new SqlCommand();
            myConnection.Open();

            myCommand2.Connection = myConnection;
            myCommand2.CommandType = CommandType.StoredProcedure;
            myCommand2.CommandText = "SelectCLAIDandName";

            myDS = myDbConnect.GetDataSetUsingCmdObj(myCommand2);
            return myDS;

        }

        public DataSet SearchForAssets(int assetID, string assetName, string assetType, string claTag, string serial)
        {
            DBConnect myDb=new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();
            SqlCommand myCommand5 = new SqlCommand();
            myCommand5.Connection = myConnection;
            myCommand5.CommandType = CommandType.StoredProcedure;
            myCommand5.CommandText = "SearchForAssetsForSOS";
            DataSet myDs = new DataSet();

            SqlParameter inputParameter1 = new SqlParameter("@assetId", assetID);
            SqlParameter inputParameter2 = new SqlParameter("@make", assetName);
            SqlParameter inputParameter3 = new SqlParameter("@model", assetType);
            SqlParameter inputParameter4 = new SqlParameter("@claTag", claTag);
            SqlParameter inputParameter5 = new SqlParameter("@serialNumber", serial);

            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.Int;
            inputParameter1.Size = 50;
            inputParameter2.Direction = ParameterDirection.Input;
            inputParameter2.SqlDbType = SqlDbType.VarChar;
            inputParameter2.Size = 50;
            inputParameter3.Direction = ParameterDirection.Input;
            inputParameter3.SqlDbType = SqlDbType.VarChar;
            inputParameter3.Size = 50;
            inputParameter4.Direction = ParameterDirection.Input;
            inputParameter4.SqlDbType = SqlDbType.VarChar;
            inputParameter4.Size = 50;
            inputParameter5.Direction = ParameterDirection.Input;
            inputParameter5.SqlDbType = SqlDbType.VarChar;
            inputParameter5.Size = 50;

            myCommand5.Parameters.Add(inputParameter1);
            myCommand5.Parameters.Add(inputParameter2);
            myCommand5.Parameters.Add(inputParameter3);
            myCommand5.Parameters.Add(inputParameter4);
            myCommand5.Parameters.Add(inputParameter5);

            myDs = myDb.GetDataSetUsingCmdObj(myCommand5);

            return myDs;
        }

        public int CreateSignOutSheet(int assetId, String claId, int arId, int assignmentPeriod, DateTime creationDate, DateTime modifyDate, DateTime dueDate, string status, string imageFileName, DateTime recordModified, DateTime recordCreated)
        {
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();
            SqlCommand myCommand4 = new SqlCommand();
         
            myCommand4.Connection = myConnection;
            myCommand4.CommandType = CommandType.StoredProcedure;
            myCommand4.CommandText = "CreateSignOutSheet";
           

            //Input parameters for stored procedure
            SqlParameter inputParameter1 = new SqlParameter("@assetID", assetId);
            SqlParameter inputParameter2 = new SqlParameter("@claID", claId);
            SqlParameter inputParameter3 = new SqlParameter("@arID", arId);
            SqlParameter inputParameter4 = new SqlParameter("@assignmentPeriod", assingmentPeriod);
            SqlParameter inputParameter5 = new SqlParameter("@dateCreated", creationDate);
            SqlParameter inputParameter6 = new SqlParameter("@dateModified", modifyDate);
            SqlParameter inputParameter7 = new SqlParameter("@dateDue", dueDate);
            SqlParameter inputParameter8 = new SqlParameter("@status", status);
            SqlParameter inputParameter9 = new SqlParameter("@imageFileName", imageFileName);
            SqlParameter inputParameter10 = new SqlParameter("@recordModified", recordModified);
            SqlParameter inputParameter11 = new SqlParameter("@recordCreated", recordCreated);
          

            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.Int;
            inputParameter1.Size = 50;
            inputParameter2.Direction = ParameterDirection.Input;
            inputParameter2.SqlDbType = SqlDbType.NChar;
            inputParameter2.Size = 50;
            inputParameter3.Direction = ParameterDirection.Input;
            inputParameter3.SqlDbType = SqlDbType.Int;
            inputParameter3.Size = 50;
            inputParameter4.Direction = ParameterDirection.Input;
            inputParameter4.SqlDbType = SqlDbType.Int;
            inputParameter4.Size = 50;
            inputParameter5.Direction = ParameterDirection.Input;
            inputParameter5.SqlDbType = SqlDbType.DateTime;
            inputParameter5.Size = 50;
            inputParameter6.Direction = ParameterDirection.Input;
            inputParameter6.SqlDbType = SqlDbType.DateTime;
            inputParameter6.Size = 50;
            inputParameter7.Direction = ParameterDirection.Input;
            inputParameter7.SqlDbType = SqlDbType.DateTime;
            inputParameter7.Size = 50;
            inputParameter8.Direction = ParameterDirection.Input;
            inputParameter8.SqlDbType = SqlDbType.VarChar;
            inputParameter8.Size = 50;
            inputParameter9.Direction = ParameterDirection.Input;
            inputParameter9.SqlDbType = SqlDbType.VarChar;
            inputParameter9.Size = 50;
            inputParameter10.Direction = ParameterDirection.Input;
            inputParameter10.SqlDbType = SqlDbType.DateTime;
            inputParameter10.Size = 50;
            inputParameter11.Direction = ParameterDirection.Input;
            inputParameter11.SqlDbType = SqlDbType.DateTime;
            inputParameter11.Size = 50;
         

            myCommand4.Parameters.Add(inputParameter1);
            myCommand4.Parameters.Add(inputParameter2);
            myCommand4.Parameters.Add(inputParameter3);
            myCommand4.Parameters.Add(inputParameter4);
            myCommand4.Parameters.Add(inputParameter5);
            myCommand4.Parameters.Add(inputParameter6);
            myCommand4.Parameters.Add(inputParameter7);
            myCommand4.Parameters.Add(inputParameter8);
            myCommand4.Parameters.Add(inputParameter9);
            myCommand4.Parameters.Add(inputParameter10);
            myCommand4.Parameters.Add(inputParameter11);

         
            try
            {

                int result = Convert.ToInt32(myCommand4.ExecuteScalar());
                return result;

            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        public int ModifyAsset(int sosID,int assetId){
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();
            SqlCommand myCommand5 = new SqlCommand();
            myCommand5.Connection = myConnection;
            myCommand5.CommandType = CommandType.StoredProcedure;
            myCommand5.CommandText = "UpdateAssetSOSID";
            SqlParameter inputParameter1 = new SqlParameter("@sosID", sosID);
            SqlParameter inputParameter2=new SqlParameter("@assetID",assetId);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.Int;
            inputParameter1.Size = 50;
            inputParameter2.Direction = ParameterDirection.Input;
            inputParameter2.SqlDbType = SqlDbType.Int;
            inputParameter2.Size = 50;
            myCommand5.Parameters.Add(inputParameter1);
            myCommand5.Parameters.Add(inputParameter2);
          

            try
            {

                int result = myCommand5.ExecuteNonQuery();
                return 1;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int DeleteSOS(int sosID)
        {
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();
            SqlCommand myCommand6 = new SqlCommand();
            myCommand6.Connection = myConnection;
            myCommand6.CommandType = CommandType.StoredProcedure;
            myCommand6.CommandText = "DeleteSOS";
            SqlParameter inputParameter1 = new SqlParameter("@sosID", sosID);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.Int;
            inputParameter1.Size = 50;
            myCommand6.Parameters.Add(inputParameter1);

            try
            {

                int result = myCommand6.ExecuteNonQuery();
                return 1;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static SignOutSheet getSOSbyID(int sosID) {
            SignOutSheet mySOS = new SignOutSheet();

            string SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";

            DataSet myDS = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand = new SqlCommand();
            myConnection.Open();

            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "getSosById";

            //Input parameters for stored procedure
            SqlParameter sosIDParam = new SqlParameter("@sosID", sosID);

            sosIDParam.Direction = ParameterDirection.Input;
            sosIDParam.SqlDbType = SqlDbType.Int;
            sosIDParam.Size = 50;

            myCommand.Parameters.Add(sosIDParam);

            myDS = myDbConnect.GetDataSetUsingCmdObj(myCommand);

            mySOS.sosID = Convert.ToInt32(myDS.Tables[0].Rows[0][0].ToString());
            mySOS.cladID = myDS.Tables[0].Rows[0][1].ToString();
            mySOS.arID = Convert.ToInt32(myDS.Tables[0].Rows[0][2].ToString());
            mySOS.assingmentPeriod = Convert.ToInt32(myDS.Tables[0].Rows[0][3].ToString());
            mySOS.dateCreated = Convert.ToDateTime(myDS.Tables[0].Rows[0][4]);
            mySOS.dateModified = Convert.ToDateTime(myDS.Tables[0].Rows[0][5]);
            mySOS.dateDue = Convert.ToDateTime(myDS.Tables[0].Rows[0][6]);
            mySOS.status = myDS.Tables[0].Rows[0][7].ToString();
            mySOS.imageFileName = myDS.Tables[0].Rows[0][8].ToString();
            mySOS.recordCreated = Convert.ToDateTime(myDS.Tables[0].Rows[0][9]);
            mySOS.recordModified = Convert.ToDateTime(myDS.Tables[0].Rows[0][10]);
            //mySOS.editorID = myDS.Tables[0].Rows[0][11].ToString();

            return mySOS;
        }
    }
}