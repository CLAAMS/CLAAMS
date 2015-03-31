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
using System.Collections;

namespace CD6 {
    public partial class sos_track : System.Web.UI.Page {
             SignOutSheet mySOS = new SignOutSheet();
        protected void Page_Load(object sender, EventArgs e) {
            String SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";
            
            DBConnect myDB = new DBConnect();
            SqlConnection myConn = new SqlConnection(SqlConnectString);
            SqlCommand MyCommand = new SqlCommand();
            myConn.Open();

            MyCommand.Connection = myConn;
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.CommandText = "sosTracking";

            gvSosTracking.DataSource = myDB.GetDataSetUsingCmdObj(MyCommand);
            gvSosTracking.DataBind();
        }
        protected void gvSosTracking_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSosTracking.Rows[index];
            int sosID = (int)gvSosTracking.DataKeys[index].Value;
            if (e.CommandName == "view")
            {
                mySOS.sosID = Convert.ToInt32(gvSosTracking.Rows[index].Cells[0].Text);
                Session.Add("SOSID", mySOS.sosID);
                Response.Redirect("./sos_view.aspx");

            }
        }

        protected void gvSosTracking_Click(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSosTracking.Rows[index];
            int sosID = (int)gvSosTracking.DataKeys[index].Value;

            if (e.CommandName == "view")
            {

            }
            else if (e.CommandName == "checkin")
            {
                SignOutSheet mySignoutSheet = new SignOutSheet();
                mySignoutSheet.sosID = Convert.ToInt32(gvSosTracking.Rows[index].Cells[0].Text);
                mySignoutSheet.dateDue= Convert.ToDateTime(gvSosTracking.Rows[index].Cells[2].Text);
                int soonness = Convert.ToInt32(gvSosTracking.Rows[index].Cells[3].Text);
                if (soonness < 1)
                {
                    mySignoutSheet.status = "Overdue";
                }
                else
                    mySignoutSheet.status = "Not Overude";
            }
        }
    }
