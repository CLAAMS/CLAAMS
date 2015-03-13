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

            searchHeader.Visible = false;
            button_search.Visible = false;
            createHeader.Visible = true;
            button_submit.Visible = true;
            recipient_form.Visible = true;
            search_results.Visible = false;
            modifyHeader.Visible = false;

            //DataTable fake_recipients = new DataTable();

            //fake_recipients.Columns.Add("FirstName", typeof(string));
            //fake_recipients.Columns.Add("LastName", typeof(string));
            //fake_recipients.Columns.Add("EmailAddress", typeof(string));
            //fake_recipients.Columns.Add("PhoneNumber", typeof(string));
            //fake_recipients.Columns.Add("PrimaryDeptAffiliation", typeof(string));
            //fake_recipients.Columns.Add("SecondaryDeptAffiliation", typeof(string));
            //fake_recipients.Columns.Add("Division", typeof(string));

            //fake_recipients.Rows.Add("Bob", "Burner", "tuf01930@temple.edu", "9997774433", "Pyschology", "Biology", "CLA");
            //fake_recipients.Rows.Add("Jim", "Jones", "tuf01930@temple.edu", "7776665544", "Physics", "Math", "CLA");
            //fake_recipients.Rows.Add("Jill", "Jackson", "tuf01930@temple.edu", "9992227744", "Math", "Physics", "Writing Center");
            //fake_recipients.Rows.Add("Barb", "Ballard", "tuf01930@temple.edu", "7774446622", "Biology", "Psychology", "CLA");
            //txtDivision.Text = "Hello";
            //gvSearchResults.DataSource = fake_recipients;
            //gvSearchResults.DataBind();


            //protected void gvSearchResult_click(object sender, GridViewCommandEventArgs e)
            //{
            //    searchHeader.Visible = false;
            //    button_search.Visible = false;
            //    createHeader.Visible = false;
            //    button_submit.Visible = true;
            //    recipient_form.Visible = true;
            //    search_results.Visible = false;
            //    modifyHeader.Visible = true;
            //}
           
                if (Session["AssetRecipient"] != null)
                {
                    bool check;
                    theAssetRecipient = (AssetRecipient)Session["AssetRecipient"];
                    createHeader.Visible = false;
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

            if (Session["AssetRecipient"] != null)
            {
                
                
                btnSubmitCreate.Visible = false;
                myAR.UpdateRow(theAssetRecipient.assetRecipientId, ddlTitle.Text, txtFirstname.Text, txtLastName.Text, txtEmail.Text, txtLocation.Text, txtDivision.Text, ddlPrimaryDept.Text, ddlSecondaryDept.Text, txtPhone.Text, theAssetRecipient.RecordCreated, theAssetRecipient.RecordModified);
            }
            else
                

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
                
            
        }

        protected  void gvSearchResult_click(object sender, GridViewCommandEventArgs e)
        {
            
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSearchResults.Rows[index];
            int arID =(int) gvSearchResults.DataKeys[index].Value;

            if (e.CommandName == "DeleteRow")
            {
                myAR.DeleteRow(arID);
                btnSearch_Click(this, e);
                
            }
            else if (e.CommandName == "modifyRecord")
            {
                bool onModify=false;
                createHeader.Visible = false;
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
                //AutoGenerate The textboxes

                txtFirstname.Text = myAR.firstName;
                txtLastName.Text = myAR.lastName;
                txtEmail.Text = myAR.emailAddress;
                txtDivision.Text = myAR.division;
                ddlPrimaryDept.Text = myAR.primaryDeptAffiliation;
                ddlSecondaryDept.Text = myAR.secondaryDeptAffiliation;
                txtPhone.Text=myAR.phoneNumber;
                lblARID.Text = myAR.assetRecipientId.ToString();
                btnSubmitCreate.Visible = false;
               
    

            }
         

           
        }

      

 

    }

}