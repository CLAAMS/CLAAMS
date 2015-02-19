using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CD6{
    public partial class master : System.Web.UI.MasterPage{
        protected void Page_Load(object sender, EventArgs e){
            string current_page = Request.Url.ToString();
            Regex regex = new Regex("login.aspx");
            Match match = regex.Match(current_page);

            if (Session["user"] != "noAuth" && Session["user"] != null && Session["UserInfo"] != null) {
                Dictionary<string, string> userInfo = (Dictionary<string,string>)Session["UserInfo"];
                lblLoginButton.Text = userInfo["givenName"];
            } else if (match.Success){

            } else {
                Session["user"] = "noAuth";
                Response.AddHeader("REFRESH", "50;URL=login.aspx");
                Response.Redirect("login.aspx");
            }
        }
    }
}