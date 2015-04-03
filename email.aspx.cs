using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Tools;
namespace CD6
{
    public partial class email : System.Web.UI.Page
    {
        string from, to, subject, body;
        protected void Page_Load(object sender, EventArgs e)
        {
            from = "tud45086@temple.edu";
            to = "tud45086@temple.edu";
            subject = "test";
            body = "testBody";
        }

       
    }
}