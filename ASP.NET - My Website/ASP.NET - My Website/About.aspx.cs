using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET___My_Website
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            TableRow tRow = new TableRow();

            TableCell tCell1 = new TableCell();
            tCell1.Text = "test cell 1";
            tRow.Cells.Add(tCell1);

            TableCell tCell2 = new TableCell();
            tCell2.Text = "test cell 2";
            tRow.Cells.Add(tCell2);

            TableCell tCell3 = new TableCell();
            tCell3.Text = "test cell 3";
            tRow.Cells.Add(tCell3);

            
            Table1.Rows.Add(tRow);
            Table1.Rows[0].Cells[0].BackColor = System.Drawing.Color.Red;
        }
    }
}