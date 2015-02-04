using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CD6{
    public partial class recipient : System.Web.UI.Page{
       AssetRecipient myAR = new AssetRecipient();
       
        protected void Page_Load(object sender, EventArgs e){
        
            searchHeader.Visible=false;
            button_search.Visible=false;
            createHeader.Visible=true;
            button_submit.Visible=true;
            recipient_form.Visible=true;
            search_results.Visible=false;
            modifyHeader.Visible=false;
            
            DataTable fake_recipients = new DataTable();

            fake_recipients.Columns.Add("FirstName", typeof(string));
            fake_recipients.Columns.Add("LastName", typeof(string));
            fake_recipients.Columns.Add("EmailAddress", typeof(string));
            fake_recipients.Columns.Add("PhoneNumber", typeof(string));
            fake_recipients.Columns.Add("PrimaryDeptAffiliation", typeof(string));
            fake_recipients.Columns.Add("SecondaryDeptAffiliation", typeof(string));
            fake_recipients.Columns.Add("Division", typeof(string));

            fake_recipients.Rows.Add("Bob","Burner","tuf01930@temple.edu","9997774433","Pyschology","Biology","CLA");
            fake_recipients.Rows.Add("Jim","Jones","tuf01930@temple.edu","7776665544","Physics","Math","CLA");
            fake_recipients.Rows.Add("Jill","Jackson","tuf01930@temple.edu","9992227744","Math","Physics","Writing Center");
            fake_recipients.Rows.Add("Barb","Ballard","tuf01930@temple.edu","7774446622","Biology","Psychology","CLA");
            txtDivision.Text = "Hello";
            gvSearchResults.DataSource=fake_recipients;
            gvSearchResults.DataBind();
        }

        protected void gvSearchResult_click(object sender, GridViewCommandEventArgs e){        
            searchHeader.Visible=false;
            button_search.Visible=false;
            createHeader.Visible=false;
            button_submit.Visible=true;
            recipient_form.Visible=true;
            search_results.Visible=false;
            modifyHeader.Visible=true;
        }

        protected void btnNewSearch_Click(object sender, EventArgs e){
            searchHeader.Visible=true;
            button_search.Visible=true;
            createHeader.Visible=false;
            button_submit.Visible=false;
            recipient_form.Visible=true;
            search_results.Visible=false;
            modifyHeader.Visible=false;
        }

        protected void btnSearch_Click(object sender, EventArgs e){
            DataSet myDS = new DataSet();
                searchHeader.Visible = false;
                button_search.Visible = false;
                createHeader.Visible = false;
                button_submit.Visible = false;
                recipient_form.Visible = false;
                search_results.Visible = true;
                modifyHeader.Visible = false;
                myAR.assetRecipientId = 1;
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
                myDS = myAR.SearchAssetRecipient(myAR.title, myAR.firstName, myAR.lastName, myAR.emailAddress, myAR.location, myAR.division, myAR.primaryDeptAffiliation, myAR.secondaryDeptAffiliation, myAR.phoneNumber, myAR.RecordCreated, myAR.RecordModified);
                gvSearchResults.DataSource = myDS;
                gvSearchResults.DataBind();
            
        }

        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            myAR.assetRecipientId = 1;
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
            myAR.CreateAssetRecipient( myAR.title, myAR.firstName, myAR.lastName, myAR.emailAddress, myAR.location, myAR.division, myAR.primaryDeptAffiliation, myAR.secondaryDeptAffiliation, myAR.phoneNumber, myAR.RecordCreated, myAR.RecordModified);
        }
    }
}