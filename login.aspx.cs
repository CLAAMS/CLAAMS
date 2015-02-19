using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CD6{
    public partial class login : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){
        }

        protected void btnLogin_Click(object sender, EventArgs e){
            if (LDAP.AuthenticateUser(txtUsername.Text, txtPassword.Text) == txtUsername.Text && txtUsername.Text != null && txtUsername.Text != ""){
                Session["user"] = txtUsername.Text;
                lblError.Text = "Login Successful";
            }else{
                lblError.Text = "Invalid username or password, please try again.";
            }

            try{
                Session["UserInfo"] = LDAP.getUserInfo(txtUsername.Text);
                lblLDAPOutput.Text = DictToString((Dictionary<string, string>)Session["UserInfo"]);
            }catch{
                lblLDAPOutput.Text = "Invalid AccessnetID";
            }
        }

        protected string DictToString(Dictionary<string, string> dict) {
            string output = "";
            foreach (KeyValuePair<string, string> item in dict) {
                output = output + item.Key + ":" + item.Value + "<br/>";
            }
            return output;
        }
    }
}