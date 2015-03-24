using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace CD6 {
    public partial class sos_create : System.Web.UI.Page  {
        SignOutSheet mySOS = new SignOutSheet();
        Asset myAsset = new Asset();
        ArrayList arrayListOfAssets = new ArrayList();
        int assetId;

        protected void Page_Load(object sender, EventArgs e){
            fillDropdowns();

            if (Session["Asset"] != null) {
                arrayListOfAssets = (ArrayList)Session["Asset"];

                foreach (Asset myAsset in arrayListOfAssets) {
                    assetId = myAsset.assetID;
                    Session.Add("assetId", assetId);
                }

                lbAssets.DataSource = arrayListOfAssets;
                lbAssets.DataTextField = "Name";
                lbAssets.DataValueField = "assetID";
                lbAssets.DataBind();
            }
        }

        protected void btnRemoveAsset_Click(object sender, EventArgs e) {
            Session.Remove("Asset");
            lbAssets.DataSource = (ArrayList)Session["Asset"];
            lbAssets.DataBind();
        }

        protected void btnAddAsset_Click(object sender, EventArgs e) {
            Response.Redirect("assetSearchForSoS.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            string submit_type = "";
            if (Session["SOS"] != null) {
                bool check;
                mySOS = (SignOutSheet)Session["SOS"];
                check = (Boolean)Session["IsOnModifyPage"];
                if (check == false) {
                    ddlRecipient.Text = mySOS.arID.ToString();
                    ddlAssigner.Text = mySOS.cladID.ToString();
                }
            }

            mySOS.cladID = ddlAssigner.SelectedValue;
            mySOS.arID = Convert.ToInt32(ddlRecipient.SelectedValue);
            //int isPermanent = Convert.ToInt32(ddlTerm.SelectedValue);

            mySOS.assingmentPeriod = Convert.ToInt32(ddlTerm.SelectedValue);
            if (mySOS.assingmentPeriod == 1) {
                mySOS.assingmentPeriod = 1;
                mySOS.dateDue = Convert.ToDateTime("09/24/3000, 3:00:00 PM");
                mySOS.status = "Not overdue";
            } else {
                mySOS.assingmentPeriod = 0;
                mySOS.dateDue = calDueDate.SelectedDate;
            }

            mySOS.dateCreated = calIssueDate.SelectedDate;
            mySOS.dateModified = DateTime.Now;

            if (mySOS.dateCreated > mySOS.dateDue) {
                mySOS.status = "Overdue";
            } else {
                mySOS.status = "Not Overdue";
                mySOS.imageFileName = "TestImageFileName";
                mySOS.recordCreated = DateTime.Now;
                mySOS.recordModified = DateTime.Now;
                assetId = Convert.ToInt32(Session["assetId"].ToString());
                int sosID = mySOS.CreateSignOutSheet(assetId, mySOS.cladID, mySOS.arID, mySOS.assingmentPeriod, mySOS.dateCreated, mySOS.dateModified, mySOS.dateDue, mySOS.status, mySOS.imageFileName, mySOS.recordCreated, mySOS.recordModified);
                mySOS.ModifyAsset(sosID, assetId);

                submit_type = "create";
            }

            string dialog_header, dialog_body;
            if (submit_type == "create") {
                dialog_header = "SOS created";
                dialog_body = string.Format("SOS for Recipient {0} has been created successfully.", mySOS.arID);
                modal(dialog_header, dialog_body);
            }
        }

        protected void fillDropdowns()
        {
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

        protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e) {
            if (int.Parse(ddlTerm.SelectedValue) == 2) {
                calDue.Visible = true;
            } else {
                calDue.Visible = false;
            }
        }

        protected void modal(string title, string body) {
            this.Master.modal_header = title;
            this.Master.modal_body = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}