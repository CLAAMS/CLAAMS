using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Tools;
using System.Data;
using Utilities;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Net.Mail;
namespace CD6 {
    public partial class sos_upload : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            int sosID = (int)Session["sosID"];
            SignOutSheet mySOS = SignOutSheet.getSOSbyID(sosID);
            Dictionary<string, string> names = SignOutSheet.getSosName(sosID);
            ArrayList assets = SignOutSheet.getAssetsForSOS(sosID);

            lbAssets.DataSource = assets;
            lbAssets.DataTextField = "Name";
            lbAssets.DataValueField = "assetID";
            lbAssets.DataBind();

            txtAssigner.Text = names["Assigner Name"];
            txtRecipient.Text = names["Recipient Name"];
            calIssueDate.SelectedDate = mySOS.dateCreated;

            if (mySOS.assingmentPeriod == 0) {
                txtTerm.Text = "Non-Permanent";
                calDue.Visible = true;
                string dueDate = mySOS.dateDue.ToShortDateString();
                DateTime DateDue = Convert.ToDateTime(dueDate);
                calDueDate.SelectedDate = DateDue;
            } else {
                txtTerm.Text = "Permanent";
            }

            if(mySOS.imageFileName == ""){
                signatureFunctions.Visible = false;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e) {
            Session.Remove("SOSID");
            Session.Remove("FileName");
            Response.Redirect("./sos_track.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e) {
            int sosID = (int)Session["SOSID"];
            uploadFile(txtRecipient.Text, sosID.ToString(), calIssueDate.SelectedDate.ToShortDateString().Replace("/","-"), calDueDate.SelectedDate.ToShortDateString().Replace("/","-"), SosHistory.getLastHistoryID(sosID).ToString());
        }

        protected void uploadFile(string recipientName, string sosID, string issueDate, string dueDate, string copy) {
            bool extensionOK = false;
            string filename = "";
            
            if(dueDate == "1-1-0001"){
                filename = string.Format("{0}_{1}_{2}_{3}", issueDate, recipientName, sosID, copy);
            } else {
                filename = string.Format("{0}_{1}_{2}_{3}_{4}", issueDate, recipientName, sosID, dueDate, copy);
            }
            
            string path = Server.MapPath("~/signatures/");
            string fileExtension = "";
            if(fuSignSheet.HasFile){
                fileExtension = System.IO.Path.GetExtension(fuSignSheet.FileName).ToLower();
                String[] allowedExtensions = {".gif", ".png", ".jpg", ".jpeg", ".tiff"};
                foreach(string extension in allowedExtensions){
                    if (extension == fileExtension) {
                        extensionOK = true;
                    }
                }
            }

            if (extensionOK) {
                try {
                    fuSignSheet.PostedFile.SaveAs(path + filename + fileExtension);
                    modal("Upload Successful", "The file was uploaded successfully.");
                    signatureFunctions.Visible = true;
                    Session["FileName"] = filename + fileExtension;
                    updateSoS();
                } catch {
                    modal("Upload Failed", "The was a problem uploading\nyour file, please try again.");
                }
            } else {
                modal("Invalid File Type", "The file type you are trying to upload\nis not supported.");
            }
        }

        protected void modal(string title, string body) {
            this.Master.modal_header = title;
            this.Master.modal_body = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void imageModal(string title, string image) {
            lblModal_header.Text = title;
            literalImage.Text = string.Format("<img src=\"./signatures/{0}\" />", image);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "imageModal();", true);
        }

        protected void linkShowSoS_Click(object sender, EventArgs e) {
            int sosID = (int)Session["SOSID"];
            string fileName = SignOutSheet.getSOSbyID(sosID).imageFileName;
            imageModal("Sign Sheet", fileName);
        }

        protected void updateSoS() {
            int sosID = (int)Session["SOSID"];
            string editorID = (string)Session["user"];
            string fileName = (string)Session["FileName"];

            string dialog_header = "", dialog_body = "";

            if (SoSFunctions.UpdateSosHistory(sosID, editorID)) {
                if(SoSFunctions.UpdateSoSFileName(sosID, editorID, fileName)){
                    dialog_header = "SoS Modified";
                    dialog_body = string.Format("{0} has been modified successfully", sosID);
                } else {
                    //CODE TO REMOVE NEW SOSHISTORY RECORD
                    //ERROR DIALOG
                }
            } else {
                dialog_header = "Error: Modify Failed";
                dialog_body = "Unable to modify record. Please try again.";
            }
            
            modal(dialog_header, dialog_body);
        }

        protected void linkSendSignature_Click(object sender, EventArgs e) {
            Email myEmail = new Email();
            int sosID = (int)Session["SOSID"];
            DataSet myDS = new DataSet();
            DataSet myDS1 = new DataSet();
            myDS=myEmail.GetDataForEmail(sosID);

            string recipient = myDS.Tables[0].Rows[0][0].ToString();
            string emailAddress = myDS.Tables[0].Rows[0][1].ToString();
            string attachement="~/signatures/"+myDS.Tables[0].Rows[0][2].ToString();
            myDS1 = myEmail.GetEmailReciept();
            string body=myDS1.Tables[0].Rows[0][0].ToString();
            string subject=myDS1.Tables[0].Rows[0][1].ToString();
            
            myEmail.sendEmail("ryanmarks62@yahoo.com", emailAddress,subject,body,attachement);
            
        }
    }
}