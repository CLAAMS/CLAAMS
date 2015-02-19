using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.DirectoryServices;
using System.Collections.Generic;

namespace CD6{
    public class LDAP{
        public static string AuthenticateUser(string accessNetID, string password){
            string strID = string.Empty;
            DirectoryEntry entry = new DirectoryEntry();

            try{
                // call getDNFRromLDAP method to anonymously (port 389)
                // search against ldap for the correct DN
                string strDN = getDNFromLDAP(accessNetID);

                //now use the found DN for the secure bind (port 636)
                entry.Path = "LDAP://rock.temple.edu/" + strDN;
                entry.Username = strDN;
                entry.Password = password;
                entry.AuthenticationType = AuthenticationTypes.SecureSocketsLayer;

                //try to fetch a property..if no errors raised then it works
                strID = entry.Properties["sAMAccountName"][0].ToString();


            }catch{
            }finally{
                entry.Close();
                entry.Dispose();
            }

            return strID;
        }

        public static string getDNFromLDAP(string strUID){
            DirectoryEntry entry = new DirectoryEntry("LDAP://rock.temple.edu/ou=temple,dc=tu,dc=temple,dc=edu");
            entry.AuthenticationType = AuthenticationTypes.None;
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            entry.Close();
            entry.Dispose();
            mySearcher.Filter = "(sAMAccountName=" + strUID + ")";
            SearchResult result = mySearcher.FindOne();
            mySearcher.Dispose();
            int nIndex = result.Path.LastIndexOf("/");
            string strDN = result.Path.Substring((nIndex + 1)).ToString().TrimEnd();
            return strDN;
        }

        public static Dictionary<string, string> getUserInfo(string accessNetID) {
            DirectoryEntry entry = new DirectoryEntry("LDAP://rock.temple.edu/ou=temple,dc=tu,dc=temple,dc=edu");
            entry.AuthenticationType = AuthenticationTypes.None;
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            entry.Close();
            entry.Dispose();
            mySearcher.Filter = "(sAMAccountName=" + accessNetID + ")";
            SearchResult result = mySearcher.FindOne();
            mySearcher.Dispose();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("givenName", result.Properties["givenName"][0].ToString());
            dict.Add("surName", result.Properties["sn"][0].ToString());
            dict.Add("email", result.Properties["mail"][0].ToString());
            dict.Add("department", result.Properties["department"][0].ToString());
            dict.Add("TUID", result.Properties["employeeID"][0].ToString());
            dict.Add("AccessNet", result.Properties["sAMAccountName"][0].ToString());
            try{
                dict.Add("address", result.Properties["streetAddress"][0].ToString());
                dict.Add("campus", result.Properties["templeEduCampus"][0].ToString());
                dict.Add("department2", result.Properties["templeEduDepartment"][0].ToString());
            }catch{}
            return dict;
        }
    }
}