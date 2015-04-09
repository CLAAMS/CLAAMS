using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace CD6
{
    public class AssetHistory
    {
        public int assetID { get; set; }
        public String CLATag { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public String Description { get; set; }
        public String SerialNumber { get; set; }
        public String Status { get; set; }
        public String Notes { get; set; }
        public DateTime recordCreated { get; set; }
        public DateTime recordModified { get; set; }
        public int assetHistoryID { get; set; }
        public DateTime ChangeTimeStamp { get; set; }
        public int sosID { get; set; }
        public String editorID { get; set; }
    }
}