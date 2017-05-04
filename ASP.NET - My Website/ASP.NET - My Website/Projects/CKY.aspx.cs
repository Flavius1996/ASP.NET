using ASP.NET___My_Website.Projects.CKY_nlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace ASP.NET___My_Website.Projects
{
    public partial class CKY : System.Web.UI.Page
    {
        // btnMain State:
            //  0: Start
            //  1: Skip to Final
            //  2: Reset
        private int btnMain_State = 0;

        // Color Choose
        private static System.Drawing.Color DefaultCellColor = System.Drawing.Color.White;
        private static System.Drawing.Color HeaderCellColor = System.Drawing.Color.WhiteSmoke;
        private static System.Drawing.Color CurCellColor = System.Drawing.Color.CadetBlue;
        private static System.Drawing.Color WriteCellColor = System.Drawing.Color.LightGreen;
        private static System.Drawing.Color UsedRuleColor = System.Drawing.Color.LightGreen;

        // fSkip
        private bool fSkip = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["FirstTime"] == null)
                {
                    Session["btnMain_State"] = btnMain_State;
                    Session["fSkip"] = false;
                    Session["FirstTime"] = false;
                }
            }

            this.BindGrid();
        }

        private void BindGrid()
        {
            CKY_Grid.DataSource = CKY_Global.CKY_GRID_DATATABLE;
            CKY_Grid.DataBind();
            CNF_Grid.DataSource = CKY_Global.CNF_GRID_DATATABLE;
            CNF_Grid.DataBind();
        }
        protected void Grid_DataBound(object sender, EventArgs e)
        {
            if (CKY_Grid.Rows.Count == 0)
                return;

            // Hide Header Row
            if (CNF_Grid.HeaderRow != null)
                CNF_Grid.HeaderRow.Visible = false;
            CKY_Grid.HeaderRow.Visible = false;
            // Style CKY_Table
            for (int i = 0; i < CKY_Global.N_Word + 1; i++)
            {
                for (int j = 0; j < CKY_Global.N_Word + 1; j++)
                {
                    // Align Center
                    CKY_Grid.Rows[i].Cells[j].HorizontalAlign = HorizontalAlign.Center;
                    CKY_Grid.Rows[i].Cells[j].VerticalAlign = VerticalAlign.Middle;

                    if (i == 0)
                        CKY_Grid.Rows[i].Cells[j].BackColor = HeaderCellColor;
                    // First Vertical row
                    if (i > 0 && j == 0)
                        CKY_Grid.Rows[i].Cells[j].BackColor = HeaderCellColor;
                }
            }
        }
        protected void Display_CNF_Table(List<CNF_Rule> Rules)
        {
            CKY_Global.CNF_GRID_DATATABLE.Columns.Add();
            foreach (CNF_Rule r in Rules)
            {

                String s;
                if (r.Left == null || r.Right[0] == null)
                    s = String.Format("&nbsp&nbsp<strong>{0}.</strong>&nbsp&nbsp&nbsp&nbspWrong format", r.ID, r.Left, r.Right[0]);
                else
                if (r.fTerminal == true)
                {
                    s = String.Format("&nbsp&nbsp<strong>{0}.</strong>&nbsp&nbsp&nbsp&nbsp{1:2}&nbsp&nbsp&nbsp&nbsp→&nbsp&nbsp&nbsp&nbsp{2:2}", r.ID, r.Left, r.Right[0]);
                }
                else
                {
                    s = String.Format("&nbsp&nbsp<strong>{0}.</strong>&nbsp&nbsp&nbsp&nbsp{1:2}&nbsp&nbsp&nbsp&nbsp→&nbsp&nbsp&nbsp&nbsp{2:2}&nbsp&nbsp&nbsp&nbsp{3:2}", r.ID, r.Left, r.Right[0], r.Right[1]);
                }

                //TableRow tRow = new TableRow();
                //TableCell tCell = new TableCell();
                //tCell.Text = s;
                //tRow.Cells.Add(tCell);

                CKY_Global.CNF_GRID_DATATABLE.Rows.Add(s);
                //CNF_Table.Rows.Add(tRow);
            }

            BoundField bfield = new BoundField();
            bfield.HeaderText = CKY_Global.CNF_GRID_DATATABLE.Columns[0].ColumnName;
            bfield.DataField = CKY_Global.CNF_GRID_DATATABLE.Columns[0].ColumnName;
            bfield.HtmlEncode = false;
            CNF_Grid.Columns.Add(bfield);

        }
        protected void Display_CKY_Table(string[] words)
        {
            CKY_Global.N_Word = words.Length;
            string s;
            int i, j;

            for (i = 0; i < CKY_Global.N_Word + 1; i++)
            {
                CKY_Global.CKY_GRID_DATATABLE.Rows.Add();
                CKY_Global.CKY_GRID_DATATABLE.Columns.Add();
            }

            // Create N+1 x N+1 table
            for (i = 0; i < CKY_Global.N_Word + 1; i++)
            {
                //DataRow TempRow2 = new DataRow();
                TableRow TempRow = new TableRow();
                for (j = 0; j < CKY_Global.N_Word + 1; j++)
                {
                    TableCell TempCell = new TableCell();
                    // Header row
                    if (i == 0 && j > 0)
                    {
                        s = String.Format("<strong>{0}</strong><br />{1}", j, words[j - 1]);
                        CKY_Global.CKY_GRID_DATATABLE.Rows[i].SetField(j, s);
                    }
                    // (0, 0) cell
                    if (i == 0 && j == 0)
                    {
                        s = "<strong>0</strong>";
                        CKY_Global.CKY_GRID_DATATABLE.Rows[i].SetField(j, s);
                    }
                    // First Vertical row
                    if (i > 0 && j == 0)
                    {
                        s = String.Format("<strong>{0}</strong>", i - 1);
                        CKY_Global.CKY_GRID_DATATABLE.Rows[i].SetField(j, s);
                    }

                    // Other Cells
                    if (i > 0 && j > 0)
                    {
                        s = "";
                        CKY_Global.CKY_GRID_DATATABLE.Rows[i].SetField(j, s);
                    }
                }
            }

            for (int k = 0; k < CKY_Global.N_Word + 1; k++)
            {
                BoundField bfield = new BoundField();
                bfield.HeaderText = CKY_Global.CKY_GRID_DATATABLE.Columns[k].ColumnName;
                bfield.DataField = CKY_Global.CKY_GRID_DATATABLE.Columns[k].ColumnName;
                bfield.HtmlEncode = false;
                CKY_Grid.Columns.Add(bfield);
            }
            this.BindGrid();

            // Create CKY_Global.CKY_TABLECELLS for processing Algorithm and Tracing
            CKY_Global.CKY_TABLECELLS = new CKY_TableCell[CKY_Global.N_Word + 1, CKY_Global.N_Word + 1];
            for (i = 0; i < CKY_Global.N_Word + 1; i++)
                for (j = 0; j < CKY_Global.N_Word + 1; j++)
                    CKY_Global.CKY_TABLECELLS[i, j] = new CKY_TableCell();
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

            string[] words = sentence.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Count() == 0)
            {
                var msg = "<strong>Warning!</strong> The Sentence is empty.";

                ScriptManager.RegisterStartupScript(MainUpdatePanel, MainUpdatePanel.GetType(), "alert", "ShowWarningAlert('" + msg + "')", true);
                return false;
            }

            List<string> Outlier_words = new List<string>();
            // Check if error not have word in Global CNF WORDS
            foreach (string w in words)
                if (CKY_Global.WORDS.IndexOf(w) == -1)
                    Outlier_words.Add(w);
                else
                    CKY_Global.SENTENCE_WORDS.Add(w);
            if (Outlier_words.Count() > 0)
            {
                var str_words = String.Join(", ", Outlier_words.ToArray());

                var msg = String.Format("<strong>Warning!</strong> Words:<strong>{0}</strong> in the Sentence are not in CNF-Terminal words.", str_words);

                ScriptManager.RegisterStartupScript(MainUpdatePanel, MainUpdatePanel.GetType(), "alert", "ShowWarningAlert('" + msg + "')", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowWarningAlert('" + msg + "')", true);
                return false;
            }
            Display_CKY_Table(words);

            return true;
        }

        protected void RestoreColor(int cell_i, int cell_j, int cell_k, int rule_id)
        {
            this.BindGrid();
            // All If-condition at this function is use for the case only change color of (cell_i, cell_k)
            //      On this case we use: RestoreColor(i, -1, k, -1)
            if (cell_j != -1)
            {
                this.CKY_Grid.Rows[cell_i].Cells[cell_j].BackColor = DefaultCellColor;
                this.CKY_Grid.Rows[cell_j].Cells[cell_k].BackColor = DefaultCellColor;
            }

            this.CKY_Grid.Rows[cell_i].Cells[cell_k].BackColor = DefaultCellColor;

            if (rule_id != -1 && rule_id < CKY_Global.CNF_RULES.Count())
                this.CNF_Grid.Rows[rule_id].Cells[0].BackColor = DefaultCellColor;
        }
        protected void ChangeColor(int cell_i, int cell_j, int cell_k, int rule_id)
        {
            this.BindGrid();
            // All If-condition at this function is use for the case only change color of (cell_i, cell_k)
            //      On this case we use: ChangeColor(i, -1, k, -1)

            if (cell_j != -1)
            {
                this.CKY_Grid.Rows[cell_i].Cells[cell_j].BackColor = CurCellColor;
                this.CKY_Grid.Rows[cell_j].Cells[cell_k].BackColor = CurCellColor;
            }
            this.CKY_Grid.Rows[cell_i].Cells[cell_k].BackColor = WriteCellColor;
            if (rule_id < CKY_Global.CNF_RULES.Count())
                this.CNF_Grid.Rows[rule_id].Cells[0].BackColor = UsedRuleColor;
        }
        protected void SetDataTable(int i, int j, string temp)
        {
            CKY_Global.CKY_GRID_DATATABLE.Rows[i].SetField(j, temp);
        }
        protected void Next(bool fskip = false)
        {
            // First cell
            if (CKY_Global.i == 0 && CKY_Global.j == 0 && CKY_Global.k == 0)    
            {
                CKY_Global.k = 1;
                CKY_Global.i = 1;
                CKY_Global.j = 1;
                string word = CKY_Global.SENTENCE_WORDS[CKY_Global.k - 1];
                int id_rule;
                CKY_Global.CKY_TABLECELLS[1, 1].Tag = CKY_TableCell.GetTagofWord(word, out id_rule);
                CKY_Global.CKY_TABLECELLS[1, 1].fTerminal = true;

                string s = String.Format("<strong>{0}</strong>", CKY_Global.CKY_TABLECELLS[1, 1].Tag);
                SetDataTable(CKY_Global.i, CKY_Global.k, s);

                ChangeColor(1, -1, 1, id_rule - 1);

                return;
            }

            int i = CKY_Global.i;
            int j = CKY_Global.j + 1;       // Get next j
            int k = CKY_Global.k;
            // TableCell (i, k) = (i, j) + (j, k)  
            CKY_TableCell CurTC;
            CKY_TableCell OppositeTC;
            int check;

            // End of k => Next k
            if (i <= 1 && j >= k)
            {
                CKY_Global.k += 1;
                CKY_Global.i = CKY_Global.k;
                CKY_Global.j = CKY_Global.k - 1;
                string word = CKY_Global.SENTENCE_WORDS[CKY_Global.k - 1];
                int id_rule;
                CKY_Global.CKY_TABLECELLS[CKY_Global.i, CKY_Global.k].Tag = CKY_TableCell.GetTagofWord(word, out id_rule);

                string s = String.Format("<strong>{0}</strong>", CKY_Global.CKY_TABLECELLS[CKY_Global.i, CKY_Global.k].Tag);
                SetDataTable(CKY_Global.i, CKY_Global.k, s);

                ChangeColor(CKY_Global.i, -1, CKY_Global.k, id_rule - 1);

                if (fskip == false)
                    return;
            }
            for (int x = i; x > 0; x--)
            {
                for (int y = j; j < k; j++)
                {
                    CurTC = CKY_Global.CKY_TABLECELLS[x, y];
                    OppositeTC = CKY_Global.CKY_TABLECELLS[y, k];
                    check = CKY_TableCell.CheckMerge(CurTC, OppositeTC);
                    if (check == -1)
                        continue;
                    else
                    {
                        CKY_Global.CKY_TABLECELLS[x, k].Set(CKY_Global.CNF_RULES[check].Left, false, x, y, y, k);

                        ChangeColor(x, y, k, check);
                        string s = String.Format("<strong>{0}</strong><br />({1}, {2})<br />({3}, {4})", CKY_Global.CKY_TABLECELLS[x, k].Tag, x, y, y, k);
                        SetDataTable(x, k, s);

                        if (fskip == false)
                        {
                            CKY_Global.i = x;
                            CKY_Global.j = y;
                            CKY_Global.k = k;
                            return;
                        }
                        else
                        {
                            RestoreColor(x, y, k, check);
                        }
                    }
                }
            }

            //if (fskip == true)
            //    Next(fskip);

        }
        protected void Reset()
        {
            CKY_Global.CNF_RULES.Clear();
            CKY_Global.WORDS.Clear();
            CKY_Global.SENTENCE_WORDS.Clear();
            CKY_Global.i = 0;
            CKY_Global.j = 0;
            CKY_Global.k = 0;
            CKY_Global.CKY_TABLECELLS = new CKY_TableCell[1,1];
            //this.Sentence_Text.Value = "";
            CKY_Global.CKY_GRID_DATATABLE = new DataTable();
        }
        protected void btnMain_Click(object sender, EventArgs e)
        {
            switch ((int) Session["btnMain_State"])
            {
                case 0:     // Start
                    {
                        // Reset before Start
                        Reset();

                        bool check = Start();
                        if (check == true)
                        {
                            Next();             // Run Next() for first cell
                            Session["btnMain_State"] = 1;
                            this.btnMain.Text = "Skip to Final";

                            // Enable Next button
                            this.btnNext.Enabled = true;

                            
                        }
                        break;
                    }
                case 1:     // Skip to Final
                    {
                        fSkip = true;
                        Next(fSkip);
                        fSkip = false;
                        Session["btnMain_State"] = 2;
                        Session["fSkip"] = true;
                        this.btnMain.Text = "Reset";
                        break;
                    }
                case 2:     // Skip to Final
                    {
                        Reset();
                        break;
                    }
            }
 
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            //CKY_Table.Rows.Add
            //CKY_Grid.Rows.Add
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            fSkip = (bool) Session["fSkip"];
            Next(fSkip);
        }

        protected void btnDefaulCNF_Click(object sender, EventArgs e)
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"./CKY_nlp/Data/CNF_Rules.txt"));
            CNF_Text.Value = fileContents;
        }


    }
}