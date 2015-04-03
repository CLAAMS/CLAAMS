using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Tools;
using System.Data;
namespace CD6 {
    public partial class email : System.Web.UI.Page {
        Email myEmail = new Email();
        DataSet myDS = new DataSet();
        bool buttonIsClicked=false;

        protected void Page_Load(object sender, EventArgs e) {

            if (Session["IsClicked"] == null)
            {
                Session.Add("IsClicked", buttonIsClicked);
            }
            if (Session["IsClicked"]!=null)
            {
                if (!IsPostBack)
                {
                    myDS = myEmail.GetEmailReciept();
                    string body = myDS.Tables[0].Rows[0][0].ToString();
                    txtEmail.Text = body;
                    buttonIsClicked = true;
                    Session["IsClicked"] = buttonIsClicked;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string body = txtEmail.Text;
            myEmail.UpdateEmailBody(body);
        }
    }
}