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

            SqlParameter inputParameter1 = new SqlParameter("@arID", objSoS.arID);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.VarChar;
            inputParameter1.Size = 50;
            objCommand.Parameters.Add(inputParameter1);

            SqlParameter inputParameter2 = new SqlParameter("@claID", objSoS.cladID);
            inputParameter2.Direction = ParameterDirection.Input;
            inputParameter2.SqlDbType = SqlDbType.VarChar;
            inputParameter2.Size = 50;
            objCommand.Parameters.Add(inputParameter2);

            SqlParameter inputParameter3 = new SqlParameter("@assingmentPeriod", objSoS.assingmentPeriod);
            inputParameter3.Direction = ParameterDirection.Input;
            inputParameter3.SqlDbType = SqlDbType.VarChar;
            inputParameter3.Size = 50;
            objCommand.Parameters.Add(inputParameter3);

            SqlParameter inputParameter4 = new SqlParameter("@dateCreated", objSoS.dateCreated);
            inputParameter4.Direction = ParameterDirection.Input;
            inputParameter4.SqlDbType = SqlDbType.DateTime;
            inputParameter4.Size = 50;
            objCommand.Parameters.Add(inputParameter4);

            SqlParameter inputParameter5 = new SqlParameter("@assetDescription", objSoS.assetDescription);
            inputParameter5.Direction = ParameterDirection.Input;
            inputParameter5.SqlDbType = SqlDbType.VarChar;
            inputParameter5.Size = 50;
            objCommand.Parameters.Add(inputParameter5);
            
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }
        public void DeleteSOS(SignOutSheet mySOS)
        {
            SqlCommand myCommand1 = new SqlCommand();
            myCommand1.CommandType = CommandType.StoredProcedure;
            myCommand1.CommandText = "DeleteSOS";

            SqlParameter inputParameter1 = new SqlParameter("sosID", mySOS.sosID);



        }

   }
}
