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
        ArrayList arrayListOfAssets = new ArrayList();
        string editor;

        protected void Page_Load(object sender, EventArgs e){
            lblCreateSOSDirections.Visible = true;
            lblCreateSOSDirections.Text = "Enter all required fields. If Term is Non-Permanent, make sure to select both issue date and due date";
            if(!IsPostBack){
                calIssueDate.SelectedDate = DateTime.Today;
                fillDropdowns();
                try {
                    editor = Session["user"].ToString();
                } catch {
                    Response.Redirect("login.aspx");
                }

                if (Session["Asset"] != null) {
                    arrayListOfAssets = (ArrayList)Session["Asset"];

                    lbAssets.DataSource = arrayListOfAssets;
                    lbAssets.DataTextField = "Name";
                    lbAssets.DataValueField = "assetID";
                    lbAssets.DataBind();
                }

                if (Session["createSosSelections"] != null) {
                    Dictionary<string, object> createSosSelections = (Dictionary<string, object>)Session["createSosSelections"];
                    ddlAssigner.SelectedValue = (string)createSosSelections["Assigner"];
                    ddlRecipient.SelectedValue = createSosSelections["Recipient"].ToString();
                    ddlTerm.SelectedValue = (string)createSosSelections["Term"];
                    calIssueDate.SelectedDate = (DateTime)createSosSelections["IssueDate"];
                    if (ddlTerm.SelectedValue == "0") {
                        calDue.Visible = true;
                        calDueDate.SelectedDate = (DateTime)createSosSelections["DueDate"];
                    }
                    Session.Remove("createSosSelections");
                }
            }
        }

        protected void btnRemoveAsset_Click(object sender, EventArgs e) {
            if(Session["Asset"] != null){
                ArrayList assets = (ArrayList)Session["Asset"];
                int assetIdToRemove = Convert.ToInt32(lbAssets.SelectedValue.ToString());
            
                foreach(Asset asset in assets){
                    if(asset.assetID == assetIdToRemove){
                        assets.Remove(asset);
                        break;
                    }
                }
            
                lbAssets.DataSource = assets;
                lbAssets.DataBind();

                Session["Asset"] = assets;
            }
        }

        protected void btnAddAsset_Click(object sender, EventArgs e) {
            Dictionary<string, object> createSosSelections = new Dictionary<string,object>();
            createSosSelections.Add("Recipient", ddlRecipient.SelectedValue);
            createSosSelections.Add("Assigner", ddlAssigner.SelectedValue);
            createSosSelections.Add("Term", ddlTerm.SelectedValue);
            createSosSelections.Add("IssueDate", calIssueDate.SelectedDate);
            if (ddlTerm.SelectedValue == "0") {
                createSosSelections.Add("DueDate", calDueDate.SelectedDate);
            }
            Session["createSosSelections"] = createSosSelections;
            Response.Redirect("assetSearchForSoS.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            if (validateInput(ddlRecipient.SelectedValue, ddlAssigner.SelectedValue, ddlTerm.SelectedValue, lbAssets, calDueDate.SelectedDate)) {
                string dialog_header = "", dialog_body = "";
                string return_code = "success";

                mySOS.cladID = ddlAssigner.SelectedValue;
                mySOS.arID = Convert.ToInt32(ddlRecipient.SelectedValue);
                mySOS.status = "Unsigned";

                mySOS.assingmentPeriod = Convert.ToInt32(ddlTerm.SelectedValue);
                if (mySOS.assingmentPeriod == 1) {
                    mySOS.assingmentPeriod = 1;
                    mySOS.dateDue = Convert.ToDateTime("09/24/3000, 3:00:00 PM");
                } else {
                    mySOS.assingmentPeriod = 0;
                    mySOS.dateDue = calDueDate.SelectedDate;
                }

                mySOS.dateCreated = calIssueDate.SelectedDate;
                mySOS.dateModified = DateTime.Now;

                mySOS.imageFileName = "TestImageFileName";
                mySOS.recordCreated = DateTime.Now;
                mySOS.recordModified = DateTime.Now;
                mySOS.editorID = (string)Session["user"];
                int assetId = 1;
                Session["SoS"] = mySOS;
                int sosID = mySOS.CreateSignOutSheet(assetId, mySOS.cladID, mySOS.arID, mySOS.assingmentPeriod, mySOS.dateCreated, mySOS.dateModified, mySOS.dateDue, mySOS.status, mySOS.imageFileName, mySOS.recordCreated, mySOS.recordModified, mySOS.editorID);
                Session["sosIdForPrint"] = sosID;
                if (sosID == -1) {
                    dialog_header = "ERROR";
                    dialog_body = "Failed to Create Sign Sheet";
                    return_code = "failure";
                } else {
                    arrayListOfAssets = (ArrayList)Session["Asset"];

                    foreach (Asset asset in arrayListOfAssets) {
                        if (!mySOS.ModifyAsset(sosID, asset.assetID, mySOS.editorID)) {
                            dialog_header = "ERROR";
                            dialog_body = "Failed to Assign Assets";
                            return_code = "failure";
                            break;
                        };
                    }
                }

                DataSet ds = Tools.DBAccess.DBCall("SELECT FirstName + ' ' + LastName as RecipientName FROM Asset_Recipient WHERE arID = " + mySOS.arID, Global.Connection_String);
                string recipientName = ds.Tables[0].Rows[0][0].ToString();
                if (return_code == "success") {
                    dialog_header = "SOS created";
                    dialog_body = string.Format("SOS {0} has been created for {1}.", sosID, recipientName);
                }
                confirmationModal(dialog_header, dialog_body);

                clearPage();
            }
        }

        protected void clearPage() {
            Session.Remove("Asset");
            Session.Remove("createSosSelections");
            calDue.Visible = false;
            ddlAssigner.SelectedIndex = 0;
            ddlRecipient.SelectedIndex = 0;
            ddlTerm.SelectedIndex = 0;

            lbAssets.Items.Clear();
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

        protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e) {
            if (int.Parse(ddlTerm.SelectedValue) == 0) {
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

        protected void confirmationModal(string header, string body) {
            lblModal_header.Text = header;
            lblModal_Body.Text = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "confirmationSos();", true);
        }

        protected bool validateInput(string recipient, string claMember, string term, ListBox lBox, DateTime dateDue) {
            string output = "";
            lblCreateError.Text = "";
            Tools.InputValidation InVal = new Tools.InputValidation();

            if (recipient == "0") {
                output += "Select recipient<br/>";
                lblCreateError.Text += "Select recipient<br/>";
            }

            if (claMember== "") {
                output += "Select assigner<br/>";
                lblCreateError.Text += "Select assigner<br/>";
            }

            if (lBox.Items.Count == 0) {
                output += "Select at least one asset<br/>";
                lblCreateError.Text += "Select at least one asset<br/>";
            }

            if (term == "0") {
                if (dateDue == Convert.ToDateTime("1/1/0001 12:00:00 AM")) {
                    output += "Select due date<br/>";
                    lblCreateError.Text += "Select due date<br/>";
                }
            } else { }

            if (output != "" && lblCreateError.Text != "") {
                modal("Invalid Input!", "The following fields contain errors:<br/>" + output);
                lblCreateError.Text = "The following fields contain errors and are missing information:<br/>" + lblCreateError.Text;
                return false;
            } else {
                return true;
            }
        }

        protected void linkRecipientSearch_Click(object sender, EventArgs e) {
            Dictionary<string, object> createSosSelections = new Dictionary<string,object>();
            createSosSelections.Add("Recipient", ddlRecipient.SelectedValue);
            createSosSelections.Add("Assigner", ddlAssigner.SelectedValue);
            createSosSelections.Add("Term", ddlTerm.SelectedValue);
            createSosSelections.Add("IssueDate", calIssueDate.SelectedDate);
            if (ddlTerm.SelectedValue == "0") {
                createSosSelections.Add("DueDate", calDueDate.SelectedDate);
            }
            Session["createSosSelections"] = createSosSelections;
            Response.Redirect("recipientSearchForSoS.aspx");
        }

        protected void link_ClickPrintSos(object sender, EventArgs e) {
            Response.Write("<script>window.open('./sos_print.aspx','_blank');</script>");
        }
    }
}