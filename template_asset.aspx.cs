using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using Tools;

namespace CD6
{
    public partial class template_asset : System.Web.UI.Page
    {
        string sqlConnectionString = Global.Connection_String;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblManageTemplateDirections.Visible = true;
            lblManageTemplateDirections.Text = "Enter all required fields to create a new asset template or update/delete existing templates";
            getTemplates();

        }

        protected void btnAddTemplate_Click(object sender, EventArgs e)
        {
            string name, make, model, description;
            int templateID = 0;
            string procedure = null;

            name = txtTemplate.Text;
            make = txtMake.Text;
            model = txtModel.Text;
            description = txtDescription.Text;

            if (btnAddTemplate.Text == "Add Template")
            {
                procedure = "createTemplate";
            }
            else if (btnAddTemplate.Text == "Save Template")
            {
                templateID = (int)Session["assetTemplateID"];
                procedure = "updateTemplate";
            }

            if (procedure != null)
            {
                string submit_type;
                DBConnect objDB = new DBConnect(sqlConnectionString);

                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = procedure;

                SqlParameter param_name = new SqlParameter("@name", name);
                param_name.Direction = ParameterDirection.Input;
                param_name.SqlDbType = SqlDbType.VarChar;
                param_name.Size = 100;
                objCommand.Parameters.Add(param_name);

                SqlParameter param_make = new SqlParameter("@make", make);
                param_make.Direction = ParameterDirection.Input;
                param_make.SqlDbType = SqlDbType.VarChar;
                param_make.Size = 100;
                objCommand.Parameters.Add(param_make);

                SqlParameter param_model = new SqlParameter("@model", model);
                param_model.Direction = ParameterDirection.Input;
                param_model.SqlDbType = SqlDbType.VarChar;
                param_model.Size = 100;
                objCommand.Parameters.Add(param_model);

                SqlParameter param_description = new SqlParameter("@description", description);
                param_description.Direction = ParameterDirection.Input;
                param_description.SqlDbType = SqlDbType.VarChar;
                param_description.Size = 100;
                objCommand.Parameters.Add(param_description);

                submit_type = "addTemplate";

                string dialog_header, dialog_body;
                if (submit_type == "addTemplate")
                {
                    dialog_header = "New Added Template";
                    dialog_body = string.Format("{0} has been created successfully", name);
                    modal(dialog_header, dialog_body);
                }

                if (procedure == "updateTemplate")
                {
                    SqlParameter param_templateID = new SqlParameter("@assetTemplateID", templateID);
                    param_templateID.Direction = ParameterDirection.Input;
                    param_templateID.SqlDbType = SqlDbType.Int;
                    param_templateID.Size = 100;
                    objCommand.Parameters.Add(param_templateID);

                    submit_type = "editTemplate";
                    if (submit_type == "editTemplate")
                    {
                        dialog_header = "Template has been updated";
                        dialog_body = string.Format("{0} has been updated successfully", name);
                        modal(dialog_header, dialog_body);
                    }
                }

                objDB.DoUpdateUsingCmdObj(objCommand);
                objDB.CloseConnection();
            }

            blankTemplateFields();
            btnAddTemplate.Text = "Add Template";
            Session.Remove("assetTemplateID");
            getTemplates();
        }

            private void blankTemplateFields() {
            txtTemplate.Text = "";
            txtDescription.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
        }

        protected void getTemplates() {
            DataSet dsAssets = new DataSet();

            string selectTemplates = "select * from Asset_Template;";
            dsAssets = Tools.DBAccess.DBCall(selectTemplates, Global.Connection_String);

            gvTemplates.DataSource = dsAssets;
            gvTemplates.DataBind();
        }

        protected void gvTemplates_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            string submit_type;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvTemplates.Rows[index];
            int assetTemplateID = Convert.ToInt32(gvTemplates.DataKeys[index].Value);
            Session["assetTemplateID"] = assetTemplateID;
            DataSet ds = Tools.DBAccess.DBCall("select Name from Asset_Template where assetTemplateID =" + assetTemplateID, Global.Connection_String);
            string templateName = ds.Tables[0].Rows[0][0].ToString();
            if (e.CommandName == "delTemplate"){
                DBConnect DBObj = new DBConnect(sqlConnectionString);
                SqlCommand commandObject = new SqlCommand();
                commandObject.CommandType = CommandType.StoredProcedure;
                commandObject.CommandText = "delAssetTemplate";

                SqlParameter param_assetTemplateID = new SqlParameter("@assetTemplateID", assetTemplateID);
                param_assetTemplateID.Direction = ParameterDirection.Input;
                param_assetTemplateID.SqlDbType = SqlDbType.Int;
                param_assetTemplateID.Size = 100;
                commandObject.Parameters.Add(param_assetTemplateID);

                submit_type = "deleteTemplate";

                string dialog_header, dialog_body;
                if (submit_type == "deleteTemplate")
                {
                    dialog_header = "Template has been deleted";
                    dialog_body = string.Format("{0} has been deleted successfully", templateName);
                    modal(dialog_header, dialog_body);
                }

                DBObj.DoUpdateUsingCmdObj(commandObject);
                DBObj.CloseConnection();

                getTemplates();
            }

            if (e.CommandName == "editTemplate"){
                string name, make, model, description, sql;
                sql = string.Format("select Name, Make, Model, Description from Asset_Template where assetTemplateID = {0};", assetTemplateID);

                DataSet data = Tools.DBAccess.DBCall(sql, Global.Connection_String);
                name = (string)data.Tables[0].Rows[0][0];
                make = (string)data.Tables[0].Rows[0][1];
                model = (string)data.Tables[0].Rows[0][2];
                description = (string)data.Tables[0].Rows[0][3];

                txtTemplate.Text = name;
                txtMake.Text = make;
                txtModel.Text = model;
                txtDescription.Text = description;

                btnAddTemplate.Text = "Save Template";
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("asset.aspx");
        }

        protected void modal(string title, string body)
        {
            this.Master.modal_header = title;
            this.Master.modal_body = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
      }
   }