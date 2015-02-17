using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CD6{
    public partial class master : System.Web.UI.MasterPage{
        protected void Page_Load(object sender, EventArgs e){
            if (Session["user"] == "Authenticated"){
            } else if (Session["user"] != "noAuth"){
                Session["user"] = "noAuth";
                Response.AddHeader("REFRESH", "50;URL=login.aspx");
                Response.Redirect("login.aspx");
            } else if (Session["user"] == "noAuth"){      
            }
        }
    }
}