using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CD6{
    public partial class assetSearch : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){

            searchResults.Visible=false;
            
            DataTable fake_asset = new DataTable();

            fake_asset.Columns.Add("assetID", typeof(string));
            fake_asset.Columns.Add("CLATag", typeof(string));
            fake_asset.Columns.Add("Make", typeof(string));
            fake_asset.Columns.Add("Model", typeof(string));
            fake_asset.Columns.Add("Description", typeof(string));
            fake_asset.Columns.Add("SerialNumber", typeof(string));
            fake_asset.Columns.Add("Status", typeof(string));
            fake_asset.Columns.Add("Notes", typeof(string));

            fake_asset.Rows.Add("asset10000","CLA1002","Dell","Laptop 2002","Dell laptop computer, 8GB RAM, 2.4GHz Quad Core, 256GB HDD","003994762","Active","Breaks a lot");
            fake_asset.Rows.Add("asset10002","CLA1005","Apple","Macbook Pro","Apple laptop computer, 16GB RAM, 2.7GHz 8Core, 512GB HDD","7872gb39rf","Inactive","");
            fake_asset.Rows.Add("asset10004","CLA1008","Samsung","24 LCD","Samsung 24in widescreen LCD display","899a0udkj3","Active","");
            fake_asset.Rows.Add("asset10006","CLA1011","Dell","Desktop 3000","Dell Desktop Computer, 200 MHz, 128MB RAM, 500MB HDD","88721bker8","Retired","");

            gvSearchResults.DataSource=fake_asset;
            gvSearchResults.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e){
            searchResults.Visible=true;
        }
    }
}