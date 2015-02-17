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
    public class AssetFunctions
    {
        DBConnect objDB = new DBConnect();
        //String SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";

        public void CreateNewAsset(Asset objAsset)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CreateAsset";

            SqlParameter inputParameter = new SqlParameter("@CLATag", objAsset.CLATag);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Make", objAsset.Make);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Model", objAsset.Model);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Description", objAsset.Description);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@SerialNumber", objAsset.SerialNumber);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Status", objAsset.Status);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Notes", objAsset.Notes);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@recordCreated", objAsset.recordCreated);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.DateTime;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@recordModified", objAsset.recordModified);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.DateTime;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public DataSet SearchForAssets(Asset objAsset)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchForAssets";

            SqlParameter inputParameter = new SqlParameter("@CLATag", objAsset.CLATag);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Make", objAsset.Make);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Model", objAsset.Model);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Description", objAsset.Description);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@SerialNumber", objAsset.SerialNumber);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Status", objAsset.Status);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@Notes", objAsset.Notes);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        public void DeleteAsset(Asset objAsset)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateAssetHistory";

            SqlParameter inputParameter = new SqlParameter("@assetID", objAsset.assetID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 100;
            objCommand.Parameters.Add(inputParameter);

            objDB.DoUpdateUsingCmdObj(objCommand);

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "DeleteAssetAndSetStatus";

            SqlParameter inputParameter1 = new SqlParameter("@assetID", objAsset.assetID);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.VarChar;
            inputParameter1.Size = 100;
            objCommand1.Parameters.Add(inputParameter1);

            objDB.DoUpdateUsingCmdObj(objCommand1);


            
        }
       
    }
}