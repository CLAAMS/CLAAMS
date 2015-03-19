using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Windows;

namespace CD6
{
    public partial class assetSearch : System.Web.UI.Page
    {
        DataSet myDS5 = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            searchResults.Visible = false;

            //DataTable fake_asset = new DataTable();

            //fake_asset.Columns.Add("assetID", typeof(string));
            //fake_asset.Columns.Add("CLATag", typeof(string));
            //fake_asset.Columns.Add("Make", typeof(string));
            //fake_asset.Columns.Add("Model", typeof(string));
            //fake_asset.Columns.Add("Description", typeof(string));
            //fake_asset.Columns.Add("SerialNumber", typeof(string));
            //fake_asset.Columns.Add("Status", typeof(string));
            //fake_asset.Columns.Add("Notes", typeof(string));

            //fake_asset.Rows.Add("asset10000", "CLA1002", "Dell", "Laptop 2002", "Dell laptop computer, 8GB RAM, 2.4GHz Quad Core, 256GB HDD", "003994762", "Active", "Breaks a lot");
            //fake_asset.Rows.Add("asset10002", "CLA1005", "Apple", "Macbook Pro", "Apple laptop computer, 16GB RAM, 2.7GHz 8Core, 512GB HDD", "7872gb39rf", "Inactive", "");
            //fake_asset.Rows.Add("asset10004", "CLA1008", "Samsung", "24 LCD", "Samsung 24in widescreen LCD display", "899a0udkj3", "Active", "");
            //fake_asset.Rows.Add("asset10006", "CLA1011", "Dell", "Desktop 3000", "Dell Desktop Computer, 200 MHz, 128MB RAM, 500MB HDD", "88721bker8", "Retired", "");


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchResults.Visible = true;

            int assetID;

            Asset myAsset = new Asset();
            SignOutSheet mySOS = new SignOutSheet();
            if (int.TryParse(txtAssetID.Text, out assetID){
                myAsset.assetID = assetID;
            }
            myAsset.Make = txtAssetName.Text;
            myAsset.Model = txtAssetType.Text;
            myAsset.CLATag = txtCLATag.Text;
            myAsset.SerialNumber = txtSerial.Text;
            if (myAsset.assetID == null || myAsset.Make == " " || myAsset.Model == " " || myAsset.CLATag == " " || myAsset.SerialNumber == " ")
            {
                lblAssetID.Text = "You have not entered all the fields, please try again";
            }
            myDS5 = mySOS.SearchForAssets(myAsset.assetID, myAsset.Make, myAsset.Model, myAsset.CLATag, myAsset.SerialNumber);
            gvSearchResults.DataSource = myDS5;
            gvSearchResults.DataBind();
            Session.Add("Dataset", myDS5);
        }

        protected void btnAddAsset_Click(object sender, EventArgs e)
        {

            myDS5 = (DataSet)Session["Dataset"];
            gvSearchResults.DataSource = myDS5;
            gvSearchResults.DataBind();
            ArrayList arrayListOfAssets = new ArrayList();

            CheckBox C = new CheckBox();

            for (int x = 0; x < myDS5.Tables[0].Rows.Count; x++)
            {

                C = (CheckBox)gvSearchResults.Rows[x].Cells[6].FindControl("chkAddAsset");
                C.Checked = true;
                if (C.Checked)
                {
                    Asset myAsset = new Asset();
                    myAsset.assetID = Convert.ToInt32(gvSearchResults.Rows[x].Cells[0].Text);
                    myAsset.CLATag = gvSearchResults.Rows[x].Cells[1].Text;
                    myAsset.Make = gvSearchResults.Rows[x].Cells[2].Text;
                    myAsset.Model = gvSearchResults.Rows[x].Cells[3].Text;
                    myAsset.SerialNumber = gvSearchResults.Rows[x].Cells[4].Text;
                    myAsset.Status = gvSearchResults.Rows[x].Cells[5].Text;
                    myAsset.Name = gvSearchResults.Rows[x].Cells[2].Text + " " + gvSearchResults.Rows[x].Cells[3].Text;
                    arrayListOfAssets.Add(myAsset);
                }

            }
            Session.Add("Asset", arrayListOfAssets);
            Response.Redirect("SOS.aspx");

        }

      

    }
}

        
   

