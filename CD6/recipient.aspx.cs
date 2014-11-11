using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CD6{
    public partial class recipient : System.Web.UI.Page{
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
            searchHeader.Visible=false;
            button_search.Visible=false;
            createHeader.Visible=false;
            button_submit.Visible=false;
            recipient_form.Visible=false;
            search_results.Visible=true;
            modifyHeader.Visible=false;
        }
    }
}