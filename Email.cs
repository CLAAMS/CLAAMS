using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Data;
using Utilities;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Net.Mime;
using System.IO;
using System.Web;

namespace CD6 {
   public class Email {
       DataSet myDs = new DataSet();
       string sqlConnection = Global.Connection_String;
       DBConnect myDbConnect = new DBConnect(Global.Connection_String);
       
       public String sendEmail(string from,string to, string subject,string body,string fileName) {
           
           fileName = HttpContext.Current.Server.MapPath(fileName);
           MailMessage mailMessage = new MailMessage();
           MailAddress fromAddress = new MailAddress(Global.Email_from);

           SmtpClient smtpClient = new SmtpClient(Global.SMTP_Server, Global.SMTP_Port);
           smtpClient.UseDefaultCredentials=false;
    
           smtpClient.EnableSsl = true;
          
           mailMessage.To.Add(to);
           mailMessage.From = fromAddress;
           mailMessage.Subject = subject;
           mailMessage.Body = body;
           mailMessage.IsBodyHtml = true;

           try{
               Attachment myAttachement = new Attachment(fileName, MediaTypeNames.Image.Jpeg);
               ContentDisposition disposition = myAttachement.ContentDisposition;
               disposition.CreationDate = File.GetCreationTime(fileName);
               disposition.ModificationDate = File.GetLastWriteTime(fileName);
               disposition.ReadDate = File.GetLastAccessTime(fileName);
               disposition.FileName = Path.GetFileName(fileName);
               disposition.Size = new FileInfo(fileName).Length;
               disposition.DispositionType = DispositionTypeNames.Attachment;
               mailMessage.Attachments.Add(myAttachement);

               smtpClient.Send(mailMessage);
               return "Email Sent";
           } catch {
               return "Email Failed";
           }
        }

        public String sendEmail(string from, string to, string subject, string body) {
        MailMessage mailMessage = new MailMessage();
            MailAddress fromAddress = new MailAddress(Global.Email_from);

            SmtpClient smtpClient = new SmtpClient(Global.SMTP_Server, Global.SMTP_Port);
            smtpClient.UseDefaultCredentials = false;
          
            smtpClient.EnableSsl = true;

            mailMessage.To.Add(to);
            mailMessage.From = fromAddress;
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            smtpClient.Send(mailMessage);
            return "Email Sent";
        }

        public DataSet GetDataForEmail(int sosID) {
            SqlConnection myConnection = new SqlConnection(sqlConnection);
            myConnection.Open();
            SqlCommand myCommand1 = new SqlCommand();
            myCommand1.Connection = myConnection;
            myCommand1.CommandType = CommandType.StoredProcedure;
            myCommand1.CommandText = "GetDataForEmail";

            SqlParameter myParameter1 = new SqlParameter("@sosID", sosID);
            myParameter1.Direction = ParameterDirection.Input;
            myParameter1.SqlDbType = SqlDbType.Int;
            myParameter1.Size = 50;
            myCommand1.Parameters.Add(myParameter1);

            myDs = myDbConnect.GetDataSetUsingCmdObj(myCommand1);
            myConnection.Close();
            return myDs;
        }

        public DataSet GetEmailReciept() {
            SqlConnection myConnection = new SqlConnection(sqlConnection);
            myConnection.Open();
            SqlCommand myCommand1 = new SqlCommand();
            myCommand1.Connection = myConnection;
            myCommand1.CommandType = CommandType.StoredProcedure;
            myCommand1.CommandText = "SelectEmailData";

            myDs = myDbConnect.GetDataSetUsingCmdObj(myCommand1);
            myConnection.Close();
            return myDs;
        }

        public int UpdateEmailBody(string body) {
            SqlConnection myConnection = new SqlConnection(sqlConnection);
            myConnection.Open();
            SqlCommand myCommand2 = new SqlCommand();
            myCommand2.Connection = myConnection;
            myCommand2.CommandType = CommandType.StoredProcedure;
            myCommand2.CommandText = "UpdateEmailBody";

            SqlParameter myParameter2 = new SqlParameter("@emailBody",body);
            myParameter2.Direction = ParameterDirection.Input;
            myParameter2.SqlDbType = SqlDbType.VarChar;
            myParameter2.Size = 1000;
            myCommand2.Parameters.Add(myParameter2);

            try {
                myCommand2.ExecuteNonQuery();
                return 1;
            } catch {
                return -1;
            }
        }
     
    }
}
