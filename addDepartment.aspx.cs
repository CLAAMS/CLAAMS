using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilities;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
namespace CD6{
    public partial class addDepartment : System.Web.UI.Page{
        int departmentID;
        string name;
        DataSet myDS = new DataSet();
        DateTime recordCreated;
        DateTime recordModified;
        DBConnect myDbConnect = new DBConnect();
        String SqlConnectString = "server=cla-server6.cla.temple.edu;Database=claams;User id=claams;Password=test=123";

        protected void Page_Load(object sender, EventArgs e){
            myDS = returnDepartments();
            gvDepartments.DataSource = myDS;
            gvDepartments.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e) {
            if (txtDeptName.Text != "") {
                departmentID = Convert.ToInt32(Session["DepartmentId"]);
                name = txtDeptName.Text;
                recordCreated = DateTime.Now;
                recordModified = DateTime.Now;
                if (btnAdd.Text == "Add Department") {
                    CreateDepartment(name, recordCreated, recordModified);
                    Page_Load(this, e);
                    txtDeptName.Text = "";
                } else {
                    ModifyDepartment(departmentID,name);
                    Page_Load(this, e);
                    lblError.Visible = false;
                }
            } else {
                lblError.Text = "Invalid input:<br/>You must enter a department name.";
                lblError.Visible = true;
            }
        }

        public int CreateDepartment(string pname, DateTime precordModified, DateTime pRecordCreated) {
            //Sql stored procedure command for creating departments
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            SqlCommand myCommand1 = new SqlCommand();
            myConnection.Open();

            myCommand1.Connection = myConnection;
            myCommand1.CommandType = CommandType.StoredProcedure;
            myCommand1.CommandText = "AddDepartment";
            
            SqlParameter inputParameter2 = new SqlParameter("Name",pname);
            SqlParameter inputParameter3 = new SqlParameter("recordCreated",pRecordCreated);
            SqlParameter inputParameter4 = new SqlParameter("recordModified",precordModified);
            
            inputParameter2.Direction = ParameterDirection.Input;
            inputParameter2.SqlDbType = SqlDbType.VarChar;
            inputParameter2.Size = 50;

            inputParameter3.Direction = ParameterDirection.Input;
            inputParameter3.SqlDbType = SqlDbType.DateTime;
            inputParameter3.Size = 50;

            inputParameter4.Direction = ParameterDirection.Input;
            inputParameter4.SqlDbType = SqlDbType.DateTime;
            inputParameter4.Size = 50;
          
            myCommand1.Parameters.Add(inputParameter2);
            myCommand1.Parameters.Add(inputParameter3);
            myCommand1.Parameters.Add(inputParameter4);
            int result;

            result = myDbConnect.DoUpdateUsingCmdObj(myCommand1);
            return result;
        }

        public int ModifyDepartment(int theDepartmentId,string theName) {
            SqlCommand myCommand3 = new SqlCommand();
            myCommand3.CommandType = CommandType.StoredProcedure;
            myCommand3.CommandText = "ModifyDepartment";

            SqlParameter inputParameter1 = new SqlParameter("Name",theName);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.VarChar;
            inputParameter1.Size = 50;
            myCommand3.Parameters.Add(inputParameter1);

            SqlParameter inputParameter2 = new SqlParameter("DepartmentId", theDepartmentId);
            inputParameter2.Direction = ParameterDirection.Input;
            inputParameter2.SqlDbType = SqlDbType.Int;
            inputParameter2.Size = 50;
            myCommand3.Parameters.Add(inputParameter2);

            int result;
            result = myDbConnect.DoUpdateUsingCmdObj(myCommand3);
            return result;
        }

        public DataSet returnDepartments() {
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

        public int DeleteDepartments(int departmentID) {
            SqlConnection myConnection = new SqlConnection(SqlConnectString);
            myConnection.Open();
            SqlCommand myCommand2 = new SqlCommand();
            myCommand2.Connection = myConnection;
            myCommand2.CommandType = CommandType.StoredProcedure;
            myCommand2.CommandText = "DeleteDepartment";

            SqlParameter inputParameter1 = new SqlParameter("departmentId", departmentID);
            inputParameter1.Direction = ParameterDirection.Input;
            inputParameter1.SqlDbType = SqlDbType.Int;
            inputParameter1.Size = 50;
            myCommand2.Parameters.Add(inputParameter1);
            int result;

            result = myDbConnect.DoUpdateUsingCmdObj(myCommand2);
            return result;
        }

        protected void gvDepartments_RowCommand(object sender, GridViewCommandEventArgs e) {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvDepartments.Rows[index];
            int departmentID = (int)gvDepartments.DataKeys[index].Value;

            if (e.CommandName == "Modify") {
                string sql;
                sql = string.Format("select Name FROM Department where DepartmentId = {0};", departmentID);
                DataSet data = Tools.DBAccess.DBCall(sql);
                name = (string)data.Tables[0].Rows[0][0];
                txtDeptName.Text = name;
                btnAdd.Text = "Save Department";
                Session.Add("DepartmentId", departmentID);
            }
        }

        protected void gvDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e) { }

        protected void btnClose_Click(object sender, EventArgs e) { }
    }
}