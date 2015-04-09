using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace CD6 {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            lblSearchAssetsForSOSDirections.Visible = true;
            lblSearchAssetsForSOSDirections.Text = "Search for assets to add to new Sign Out Sheet based on any combination of fields";
            searchResults.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            Asset myAsset = new Asset();
            SignOutSheet mySOS = new SignOutSheet();
            int assetID;

            if (int.TryParse(txtAssetID.Text, out assetID)) {
                myAsset.assetID = assetID;
            } else {
                myAsset.assetID = -1;
            }

            myAsset.Make = txtAssetName.Text;
            myAsset.Model = txtAssetType.Text;
            myAsset.CLATag = txtCLATag.Text;
            myAsset.SerialNumber = txtSerial.Text;

            DataSet dataset = mySOS.SearchForAssets(myAsset.assetID, myAsset.Make, myAsset.Model, myAsset.CLATag, myAsset.SerialNumber);
            gvSearchResults.DataSource = dataset;
            gvSearchResults.DataBind();
            searchResults.Visible = true;
            lblSearchAssetsForSOSDirections.Visible = false;
            lblSearchAssetsForSOSSelectDirections.Visible = true;
            lblSearchAssetsForSOSSelectDirections.Text = "Select at least one asset to add to Sign Out Sheet";
            searchFields.Visible = false;
        }

        protected void btnAddAsset_Click(object sender, EventArgs e) {
            ArrayList arraylistOfAssets = new ArrayList();

            for (int i = 0; i < gvSearchResults.Rows.Count; i++){
                CheckBox checkbox = (CheckBox)gvSearchResults.Rows[i].FindControl("chkAddAsset");
                if (checkbox.Checked) {
                    Asset myAsset = new Asset();
                    myAsset.assetID = Convert.ToInt32(gvSearchResults.Rows[i].Cells[0].Text);
                    myAsset.CLATag = gvSearchResults.Rows[i].Cells[1].Text;
                    myAsset.Make = gvSearchResults.Rows[i].Cells[2].Text;
                    myAsset.Model = gvSearchResults.Rows[i].Cells[3].Text;
                    myAsset.SerialNumber = gvSearchResults.Rows[i].Cells[4].Text;
                    myAsset.Status = gvSearchResults.Rows[i].Cells[5].Text;
                    myAsset.Name = gvSearchResults.Rows[i].Cells[2].Text + " " + gvSearchResults.Rows[i].Cells[3].Text;
                    arraylistOfAssets.Add(myAsset);
                }
            }

            Session.Add("Asset", arraylistOfAssets);
            Response.Redirect("sos_create.aspx");
        }

        protected void btnNewSearch_Click(object sender, EventArgs e) {
            searchFields.Visible = true;
            searchResults.Visible = false;
        }
    }
}