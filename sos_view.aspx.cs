using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace CD6 {
    public partial class sos_view : System.Web.UI.Page {
        SignOutSheet mySOS = new SignOutSheet();
        SoSFunctions sosFunctions = new SoSFunctions();
        int sosID;

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack){
                sosID = -1;
                loadOriginal();
            }
        }

        protected void loadOriginal() {
            try {
                sosID = (int)Session["SOSID"];
               // Session.Remove("SOSID");
            } catch {
                Response.Redirect("./sos_search.aspx");
            }

            mySOS = SignOutSheet.getSOSbyID(sosID);
            txtRecipient.Text = mySOS.arID.ToString();
            txtAssigner.Text = mySOS.cladID.ToString();
            txtTerm.Text = mySOS.assingmentPeriod.ToString();
            calIssueDate.SelectedDate = mySOS.dateCreated;

            if (mySOS.assingmentPeriod == 0)  {
                calDue.Visible = true;
                calDueDate.Enabled = true;
                calDueDate.SelectedDate = mySOS.dateDue;
            }

            getAssets(sosID);
            fillHistory(sosID);        
        }

        protected void btnClose_Click(object sender, EventArgs e) {
            Response.Redirect("./sos_search.aspx");
        }

        protected void fillHistory(int sosID) {
            ArrayList histories = SosHistory.getHistoryForSOS(sosID);
            ddlHistory.Items.Clear();
            ddlHistory.Items.Add(new ListItem(""));
            ddlHistory.DataSource = histories;
            ddlHistory.DataTextField = "DateCreated";
            ddlHistory.DataValueField = "sosHistoryID";
            ddlHistory.DataBind();
        }

        protected void getAssets(int sosID) {
            ArrayList assets = SignOutSheet.getAssetsForSOS(sosID);
            lbAssets.DataSource = assets;
            lbAssets.DataTextField = "Name";
            lbAssets.DataValueField = "assetID";
            lbAssets.DataBind();
        }

        protected void ddlHistory_SelectedIndexChanged(object sender, EventArgs e) {
            int sosHistoryID = -1;

            try {
                sosHistoryID = Convert.ToInt32(ddlHistory.SelectedValue.ToString());
            } catch {
                loadOriginal();
                return;
            }

            SosHistory history = SosHistory.getHistoryByID(sosHistoryID);

            sosID = history.sosID;
            Session["sosID"] = sosID;
            txtAssigner.Text = history.arID.ToString();
            txtRecipient.Text = history.cladID.ToString();
            txtTerm.Text = history.assingmentPeriod.ToString();
            calIssueDate.SelectedDate = history.dateModified;
            if (history.assingmentPeriod == 2){
                calDue.Visible = true;
                calDueDate.SelectedDate = history.dateDue;
               
            }
        }

        protected void btnSubmitModification_Click(object sender, EventArgs e)
        {
            string submit_type;
            string editorID = (string)Session["user"];
            int sosIDDueDate = (int)Session["SOSID"];
           // DataSet ds = Tools.DBAccess.DBCall( "select assetTemplateID, Name from Asset_Template");
            DateTime dueDate = calDueDate.SelectedDate;

            submit_type = "update";
            sosFunctions.UpdateSoSDueDate(sosIDDueDate, editorID, dueDate);
            

            string dialog_header, dialog_body;
            if (submit_type == "update")
            {
                dialog_header = "SoS Modified";
                dialog_body = string.Format("{0} has been modified successfully", sosIDDueDate);
                modal(dialog_header, dialog_body);
            }
        }

        protected void modal(string title, string body)
        {
            this.Master.modal_header = title;
            this.Master.modal_body = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}