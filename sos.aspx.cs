using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
namespace CD6{
    public partial class sos : System.Web.UI.Page{
            SignOutSheet mySOS = new SignOutSheet();
            DataSet ds = new DataSet();
            ArrayList arrayListOfAssets = new ArrayList();
            protected void Page_Load(object sender, EventArgs e)
            {
                ddlTerm_SelectedIndexChanged(this, e);

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

                AssetListBox.Visible = true;
                txtSearchAsset.Visible = false;
                if (!IsPostBack)
                {
                    //Establishing DropDown Choices for Recipients
                    DataSet myDS = mySOS.returnSignSheetRecipients();
                    DataTable namesAndIds = new DataTable();
                    namesAndIds.Columns.Add("Name", typeof(string));
                    namesAndIds.Columns.Add("ARID", typeof(int));
                    foreach (DataRow row in myDS.Tables[0].Rows)
                    {
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


                    //Establishing DropDownChoices for Asignees
                    DataSet myDS2 = mySOS.returnAssigner();
                    DataTable claIDAndName = new DataTable();
                    claIDAndName.Columns.Add("claID", typeof(string));
                    claIDAndName.Columns.Add("Name", typeof(string));
                    DataRow newRow_ = claIDAndName.NewRow();
                    newRow_["claID"] = "";
                    newRow_["Name"] = "";
                    claIDAndName.Rows.Add(newRow_);
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
                  
                    if (Session["Asset"] != null)
                    {
                        arrayListOfAssets = (ArrayList)Session["Asset"];
                        //If there are prior assets
                       
                        lstbxAssets.DataSource = arrayListOfAssets;
                        lstbxAssets.DataTextField = "Name";
                        lstbxAssets.DataValueField = "assetID";
                        lstbxAssets.DataBind();
                        
                    }

                    //Establishing DropDown Choices for Assets
                    //DataSet myDS3 = mySOS.returnAssets();
                    //DataTable claTagAndType = new DataTable();
                    //claTagAndType.Columns.Add("AssetID", typeof(int));
                    //claTagAndType.Columns.Add("Type", typeof(string));
                    //foreach (DataRow row in myDS3.Tables[0].Rows)
                    //{
                    //    DataRow newRow3 = claTagAndType.NewRow();
                    //    newRow3["AssetID"] = row[0].ToString();
                    //    newRow3["Type"] = row[1].ToString();
                    //    claTagAndType.Rows.Add(newRow3);
                    //}
                    //lstbxAssets.Items.Clear();
                    //lstbxAssets.DataSource = claTagAndType;
                    //lstbxAssets.DataTextField = "Type";
                    //lstbxAssets.DataValueField = "AssetID";
                    //lstbxAssets.DataBind();

                }  

            }

        protected void btnNewSearch_Click(object sender, EventArgs e){
            searchHeader.Visible=true;
            //recipientSearch.Visible=true;
            button_search.Visible=true;
            createHeader.Visible=false;
            recipientCreate.Visible=true;
            button_submit.Visible=false;
            sos_form.Visible=true;
            search_results.Visible=false;
            searchButtons.Visible=false;
            trackingHeader.Visible=false;
            searchResultsHeader.Visible=false;
            modifyHeader.Visible=false;
            uploadSheet.Visible=false;

            AssetListBox.Visible = false;
            txtSearchAsset.Visible = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e){
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
            mySOS.assingmentPeriod = ddlTerm.SelectedValue;
            if(mySOS.assingmentPeriod == "0")
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

        protected void btnTrack_Click(object sender, EventArgs e){
            searchHeader.Visible=false;
            button_search.Visible=false;
            createHeader.Visible=false;
            button_submit.Visible=false;
            sos_form.Visible=false;
            search_results.Visible=true;
            searchButtons.Visible=false;
            trackingHeader.Visible=true;
            searchResultsHeader.Visible=false;
            modifyHeader.Visible=false;
            uploadSheet.Visible=false;
        }

        protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e){
            if(int.Parse(ddlTerm.SelectedValue)==0){
                dueCal.Visible=true;
            }else{
                dueCal.Visible=false;
            }
        }

        protected void gvSearchResults_RowCommand(object sender, GridViewCommandEventArgs e){
            searchHeader.Visible=false;
            button_search.Visible=false;
            createHeader.Visible=false;
            button_submit.Visible=true;
            sos_form.Visible=true;
            search_results.Visible=false;
            searchButtons.Visible=false;
            trackingHeader.Visible=false;
            searchResultsHeader.Visible=false;
            modifyHeader.Visible=true;
            uploadSheet.Visible=true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
              
                mySOS.cladID = ddlAssigner.SelectedValue;
                mySOS.arID = Convert.ToInt32(ddlRecipient.SelectedValue);
            
                mySOS.dateCreated = calIssueDate.SelectedDate;
                mySOS.dateModified = DateTime.Now;
                mySOS.dateDue = calDueDate.SelectedDate;
                mySOS.assingmentPeriod = ddlTerm.Text;
               
                if (Convert.ToInt32(mySOS.assingmentPeriod)<0)
                {
                    mySOS.status = "Overdue";
                }
                else
                mySOS.status = "Not Overdue";
                mySOS.imageFileName = "TestImageFileName";
                mySOS.recordCreated = DateTime.Now;
                mySOS.recordModified = DateTime.Now;
                int sosID=mySOS.CreateSignOutSheet(mySOS.assetID, mySOS.cladID, mySOS.arID, mySOS.assingmentPeriod, mySOS.dateCreated, mySOS.dateModified, mySOS.dateDue, mySOS.status, mySOS.imageFileName, mySOS.recordCreated, mySOS.recordModified);
                mySOS.ModifyAsset(mySOS.assetID, mySOS.cladID, mySOS.arID, mySOS.assingmentPeriod, mySOS.dateCreated, mySOS.dateModified, mySOS.dateDue, mySOS.status, mySOS.imageFileName, mySOS.recordModified, mySOS.recordCreated, sosID);
        }
    }
}