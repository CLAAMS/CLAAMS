using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Utilities;
using System.IO;
using System.Text;

namespace CD6 {
    public partial class sos_track : System.Web.UI.Page {
        SignOutSheet mySOS = new SignOutSheet();

        protected void Page_Load(object sender, EventArgs e) {
            String SqlConnectString = Global.Connection_String;

            DBConnect myDB = new DBConnect(SqlConnectString);
            SqlConnection myConn = new SqlConnection(SqlConnectString);
            SqlCommand MyCommand = new SqlCommand();
            myConn.Open();

            MyCommand.Connection = myConn;
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.CommandText = "sosTracking";

            gvSosTracking.DataSource = myDB.GetDataSetUsingCmdObj(MyCommand);
            gvSosTracking.DataBind();
        }

        protected void gvSosTracking_RowCommand(object sender, GridViewCommandEventArgs e) {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSosTracking.Rows[index];
            int sosID = (int)gvSosTracking.DataKeys[index].Value;

            if (e.CommandName == "view") {
                mySOS.sosID = Convert.ToInt32(gvSosTracking.Rows[index].Cells[0].Text);
                Session.Add("SOSID", mySOS.sosID);
                Response.Redirect("./sos_view.aspx");
            }
        }

        protected void linkExport_Click(object sender, EventArgs e) {
            string results = Tools.CSV.gvToCsv(gvSosTracking);

            Response.Clear();
            Response.AppendHeader("content-disposition", "attachment; filename=myfile.txt");
            Response.ContentType = "text/xml";
            UTF8Encoding encoding = new UTF8Encoding();
            Response.Write(results);
            Response.Flush();
            Response.End();
        }
    }
}
