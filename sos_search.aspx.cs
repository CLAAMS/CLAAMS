using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace CD6 {
    public partial class sos_search : System.Web.UI.Page {
        SignOutSheet mySOS = new SignOutSheet();

        protected void Page_Load(object sender, EventArgs e) {
            lblSearchSOSDirections.Visible = true;
            lblSearchSOSDirections.Text = "Enter any combination of fields to search for Sign Out Sheets. To view all Sign Out Sheets, leave all fields blank and click search button.";
            fillDropdowns();
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            mySOS.arID = Convert.ToInt32(ddlRecipient.SelectedValue);
            mySOS.cladID = ddlAssigner.SelectedValue;
            mySOS.assingmentPeriod = Convert.ToInt32(ddlTerm.SelectedValue);

            if (mySOS.assingmentPeriod == 1) {
                if (calDueDate.SelectedDate == Convert.ToDateTime("1/1/0001 12:00:00 AM")) {
                    mySOS.dateDue = Convert.ToDateTime("1/1/1900 12:00:00 AM");
                } else {
                    mySOS.dateDue = calDueDate.SelectedDate;
                }
            }

            mySOS.dateCreated = calIssueDate.SelectedDate;

            if (mySOS.dateCreated == Convert.ToDateTime("1/1/0001 12:00:00 AM")) {
                mySOS.dateCreated = Convert.ToDateTime("1/1/1900 12:00:00 AM");
            }

            if (mySOS.dateDue == Convert.ToDateTime("1/1/0001 12:00:00 AM")) {
                mySOS.dateDue = Convert.ToDateTime("1/1/1900 12:00:00 AM");
            }

            mySOS.assetDescription = txtSearchAsset.Text;

            SoSFunctions sosFunctions = new SoSFunctions();

            gvSearchResults.DataSource = sosFunctions.SearchSoS(mySOS);
            gvSearchResults.DataBind();

            searchResults.Visible = true;
        }

        protected void gvSearchResults_RowCommand(object sender, GridViewCommandEventArgs e) {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSearchResults.Rows[index];
            int sosID = (int)gvSearchResults.DataKeys[index].Value;
            string submit_type;

            if (e.CommandName == "Delete") {
                mySOS.DeleteSOS(sosID, (string)Session["user"]);
                submit_type = "archive";

                string dialog_header, dialog_body;
                if (submit_type == "archive") {
                    mySOS.sosID = sosID;
                    dialog_header = "SOS Archived";
                    dialog_body = string.Format("{0} has been archived successfully and removed from active Sign Out Sheets.", mySOS.sosID);
                    modal(dialog_header, dialog_body);
                }
            } else if (e.CommandName == "modify") {
                bool onModify = false;
                mySOS.sosID = Convert.ToInt32(gvSearchResults.Rows[index].Cells[0].Text);
                Session.Add("SOSID", mySOS.sosID);
                Session.Add("IsOnModifyPage", onModify);
                if (mySOS.assingmentPeriod == 0)
                {
                    dueCal.Visible = true;
                    calDueDate.Enabled = true;
                }
                else 
                {
                    dueCal.Visible = false;
                    calDueDate.Enabled = false;
                }
                calIssueDate.Enabled = true;
                Response.Redirect("./sos_view.aspx");
               
            }
        }

        protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e) {
            if (int.Parse(ddlTerm.SelectedValue) == 0) {
                dueCal.Visible = true;
            } else {
                dueCal.Visible = false;
            }
        }

        protected void fillDropdowns() {
            DataSet recipients = mySOS.returnSignSheetRecipients();
            DataSet assigners = mySOS.returnAssigner();

            DataTable namesAndIds = new DataTable();
            namesAndIds.Columns.Add("Name", typeof(string));
            namesAndIds.Columns.Add("ARID", typeof(int));

            DataRow blankRow = namesAndIds.NewRow();
            blankRow["Name"] = "";
            blankRow["ArID"] = 0;
            namesAndIds.Rows.Add(blankRow);

            foreach (DataRow row in recipients.Tables[0].Rows) {
                DataRow newRow = namesAndIds.NewRow();
                newRow["Name"] = row[1].ToString();
                newRow["ARID"] = Convert.ToInt32(row[0]);
                namesAndIds.Rows.Add(newRow);
            }

            ddlRecipient.Items.Clear();
            ddlRecipient.DataSource = namesAndIds;
            ddlRecipient.DataTextField = "Name";
            ddlRecipient.DataValueField = "ARID";
            ddlRecipient.DataBind();

            DataTable claIDAndName = new DataTable();
            claIDAndName.Columns.Add("claID", typeof(string));
            claIDAndName.Columns.Add("Name", typeof(string));
            DataRow blankRow2 = claIDAndName.NewRow();
            blankRow2["claID"] = "";
            blankRow2["Name"] = "";
            claIDAndName.Rows.Add(blankRow2);

            foreach (DataRow row in assigners.Tables[0].Rows) {
                DataRow newRow2 = claIDAndName.NewRow();
                newRow2["claID"] = row[0].ToString();
                newRow2["Name"] = row[1].ToString();
                claIDAndName.Rows.Add(newRow2);
            }

            ddlAssigner.Items.Clear();
            ddlAssigner.DataSource = claIDAndName;
            ddlAssigner.DataTextField = "Name";
            ddlAssigner.DataValueField = "claID";
            ddlAssigner.DataBind();
        }

        protected void modal(string title, string body) {
            this.Master.modal_header = title;
            this.Master.modal_body = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

   
    }
}