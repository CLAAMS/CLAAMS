using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CD6{
    public partial class asset : System.Web.UI.Page
    {
        Asset objAsset = new Asset();
        AssetFunctions objAssetFunctions = new AssetFunctions();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmitModifyAsset.Visible = false;

            search_results.Visible=false;
            submit_button.Visible=true;
            asset_form.Visible=true;
            search_button.Visible=false;
            searchHeader.Visible=false;
            createHeader.Visible=true;
            history.Visible=false;
            modifyHeader.Visible=false;
            templateRow.Visible=true;
            lblSerialLeft.Visible=true;
            txtSerialLeft.Visible=true;
            filler.Visible=false;
            lblSerialRight.Visible=false;
            txtSerialRight.Visible=false;

            //DataTable fake_asset = new DataTable();

            //fake_asset.Columns.Add("assetID", typeof(string));
            //fake_asset.Columns.Add("CLATag", typeof(string));
            //fake_asset.Columns.Add("Make", typeof(string));
            //fake_asset.Columns.Add("Model", typeof(string));
            //fake_asset.Columns.Add("Description", typeof(string));
            //fake_asset.Columns.Add("SerialNumber", typeof(string));
            //fake_asset.Columns.Add("Status", typeof(string));
            //fake_asset.Columns.Add("Notes", typeof(string));

            //fake_asset.Rows.Add("asset10000","CLA1002","Dell","Laptop 2002","Dell laptop computer, 8GB RAM, 2.4GHz Quad Core, 256GB HDD","003994762","Active","Breaks a lot");
            //fake_asset.Rows.Add("asset10002","CLA1005","Apple","Macbook Pro","Apple laptop computer, 16GB RAM, 2.7GHz 8Core, 512GB HDD","7872gb39rf","Inactive","");
            //fake_asset.Rows.Add("asset10004","CLA1008","Samsung","24 LCD","Samsung 24in widescreen LCD display","899a0udkj3","Active","");
            //fake_asset.Rows.Add("asset10006","CLA1011","Dell","Desktop 3000","Dell Desktop Computer, 200 MHz, 128MB RAM, 500MB HDD","88721bker8","Retired","");

            //gvSearchResults.DataSource=fake_asset;
            //gvSearchResults.DataBind();
        }

        protected void gvSearchResult_click(object sender, GridViewCommandEventArgs e){
            search_results.Visible=false;
            submit_button.Visible=true;
            asset_form.Visible=true;
            search_button.Visible=false;
            searchHeader.Visible=false;
            createHeader.Visible=false;
            history.Visible=true;
            modifyHeader.Visible=true;
            templateRow.Visible=false;

           
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSearchResults.Rows[index];

            if (e.CommandName == "deleteRecord")
            {
                int assetID = Convert.ToInt32(gvSearchResults.DataKeys[index].Value);
                objAsset.assetID = assetID;

                objAssetFunctions.DeleteAsset(objAsset);
                btnSearch_Click(this, e);
                    
            }
            else if (e.CommandName == "modifyRecord")
            {
                createHeader.Visible = false;
                modifyHeader.Visible = true;

                btnSubmit.Visible = false;
                btnSubmitModifyAsset.Visible = true;

                int assetID = Convert.ToInt32(gvSearchResults.DataKeys[index].Value);
                

                ////Set the Object values to the gridview
                objAsset.assetID = assetID;
                objAsset.CLATag = gvSearchResults.Rows[index].Cells[1].Text;
                objAsset.Make = gvSearchResults.Rows[index].Cells[2].Text;
                objAsset.Model = gvSearchResults.Rows[index].Cells[3].Text;
                objAsset.SerialNumber = gvSearchResults.Rows[index].Cells[4].Text;
                objAsset.Status = gvSearchResults.Rows[index].Cells[5].Text;
                objAsset.Description = gvSearchResults.Rows[index].Cells[6].Text;
                objAsset.Notes = gvSearchResults.Rows[index].Cells[7].Text;
                objAsset.recordCreated = DateTime.Now;
                objAsset.recordModified = DateTime.Now;

                txtCLAID.Text = objAsset.CLATag;
                txtMake.Text = objAsset.Make;
                txtModel.Text = objAsset.Model;
                txtSerialLeft.Text = objAsset.SerialNumber;
                ddlStatus.Text = objAsset.Status;
                txtDescription.Text = objAsset.Description;
                txtNotes.Text = objAsset.Notes;
                lblAssetID.Text = objAsset.assetID.ToString();

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = true;
            btnSubmitModifyAsset.Visible = false;
            objAsset.CLATag = txtCLAID.Text;
            objAsset.Make = txtMake.Text;
            objAsset.Model = txtModel.Text;
            objAsset.Description = txtDescription.Text;
            objAsset.SerialNumber = txtSerialLeft.Text;
            objAsset.Status = ddlStatus.SelectedValue;
            objAsset.Notes = txtNotes.Text;
            objAsset.recordCreated = DateTime.Now;
            objAsset.recordModified = DateTime.Now;

            objAssetFunctions.CreateNewAsset(objAsset);

            
        }

        protected void btnSearch_Click(object sender, EventArgs e){
            btnSubmit.Visible = false;
            btnSubmitModifyAsset.Visible = false;
            search_results.Visible=true;
            submit_button.Visible=false;
            search_button.Visible=false;
            asset_form.Visible=false;
            history.Visible=false;
            modifyHeader.Visible=false;
            templateRow.Visible=false;

            objAsset.assetID = 0;
            objAsset.CLATag = txtCLAID.Text;
            objAsset.Make = txtMake.Text;
            objAsset.Model = txtModel.Text;
            objAsset.Description = txtDescription.Text;
            objAsset.SerialNumber = txtSerialLeft.Text;
            objAsset.Status = ddlStatus.SelectedValue;
            objAsset.Notes = txtNotes.Text;

            gvSearchResults.DataSource = objAssetFunctions.SearchForAssets(objAsset);
            gvSearchResults.DataBind();
          
        }

        protected void btnNewSearch_Click(object sender, EventArgs e){
            btnSubmit.Visible = false;
            btnSubmitModifyAsset.Visible = false;
            search_results.Visible=false;
            submit_button.Visible=false;
            asset_form.Visible=true;
            search_button.Visible=true;
            searchHeader.Visible=true;
            createHeader.Visible=false;
            history.Visible=false;
            modifyHeader.Visible=false;
            txtNotes.Rows=1;
            txtDescription.Rows=1;
            templateRow.Visible=false;
            lblSerialLeft.Visible=false;
            txtSerialLeft.Visible=false;
            filler.Visible=true;
            lblSerialRight.Visible=true;
            txtSerialRight.Visible=true;
        }

        protected void btnCreate_Click(object sender, EventArgs e){
            btnSubmitModifyAsset.Visible = false;
            btnSubmit.Visible = true;
            search_results.Visible=false;
            submit_button.Visible=true;
            asset_form.Visible=true;
            search_button.Visible=false;
            searchHeader.Visible=false;
            createHeader.Visible=true;
            history.Visible=false;
            modifyHeader.Visible=false;
            templateRow.Visible=true;
            lblSerialLeft.Visible=true;
            txtSerialLeft.Visible=true;
            filler.Visible=false;
            lblSerialRight.Visible=false;
            txtSerialRight.Visible=false;
        }

        protected void btnSubmitModifyAsset_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = false;

            objAsset.assetID = Convert.ToInt32(lblAssetID.Text);
            objAsset.CLATag = txtCLAID.Text;
            objAsset.Make = txtMake.Text;
            objAsset.Model = txtModel.Text;
            objAsset.SerialNumber = txtSerialLeft.Text;
            objAsset.Status = ddlStatus.SelectedValue;
            objAsset.Description = txtDescription.Text;
            objAsset.Notes = txtNotes.Text;
            objAsset.recordCreated = DateTime.Now;
            objAsset.recordModified = DateTime.Now;

            objAssetFunctions.ModifyAsset(objAsset);
            btnSearch_Click(this, e);
        }

       

        
    }
}