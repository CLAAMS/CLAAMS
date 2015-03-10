using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Utilities;

namespace CD6{
    public partial class users : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){

            UsersList.Visible=true;
            usersHeader.Visible=true;
            modifyHeader.Visible=false;
            createHeader.Visible=false;
            UserForm.Visible=false;

            DataSet Users = Tools.DBAccess.DBCall("select claID, FirstName, LastName, UserStatus, EmailAddress from CLA_IT_Member");
            DataSet userList = new DataSet();
            userList.Tables.Add();
            userList.Tables[0].Columns.Add("accessNetID", typeof(string));
            userList.Tables[0].Columns.Add("First Name", typeof(string));
            userList.Tables[0].Columns.Add("Last Name", typeof(string));
            userList.Tables[0].Columns.Add("Status", typeof(string));
            userList.Tables[0].Columns.Add("email", typeof(string));

            foreach(DataRow row in Users.Tables[0].Rows){
                DataRow newRow = userList.Tables[0].NewRow();
                string accessNetID = row[0].ToString();
                string firstName = row[1].ToString();
                string lastName = row[2].ToString();
                string status = row[3].ToString();
                string email = row[4].ToString();

                newRow.SetField("accessNetID", accessNetID);
                newRow.SetField("First Name", firstName);
                newRow.SetField("Last Name", lastName);
                newRow.SetField("Status", status);
                newRow.SetField("email", email);
                userList.Tables[0].Rows.Add(newRow);
            }
            gvUsers.DataSource=userList;
            gvUsers.DataBind();
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e){
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvUsers.Rows[index];

            string firstName = row.Cells[0].Text;
            string lastName = row.Cells[1].Text;
            string accessNetID = row.Cells[2].Text;
            string email = row.Cells[3].Text;
            string status = row.Cells[4].Text;
            
            if (e.CommandName == "switchStatus"){
                DBConnect DBObj = new DBConnect();
                SqlCommand commandObject = new SqlCommand();
                commandObject.CommandType = CommandType.StoredProcedure;
                commandObject.CommandText = "updateUserStatus";

                SqlParameter param_AccessNetID = new SqlParameter("@accessNetID", accessNetID);
                param_AccessNetID.Direction = ParameterDirection.Input;
                param_AccessNetID.SqlDbType = SqlDbType.VarChar;
                param_AccessNetID.Size = 100;
                commandObject.Parameters.Add(param_AccessNetID);

                if (status == "Active"){
                    SqlParameter param_UserStatus = new SqlParameter("@status", "Inactive");
                    param_UserStatus.Direction = ParameterDirection.Input;
                    param_UserStatus.SqlDbType = SqlDbType.VarChar;
                    param_UserStatus.Size = 100;
                    commandObject.Parameters.Add(param_UserStatus);
                } else if (status == "Inactive") {
                    SqlParameter param_UserStatus = new SqlParameter("@status", "Active");
                    param_UserStatus.Direction = ParameterDirection.Input;
                    param_UserStatus.SqlDbType = SqlDbType.VarChar;
                    param_UserStatus.Size = 100;
                    commandObject.Parameters.Add(param_UserStatus);
                }

                DBObj.DoUpdateUsingCmdObj(commandObject);
                DBObj.CloseConnection();

                Page_Load(this, e);
            }

            if (e.CommandName == "modify") {
                UsersList.Visible = false;
                usersHeader.Visible = false;
                modifyHeader.Visible = true;
                createHeader.Visible = false;
                UserForm.Visible = true;

                txtCLAID.Text = accessNetID;
                txtEmail.Text = email;
                txtFirstName.Text = firstName;
                txtLastName.Text = lastName;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e){
            UsersList.Visible=false;
            usersHeader.Visible=false;
            modifyHeader.Visible=false;
            createHeader.Visible=true;
            UserForm.Visible=true;
        }

        protected void btnCurrent_Click(object sender, EventArgs e){
            UsersList.Visible=true;
            usersHeader.Visible=true;
            modifyHeader.Visible=false;
            createHeader.Visible=false;
            UserForm.Visible=false;
        }
    }
}