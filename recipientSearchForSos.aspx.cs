using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Data;
using Utilities;

namespace CD6 {
    public partial class recipientSearchForSos : System.Web.UI.Page {
        String SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";
        Dictionary<string, object> createSosSelections = new Dictionary<string, object>();

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack){
                fillDropdowns();
            }
            createSosSelections = (Dictionary<string, object>)Session["createSosSelections"];
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            string sql = "select arID, FirstName, LastName, EmailAddress, Location, (select Divisions.DivisionName from Divisions where DivisionID=Division) as DivisionName, (select Department.Name from Department where DepartmentId=PrimaryDeptAffiliation) as PrimaryDept, (select Department.Name from Department where DepartmentId=SecondaryDeptAffiliation) as SecondaryDept, PhoneNumber from Asset_Recipient where arID is not null";

            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;

            //int division = Convert.ToInt32(ddlDivision.SelectedValue);
            int division, primaryDept, secondaryDept;
            
            if (!Int32.TryParse(ddlDivision.SelectedValue, out division)) {
                division = 0;
            }

            if (!Int32.TryParse(ddlSecondaryDept.SelectedValue, out secondaryDept)) {
                secondaryDept = 0;
            }

            if (!Int32.TryParse(ddlPrimaryDept.SelectedValue, out primaryDept)) {
                primaryDept = 0;
            }

            sql += string.Format(" and Firstname like '%{0}%' and LastName like '%{1}%' and EmailAddress like '%{2}%'", firstName, lastName, email);

            if (division != 0){
                sql += string.Format(" and Division={0}", division.ToString());
            }

            if (primaryDept != 0){
                sql += string.Format(" and PrimaryDeptAffiliation={0}", primaryDept.ToString());
            }

            if (secondaryDept != 0){
                sql += string.Format(" and SecondaryDeptAffiliation={0}", secondaryDept.ToString());
            }

            gvSearchResults.DataSource = Tools.DBAccess.DBCall(sql);
            gvSearchResults.DataBind();
            searchResults.Visible = true;
        }

        protected void gvSearchResults_RowCommand(object sender, GridViewCommandEventArgs e) {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSearchResults.Rows[index];
            int arID = (int)gvSearchResults.DataKeys[index].Value;

            if (e.CommandName == "selectRecipient") {
                createSosSelections["Recipient"] = arID;
                Session["createSosSelections"] = createSosSelections;
                Response.Redirect("./sos_create.aspx");
            }
        }

        protected void fillDropdowns() {
            DataSet dsDepartments = getDepartments();
            DataSet dsDivisions = getDivisions();

            Dictionary<int, string> depts = new Dictionary<int, string>();
            Dictionary<int, string> divisions = new Dictionary<int, string>();

            foreach(DataRow row in dsDepartments.Tables[0].Rows) {
                depts.Add((int)row.ItemArray[0], row.ItemArray[1].ToString());
            }

            foreach(DataRow row in dsDivisions.Tables[0].Rows) {
                divisions.Add((int)row.ItemArray[0], row.ItemArray[1].ToString());
            }

            ddlSecondaryDept.Items.Clear();
            ddlSecondaryDept.Items.Add(new ListItem(""));
            ddlSecondaryDept.DataValueField = "Key";
            ddlSecondaryDept.DataTextField = "Value";

            ddlPrimaryDept.Items.Clear();
            ddlPrimaryDept.Items.Add(new ListItem(""));
            ddlPrimaryDept.DataValueField = "Key";
            ddlPrimaryDept.DataTextField = "Value";

            ddlDivision.Items.Clear();
            ddlDivision.Items.Add(new ListItem(""));
            ddlDivision.DataValueField = "Key";
            ddlDivision.DataTextField = "Value";

            ddlDivision.DataSource = divisions;
            ddlPrimaryDept.DataSource = depts;
            ddlSecondaryDept.DataSource = depts;
            
            ddlDivision.DataBind();
            ddlPrimaryDept.DataBind();
            ddlSecondaryDept.DataBind();
        }

        protected DataSet getDepartments() {
            DataSet testDS = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand1 = new SqlCommand();
            myConnection.Open();

            myCommand1.Connection = myConnection;
            myCommand1.CommandType = CommandType.StoredProcedure;
            myCommand1.CommandText = "GetDepartments";
            testDS = myDbConnect.GetDataSetUsingCmdObj(myCommand1);
            return testDS;
        }

        protected DataSet getDivisions() {
            DataSet testDS = new DataSet();
            DBConnect myDbConnect = new DBConnect();
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand1 = new SqlCommand();
            myConnection.Open();

            myCommand1.Connection = myConnection;
            myCommand1.CommandType = CommandType.StoredProcedure;
            myCommand1.CommandText = "GetDivisions";
            testDS = myDbConnect.GetDataSetUsingCmdObj(myCommand1);
            return testDS;
        }
    }
}