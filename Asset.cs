using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using Utilities;
using System.Data.SqlClient;


namespace CD6
{
    public class Asset
    {
  
            public int assetID { get; set; }
            //public int assetHisotryId { get; set; }
            public string CLATag { get; set; }
            public string Make { get; set; }
            public string Name { get; set; }
            public string Model { get; set; }
            public string Description { get; set; }
            public string SerialNumber { get; set; }
            public string Status { get; set; }
            public string Notes { get; set; }
            public DateTime recordModified { get; set; }
            public DateTime recordCreated { get; set; }

            
        
    }
}