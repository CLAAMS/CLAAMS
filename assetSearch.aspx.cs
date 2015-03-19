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
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Asset myAsset = new Asset();
            SignOutSheet mySOS = new SignOutSheet();
            int assetID;

            if (int.TryParse(txtAssetID.Text, out assetID))
            {
                myAsset.assetID = assetID;
            }
            else {
                myAsset.assetID = -1;
            }

            myAsset.Make = txtAssetName.Text;
            myAsset.Model = txtAssetType.Text;
            myAsset.CLATag = txtCLATag.Text;
            myAsset.SerialNumber = txtSerial.Text;

            if (myAsset.assetID == -1 || myAsset.Make == "" || myAsset.Model == "" || myAsset.CLATag == "" || myAsset.SerialNumber == "")
            {
                lblERROR.Visible = true;
                lblERROR.Text = "You have not entered all the fields, please try again";
            }
            else
            {
                myDS5 = mySOS.SearchForAssets(myAsset.assetID, myAsset.Make, myAsset.Model, myAsset.CLATag, myAsset.SerialNumber);
                gvSearchResults.DataSource = myDS5;
                gvSearchResults.DataBind();
                Session.Add("Dataset", myDS5);
                searchResults.Visible = true;
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

        
   

