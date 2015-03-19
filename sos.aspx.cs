using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
namespace CD6
{
    public partial class sos : System.Web.UI.Page
    {
        SignOutSheet mySOS = new SignOutSheet();
        DataSet ds = new DataSet();
        Asset myAsset = new Asset();

        ArrayList arrayListOfAssets=new ArrayList();
        int assetId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlTerm_SelectedIndexChanged(this, e);

            searchHeader.Visible = false;
            button_search.Visible = false;
            createHeader.Visible = true;
            //recipientSearch.Visible = false;
            recipientCreate.Visible = true;
            button_submit.Visible = true;
            sos_form.Visible = true;
            search_results.Visible = false;
            searchButtons.Visible = true;
            trackingHeader.Visible = true;
            searchResultsHeader.Visible = false;
            modifyHeader.Visible = false;
            uploadSheet.Visible = false;

            AssetListBox.Visible = true;
            txtSearchAsset.Visible = false;
           
            if (!IsPostBack)
            {
                //Establishing DropDown Choices for Recipients
                
                DataSet myDS = mySOS.returnSignSheetRecipients();
               
                DataTable namesAndIds = new DataTable();
                namesAndIds.Columns.Add("Name", typeof(string));
                namesAndIds.Columns.Add("ARID", typeof(int));

                DataRow blankRow = namesAndIds.NewRow();
                blankRow["Name"] = "";
                blankRow["ArID"] = 0;
                namesAndIds.Rows.Add(blankRow);
                foreach (DataRow row in myDS.Tables[0].Rows)
                {
                    DataRow newRow = namesAndIds.NewRow();
                    newRow["Name"] = row[1].ToString();
                    newRow["ARID"] = Convert.ToInt32(row[0]);
                    namesAndIds.Rows.Add(newRow);

                    searchHeader.Visible = false;
                    button_search.Visible = false;
                    createHeader.Visible = true;
                    // recipientSearch.Visible = false;
                    recipientCreate.Visible = true;
                    button_submit.Visible = true;
                    sos_form.Visible = true;
                    search_results.Visible = false;
                    searchButtons.Visible = true;
                    trackingHeader.Visible = true;
                    searchResultsHeader.Visible = false;
                    modifyHeader.Visible = false;
                    uploadSheet.Visible = false;
                }

                ddlRecipient.Items.Clear();
                ddlRecipient.DataSource = namesAndIds;
                ddlRecipient.DataTextField = "Name";
                ddlRecipient.DataValueField = "ARID";
                ddlRecipient.DataBind();
               

                if (Session["Asset"] != null)
                {
                    arrayListOfAssets = (ArrayList)Session["Asset"];
                    foreach (Asset myAsset in arrayListOfAssets)
                    {
                        assetId = myAsset.assetID;
                        Session.Add("assetId",assetId);
                    }
                    lstbxAssets.DataSource = arrayListOfAssets;
                    lstbxAssets.DataTextField = "Name";
                    lstbxAssets.DataValueField = "assetID";
                    lstbxAssets.DataBind();
                }

                //Establishing DropDownChoices for Asignees
                DataSet myDS2 = mySOS.returnAssigner();
                DataTable claIDAndName = new DataTable();
                claIDAndName.Columns.Add("claID", typeof(string));
                claIDAndName.Columns.Add("Name", typeof(string));
                DataRow blankRow2 = claIDAndName.NewRow();
                blankRow2["claID"] = "";
                blankRow2["Name"] = "";
                claIDAndName.Rows.Add(blankRow2);
                foreach (DataRow row in myDS2.Tables[0].Rows)
                {
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
                if (ddlTerm.Items[0].Text=="Permanent")
                {
                    ddlTerm.Items.Insert(0, new ListItem(String.Empty, 0.ToString()));
                    ddlTerm.SelectedIndex = 0;
                }
                

              
            }
        }

         protected void btnSearch_Click(object sender, EventArgs e)
         {

            searchHeader.Visible=false;
           // recipientSearch.Visible=false;
            button_search.Visible=false;
            createHeader.Visible=false;
            recipientCreate.Visible=true;
            button_submit.Visible=false;
            sos_form.Visible=false;
            search_results.Visible=true;
            searchButtons.Visible=true;
            trackingHeader.Visible=false;
            searchResultsHeader.Visible=true;
            modifyHeader.Visible=false;
            uploadSheet.Visible=false;

            mySOS.arID = Convert.ToInt32(ddlRecipient.SelectedValue);
            mySOS.cladID = ddlAssigner.SelectedValue;
            //mySOS.assingmentPeriod = DateTime.Compare(mySOS.dateCreated, mySOS.dateDue).ToString(); 
            mySOS.assingmentPeriod = Convert.ToInt32(ddlTerm.SelectedValue);
            if(mySOS.assingmentPeriod == 2)
            {
                mySOS.dateDue = calDueDate.SelectedDate;
            }

            mySOS.dateCreated = calIssueDate.SelectedDate;

            if (calIssueDate.SelectedDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
            {
                mySOS.dateCreated = Convert.ToDateTime("1/1/1900 12:00:00 AM");
            }
            mySOS.assetDescription = txtSearchAsset.Text;

            SoSFunctions sosFunctions = new SoSFunctions();
            
            gvSearchResults.DataSource = sosFunctions.SearchSoS(mySOS);
            gvSearchResults.DataBind();
 



            
        }



        protected void btnNewSearch_Click(object sender, EventArgs e)
        {
            searchHeader.Visible = true;
            //recipientSearch.Visible=true;
            button_search.Visible = true;
            createHeader.Visible = false;
            recipientCreate.Visible = true;
            button_submit.Visible = false;
            sos_form.Visible = true;
            search_results.Visible = false;
            searchButtons.Visible = false;
            trackingHeader.Visible = false;
            searchResultsHeader.Visible = false;
            modifyHeader.Visible = false;
            uploadSheet.Visible = false;

            AssetListBox.Visible = false;
            txtSearchAsset.Visible = true;

            //ddlRecipient.SelectedIndex = 0;
            //ddlAssigner.SelectedIndex = 0;
            //ddlTerm.SelectedIndex = 0;
            //txtSearchAsset.Text = "";
            //calDueDate.SelectedDates.Clear();
            //calIssueDate.SelectedDates.Clear();
        }

        protected void btnTrack_Click(object sender, EventArgs e)
        {
            searchHeader.Visible = false;
            button_search.Visible = false;
            createHeader.Visible = false;
            button_submit.Visible = false;
            sos_form.Visible = false;
            search_results.Visible = true;
            searchButtons.Visible = false;
            trackingHeader.Visible = true;
            searchResultsHeader.Visible = false;
            modifyHeader.Visible = false;
            uploadSheet.Visible = false;
        }

        protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(ddlTerm.SelectedValue) == 2)
            {
                dueCal.Visible = true;
            }
            else
            {
                dueCal.Visible = false;
            }
        }

