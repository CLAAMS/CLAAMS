using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CD6{
    public partial class manageTemplates : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){
            DataTable fake_asset = new DataTable();

            fake_asset.Columns.Add("TemplateName", typeof(string));
            fake_asset.Columns.Add("Make", typeof(string));
            fake_asset.Columns.Add("Model", typeof(string));
            fake_asset.Columns.Add("Description", typeof(string));

            fake_asset.Rows.Add("Dell Laptop","Dell","Laptop 2002","Dell laptop computer, 8GB RAM, 2.4GHz Quad Core, 256GB HDD");
            fake_asset.Rows.Add("Apple Laptop","Apple","Macbook Pro","Apple laptop computer, 16GB RAM, 2.7GHz 8Core, 512GB HDD");
            fake_asset.Rows.Add("Samsung Flatscreen","Samsung","24 LCD","Samsung 24in widescreen LCD display");
            fake_asset.Rows.Add("Dell Desktop","Dell","Desktop 3000","Dell Desktop Computer, 200 MHz, 128MB RAM, 500MB HDD");

            gvTemplates.DataSource=fake_asset;
            gvTemplates.DataBind();
        }
    }
}