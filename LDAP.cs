using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.DirectoryServices;

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
    }
}