using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

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
            dsAssets = Tools.DBAccess.DBCall(selectTemplates, Global.Connection_String);
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
            DataSet data = Tools.DBAccess.DBCall(sql, Global.Connection_String);
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
                lblErrorModify.Text = "";
                createHeader.Visible = false;
                modifyHeader.Visible = true;
                lblModifyAssetDirections.Visible = true;
                lblModifyAssetDirections.Text = "Enter all required fields in correct format to submit modified asset successfully. Use the history dropdown to view previously modified versions of a particular asset.";

                btnSubmit.Visible = false;
                btnSubmitModifyAsset.Visible = true;

                Asset sessionAsset = (Asset)Session["Asset"];
                
                int assetID = Convert.ToInt32(gvSearchResults.DataKeys[index].Value);
                DataSet theDataset = objAsset.GetAssetForSelectedRecord(assetID);

                fillHistory(assetID);

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
            if (validateInput(txtCLAID.Text, txtMake.Text, txtModel.Text)) 
            {
                DataSet ds = Tools.DBAccess.DBCall(string.Format("SELECT * FROM Asset WHERE CLATag = '{0}'", txtCLAID.Text), Global.Connection_String);

                if (ds.Tables[0].Rows.Count == 0)
                {
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
                    if (submit_type == "create")
                    {
                        dialog_header = "Asset Created";
                        dialog_body = string.Format("{0} {1} has been created successfully.", objAsset.Make, objAsset.Model);
                        modal(dialog_header, dialog_body);
                    }
                }
                else
                {
                    string submit_type;
                    submit_type = "error";

                    string dialog_header, dialog_body;
                    if (submit_type == "error")
                    {
                        dialog_header = "Error";
                        dialog_body = string.Format("This CLATag already exists. Please enter a different CLATag to successfully create new asset");
                        modal(dialog_header, dialog_body);
                    }
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
            modifyHeader.Visible = false;

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
            lblError.Text = "";
        }

        protected void btnSubmitModifyAsset_Click(object sender, EventArgs e) {
            btnSubmit.Visible = false;
            createHeader.Visible = false;
            modifyHeader.Visible = true;
            btnSubmitModifyAsset.Visible = true;

            if (validateInputModify(txtCLAID.Text, txtMake.Text, txtModel.Text))
            {
                DataSet ds1 = Tools.DBAccess.DBCall(string.Format("SELECT * FROM Asset WHERE CLATag = '{0}'", txtCLAID.Text), Global.Connection_String);

                if (ds1.Tables[0].Rows.Count == 0)
                {
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

                    DataSet ds = Tools.DBAccess.DBCall(string.Format("select sosID from Asset where assetID = {0}", objAsset.assetID), Global.Connection_String);
                    int sosID = 0;
                    if (int.TryParse(ds.Tables[0].Rows[0][0].ToString(), out sosID))
                    {
                        objAsset.sosID = sosID;
                        Session["AssetObject"] = objAsset;
                        modal2("Modify Asset", "Are you sure you want to modify this asset?");
                    }
                    else
                    {
                        objAsset.sosID = sosID;
                        Session["AssetObject"] = objAsset;
                        modal2("Modify Asset", "Are you sure you want to modify this asset?");
                    }
                }
                else
                {
                    string submit_type;
                    submit_type = "error";

                    string dialog_header, dialog_body;
                    if (submit_type == "error")
                    {
                        dialog_header = "Error";
                        dialog_body = string.Format("This CLATag already exists. Please enter a different CLATag to successfully create new asset");
                        modal(dialog_header, dialog_body);
                    }
                }
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
            lblError.Text = "";
            lblErrorModify.Text = "";
            Tools.InputValidation InVal = new Tools.InputValidation();

            if (CLATag == "") {
                output += "Invalid CLA Tag<br/>";
                lblError.Text += "Enter CLA Tag<br/>";
            }

            if (Make == "") {
                output += "Invalid Make<br/>";
                lblError.Text += "Enter Make<br/>";
            }

            if (Model == "") {
                output += "Invalid Model<br/>";
                lblError.Text += "Enter Model<br/>";
            }

            if (output != "" && lblError.Text != "") 
            {
                modal("Invalid Input!", "The following fields contain errors:<br/>" + output);
                lblError.Text = "The following fields contain errors and are missing information:<br/>" + lblError.Text;
                return false;
            }
            else 
            {
                return true;
            }
        }

        protected bool validateInputModify(string CLATag, string Make, string Model)
        {
            string output = "";
            lblErrorModify.Text = "";
            Tools.InputValidation InVal = new Tools.InputValidation();

            if (CLATag == "")
            {
                output += "Invalid CLA Tag<br/>";
                lblErrorModify.Text += "Enter CLA Tag<br/>";
            }

            if (Make == "")
            {
                output += "Invalid Make<br/>";
                lblErrorModify.Text += "Enter Make<br/>";
            }

            if (Model == "")
            {
                output += "Invalid Model<br/>";
                lblErrorModify.Text += "Enter Model<br/>";
            }

            if (output != "" && lblErrorModify.Text != "")
            {
                modal("Invalid Input!", "The following fields contain errors:<br/>" + output);
                lblErrorModify.Text = "The following fields contain errors and are missing information:<br/>" + lblErrorModify.Text;
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void fillHistory(int assetID) {
            Dictionary<int, DateTime> histories = AssetHistory.getAssetHistories(assetID);

            ddlAssetHistory.Items.Clear();
            ddlAssetHistory.Items.Add(new ListItem("", assetID.ToString()));

            ddlAssetHistory.DataTextField = "Value";
            ddlAssetHistory.DataValueField = "Key";

            ddlAssetHistory.DataSource = histories;
            ddlAssetHistory.DataBind();
        }

        protected void toggleWriteable(string which) {
            if (which == "writable") {
                txtCLAID.Enabled = true;
                txtMake.Enabled = true;
                txtModel.Enabled = true;
                txtSerialLeft.Enabled = true;
                lblAssetID.Enabled = true;
                txtNotes.Enabled = true;
                ddlStatus.Enabled = true;
                txtDescription.Enabled = true;
            } else if (which == "nonwritable") {
                txtCLAID.Enabled = false;
                txtMake.Enabled = false;
                txtModel.Enabled = false;
                txtSerialLeft.Enabled = false;
                lblAssetID.Enabled = false;
                txtNotes.Enabled = false;
                ddlStatus.Enabled = false;
                txtDescription.Enabled = false;
            }
        }

        protected void ddlAssetHistory_SelectedIndexChanged(object sender, EventArgs e) {
            if (ddlAssetHistory.SelectedIndex == 0) {
                templateRow.Visible = true;
                history.Visible = true;

                toggleWriteable("writable");
                int assetID = int.Parse(ddlAssetHistory.SelectedValue);

                createHeader.Visible = false;
                modifyHeader.Visible = true;
                viewHeader.Visible = false;
                lblModifyAssetDirections.Visible = true;
                lblModifyAssetDirections.Text = "Enter all required fields in correct format to submit modified asset successfully. Use the history dropdown to view previously modified versions of a particular asset.";

                btnSubmit.Visible = false;
                btnSubmitModifyAsset.Visible = true;
                
                DataSet dsAsset = objAsset.GetAssetForSelectedRecord(assetID);
                Asset asset = new Asset();

                asset.assetID = (int)dsAsset.Tables[0].Rows[0].ItemArray[0];
                asset.CLATag = dsAsset.Tables[0].Rows[0].ItemArray[1].ToString();
                asset.Make = dsAsset.Tables[0].Rows[0].ItemArray[2].ToString();
                asset.Model = dsAsset.Tables[0].Rows[0].ItemArray[3].ToString();
                asset.Description = dsAsset.Tables[0].Rows[0].ItemArray[4].ToString();
                asset.SerialNumber = dsAsset.Tables[0].Rows[0].ItemArray[5].ToString();
                asset.Status = dsAsset.Tables[0].Rows[0].ItemArray[6].ToString();
                asset.Notes = dsAsset.Tables[0].Rows[0].ItemArray[7].ToString();
                asset.recordCreated = DateTime.Parse(dsAsset.Tables[0].Rows[0].ItemArray[8].ToString());
                asset.recordModified = DateTime.Parse(dsAsset.Tables[0].Rows[0].ItemArray[9].ToString());
                try {
                    asset.sosID = (int)dsAsset.Tables[0].Rows[0].ItemArray[10];
                } catch {}
                asset.editorID = dsAsset.Tables[0].Rows[0].ItemArray[11].ToString();

                fillHistory(assetID);

                txtCLAID.Text = asset.CLATag;
                txtMake.Text = asset.Make;
                txtModel.Text = asset.Model;
                txtSerialLeft.Text = asset.SerialNumber;
                ddlStatus.Text = asset.Status;
                txtDescription.Text = asset.Description;
                txtNotes.Text = asset.Notes;
                lblAssetID.Text = asset.assetID.ToString();
            } else {
                toggleWriteable("nonwritable");
                int assetHistoryID = int.Parse(ddlAssetHistory.SelectedValue);

                AssetHistory objAsset = AssetHistory.getAssetHistory(assetHistoryID);

                int assetID = objAsset.assetID;

                templateRow.Visible = false;

                createHeader.Visible = false;
                modifyHeader.Visible = false;
                viewHeader.Visible = true;
                lblViewAssetDirections.Visible = true;
                lblViewAssetDirections.Text = "Enter all required fields in correct format to submit modified asset successfully. Use the history dropdown to view previously modified versions of a particular asset.";

                history.Visible = true;

                btnSubmit.Visible = false;
                btnSubmitModifyAsset.Visible = false;

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

        protected void linkExport_Click(object sender, EventArgs e) {
            string results = Tools.CSV.gvToCsv(gvSearchResults);
            string[] lines = results.Split('\n');

            Response.Clear();
            Response.AppendHeader("content-disposition", "attachment; filename=myfile.txt");
            Response.ContentType = "text/xml";
            foreach (string line in lines) {
                Response.Write(line + Environment.NewLine);
            }
            Response.Flush();
            Response.End();
        }
    }
}