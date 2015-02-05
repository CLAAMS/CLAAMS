using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CD6{
    public partial class addDepartment : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){
            DataTable departments = new DataTable();

            departments.Columns.Add("Department", typeof(string));

            departments.Rows.Add("English");
            departments.Rows.Add("Psychology");
            departments.Rows.Add("History");
            departments.Rows.Add("Language");

            gvDepartments.DataSource=departments;
            gvDepartments.DataBind();
        }
    }
}