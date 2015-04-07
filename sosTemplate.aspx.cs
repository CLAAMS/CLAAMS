using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CD6
{
    public partial class sosTemplate : System.Web.UI.Page
    {
        SoSFunctions myFunctions = new SoSFunctions();
        DataSet myDS = new DataSet();
        bool buttonIsClicked = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsClicked"] == null)
            {
                Session.Add("IsClicked", buttonIsClicked);
            }
            if (Session["IsClicked"] != null)
            {
                if (!IsPostBack)
                {
                    myDS = myFunctions.GetSOSReciept();
                    string body = myDS.Tables[0].Rows[0][0].ToString();
                    txtSOSCopy.Text = body;
                    buttonIsClicked = true;
                    Session["IsClicked"] = buttonIsClicked;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string body = txtSOSCopy.Text;
            myFunctions.UpdateSoSBody(body);
        }
    }
}