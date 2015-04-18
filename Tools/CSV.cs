using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Utilities;
using System.Text;
using System.IO;

namespace Tools
{
    public class CSV
    {
        public string ConvertGridviewToCSV(GridView theGridview)
        {
            string result=" ";
            StreamWriter mySw = new StreamWriter("c:\\gridview.csv");
            for (int x = 0; x < theGridview.Columns.Count; x++)
            {
                mySw.Write(theGridview.Columns[int].HeaderText);
                if(x!=theGridview.Columns.Count)
                {
                    mySw.Write(",");
                }
            }

            foreach(GridViewRow row in theGridview.Rows)
            {
                for(int y=0;y<theGridview.Columns.Count;y++)
                {
                mySw.Write(row.Cells[int].Text);
                if(y !=theGridview.Columns.Count)
                {
                    mySw.Write(",");
                }
        }
                mySw.Write(mySw.NewLine);
    }
            mySw.Flush();
            mySw.Close();
            return result;
        }
    }
}
