using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace CD6{
    public partial class login : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLoginInstructions.Visible = false;
            lblLoginInstructions.Text = "Enter correct accessnetID and password to begin using the CLAAMS system";
        }

        protected void btnLogin_Click(object sender, EventArgs e){
            if (LDAP.AuthenticateUser(txtUsername.Text, txtPassword.Text) == txtUsername.Text && txtUsername.Text != null && txtUsername.Text != "" && ValidUser(txtUsername.Text)){
                Session["user"] = txtUsername.Text;
                lblLoginInstructions.Visible = false;
                lblError.Text = "Login Successful";
                Session["UserInfo"] = LDAP.getUserInfo(txtUsername.Text);
                Response.Redirect("sos_create.aspx");
            } else {
                lblLoginInstructions.Visible = false;
                lblError.Text = "Invalid username or password, please try again. \n\n";
            }

            //try{
            //    Session["UserInfo"] = LDAP.getUserInfo(txtUsername.Text);
            //    lblLDAPOutput.Text = DictToString((Dictionary<string, string>)Session["UserInfo"]);
            //    Response.Redirect("sos_create.aspx");
            //}catch{
            //    lblLDAPOutput.Text = "Invalid AccessnetID";
            //}
        }

        protected string DictToString(Dictionary<string, string> dict) {
            string output = "";

            foreach (KeyValuePair<string, string> item in dict) {
                output = output + item.Key + ":" + item.Value + "<br/>";
            }
            
            return output;
        }

        protected bool ValidUser(string accessNetID) {
            bool output;
            string sql = string.Format("select claID from CLA_IT_Member where claID='{0}' and UserStatus='Active'",accessNetID);
            DataSet result = Tools.DBAccess.DBCall(sql);
            
            if (result.Tables[0].Rows.Count == 1){
                output=true;
            }else{
                output=false;
            }
            
            return output;
        }
    }
}