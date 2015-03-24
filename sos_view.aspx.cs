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
        Asset myAsset = new Asset();
        SignOutSheet mySOS = new SignOutSheet();

        protected void Page_Load(object sender, EventArgs e) {
            int sosID = -1;

            try {
                sosID = (int)Session["SOSID"];
                Session.Remove("SOSID");
            } catch {
                Response.Redirect("./sos_search.aspx");
            }

            mySOS = SignOutSheet.getSOSbyID(sosID);
            txtRecipient.Text = mySOS.arID.ToString();
            txtAssigner.Text = mySOS.cladID.ToString();
            txtTerm.Text = mySOS.assingmentPeriod.ToString();
            calIssueDate.SelectedDate = mySOS.dateCreated;
            if (mySOS.assingmentPeriod == 2) {
                calDue.Visible = true;
                calDueDate.SelectedDate = mySOS.dateDue;
            }

            getAssets(sosID);

            fillHistory(sosID);
        }

        protected void btnClose_Click(object sender, EventArgs e) {
            Response.Redirect("./sos_search.aspx");
        }

        protected void fillHistory(int sosID) {
            
        }

        protected void getAssets(int sosID) { 
        
        }
    }
}