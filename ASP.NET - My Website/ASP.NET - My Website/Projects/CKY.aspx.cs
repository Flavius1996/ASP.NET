using ASP.NET___My_Website.Projects.CKY_nlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET___My_Website.Projects
{
    public partial class CKY : System.Web.UI.Page
    {
        // btnMain State:
            //  0: Start
            //  1: Skip to Final
            //  2: Reset

        private int btnMain_State = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideAllAlerts()", true);
            }

            btnMain.OnClientClick = "window.scrollTo = function(x,y) { return true; };";
        }
        protected void Display_CNF_Table(List<CNF_Rule> Rules)
        {
            foreach (CNF_Rule r in Rules)
            {
                String s;
                if (r.Left == null || r.Right[0] == null)
                    s = String.Format("<strong>{0}.</strong>&nbsp&nbsp&nbsp&nbspWrong format", r.ID, r.Left, r.Right[0]);
                else
                if (r.fTerminal == true)
                {
                    s = String.Format("<strong>{0}.</strong>&nbsp&nbsp&nbsp&nbsp{1:2}&nbsp&nbsp&nbsp&nbsp→&nbsp&nbsp&nbsp&nbsp{2:2}", r.ID, r.Left, r.Right[0]);
                }
                else
                {
                    s = String.Format("<strong>{0}.</strong>&nbsp&nbsp&nbsp&nbsp{1:2}&nbsp&nbsp&nbsp&nbsp→&nbsp&nbsp&nbsp&nbsp{2:2}&nbsp&nbsp&nbsp&nbsp{3:2}", r.ID, r.Left, r.Right[0], r.Right[1]);
                }

                TableRow tRow = new TableRow();
                TableCell tCell = new TableCell();
                tCell.Text = s;
                tRow.Cells.Add(tCell);


                CNF_Table.Rows.Add(tRow);
                //CNF_Table.Rows[0].Cells[0].BackColor = System.Drawing.Color.Red;
            }
        }
        protected void Display_CKY_Table(string[] words)
        {

        }
        protected bool Start()
        {
            string CNF_text = CNF_Text.Value;
            string sentence = Sentence_Text.Value;

            string[] lines = CNF_text.Split(new string[] { "\n" }, StringSplitOptions.None);

            //string[] lines = CNF_text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i <lines.Length; i++)
            {
                CNF_Rule rule = new CNF_Rule(i + 1, lines[i]);
                CKY_Global.CNF_RULES.Add(rule);
            }

            Display_CNF_Table(CKY_Global.CNF_RULES);

            string[] words = sentence.Split(new char[] { ' ', ',', '.' });
            // Check if error not have word in Global CNF WORDS
            foreach (string w in words)
            {
                if (CKY_Global.WORDS.IndexOf(w) == -1)
                {
                    var msg = "<strong>Warning!</strong> Some words in Sentence are not in CNF Rules.";
                    ScriptManager.RegisterStartupScript(MainUpdatePanel, MainUpdatePanel.GetType(), "alert", "ShowWarningAlert('" + msg + "')", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowWarningAlert('" + msg + "')", true);
                    return false;
                }
            }

            Display_CKY_Table(words);

            return true;
        }
        protected void Reset()
        {
            CKY_Global.CNF_RULES.Clear();
            CKY_Global.WORDS.Clear();
            //this.Sentence_Text.Value = "";
            this.CKY_Table.Rows.Clear();
        }
        protected void btnMain_Click(object sender, EventArgs e)
        {
            switch (btnMain_State)
            {
                case 0:     // Start
                    {
                        // Reset before Start
                        Reset();

                        bool check = Start();
                        if (check == true)
                        {
                            btnMain_State = 2;
                            this.btnMain.Text = "Skip to Final";
                        }
                        break;
                    }
                case 1:     // Skip to Final
                    {

                        break;
                    }
                case 2:     // Skip to Final
                    {
                        Reset();
                        break;
                    }
            }
            //TableRow tRow = new TableRow();
            //TableCell tCell1 = new TableCell();
            //tCell1.Text = "test cell 1";
            //tRow.Cells.Add(tCell1);

            //TableCell tCell2 = new TableCell();
            //tCell2.Text = "test cell 2";
            //tRow.Cells.Add(tCell2);

            //TableCell tCell3 = new TableCell();
            //tCell3.Text = "test cell 3";
            //tRow.Cells.Add(tCell3);

            //Table1.Rows.Add(tRow);
            //Table1.Rows[0].Cells[0].BackColor = System.Drawing.Color.Red;
        }

        protected void btnHelloWorld_Click(object sender, EventArgs e)
        {
            lblHelloWorld.Text = "Hello, world - this is a fresh message from ASP.NET AJAX! The time right now is: " + DateTime.Now.ToLongTimeString();
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            var msg = "<strong>OK!</strong> Successful Reading Data";
            ScriptManager.RegisterStartupScript(MainUpdatePanel, MainUpdatePanel.GetType(), "alert", "ShowSuccessAlert('" + msg + "')", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowSuccessAlert('" + msg + "')", true);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            var msg = "<strong>Fail!</strong> Error Reading Data";
            //ScriptManager.RegisterStartupScript(MainUpdatePanel, MainUpdatePanel.GetType(), "alert", "ShowDangerAlert('" + msg + "')", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowDangerAlert('" + msg + "')", true);
        }

        protected void btnDefaulCNF_Click(object sender, EventArgs e)
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"./CKY_nlp/Data/CNF_Rules.txt"));
            CNF_Text.Value = fileContents;
        }
    }
}