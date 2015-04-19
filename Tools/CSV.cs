using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;
using System.Data;
using System.Text;
using System.IO;

namespace Tools {
    public class CSV {
        public string ConvertGridviewToCSV(GridView theGridview) {
            string result=" ";
            StreamWriter mySw = new StreamWriter("c:\\gridview.csv");
            for (int x = 0; x < theGridview.Columns.Count; x++) {
                mySw.Write(theGridview.Columns[x].HeaderText);
                if(x!=theGridview.Columns.Count) {
                    mySw.Write(",");
                }
            }

            foreach(GridViewRow row in theGridview.Rows) {
                for(int y=0;y<theGridview.Columns.Count;y++) {
                    mySw.Write(row.Cells[y].Text);
                    if(y !=theGridview.Columns.Count) {
                        mySw.Write(",");
                    }
                }
                    mySw.Write(mySw.NewLine);
            }

            mySw.Flush();
            mySw.Close();
            return result;
        }

        public static string gvToCsv(GridView gv) {
            string result = "";

            // Write the header row
            for (int i = 0; i < gv.Columns.Count; i++) {
                result += gv.Columns[i].HeaderText;
                if(i != gv.Columns.Count) {
                    result += ";";
                }
            }
            result += "\n";

            // Write each row
            foreach (GridViewRow row in gv.Rows) {
                for (int i = 0; i < gv.Columns.Count; i++) {
                    result += row.Cells[i].Text;
                    if (i != gv.Columns.Count) {
                        result += ";";
                    }
                }
                result += "\n";
            }
            return result;
        }
    }
}
