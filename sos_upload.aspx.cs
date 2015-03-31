using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace CD6 {
    public partial class sos_upload : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            int sosID = (int)Session["sosID"];
            //int sosID = 3081;
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

        }

        protected void btnUpload_Click(object sender, EventArgs e) {
            uploadFile(txtRecipient.Text, "3081", calIssueDate.SelectedDate.ToShortDateString().Replace("/","-"));
        }

        protected void uploadFile(string recipientName, string sosID, string issueDate) {
            bool extensionOK = false;
            string path = Server.MapPath("~/signatures/");
            string filename = string.Format("{0}_{1}_{2}", issueDate, recipientName, sosID);
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
                } catch(Exception ex) {
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
    }
}