using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Configuration;

namespace CD6 {
    public class Global : System.Web.HttpApplication {
        public static string LDAP_Server = WebConfigurationManager.AppSettings.Get("LDAP_Server");
        public static string LDAP_Domain = WebConfigurationManager.AppSettings.Get("LDAP_Domain");
        public static string SMTP_Server = WebConfigurationManager.AppSettings.Get("SMTP_Server");
        public static int SMTP_Port = int.Parse(WebConfigurationManager.AppSettings.Get("SMTP_Port"));
        public static string Connection_String = WebConfigurationManager.AppSettings.Get("ConnectionString");
        public static string Email_from = WebConfigurationManager.AppSettings.Get("EMAIL_From");

        protected void Application_Start(object sender, EventArgs e) { }

        protected void Session_Start(object sender, EventArgs e) { }

        protected void Application_BeginRequest(object sender, EventArgs e) { }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) { }

        protected void Application_Error(object sender, EventArgs e) { }

        protected void Session_End(object sender, EventArgs e) { }

        protected void Application_End(object sender, EventArgs e) { }
    }
}