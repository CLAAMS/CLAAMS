using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Utilities;
using System.Text;
using System.IO;
namespace CD6
{
    public partial class CurlPage : System.Web.UI.Page
    {
        Email myEmail = new Email();
        string key=" ";
        GridView gridView = new GridView();
        String SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";
            
            DBConnect myDB = new DBConnect();
           
            
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string[] results = Request.RawUrl.ToString().Split(new char[] { '?' });
                key = results[1];
            }
            catch
            {
                key = " ";

            }
            
            if (key == "12345")
            {
                lblValidation.Text = "It worked";
                SqlConnection myConn = new SqlConnection(SqlConnectString);
                SqlCommand MyCommand = new SqlCommand();
                myConn.Open();
               MyCommand.Connection = myConn;
               MyCommand.CommandType = CommandType.StoredProcedure;
               MyCommand.CommandText = "sosTracking";
               gridView.DataSource = myDB.GetDataSetUsingCmdObj(MyCommand);
               gridView.DataBind();
               myEmail.sendEmail("ryanmarks62@yahoo.com", "tud45086@temple.edu", "Weekly Dashboard of Sign out Sheets", "Hello! This is your weekly dashboard of overdue Sign Out Sheets, and ones that are close to overdue." + render(gridView) + "Thank you, and have a good day!  Regards, the CLAAMS System");
            }
            else
                lblValidation.Text = "It didn't work";
        }

        public  string render(GridView theGridview)
        {

            StringBuilder mySB = new StringBuilder();
            StringWriter mySW = new StringWriter(mySB);
            HtmlTextWriter myWriter = new HtmlTextWriter(mySW);
            theGridview.RenderControl(myWriter);

            //return Regex.Replace(mySB.ToString(),@"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>",string.Empty);
            return mySB.ToString();

        }
    }
}