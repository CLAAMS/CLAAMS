using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CD6
{
    public partial class recipient : System.Web.UI.Page
    {
        AssetRecipient myAR = new AssetRecipient();
        AssetRecipient theAssetRecipient = new AssetRecipient();
        DataSet myDS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCreate_Click(this, e);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e) {
            searchHeader.Visible = false;
            button_search.Visible = false;
            createHeader.Visible = true;
            button_submit.Visible = true;
            recipient_form.Visible = true;
            search_results.Visible = false;
            modifyHeader.Visible = false;

            if (Session["AssetRecipient"] != null)
            {
                bool check;
                theAssetRecipient = (AssetRecipient)Session["AssetRecipient"];
                createHeader.Visible = false;
                modifyHeader.Visible = true;
                check = (Boolean)Session["IsOnModifyPage"];
                if (check == false)
                {
                    bool onModifyPage = true;
                    ddlTitle.Text = theAssetRecipient.title;
                    txtFirstname.Text = theAssetRecipient.firstName;
                    txtLastName.Text = theAssetRecipient.lastName;
                    txtEmail.Text = theAssetRecipient.emailAddress;
                    txtDivision.Text = theAssetRecipient.division;
                    ddlPrimaryDept.Text = theAssetRecipient.primaryDeptAffiliation;
                    ddlSecondaryDept.Text = theAssetRecipient.secondaryDeptAffiliation;
                    txtPhone.Text = theAssetRecipient.phoneNumber;
                    //text.Text = theAssetRecipient.assetRecipientId.ToString();
                    btnSubmitCreate.Visible = true;
                    Session["IsOnModifyPage"] = onModifyPage;
                }
            }
            if (ddlSecondaryDept.Items[0].Text == "English" && ddlPrimaryDept.Items[0].Text == "English")
            {
                ddlPrimaryDept.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlPrimaryDept.SelectedIndex = 0;
                ddlSecondaryDept.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlSecondaryDept.SelectedIndex = 0;
            }
        }

        protected void btnNewSearch_Click(object sender, EventArgs e)
        {
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
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
            myAR.primaryDeptAffiliation = ddlPrimaryDept.Text;
            myAR.secondaryDeptAffiliation = ddlSecondaryDept.Text;
            myAR.phoneNumber = txtPhone.Text;
            myAR.RecordCreated = DateTime.Now.ToString();
            myAR.RecordModified = DateTime.Now.ToString();

            gvSearchResults.DataSource = myAR.SearchAssetRecipient(myAR.title, myAR.firstName, myAR.lastName, myAR.emailAddress, myAR.location, myAR.division, myAR.primaryDeptAffiliation, myAR.secondaryDeptAffiliation, myAR.phoneNumber, myAR.RecordCreated, myAR.RecordModified);
            gvSearchResults.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string submit_type;

            if (Session["AssetRecipient"] != null)
            {
                myAR.UpdateRow(theAssetRecipient.assetRecipientId, ddlTitle.Text, txtFirstname.Text, txtLastName.Text, txtEmail.Text, txtLocation.Text, txtDivision.Text, ddlPrimaryDept.Text, ddlSecondaryDept.Text, txtPhone.Text, theAssetRecipient.RecordCreated, theAssetRecipient.RecordModified);
                submit_type = "update";
            }
            else
            {
                myAR.title = ddlTitle.Text;
                myAR.firstName = txtFirstname.Text;
                myAR.lastName = txtLastName.Text;
                myAR.emailAddress = txtEmail.Text;
                myAR.location = txtLocation.Text;
                myAR.division = txtDivision.Text;
                myAR.primaryDeptAffiliation = ddlPrimaryDept.Text;
                myAR.secondaryDeptAffiliation = ddlSecondaryDept.Text;
                myAR.phoneNumber = txtPhone.Text;
                myAR.RecordCreated = DateTime.Now.ToString();
                myAR.RecordModified = DateTime.Now.ToString();
                myAR.CreateAssetRecipient(myAR.title, myAR.firstName, myAR.lastName, myAR.emailAddress, myAR.location, myAR.division, myAR.primaryDeptAffiliation, myAR.secondaryDeptAffiliation, myAR.phoneNumber, myAR.RecordCreated, myAR.RecordModified);
                submit_type = "create";
            }

            string dialog_header, dialog_body;
            if (submit_type == "create")
            {
                dialog_header = "Recipient Created";
                dialog_body = string.Format("{0} {1} has been created successfully.", txtFirstname.Text, txtLastName.Text);
                modal(dialog_header, dialog_body);
            }
            else if (submit_type == "update")
            {
                dialog_header = "Recipient Updated";
                dialog_body = string.Format("{0} {1} has been updated successfully.", txtFirstname.Text, txtLastName.Text);
                modal(dialog_header, dialog_body);
            }
            


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

        protected  void gvSearchResult_click(object sender, GridViewCommandEventArgs e)
        {
            string submit_type;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSearchResults.Rows[index];
            int arID =(int) gvSearchResults.DataKeys[index].Value;
            

            if (e.CommandName == "DeleteRow")
            {
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
            else if (e.CommandName == "modifyRecord")
            {
                bool onModify=false;
                createHeader.Visible = false;
                btnSubmitCreate.Visible = true;
                modifyHeader.Visible = true;

                //Set the Object values to the gridview
                myAR.assetRecipientId = arID;
                myAR.firstName = gvSearchResults.Rows[index].Cells[1].Text;
                myAR.lastName =  gvSearchResults.Rows[index].Cells[2].Text;
                myAR.emailAddress = gvSearchResults.Rows[index].Cells[3].Text;
                myAR.division = gvSearchResults.Rows[index].Cells[7].Text;
                myAR.primaryDeptAffiliation = gvSearchResults.Rows[index].Cells[5].Text;
                myAR.secondaryDeptAffiliation = gvSearchResults.Rows[index].Cells[6].Text;
                myAR.phoneNumber = gvSearchResults.Rows[index].Cells[4].Text;
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
    }
}