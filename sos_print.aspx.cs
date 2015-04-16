using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace CD6 {
    public partial class sos_print : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            int sosId = (int)Session["sosIdForPrint"];

            DataSet info = getInfo(sosId);

            DateTime dueDate = (DateTime)info.Tables[0].Rows[0].ItemArray[4];
            if (DateTime.Equals(dueDate, DateTime.Parse("9/24/3000 3:00:00 PM"))) {
                divDue.Visible = false;
            }

            lblPrintDate.Text = DateTime.Now.ToShortDateString();
            lblRecipientName.Text = info.Tables[0].Rows[0].ItemArray[0].ToString();
            lblAssignerName.Text = info.Tables[0].Rows[0].ItemArray[1].ToString();
            lblRecipientDepartment.Text = info.Tables[0].Rows[0].ItemArray[3].ToString();
            lblDueDate.Text = dueDate.ToShortDateString();
            lblRecipientLocation.Text = info.Tables[0].Rows[0].ItemArray[5].ToString();

            gvAssets.DataSource = info;
            gvAssets.DataBind();
        }

        protected DataSet getInfo(int sosId) {
            string SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";

            DBConnect dbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "PrintInfo";

            SqlParameter inputAssetID = new SqlParameter("@sosId", sosId);

            inputAssetID.Direction = ParameterDirection.Input;
            inputAssetID.SqlDbType = SqlDbType.Int;
            inputAssetID.Size = 50;

            myCommand.Parameters.Add(inputAssetID);

            try {
                DataSet myDs = dbConnect.GetDataSetUsingCmdObj(myCommand);
                return myDs;
            } catch {
                return null;
            }
        }
    }
}