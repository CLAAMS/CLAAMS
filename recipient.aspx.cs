using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace CD6 {
    public partial class recipient : System.Web.UI.Page {
        AssetRecipient myAR = new AssetRecipient();
        AssetRecipient theAssetRecipient = new AssetRecipient();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                fillDropDowns();
                btnCreate_Click(this, e);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e) {
            createHeader.Visible = true;
            modifyHeader.Visible = false;
            lblSearchRecipientsDirections.Visible = false;
            lblModifyRecipientsDirections.Visible = false;
            lblCreateRecipientsDirections.Visible = true;
            lblCreateRecipientsDirections.Text = "To create a new recipient, please enter all required fields in proper format. Use the Add Department link to create new department affiliations, if not listed in the drop down list or to modify names of existing departments";
            searchHeader.Visible = false;
            button_search.Visible = false;
            button_submit.Visible = true;
            recipient_form.Visible = true;
            search_results.Visible = false;

            if (Session["AssetRecipient"] != null) {
                bool check;
                theAssetRecipient = (AssetRecipient)Session["AssetRecipient"];
                createHeader.Visible = false;
                modifyHeader.Visible = true;
                check = (Boolean)Session["IsOnModifyPage"];

                lblCreateRecipientsDirections.Visible = false;
                lblModifyRecipientsDirections.Visible = true;
                lblModifyRecipientsDirections.Text = "Make sure to enter all required fields in proper format in order to successfully modify a existing recipient";

                if (check == false) {
                    bool onModifyPage = true;
                    lblARID.Text = theAssetRecipient.assetRecipientId.ToString();
                    txtLocation.Text = theAssetRecipient.location;
                    ddlTitle.Text = theAssetRecipient.title;
                    txtFirstname.Text = theAssetRecipient.firstName;
                    txtLastName.Text = theAssetRecipient.lastName;
                    txtEmail.Text = theAssetRecipient.emailAddress;
                    txtDivision.Text = theAssetRecipient.division;
                    ddlPrimaryDept.SelectedValue = theAssetRecipient.primaryDeptAffiliation.ToString();
                    ddlSecondaryDept.SelectedValue = theAssetRecipient.secondaryDeptAffiliation.ToString();
                    txtPhone.Text = theAssetRecipient.phoneNumber;
                    //text.Text = theAssetRecipient.assetRecipientId.ToString();
                    btnSubmitCreate.Visible = true;
                    Session["IsOnModifyPage"] = onModifyPage;
                }
            }
        }

        protected void btnNewSearch_Click(object sender, EventArgs e) {
            lblCreateRecipientsDirections.Visible = false;
            lblModifyRecipientsDirections.Visible = false;
            lblSearchRecipientsDirections.Visible = true;
            lblSearchRecipientsDirections.Text = "Enter any combination of fields to seach for specific recipients or search for all recipinets by clicking search button with no fields entered";
            searchHeader.Visible = true;
            button_search.Visible = true;
            createHeader.Visible = false;
            button_submit.Visible = false;
            recipient_form.Visible = true;
            search_results.Visible = false;
            modifyHeader.Visible = false;

            ddlTitle.Text = "";
            txtFirstname.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtLocation.Text = "";
            txtDivision.Text = "";
            ddlPrimaryDept.Text = "";
            ddlSecondaryDept.Text = "";
            txtPhone.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            searchHeader.Visible = false;
            button_search.Visible = false;
            createHeader.Visible = false;
            button_submit.Visible = false;
            recipient_form.Visible = false;
            search_results.Visible = true;
            modifyHeader.Visible = false;
            
            myAR.title = ddlTitle.Text;
            myAR.firstName = txtFirstname.Text;
            myAR.lastName = txtLastName.Text;
            myAR.emailAddress = txtEmail.Text;
            myAR.location = txtLocation.Text;
            myAR.division = txtDivision.Text;
            
            if(ddlPrimaryDept.SelectedValue == ""){
                myAR.primaryDeptAffiliation = 0;
            } else {
                myAR.primaryDeptAffiliation = Convert.ToInt32(ddlPrimaryDept.SelectedValue.ToString());
            }

            if(ddlSecondaryDept.SelectedValue == ""){
                myAR.secondaryDeptAffiliation = 0;
            } else {
                myAR.secondaryDeptAffiliation = Convert.ToInt32(ddlSecondaryDept.SelectedValue.ToString());
            }

            myAR.phoneNumber = txtPhone.Text;
            myAR.RecordCreated = DateTime.Now.ToString();
            myAR.RecordModified = DateTime.Now.ToString();

            gvSearchResults.DataSource = myAR.SearchAssetRecipient(myAR.title, myAR.firstName, myAR.lastName, myAR.emailAddress, myAR.location, myAR.division, myAR.primaryDeptAffiliation, myAR.secondaryDeptAffiliation, myAR.phoneNumber, myAR.RecordCreated, myAR.RecordModified);
            gvSearchResults.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            int PrimaryDept;
            
            try { 
                PrimaryDept = Convert.ToInt32(ddlPrimaryDept.SelectedValue);
            } catch {
                PrimaryDept = 0;
            }

            if(validateInput(txtFirstname.Text, txtLastName.Text, txtEmail.Text, txtLocation.Text, PrimaryDept)){
                if (Session["AssetRecipient"] != null) {
                    modal1("Modify Recipient", "Are you sure you want to modify this recipient?");  
                } else {
                    myAR.title = ddlTitle.Text;
                    myAR.firstName = txtFirstname.Text;
                    myAR.lastName = txtLastName.Text;
                    myAR.emailAddress = txtEmail.Text;
                    myAR.location = txtLocation.Text;
                    myAR.division = txtDivision.Text;
                    myAR.primaryDeptAffiliation = Convert.ToInt32(ddlPrimaryDept.SelectedValue);
                    try {
                        myAR.secondaryDeptAffiliation = Convert.ToInt32(ddlSecondaryDept.SelectedValue);
                    } catch {}
                    myAR.phoneNumber = txtPhone.Text;
                    myAR.RecordCreated = DateTime.Now.ToString();
                    myAR.RecordModified = DateTime.Now.ToString();
                    myAR.CreateAssetRecipient(myAR.title, myAR.firstName, myAR.lastName, myAR.emailAddress, myAR.location, myAR.division, myAR.primaryDeptAffiliation, myAR.secondaryDeptAffiliation, myAR.phoneNumber, myAR.RecordCreated, myAR.RecordModified);

                    string dialog_header, dialog_body;
                    dialog_header = "Recipient Created";
                    dialog_body = string.Format("{0} {1} has been created successfully.", txtFirstname.Text, txtLastName.Text);
                    modal(dialog_header, dialog_body);

                    ddlTitle.Text = "";
                    txtFirstname.Text = "";
                    txtLastName.Text = "";
                    txtEmail.Text = "";
                    txtLocation.Text = "";
                    txtDivision.Text = "";
                    ddlPrimaryDept.Text = "";
                    ddlSecondaryDept.Text = "";
                    txtPhone.Text = "";

                    Session["AssetRecipient"] = null;
                    btnCreate_Click(this, e);
                }
            } else {
                //BAD INPUT HANDLING
            }
        }

        protected  void gvSearchResult_click(object sender, GridViewCommandEventArgs e) {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSearchResults.Rows[index];
            int arID =(int) gvSearchResults.DataKeys[index].Value;
            
            if (e.CommandName == "DeleteRow") {
                //myAR.DeleteRow(arID);
                //btnSearch_Click(this, e);
                //submit_type = "delete"; 
                //string dialog_header, dialog_body;
                //if (submit_type == "delete")
                //{
                      //myAR.firstName = txtFirstname.Text;
                      //myAR.lastName = txtLastName.Text;
                //    dialog_header = "Recipient Deleted";
                //    dialog_body = string.Format("{0} {1} has been deleted successfully.", myAR.firstName, myAR.lastName);
                //    modal(dialog_header, dialog_body);
                //}
              
            } 
            else if (e.CommandName == "modifyRecord") {

                bool onModify=false;
                createHeader.Visible = false;
                btnSubmitCreate.Visible = true;
                modifyHeader.Visible = true;

                //Set the Object values to the gridview
                
                myAR.assetRecipientId = arID;
                DataSet locationDataSet = myAR.GetLocationForSelectedRecord(myAR.assetRecipientId);
                myAR.assetRecipientId = Convert.ToInt32(locationDataSet.Tables[0].Rows[0][0]);
                myAR.location = locationDataSet.Tables[0].Rows[0][5].ToString();
                myAR.firstName = gvSearchResults.Rows[index].Cells[2].Text;
                myAR.lastName =  gvSearchResults.Rows[index].Cells[3].Text;
                myAR.emailAddress = gvSearchResults.Rows[index].Cells[4].Text;
                myAR.division = locationDataSet.Tables[0].Rows[0][6].ToString();

                if(locationDataSet.Tables[0].Rows[0][7] is System.DBNull){
                    myAR.primaryDeptAffiliation = 0;
                } else {
                    myAR.primaryDeptAffiliation = (int)locationDataSet.Tables[0].Rows[0][7];
                }

                if(locationDataSet.Tables[0].Rows[0][8] is System.DBNull){
                    myAR.secondaryDeptAffiliation = 0;
                } else {
                    myAR.secondaryDeptAffiliation = (int)locationDataSet.Tables[0].Rows[0][8];
                }
                
                myAR.phoneNumber = gvSearchResults.Rows[index].Cells[5].Text;
                myAR.RecordCreated = DateTime.Now.ToString();
                myAR.RecordModified = DateTime.Now.ToString();
                gvSearchResults.Visible=false;
                Session.Add("AssetRecipient", myAR);
                Session.Add("IsOnModifyPage", onModify);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void modal(string title, string body) {
            this.Master.modal_header = title;
            this.Master.modal_body = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void modal1(string title, string body) {
            lblModifyRecipient_header.Text = title;
            lblModifyRecipient_body.Text = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "modifyRecipient();", true);
        }

        protected void fillDropDowns(){
            string SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";

            DataSet departments = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand = new SqlCommand();
            myConnection.Open();

            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "GetDepartments";

            departments = myDbConnect.GetDataSetUsingCmdObj(myCommand);
            Dictionary<int, string> depts = new Dictionary<int, string>();

            foreach(DataRow row in departments.Tables[0].Rows){
                depts.Add((int)row.ItemArray[0], row.ItemArray[1].ToString());
            }

            ddlPrimaryDept.Items.Clear();
            ddlPrimaryDept.Items.Add(new ListItem(""));
            ddlPrimaryDept.DataValueField = "Key";
            ddlPrimaryDept.DataTextField = "Value";

            ddlSecondaryDept.Items.Clear();
            ddlSecondaryDept.Items.Add(new ListItem(""));
            ddlSecondaryDept.DataValueField = "Key";
            ddlSecondaryDept.DataTextField = "Value";

            ddlPrimaryDept.DataSource = depts;
            ddlSecondaryDept.DataSource = depts;

            ddlPrimaryDept.DataBind();
            ddlSecondaryDept.DataBind();


        }

        protected void btnModifyRecipientModalYes_Click(object sender, EventArgs e) {
            int pdt, sdt;

            theAssetRecipient.RecordModified = DateTime.Now.ToString();
            int assetrecipientID = Convert.ToInt32(lblARID.Text);
            
            try{
                pdt = Convert.ToInt32(ddlPrimaryDept.SelectedValue);
            } catch {
                pdt = 0;
            }

            try {
                sdt = Convert.ToInt32(ddlSecondaryDept.SelectedValue);
            } catch {
                sdt = 0;
            }

            myAR.UpdateRow(assetrecipientID, ddlTitle.Text, txtFirstname.Text, txtLastName.Text, txtEmail.Text, txtLocation.Text, txtDivision.Text, pdt, sdt, txtPhone.Text, theAssetRecipient.RecordModified);    
            string dialog_header, dialog_body;
            dialog_header = "Recipient Modified";
            dialog_body = string.Format("{0} {1} has been modified successfully.", txtFirstname.Text, txtLastName.Text);
            modal(dialog_header, dialog_body);
        }

        protected void btnModifyRecipientModalNo_Click(object sender, EventArgs e) {
            modifyHeader.Visible = true;
	    }

        protected bool validateInput(string firstName, string lastName, string email, string location, int primaryDept) {
            string output = "";
            Tools.InputValidation InVal = new Tools.InputValidation();

            if (firstName == ""){
                output += "Invalid First Name<br/>";
            }

            if (lastName == ""){
                output += "Invalid Last Name<br/>";
            }

            if(location == ""){
                output += "Invalid Location<br/>";
            }

            if(!InVal.IsValidEmail(email)){
                output += "Invalid Email Address<br/>";
            }

            if(primaryDept == 0){
                output += "Invalid Primary Department";
            }

            if(output != ""){
                modal("Invalid Input!", "The following fields contain errors:<br/>" + output);
                return false;
            } else {
                return true;
            }
        }
    }
}