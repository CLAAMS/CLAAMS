using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CD6{
    public partial class users : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){

            UsersList.Visible=true;
            usersHeader.Visible=true;
            modifyHeader.Visible=false;
            createHeader.Visible=false;
            UserForm.Visible=false;

            DataTable fake_users = new DataTable();

            fake_users.Columns.Add("FirstName", typeof(string));
            fake_users.Columns.Add("LastName", typeof(string));
            fake_users.Columns.Add("CLAID", typeof(string));
            fake_users.Columns.Add("Email", typeof(string));

            fake_users.Rows.Add("John","Bonham","tuf01657","johnb@temple.edu");
            fake_users.Rows.Add("Jimmy","Paige","tuw02674","jimmyp@temple.edu");
            fake_users.Rows.Add("Robert","Plant","tud01735","robertp@temple.edu");
            fake_users.Rows.Add("John","Paul Jones","tus09337","johnp@temple.edu");

            gvUsers.DataSource=fake_users;
            gvUsers.DataBind();
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e){
            UsersList.Visible=false;
            usersHeader.Visible=false;
            modifyHeader.Visible=true;
            createHeader.Visible=false;
            UserForm.Visible=true;
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