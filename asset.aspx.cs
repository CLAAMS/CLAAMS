using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CD6{
    public partial class asset : System.Web.UI.Page {
        Asset objAsset = new Asset();
        AssetFunctions objAssetFunctions = new AssetFunctions();
        protected void Page_Load(object sender, EventArgs e) {
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
            lblCreateAssetDirections.Visible = true;
            lblCreateAssetDirections.Text = "To create new asset, please enter all required fields in proper format. You may use the Templates drop-down option to auto-populate fields or use the Manage Templates link to create, modify, or delete new auto-fill template designs";

            if(!Page.IsPostBack){
                populateTemplateDropdown();
            }

            if (Session["createAssetSelections"] != null) {
                Dictionary<string, object> createAssetSelections = (Dictionary<string, object>)Session["createAssetSelections"];
                txtCLAID.Text = (string)createAssetSelections["CLATag"];
                txtMake.Text = (string)createAssetSelections["Make"];
                txtModel.Text = (string)createAssetSelections["Model"];
                txtSerialLeft.Text = (string)createAssetSelections["SerialNumber"];
                ddlStatus.SelectedValue = (string)createAssetSelections["Status"];
                txtDescription.Text = (string)createAssetSelections["Description"];
                txtNotes.Text = (string)createAssetSelections["Notes"];
            }
        }

        private void populateTemplateDropdown() {
            DataSet dsAssets = new DataSet();

            string selectTemplates = "select assetTemplateID, Name from Asset_Template;";
            dsAssets = Tools.DBAccess.DBCall(selectTemplates);
            ddlAssetTemplate.DataSource = dsAssets;
            ddlAssetTemplate.DataTextField = dsAssets.Tables[0].Columns[1].ColumnName;
            ddlAssetTemplate.DataValueField = dsAssets.Tables[0].Columns[0].ColumnName;
            ddlAssetTemplate.DataBind();

            ddlAssetTemplate.Items.Insert(0, new ListItem("", ""));
            ddlAssetTemplate.SelectedValue = "";
        }

        private String[] getTemplate(int templateID) {
            string[] template = new string[3];
            string sql = string.Format("select Make, Model, Description from Asset_Template where assetTemplateID = {0};", templateID);
            DataSet data = Tools.DBAccess.DBCall(sql);
            template[0] = (string)data.Tables[0].Rows[0][0].ToString();
            template[1] = (string)data.Tables[0].Rows[0][1].ToString();
            template[2] = (string)data.Tables[0].Rows[0][2].ToString();
            return template;
        }

        protected void gvSearchResult_click(object sender, GridViewCommandEventArgs e) {
            search_results.Visible = false;
            submit_button.Visible = true;
            asset_form.Visible = true;
            search_button.Visible = false;
            searchHeader.Visible = false;
            createHeader.Visible = false;
            history.Visible = true;
            modifyHeader.Visible = true;
            templateRow.Visible = false;

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSearchResults.Rows[index];
            if (e.CommandName == "deleteRecord") {
                string editorID = "";
                editorID = Session["user"].ToString();
                objAsset.editorID = editorID;
                int assetID = Convert.ToInt32(gvSearchResults.DataKeys[index].Value);
                objAsset.assetID = assetID;
                objAsset.Make = gvSearchResults.Rows[index].Cells[2].Text;
                objAsset.Model = gvSearchResults.Rows[index].Cells[3].Text;
                Session["ObjAsset"] = objAsset;
                modal1("Asset Archive", "Are you sure you want to archive this asset?");
               // btnSearch_Click(this, e);
            } else if (e.CommandName == "modifyRecord") {
                createHeader.Visible = false;
                modifyHeader.Visible = true;
                lblModifyAssetDirections.Visible = true;
                lblModifyAssetDirections.Text = "Enter all required fields in correct format to submit modified asset successfully. Use the history dropdown to view previously modified versions of a particular asset.";

                btnSubmit.Visible = false;
                btnSubmitModifyAsset.Visible = true;

                Asset sessionAsset = (Asset)Session["Asset"];
                
                int assetID = Convert.ToInt32(gvSearchResults.DataKeys[index].Value);
                DataSet theDataset = objAsset.GetAssetForSelectedRecord(assetID);

                ////Set the Object values to the gridview
                objAsset.assetID = assetID;
                objAsset.CLATag = gvSearchResults.Rows[index].Cells[1].Text;
                objAsset.Make = gvSearchResults.Rows[index].Cells[2].Text;
                objAsset.Model = gvSearchResults.Rows[index].Cells[3].Text;
                objAsset.SerialNumber = gvSearchResults.Rows[index].Cells[4].Text;
                objAsset.Status = gvSearchResults.Rows[index].Cells[5].Text;
                objAsset.Description = theDataset.Tables[0].Rows[0][4].ToString();
                objAsset.Notes = theDataset.Tables[0].Rows[0][7].ToString();
                objAsset.recordCreated = DateTime.Now;
                objAsset.recordModified = DateTime.Now;

                txtCLAID.Text = objAsset.CLATag;
                
                try {
                    int.Parse(objAsset.CLATag);
                } catch { }
                
                txtMake.Text = objAsset.Make;
                txtModel.Text = objAsset.Model;
                txtSerialLeft.Text = objAsset.SerialNumber;
                ddlStatus.Text = objAsset.Status;
                txtDescription.Text = objAsset.Description;
                txtNotes.Text = objAsset.Notes;
                lblAssetID.Text = objAsset.assetID.ToString();
            } else if(e.CommandName == "checkinRecord") { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            if (validateInput(txtCLAID.Text, txtMake.Text, txtModel.Text)) {
                string submit_type;
                string editor = Session["user"].ToString();
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

                objAssetFunctions.CreateNewAsset(objAsset, editor);

                txtCLAID.Text = "";
                txtMake.Text = "";
                txtModel.Text = "";
                txtDescription.Text = "";
                txtSerialLeft.Text = "";
                ddlStatus.Text = "";
                txtNotes.Text = "";

                submit_type = "create";

                string dialog_header, dialog_body;
                if (submit_type == "create") {
                    dialog_header = "Asset Created";
                    dialog_body = string.Format("{0} {1} has been created successfully.", objAsset.Make, objAsset.Model);
                    modal(dialog_header, dialog_body);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            btnSubmit.Visible = false;
            btnSubmitModifyAsset.Visible = false;
            search_results.Visible = true;
            submit_button.Visible = false;
            search_button.Visible = false;
            asset_form.Visible = false;
            history.Visible = false;
            modifyHeader.Visible = false;
            templateRow.Visible = false;

            objAsset.assetID = 0;
            objAsset.CLATag = txtCLAID.Text;
            objAsset.Make = txtMake.Text;
            objAsset.Model = txtModel.Text;
            objAsset.Description = txtDescription.Text;
            objAsset.SerialNumber = txtSerialRight.Text;
            objAsset.Status = ddlStatus.SelectedValue;
            objAsset.Notes = txtNotes.Text;
          
            DataSet assetDataSource = objAssetFunctions.SearchForAssets(objAsset);
            gvSearchResults.DataSource = assetDataSource;
            gvSearchResults.DataBind();
        }

        protected void btnNewSearch_Click(object sender, EventArgs e){
            lblSearchAssetsDirections.Visible = true;
            lblSearchAssetsDirections.Text = "Enter any combination of fields to search for specific assets or click search with all blank values to view all assets";
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

            txtCLAID.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtDescription.Text = "";
            txtSerialLeft.Text = "";
            txtNotes.Text = "";

            if(ddlStatus.Items[0].Value != ""){
                ddlStatus.Items.Insert(0, new ListItem("", ""));
                ddlStatus.SelectedValue = "";
            }
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

            if(ddlStatus.Items[0].Value == ""){
                ddlStatus.Items.RemoveAt(0);
            }

            txtCLAID.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtSerialLeft.Text = "";
            txtDescription.Text = "";
            txtNotes.Text = "";
        }

        protected void btnSubmitModifyAsset_Click(object sender, EventArgs e) {
            btnSubmit.Visible = false;

            if (validateInput(txtCLAID.Text, txtMake.Text, txtModel.Text)) {
                objAsset.assetID = Convert.ToInt32(lblAssetID.Text);
                objAsset.CLATag = txtCLAID.Text;
                objAsset.Make = txtMake.Text;
                Session["Make1"] = objAsset.Make;
                objAsset.Model = txtModel.Text;
                Session["Model1"] = objAsset.Model;
                objAsset.SerialNumber = txtSerialLeft.Text;
                objAsset.Status = ddlStatus.SelectedValue;
                objAsset.Description = txtDescription.Text;
                objAsset.Notes = txtNotes.Text;
                objAsset.recordCreated = DateTime.Now;
                objAsset.recordModified = DateTime.Now;
                objAsset.editorID = Session["user"].ToString();

                DataSet ds = Tools.DBAccess.DBCall(string.Format("select sosID from Asset where assetID = {0}", objAsset.assetID));
                int sosID = 0;
                if (int.TryParse(ds.Tables[0].Rows[0][0].ToString(), out sosID)) {
                    objAsset.sosID = sosID;
                    Session["AssetObject"] = objAsset;
                    modal2("Modify Asset", "Are you sure you want to modify this asset?");
                } else {
                    objAsset.sosID = sosID;
                    Session["AssetObject"] = objAsset;
                    modal2("Modify Asset", "Are you sure you want to modify this asset?");
                }
            } else {
                modifyHeader.Visible = true;
                createHeader.Visible = false;
                btnSubmitModifyAsset.Visible = true;
            }
        }

        protected void ddlAssetTemplate_SelectedIndexChanged(object sender, EventArgs e) {
            if (ddlAssetTemplate.SelectedValue != "") {
                int assetTemplateID = Convert.ToInt32(ddlAssetTemplate.SelectedValue);
                string[] template = getTemplate(assetTemplateID);
                txtMake.Text = template[0];
                txtModel.Text = template[1];
                txtDescription.Text = template[2];
            } else {
                txtMake.Text = "";
                txtModel.Text = "";
                txtDescription.Text = "";
                txtNotes.Text = "";
                txtSerialLeft.Text = "";
                txtSerialRight.Text = "";
                txtCLAID.Text = "";
            }
        }

        protected void modal(string title, string body) {
            this.Master.modal_header = title;
            this.Master.modal_body = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void modal1(string title, string body) {
            lblModal_header.Text = title;
            lblModal_body.Text = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "archiveAsset();", true);
        }

        protected void modal2(string title, string body) {
            lblModifyAssetModal_header.Text = title;
            lblModifyAssetModal_body.Text = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "modifyAsset();", true);
        }

        protected void btnCheckIN_Click(object sender, EventArgs e) { }

        protected void manage_templates_Click(object sender, EventArgs e) {
            Dictionary<string, object> createAssetSelections = new Dictionary<string, object>();
            createAssetSelections.Add("CLATag", txtCLAID.Text);
            createAssetSelections.Add("Make", txtMake.Text);
            createAssetSelections.Add("Model", txtModel.Text);
            createAssetSelections.Add("SerialNumber", txtSerialLeft.Text);
            createAssetSelections.Add("Status", ddlStatus.SelectedValue);
            createAssetSelections.Add("Description", txtDescription.Text);
            createAssetSelections.Add("Notes", txtNotes.Text);

            Session["createAssetSelections"] = createAssetSelections;
            Response.Redirect("template_asset.aspx");
        }

        protected void btnArchiveAssetYes_Click(object sender, EventArgs e) {
                objAssetFunctions.DeleteAsset((Asset)Session["ObjAsset"]);
                string dialog_header, dialog_body;
                dialog_header = "Asset Archived";
                dialog_body = string.Format("{0} {1} has been archived successfully.", objAsset.Make, objAsset.Model);
                modal(dialog_header, dialog_body);
        }

        protected void btnArchiveAssetNo_Click(object sender, EventArgs e) {
            btnSearch_Click(this, e);
        }

        protected void btnModifyAssetModalYes_Click(object sender, EventArgs e) {
            objAssetFunctions.ModifyAsset((Asset)Session["AssetObject"]);
            string dialog_header, dialog_body;
            dialog_header = "Asset Modified";
            dialog_body = string.Format("{0} {1} has been modified successfully.", Session["Make1"], Session["Model1"]);
            modal(dialog_header, dialog_body);
            btnSearch_Click(this, e);
        }

        protected void btnModifyAssetModalNo_Click(object sender, EventArgs e) {
            btnSubmitModifyAsset_Click(this, e);
        }

        protected bool validateInput(string CLATag, string Make, string Model) {
            string output = "";
            Tools.InputValidation InVal = new Tools.InputValidation();

            if (CLATag == "") {
                output += "Invalid CLA Tag<br/>";
            }

            if (Make == "") {
                output += "Invalid Make<br/>";
            }

            if (Model == "") {
                output += "Invalid Model<br/>";
            }

            if (output != "") {
                modal("Invalid Input!", "The following fields contain errors:<br/>" + output);
                return false;
            } else {
                return true;
            }
        }
    }
}