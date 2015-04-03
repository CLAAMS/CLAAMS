using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Utilities;
namespace CD6{
    public class AssetRecipient {
        public int assetRecipientId { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string location { get; set; }
        public string division { get; set; }
        public string primaryDeptAffiliation { get; set; }
        public string secondaryDeptAffiliation { get; set; }
        public string phoneNumber { get; set; }
        public string RecordCreated { get; set; }
        public string RecordModified { get; set; }
        String SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";

        public int CreateAssetRecipient(string Ptitle, string pFirstName, string pLastName, string PemailAddress, string plocation, string pdivision, string pprimaryDeptAffiliation, string psecondaryDeptAffiliation, string pphonenumber, string precordcreated, string precordmodified) {
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();
            SqlCommand myCommand1 = new SqlCommand();
            myCommand1.Connection = myConnection;
            myCommand1.CommandType = CommandType.StoredProcedure;
            myCommand1.CommandText = "CreateAssetRecipient";

            //SqlParameter inputParameter1 = new SqlParameter("@arID", PassetRecipientID);
            SqlParameter inputParameter2 = new SqlParameter("@Title", Ptitle);
            SqlParameter inputParameter3 = new SqlParameter("@FirstName", pFirstName);
            SqlParameter inputParameter4 = new SqlParameter("@LastName", pLastName);
            SqlParameter inputParameter5 = new SqlParameter("@EmailAddress", PemailAddress);
            SqlParameter inputParameter6 = new SqlParameter("@Location", plocation);
            SqlParameter inputParameter7 = new SqlParameter("@Division", pdivision);
            SqlParameter inputParameter8 = new SqlParameter("@PrimaryDeptAffiliation", pprimaryDeptAffiliation);
            SqlParameter inputParameter9 = new SqlParameter("@SecondaryDeptAffiliation", psecondaryDeptAffiliation);
            SqlParameter inputParameter10 = new SqlParameter("@PhoneNumber", pphonenumber);
            SqlParameter inputParameter11 = new SqlParameter("@recordCreated", precordcreated);
            SqlParameter inputParameter12 = new SqlParameter("@recordModified", precordmodified);

            //inputParameter1.Direction = ParameterDirection.Input;
            //inputParameter1.SqlDbType = SqlDbType.NChar;
            //inputParameter1.Size = 8;
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
            inputParameter6.Direction = ParameterDirection.Input;
            inputParameter6.SqlDbType = SqlDbType.VarChar;
            inputParameter6.Size = 50;
            inputParameter7.Direction = ParameterDirection.Input;
            inputParameter7.SqlDbType = SqlDbType.VarChar;
            inputParameter7.Size = 50;
            inputParameter8.Direction = ParameterDirection.Input;
            inputParameter8.SqlDbType = SqlDbType.VarChar;
            inputParameter8.Size = 50;
            inputParameter9.Direction = ParameterDirection.Input;
            inputParameter9.SqlDbType = SqlDbType.VarChar;
            inputParameter9.Direction = ParameterDirection.Input;
            inputParameter10.Direction = ParameterDirection.Input;
            inputParameter10.SqlDbType = SqlDbType.VarChar;
            inputParameter10.Size = 50;
            inputParameter11.Direction = ParameterDirection.Input;
            inputParameter11.SqlDbType = SqlDbType.DateTime;
            inputParameter11.Size = 50;
            inputParameter12.Direction = ParameterDirection.Input;
            inputParameter12.SqlDbType = SqlDbType.DateTime;
            inputParameter12.Size = 50;

            //myCommand.Parameters.Add(Convert.ToInt16(inputParameter1));
            myCommand1.Parameters.Add(inputParameter2);
            myCommand1.Parameters.Add(inputParameter3);
            myCommand1.Parameters.Add(inputParameter4);
            myCommand1.Parameters.Add(inputParameter5);
            myCommand1.Parameters.Add(inputParameter6);
            myCommand1.Parameters.Add(inputParameter7);
            myCommand1.Parameters.Add(inputParameter8);
            myCommand1.Parameters.Add(inputParameter9);
            myCommand1.Parameters.Add(inputParameter10);
            myCommand1.Parameters.Add(inputParameter11);
            myCommand1.Parameters.Add(inputParameter12);

            try {
                myCommand1.ExecuteNonQuery();
                return 1;
            } catch {
                return -1;
            }
        }

        public DataSet SearchAssetRecipient(string pTitle, string pFirstName, string pLastName, string PemailAddress, string plocation, string pdivision, string pprimaryDeptAffiliation, string psecondaryDeptAffiliation, string pphonenumber, string precordcreated, string precordmodified) {
            DataSet myDS = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand2 = new SqlCommand();
            myConnection.Open();
            myCommand2.Connection = myConnection;
            myCommand2.CommandType = CommandType.StoredProcedure;
            myCommand2.CommandText = "SearchForAssetRecipient";
            SqlParameter inputParameter2 = new SqlParameter("@Title", pTitle);
            SqlParameter inputParameter3 = new SqlParameter("@FirstName", pFirstName);
            SqlParameter inputParameter4 = new SqlParameter("@LastName", pLastName);
            SqlParameter inputParameter5 = new SqlParameter("@EmailAddress", PemailAddress);
            SqlParameter inputParameter6 = new SqlParameter("@Location", plocation);
            SqlParameter inputParameter7 = new SqlParameter("@Division", pdivision);
            SqlParameter inputParameter8 = new SqlParameter("@PrimaryDeptAffiliation", pprimaryDeptAffiliation);
            SqlParameter inputParameter9 = new SqlParameter("@SecondaryDeptAffiliation", psecondaryDeptAffiliation);
            SqlParameter inputParameter10 = new SqlParameter("@PhoneNumber", pphonenumber);
            SqlParameter inputParameter11 = new SqlParameter("@recordCreated", precordcreated);
            SqlParameter inputParameter12 = new SqlParameter("@recordModified", precordmodified);
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
            inputParameter6.Direction = ParameterDirection.Input;
            inputParameter6.SqlDbType = SqlDbType.VarChar;
            inputParameter6.Size = 50;
            inputParameter7.Direction = ParameterDirection.Input;
            inputParameter7.SqlDbType = SqlDbType.VarChar;
            inputParameter7.Size = 50;
            inputParameter8.Direction = ParameterDirection.Input;
            inputParameter8.SqlDbType = SqlDbType.VarChar;
            inputParameter8.Size = 50;
            inputParameter9.Direction = ParameterDirection.Input;
            inputParameter9.SqlDbType = SqlDbType.VarChar;
            inputParameter9.Size = 50;
            inputParameter10.Direction = ParameterDirection.Input;
            inputParameter10.SqlDbType = SqlDbType.VarChar;
            inputParameter10.Size = 50;
            inputParameter11.Direction = ParameterDirection.Input;
            inputParameter11.SqlDbType = SqlDbType.VarChar;
            inputParameter11.Size = 50;
            inputParameter12.Direction = ParameterDirection.Input;
            inputParameter12.SqlDbType = SqlDbType.VarChar;
            inputParameter12.Size = 50;
            myCommand2.Parameters.Add(inputParameter2);
            myCommand2.Parameters.Add(inputParameter3);
            myCommand2.Parameters.Add(inputParameter4);
            myCommand2.Parameters.Add(inputParameter5);
            myCommand2.Parameters.Add(inputParameter6);
            myCommand2.Parameters.Add(inputParameter7);
            myCommand2.Parameters.Add(inputParameter8);
            myCommand2.Parameters.Add(inputParameter9);
            myCommand2.Parameters.Add(inputParameter10);
            myCommand2.Parameters.Add(inputParameter11);
            myCommand2.Parameters.Add(inputParameter12);

            try {
                myDS = myDbConnect.GetDataSetUsingCmdObj(myCommand2);
                return myDS;
            } catch {
                return null;
            }
        }

        public int DeleteRow(int assetRecipientId) {
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand3 = new SqlCommand();
            myConnection.Open();
            myCommand3.Connection = myConnection;
            myCommand3.CommandType = CommandType.StoredProcedure;
            myCommand3.CommandText = "DeleteAssetRecipient";
            SqlParameter inputParameter1 = new SqlParameter("@arID", assetRecipientId);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.Int;
            inputParameter1.Size = 50;
            myCommand3.Parameters.Add(inputParameter1);
            try {
                myDbConnect.DoUpdateUsingCmdObj(myCommand3);
                return 1;
            } catch {
                return -1;
            }
        }

        public int UpdateRow(int assetRecipientID,string pTitle,string pFirstName,string pLastName,string pEmail, string pLocation, string pDivision, string pPDA, string pSDA, string pPhone, string pRecordModified) {
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand5 = new SqlCommand();
            myConnection.Open();
            myCommand5.Connection = myConnection;
            myCommand5.CommandType = CommandType.StoredProcedure;
            myCommand5.CommandText = "ModifyAssetRecipient";
            SqlParameter inputParameter1 = new SqlParameter("@arID", assetRecipientID);
            SqlParameter inputParameter2 = new SqlParameter("@Title", pTitle);
            SqlParameter inputParameter3 = new SqlParameter("@FirstName", pFirstName);
            SqlParameter inputParameter4 = new SqlParameter("@LastName", pLastName);
            SqlParameter inputParameter5 = new SqlParameter("@EmailAddress", pEmail);
            SqlParameter inputParameter6 = new SqlParameter("@Location", pLocation);
            SqlParameter inputParameter7 = new SqlParameter("@Division", pDivision);
            SqlParameter inputParameter8 = new SqlParameter("@PrimaryDeptAffiliation", pPDA);
            SqlParameter inputParameter9 = new SqlParameter("@SecondaryDeptAffiliation", pSDA);
            SqlParameter inputParameter10 = new SqlParameter("@PhoneNumber", pPhone);
            
            SqlParameter inputParameter12 = new SqlParameter("@recordModified", pRecordModified);
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
            inputParameter6.Direction = ParameterDirection.Input;
            inputParameter6.SqlDbType = SqlDbType.VarChar;
            inputParameter6.Size = 50;
            inputParameter7.Direction = ParameterDirection.Input;
            inputParameter7.SqlDbType = SqlDbType.VarChar;
            inputParameter7.Size = 50;
            inputParameter8.Direction = ParameterDirection.Input;
            inputParameter8.SqlDbType = SqlDbType.VarChar;
            inputParameter8.Size = 50;
            inputParameter9.Direction = ParameterDirection.Input;
            inputParameter9.SqlDbType = SqlDbType.VarChar;
            inputParameter9.Size = 50;
            inputParameter10.Direction = ParameterDirection.Input;
            inputParameter10.SqlDbType = SqlDbType.VarChar;
            inputParameter10.Size = 50;
          
            inputParameter12.Direction = ParameterDirection.Input;
            inputParameter12.SqlDbType = SqlDbType.VarChar;
            inputParameter12.Size = 50;
            myCommand5.Parameters.Add(inputParameter1);
            myCommand5.Parameters.Add(inputParameter2);
            myCommand5.Parameters.Add(inputParameter3);
            myCommand5.Parameters.Add(inputParameter4);
            myCommand5.Parameters.Add(inputParameter5);
            myCommand5.Parameters.Add(inputParameter6);
            myCommand5.Parameters.Add(inputParameter7);
            myCommand5.Parameters.Add(inputParameter8);
            myCommand5.Parameters.Add(inputParameter9);
            myCommand5.Parameters.Add(inputParameter10);
            myCommand5.Parameters.Add(inputParameter12);

            try {
                myDbConnect.DoUpdateUsingCmdObj(myCommand5);
                return 1;
            } catch {
                return -1;
            }
        }

        public DataSet GetLocationForSelectedRecord(int ARID) {
            DBConnect theDB=new DBConnect();
            SqlConnection myConnection=new SqlConnection(SqlConnectString);
            SqlCommand myCommand6=new SqlCommand();
            myConnection.Open();
            myCommand6.Connection = myConnection;
            myCommand6.CommandType = CommandType.StoredProcedure;
            myCommand6.CommandText = "GetLocationForSelectedRecord";

            SqlParameter inputParameter1=new SqlParameter("arID",ARID);
            inputParameter1.Direction=ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.Int;
            inputParameter1.Size=50;

            myCommand6.Parameters.Add(inputParameter1);
            DataSet myDS=theDB.GetDataSetUsingCmdObj(myCommand6);
            return myDS;
        }
    }
}

