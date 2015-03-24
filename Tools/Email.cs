using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace Tools
{
   public class Email
    {
        

        public  String sendEmail(string from,string to, string subject,string body )
        {
           
            MailMessage mailMessage = new MailMessage();
            MailAddress fromAddress = new MailAddress("ryanmarks62@yahoo.com");

            SmtpClient smtpClient = new SmtpClient("smtp.mail.yahoo.com",587);
            smtpClient.UseDefaultCredentials=false;
            smtpClient.Credentials = new System.Net.NetworkCredential("ryanmarks62@yahoo.com", "Atownyea1");
            smtpClient.EnableSsl = true;
            
            mailMessage.To.Add(to);
            mailMessage.From = fromAddress;
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = false;
            
            smtpClient.Send(mailMessage);
            return "Email Sent";
        }
    }
}
