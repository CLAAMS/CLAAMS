using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CD6{
    public partial class sos : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){

            ddlTerm_SelectedIndexChanged(this, e);

            searchHeader.Visible=false;
            button_search.Visible=false;
            createHeader.Visible=true;
            recipientSearch.Visible=false;
            recipientCreate.Visible=true;
            button_submit.Visible=true;
            sos_form.Visible=true;
            search_results.Visible=false;
            searchButtons.Visible=true;
            trackingHeader.Visible=true;
            searchResultsHeader.Visible=false;
            modifyHeader.Visible=false;
            uploadSheet.Visible=false;

            DataTable fake_sos = new DataTable();
            fake_sos.Columns.Add("sosID", typeof(string));
            fake_sos.Columns.Add("assetID", typeof(string));
            fake_sos.Columns.Add("claID", typeof(string));
            fake_sos.Columns.Add("arID", typeof(string));
            fake_sos.Columns.Add("AssignmentPeriod", typeof(string));
            fake_sos.Columns.Add("DateCreated", typeof(string));
            fake_sos.Columns.Add("DateModified", typeof(string));
            fake_sos.Columns.Add("DateDue", typeof(string));
            fake_sos.Columns.Add("Status", typeof(string));
            fake_sos.Columns.Add("ImageFileName", typeof(string));
            fake_sos.Columns.Add("recordModified", typeof(string));
            fake_sos.Columns.Add("recordCreated", typeof(string));

            fake_sos.Rows.Add("sos10000", "asset10000", "tua10000", "tug10000", "Permanent", "10/28/2014", "10/31/2014", null, "Active", "img1000000.jpg", "10/31/2014", "10/28/2014");
            fake_sos.Rows.Add("sos10001", "asset10001", "tub10000", "tuh10000", "Permanent", "10/28/2014", "10/31/2014", null, "Active", "img1000001.jpg", "10/31/2014", "10/28/2014");
            fake_sos.Rows.Add("sos10002", "asset10002", "tuc10000", "tui10000", "Temporary", "10/28/2014", "10/31/2014", "01/02/2015", "Active", "img1000002.jpg", "10/31/2014", "10/28/2014");
            fake_sos.Rows.Add("sos10003", "asset10003", "tud10000", "tuj10000", "Temporary", "10/28/2014", "10/31/2014", "01/02/2015", "Active", "img1000003.jpg", "10/31/2014", "10/28/2014");
            fake_sos.Rows.Add("sos10004", "asset10004", "tue10000", "tuk10000", "Permanent", "10/28/2014", "10/31/2014", null, "Active", "img1000004.jpg", "10/31/2014", "10/28/2014");
            fake_sos.Rows.Add("sos10005", "asset10005", "tuf10000", "tul10000", "Temporary", "10/28/2014", "10/31/2014", "01/02/2015", "Active", "img1000005.jpg", "10/31/2014", "10/28/2014");

            fake_sos.Rows.Add("sos10000", "asset10000", "tua10000", "tug10000", "Permanent", "10/28/2014", "10/31/2014", null, "Active", "img1000000.jpg", "10/31/2014", "10/28/2014");
            fake_sos.Rows.Add("sos10001", "asset10001", "tub10000", "tuh10000", "Permanent", "10/28/2014", "10/31/2014", null, "Active", "img1000001.jpg", "10/31/2014", "10/28/2014");
            fake_sos.Rows.Add("sos10002", "asset10002", "tuc10000", "tui10000", "Temporary", "10/28/2014", "10/31/2014", "01/02/2015", "Active", "img1000002.jpg", "10/31/2014", "10/28/2014");
            fake_sos.Rows.Add("sos10003", "asset10003", "tud10000", "tuj10000", "Temporary", "10/28/2014", "10/31/2014", "01/02/2015", "Active", "img1000003.jpg", "10/31/2014", "10/28/2014");
            fake_sos.Rows.Add("sos10004", "asset10004", "tue10000", "tuk10000", "Permanent", "10/28/2014", "10/31/2014", null, "Active", "img1000004.jpg", "10/31/2014", "10/28/2014");
            fake_sos.Rows.Add("sos10005", "asset10005", "tuf10000", "tul10000", "Temporary", "10/28/2014", "10/31/2014", "01/02/2015", "Active", "img1000005.jpg", "10/31/2014", "10/28/2014");

            gvSearchResults.DataSource = fake_sos;
            gvSearchResults.DataBind();
        }

        protected void btnNewSearch_Click(object sender, EventArgs e){
            searchHeader.Visible=true;
            recipientSearch.Visible=true;
            button_search.Visible=true;
            createHeader.Visible=false;
            recipientCreate.Visible=false;
            button_submit.Visible=false;
            sos_form.Visible=true;
            search_results.Visible=false;
            searchButtons.Visible=false;
            trackingHeader.Visible=false;
            searchResultsHeader.Visible=false;
            modifyHeader.Visible=false;
            uploadSheet.Visible=false;
        }

        protected void btnSearch_Click(object sender, EventArgs e){
            searchHeader.Visible=false;
            recipientSearch.Visible=false;
            button_search.Visible=false;
            createHeader.Visible=false;
            recipientCreate.Visible=false;
            button_submit.Visible=false;
            sos_form.Visible=false;
            search_results.Visible=true;
            searchButtons.Visible=true;
            trackingHeader.Visible=false;
            searchResultsHeader.Visible=true;
            modifyHeader.Visible=false;
            uploadSheet.Visible=false;
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
    }
}