        protected void gvSearchResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            searchHeader.Visible = false;
            button_search.Visible = false;
            createHeader.Visible = false;
            button_submit.Visible = true;
            sos_form.Visible = true;
            search_results.Visible = false;
            searchButtons.Visible = false;
            trackingHeader.Visible = false;
            searchResultsHeader.Visible = false;
            modifyHeader.Visible = true;
            uploadSheet.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string submit_type;

            mySOS.cladID = ddlAssigner.SelectedValue;
            mySOS.arID = Convert.ToInt32(ddlRecipient.SelectedValue);
            //int isPermanent = Convert.ToInt32(ddlTerm.SelectedValue);

            mySOS.assingmentPeriod = Convert.ToInt32(ddlTerm.SelectedValue);
            if (mySOS.assingmentPeriod == 1)
            {
                mySOS.assingmentPeriod = 1;
                mySOS.dateDue = Convert.ToDateTime("09/24/3000, 3:00:00 PM");
                mySOS.status = "Not overdue";
            }
            else
            {
                mySOS.assingmentPeriod = 0;
                mySOS.dateDue = calDueDate.SelectedDate;
            }
            mySOS.dateCreated = calIssueDate.SelectedDate;
            mySOS.dateModified = DateTime.Now;
            
            if (mySOS.dateCreated>mySOS.dateDue)
            {
                mySOS.status = "Overdue";
            }
            else
            mySOS.status = "Not Overdue";
            mySOS.imageFileName = "TestImageFileName";
            mySOS.recordCreated = DateTime.Now;
            mySOS.recordModified = DateTime.Now;
            assetId = Convert.ToInt32(Session["assetId"].ToString());
            int sosID = mySOS.CreateSignOutSheet(assetId, mySOS.cladID, mySOS.arID, mySOS.assingmentPeriod, mySOS.dateCreated, mySOS.dateModified, mySOS.dateDue, mySOS.status, mySOS.imageFileName, mySOS.recordCreated, mySOS.recordModified);
            mySOS.ModifyAsset(sosID, assetId);

            submit_type = "create";

            string dialog_header, dialog_body;
            if (submit_type == "create")
            {
                dialog_header = "SOS created";
                dialog_body = string.Format("SOS for Recipient {0} has been created successfully.", mySOS.arID);
                modal(dialog_header, dialog_body);
            }

            //ddlRecipient.SelectedIndex = 0;
            //ddlAssigner.SelectedIndex = 0;
            //ddlTerm.SelectedIndex = 0;
            //lstbxAssets.Items.Clear();
            //calDueDate.SelectedDates.Clear();
            //calIssueDate.SelectedDates.Clear();

        }

        protected void btnAddAsset_Click(object sender, EventArgs e)
        {
            Response.Redirect("assetSearch.aspx");
        }

        protected void btnRemoveAsset_Click(object sender, EventArgs e)
        {
            Session.Remove("Asset");
            lstbxAssets.DataSource = (ArrayList)Session["Asset"];
            lstbxAssets.DataBind();
        }

        protected void gvSearchResults_Click(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSearchResults.Rows[index];
            int sosID = (int)gvSearchResults.DataKeys[index].Value;
            string submit_type;

            if (e.CommandName == "Delete")
            {
                mySOS.DeleteSOS(sosID);
                btnSearch_Click(this, e);
                submit_type = "archive";

                string dialog_header, dialog_body;
                if (submit_type == "archive")
                {
                    mySOS.sosID = sosID;
                    dialog_header = "SOS Archived";
                    dialog_body = string.Format("{0} has been archived successfully and removed from active Sign Out Sheets.", mySOS.sosID);
                    modal(dialog_header, dialog_body);
                }
            }
            else if (e.CommandName == "modify")
            {
                createHeader.Visible = false;
                modifyHeader.Visible = true;
            }
        }

        protected void gvSearchResults_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void modal(string title, string body)
        {
            this.Master.modal_header = title;
            this.Master.modal_body = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

      
    }
}

