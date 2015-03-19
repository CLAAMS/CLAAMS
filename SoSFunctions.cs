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

            string assingmentPeriod;

            if (objSoS.assingmentPeriod == 0)
            {
                assingmentPeriod = "";
            }
            else
            {
                assingmentPeriod = objSoS.assingmentPeriod.ToString();
            }
            inputParameter = new SqlParameter("@assingmentPeriod", assingmentPeriod);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@dateCreated", objSoS.dateCreated);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.DateTime;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@assetDescription", objSoS.assetDescription);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

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
