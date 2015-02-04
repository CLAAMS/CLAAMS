﻿using System;
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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
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
            search_results.Visible=true;
            submit_button.Visible=false;
            search_button.Visible=false;
            asset_form.Visible=false;
            history.Visible=false;
            modifyHeader.Visible=false;
            templateRow.Visible=false;
        }

        protected void btnNewSearch_Click(object sender, EventArgs e){
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
    }
}