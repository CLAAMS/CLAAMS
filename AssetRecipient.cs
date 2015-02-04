using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Utilities;
namespace CD6
{
    public class AssetRecipient
    {
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

        SqlCommand myCommand = new SqlCommand();
        public int CreateAssetRecipient(string Ptitle, string pFirstName, string pLastName, string PemailAddress, string plocation, string pdivision, string pprimaryDeptAffiliation, string psecondaryDeptAffiliation, string pphonenumber, string precordcreated, string precordmodified)
        {

            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();

            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "CreateAssetRecipient";

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
            myCommand.Parameters.Add(inputParameter2);
            myCommand.Parameters.Add(inputParameter3);
            myCommand.Parameters.Add(inputParameter4);
            myCommand.Parameters.Add(inputParameter5);
            myCommand.Parameters.Add(inputParameter6);
            myCommand.Parameters.Add(inputParameter7);
            myCommand.Parameters.Add(inputParameter8);
            myCommand.Parameters.Add(inputParameter9);
            myCommand.Parameters.Add(inputParameter10);
            myCommand.Parameters.Add(inputParameter11);
            myCommand.Parameters.Add(inputParameter12);

            try
            {

                myCommand.ExecuteNonQuery();
                return 1;
                
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public DataSet SearchAssetRecipient(string pTitle, string pFirstName, string pLastName, string PemailAddress, string plocation, string pdivision, string pprimaryDeptAffiliation, string psecondaryDeptAffiliation, string pphonenumber, string precordcreated, string precordmodified)
        {
            DataSet myDS = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "SearchForAssetRecipient";
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
            myCommand.Parameters.Add(inputParameter2);
            myCommand.Parameters.Add(inputParameter3);
            myCommand.Parameters.Add(inputParameter4);
            myCommand.Parameters.Add(inputParameter5);
            myCommand.Parameters.Add(inputParameter6);
            myCommand.Parameters.Add(inputParameter7);
            myCommand.Parameters.Add(inputParameter8);
            myCommand.Parameters.Add(inputParameter9);
            myCommand.Parameters.Add(inputParameter10);
            myCommand.Parameters.Add(inputParameter11);
            myCommand.Parameters.Add(inputParameter12);
            try
            {

                myDbConnect.GetDataSetUsingCmdObj(myCommand);
                myConnection.Close();
                return myDS;
              
            }
            catch (Exception ex)
            {
                return null;
            }


        }



    }
}
