using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Utilities;
using System.Collections;
using System.Data;

namespace CD6
{
    public class SoSFunctions
    {
        DBConnect objDB = new DBConnect();

        public DataSet SearchSoS(SignOutSheet objSoS)
        { 
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchForSOS";

            SqlParameter inputParameter = new SqlParameter("@arID", objSoS.arID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@claID", objSoS.cladID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@assingmentPeriod", objSoS.assingmentPeriod);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@dateCreated", objSoS.dateCreated);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.DateTime;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            string dateDue = objSoS.dateDue.ToString();
            if(objSoS.dateDue.ToString() == "1/1/1900 12:00:00 AM"){
                dateDue = "";
            }
            inputParameter = new SqlParameter("@dateDue", dateDue);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@assetDescription", objSoS.assetDescription);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            objDB.CloseConnection();
            return myDS;
        }

        public void DeleteSOS(SignOutSheet mySOS)
        {
            SqlCommand myCommand1 = new SqlCommand();
            myCommand1.CommandType = CommandType.StoredProcedure;
            myCommand1.CommandText = "DeleteSOS";

            SqlParameter inputParameter1 = new SqlParameter("sosID", mySOS.sosID);
        }

        public static bool UpdateSosHistory(int sosID, string editorID) {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateSOSHistory";

            SqlParameter inputParameter = new SqlParameter("@sosID", sosID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@editorID", editorID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            try {
                if (objDB.DoUpdateUsingCmdObj(objCommand) == -1) {
                    objDB.CloseConnection();
                    return false;
                }
                objDB.CloseConnection();
                return true;
            } catch {
                objDB.CloseConnection();
                return false;
            }
        }
        
        public static bool UpdateSoSDueDate(int sosID, string editorID, DateTime dueDate) {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "UpdateModifiedSOSDate";

            SqlParameter inputParameter1 = new SqlParameter("@sosID", sosID);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.VarChar;
            inputParameter1.Size = 100;
            objCommand1.Parameters.Add(inputParameter1);

            inputParameter1 = new SqlParameter("@dueDate", dueDate);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.VarChar;
            inputParameter1.Size = 100;
            objCommand1.Parameters.Add(inputParameter1);

            inputParameter1 = new SqlParameter("@editorID", editorID);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.VarChar;
            inputParameter1.Size = 100;
            objCommand1.Parameters.Add(inputParameter1);

            try {
                objDB.DoUpdateUsingCmdObj(objCommand1);
                objDB.CloseConnection();
                return true;
            } catch {
                objDB.CloseConnection();
                return false;
            }
        }

        public static bool UpdateSoSFileName(int sosID, string editorID, string fileName) {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "UpdateSosFileName";

            SqlParameter inputParameter1 = new SqlParameter("@sosID", sosID);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.VarChar;
            inputParameter1.Size = 100;
            objCommand1.Parameters.Add(inputParameter1);

            inputParameter1 = new SqlParameter("@fileName", fileName);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.VarChar;
            inputParameter1.Size = 100;
            objCommand1.Parameters.Add(inputParameter1);

            inputParameter1 = new SqlParameter("@editorID", editorID);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.VarChar;
            inputParameter1.Size = 100;
            objCommand1.Parameters.Add(inputParameter1);

            try {
                objDB.DoUpdateUsingCmdObj(objCommand1);
                objDB.CloseConnection();
                return true;
            } catch {
                objDB.CloseConnection();
                return false;
            }
        }
    }
}
