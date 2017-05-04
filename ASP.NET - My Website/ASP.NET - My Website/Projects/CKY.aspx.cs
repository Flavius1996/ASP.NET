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
        //private int btnMain_State = 0;

        // Color Choose
        private static System.Drawing.Color DefaultCellColor = System.Drawing.Color.White;
        private static System.Drawing.Color HeaderCellColor = System.Drawing.Color.WhiteSmoke;
        private static System.Drawing.Color CurCellColor = System.Drawing.Color.LightBlue;
        private static System.Drawing.Color WriteCellColor = System.Drawing.Color.LightGreen;
        private static System.Drawing.Color UsedRuleColor = System.Drawing.Color.LightGreen;
        public int CKY_i
        {
            get
            {
                return (int) ViewState["i"];
            }
            set
            {
                ViewState["i"] = value;
            }
        }
        public int CKY_j
        {
            get
            {
                return (int) ViewState["j"];
            }
            set
            {
                ViewState["j"] = value;
            }
        }
        public int CKY_k
        {
            get
            {
                return (int) ViewState["k"];
            }
            set
            {
                ViewState["k"] = value;
            }
        }
        public List<string> WORDS
        {
            get
            {
                return (List<string>)Session["WORDS"];
            }
            set
            {
                Session["WORDS"] = value;
            }
        }
        public List<string> SENTENCE_WORDS
        {
            get
            {
                return (List<string>)Session["SENTENCE_WORDS"];
            }
            set
            {
                Session["SENTENCE_WORDS"] = value;
            }
        }
        public List<CNF_Rule> CNF_RULES
        {
            get
            {
                return (List<CNF_Rule>)Session["CNF_RULES"];
            }
            set
            {
                Session["CNF_RULES"] = value;
            }
        }
        public int N_Word
        {
            get
            {
                return (int) ViewState["N_WORDS"];
            }
            set
            {
                ViewState["N_WORDS"] = value;
            }
        }
        public CKY_TableCell[,] CKY_TABLECELLS
        {
            get
            {
                return (CKY_TableCell[,]) Session["CKY_TABLECELLS"];
            }
            set
            {
                Session["CKY_TABLECELLS"] = value;
            }
        }
        public DataTable CKY_DATATABLE
        {
            get
            {
                return (DataTable)Session["CKY_DATATABLE"];
            }
            set
            {
                Session["CKY_DATATABLE"] = value;
            }
        }
        public DataTable CNF_DATATABLE
        {
            get
            {
                return (DataTable)Session["CNF_DATATABLE"];
            }
            set
            {
                Session["CNF_DATATABLE"] = value;
            }
        }
        public string btnMain_State
        {
            get
            {
                return (string)ViewState["btnMain_State"];
            }
            set
            {
                ViewState["btnMain_State"] = value;
            }
        }
        public bool FinalCell       // Touch FinalCell  => Break Next()
        {
            get
            {
                return (bool) ViewState["FinalCell"];
            }
            set
            {
                ViewState["FinalCell"] = value;
            }
        }
        public List<ProcessChain> PROCESSCHAIN       // Touch FirstCell  => Break Prev()
        {
            get
            {
                return (List<ProcessChain>) Session["PROCESSCHAIN"];
            }
            set
            {
                Session["PROCESSCHAIN"] = value;
            }
        }

        // fSkip
        //private bool fSkip = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Reset();
            }

            this.BindGrid();
        }

        private void BindGrid()
        {
            CKY_Grid.DataSource = CKY_DATATABLE;
            CKY_Grid.DataBind();
            CNF_Grid.DataSource = CNF_DATATABLE;
            CNF_Grid.DataBind();

            // Hide Header Row
            if (CNF_Grid.Rows.Count != 0)
                CNF_Grid.HeaderRow.Visible = false;

        }
        protected void Grid_DataBound(object sender, EventArgs e)
        {
            if (CKY_Grid.Rows.Count == 0)
                return;
            CKY_Grid.HeaderRow.Visible = false;
            // Style CKY_Table
            for (int i = 0; i < N_Word + 1; i++)
            {
                for (int j = 0; j < N_Word + 1; j++)
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
            DataTable CNF_GRID_DATATABLE = new DataTable();
            CNF_GRID_DATATABLE.Columns.Add();
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

                CNF_GRID_DATATABLE.Rows.Add(s);
                //CNF_Table.Rows.Add(tRow);
            }

            BoundField bfield = new BoundField();
            bfield.HeaderText = CNF_GRID_DATATABLE.Columns[0].ColumnName;
            bfield.DataField = CNF_GRID_DATATABLE.Columns[0].ColumnName;
            bfield.HtmlEncode = false;
            CNF_Grid.Columns.Add(bfield);

            CNF_DATATABLE = CNF_GRID_DATATABLE;
        }
        protected void Display_CKY_Table(string[] words)
        {
            DataTable CKY_GRID_DATATABLE = new DataTable();
            N_Word = words.Length;

            string s;
            int i, j;

            for (i = 0; i < N_Word + 1; i++)
            {
                CKY_GRID_DATATABLE.Rows.Add();
                CKY_GRID_DATATABLE.Columns.Add();
            }

            // Create N+1 x N+1 table
            for (i = 0; i < N_Word + 1; i++)
            {
                //DataRow TempRow2 = new DataRow();
                TableRow TempRow = new TableRow();
                for (j = 0; j < N_Word + 1; j++)
                {
                    TableCell TempCell = new TableCell();
                    // Header row
                    if (i == 0 && j > 0)
                    {
                        s = String.Format("<strong>{0}</strong><br />{1}", j, words[j - 1]);
                        CKY_GRID_DATATABLE.Rows[i].SetField(j, s);
                    }
                    // (0, 0) cell
                    if (i == 0 && j == 0)
                    {
                        s = "<strong>0</strong>";
                        CKY_GRID_DATATABLE.Rows[i].SetField(j, s);
                    }
                    // First Vertical row
                    if (i > 0 && j == 0)
                    {
                        s = String.Format("<strong>{0}</strong>", i - 1);
                        CKY_GRID_DATATABLE.Rows[i].SetField(j, s);
                    }

                    // Other Cells
                    if (i > 0 && j > 0)
                    {
                        s = "";
                        CKY_GRID_DATATABLE.Rows[i].SetField(j, s);
                    }
                }
            }

            for (int k = 0; k < N_Word + 1; k++)
            {
                BoundField bfield = new BoundField();
                bfield.HeaderText = CKY_GRID_DATATABLE.Columns[k].ColumnName;
                bfield.DataField = CKY_GRID_DATATABLE.Columns[k].ColumnName;
                bfield.HtmlEncode = false;
                CKY_Grid.Columns.Add(bfield);
            }

            CKY_DATATABLE = CKY_GRID_DATATABLE;

            this.BindGrid();


            // Create CKY_Global.CKY_TABLECELLS for processing Algorithm and Tracing
            CKY_TableCell[,] cky_Tablecells = new CKY_TableCell[N_Word + 1, N_Word + 1];
            for (i = 0; i < N_Word + 1; i++)
                for (j = 0; j < N_Word + 1; j++)
                    cky_Tablecells[i, j] = new CKY_TableCell();
            this.CKY_TABLECELLS = cky_Tablecells;
        }
        protected bool Start()
        {
            List<CNF_Rule> cnf_rules = new List<CNF_Rule>();
            List<string> words = new List<string>();
            List<string> sentence_words = new List<string>();

            string CNF_text = CNF_Text.Value;
            string sentence = Sentence_Text.Value;

            string[] lines = CNF_text.Split(new string[] { "\n" }, StringSplitOptions.None);

            //string[] lines = CNF_text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                CNF_Rule rule = new CNF_Rule(i + 1, lines[i], words);
                cnf_rules.Add(rule);
            }
            Display_CNF_Table(cnf_rules);

            string[] wordsinSentence = sentence.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (wordsinSentence.Count() == 0)
            {
                var msg = "<strong>Warning!</strong> The Sentence is empty.";

                ScriptManager.RegisterStartupScript(MainUpdatePanel, MainUpdatePanel.GetType(), "alert", "ShowWarningAlert('" + msg + "')", true);
                return false;
            }

            List<string> Outlier_words = new List<string>();
            // Check if error not have word in Global CNF WORDS
            foreach (string w in wordsinSentence)
                if (words.IndexOf(w) == -1)
                    Outlier_words.Add(w);
                else
                    sentence_words.Add(w);

            if (Outlier_words.Count() > 0)
            {
                var str_words = String.Join(", ", Outlier_words.ToArray());

                var msg = String.Format("<strong>Warning!</strong> Words:<strong>{0}</strong> in the Sentence are not in CNF-Terminal words.", str_words);

                ScriptManager.RegisterStartupScript(MainUpdatePanel, MainUpdatePanel.GetType(), "alert", "ShowWarningAlert('" + msg + "')", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowWarningAlert('" + msg + "')", true);
                return false;
            }

            this.CNF_RULES = cnf_rules;
            this.WORDS = words;
            this.SENTENCE_WORDS = sentence_words;
            
            Display_CKY_Table(wordsinSentence);

            return true;
        }

        protected void RestoreColor(int cell_i, int cell_j, int cell_k, int rule_id)
        {
            this.BindGrid();
            // All If-condition at this function is use for the case only change color of (cell_i, cell_k)
            //      On this case we use: RestoreColor(i, -1, k, -1)
            if (cell_j != -1)
            {
                this.CKY_Grid.Rows[cell_i + 1].Cells[cell_j].BackColor = DefaultCellColor;
                this.CKY_Grid.Rows[cell_j + 1].Cells[cell_k].BackColor = DefaultCellColor;
            }

            this.CKY_Grid.Rows[cell_i + 1].Cells[cell_k].BackColor = DefaultCellColor;

            if (rule_id != -1 && rule_id < CNF_RULES.Count())
                this.CNF_Grid.Rows[rule_id].Cells[0].BackColor = DefaultCellColor;
        }
        protected void ChangeColor(int cell_i, int cell_j, int cell_k, int rule_id)
        {
            this.BindGrid();
            // All If-condition at this function is use for the case only change color of (cell_i, cell_k)
            //      On this case we use: ChangeColor(i, -1, k, -1)

            if (cell_j != -1)
            {
                this.CKY_Grid.Rows[cell_i + 1].Cells[cell_j].BackColor = CurCellColor;
                this.CKY_Grid.Rows[cell_j + 1].Cells[cell_k].BackColor = CurCellColor;
            }
            this.CKY_Grid.Rows[cell_i + 1].Cells[cell_k].BackColor = WriteCellColor;
            if (rule_id < CNF_RULES.Count())
                this.CNF_Grid.Rows[rule_id].Cells[0].BackColor = UsedRuleColor;
        }
        protected void SetDataTable(int i, int j, string temp)
        {
            DataTable CKY_GRID_DATATABLE = CKY_DATATABLE;
            CKY_GRID_DATATABLE.Rows[i + 1].SetField(j, temp);
            CKY_DATATABLE = CKY_GRID_DATATABLE;
        }
        protected void Next(bool fskip = false)
        {
            string s;
            int id_rule;
            string word;
            CKY_TableCell[,] cky_tablecells = CKY_TABLECELLS;
            // First cell
            if ((int) CKY_i == 0 && (int) CKY_j == 0 && (int) CKY_k == 0)    
            {
                CKY_k = 1;
                CKY_i = 0;
                CKY_j = 1;
                word = SENTENCE_WORDS[(int) CKY_k - 1];
                cky_tablecells[0, 1].Tag = CKY_TableCell.GetTagofWord(word, out id_rule, CNF_RULES);
                cky_tablecells[0, 1].fTerminal = true;

                s = String.Format("<strong>{0}</strong>", cky_tablecells[0, 1].Tag);
                CKY_TABLECELLS = cky_tablecells;
                SetDataTable(0, 1, s);

                ChangeColor(0, -1, 1, id_rule - 1);

                return;
            }

            int i = (int) CKY_i;
            int j = (int) CKY_j + 1;       // Get next j
            int k = (int) CKY_k;
            // TableCell (i, k) = (i, j) + (j, k)  
            CKY_TableCell CurTC;
            CKY_TableCell OppositeTC;
            int check;

            // End of k col => Next k
            if (i <= 0 && j >= k)
            {
                CKY_k = (int) CKY_k + 1;
                CKY_i = (int) CKY_k - 2;
                CKY_j = (int) CKY_k - 2;

                word = SENTENCE_WORDS[(int) CKY_k - 1];
                cky_tablecells[(int) CKY_k - 1, (int) CKY_k].Tag = CKY_TableCell.GetTagofWord(word, out id_rule, CNF_RULES);

                s = String.Format("<strong>{0}</strong>", cky_tablecells[(int) CKY_k - 1, (int) CKY_k].Tag);
                SetDataTable((int) CKY_k - 1, (int) CKY_k, s);

                ChangeColor((int) CKY_k - 1, -1, (int) CKY_k, id_rule - 1);

                CKY_TABLECELLS = cky_tablecells;

                //List<ProcessChain> PC = PROCESSCHAIN;
                //PC.Add
                if (fskip)
                    Next(fskip);
                else
                    return;
            }
            if (FinalCell == true)
                return;
            if (j == k)
            {
                j = i;
                i = i - 1;
            }
            int x ,y;
            for (x = i; x >= 0; x--)
            {
                for (y = j; y < k; y++)
                {
                    CurTC = cky_tablecells[x, y];
                    OppositeTC = cky_tablecells[y, k];
                    check = CKY_TableCell.CheckMerge(CurTC, OppositeTC, CNF_RULES);
                    if (check == -1)
                        continue;
                    else
                    {
                        cky_tablecells[x, k].Set(CNF_RULES[check - 1].Left, false, x, y, y, k);

                        s = String.Format("<strong>{0}</strong><br />({1}, {2}) + ({3}, {4})", cky_tablecells[x, k].Tag, x, y, y, k);
                        SetDataTable(x, k, s);

                        ChangeColor(x, y, k, check - 1);

                        CKY_TABLECELLS = cky_tablecells;
                        if (x == 0 && k == N_Word)
                        {
                            FinalCell = true;
                            btnMain_State = "Reset";
                            btnMain.Text = "Reset";
                            btnNext.Enabled = false;
                            CKY_i = x;
                            CKY_j = y;
                            CKY_k = k;
                            return;
                        }
                        if (fskip == false)
                        {
                            CKY_i = x;
                            CKY_j = y;
                            CKY_k = k;
                            return;
                        }
                        else
                        {
                            //RestoreColor(x, y, k, check - 1);
                            CKY_i = x;
                            CKY_j = y;
                            CKY_k = k;
                            Next(fskip);
                            if (FinalCell == true)
                                return;
                        }
                    }
                }
                if (y == k)
                    j = i;
                
            }

            CKY_k = (int) CKY_k + 1;
            CKY_i = (int) CKY_k - 2;
            CKY_j = (int) CKY_k - 2;
            if ((int) CKY_k > N_Word)
            {
                FinalCell = true;
                btnMain_State = "Reset";
                btnMain.Text = "Reset";
                btnNext.Enabled = false;
                this.BindGrid();
                return;
            }
            word = SENTENCE_WORDS[(int) CKY_k - 1];
            cky_tablecells[(int) CKY_k - 1, (int) CKY_k].Tag = CKY_TableCell.GetTagofWord(word, out id_rule, CNF_RULES);

            s = String.Format("<strong>{0}</strong>", cky_tablecells[(int) CKY_k - 1, (int) CKY_k].Tag);
            SetDataTable((int) CKY_k - 1, (int) CKY_k, s);

            ChangeColor((int) CKY_k - 1, -1, (int) CKY_k, id_rule - 1);

            CKY_TABLECELLS = cky_tablecells;
            if (fskip == true)
                Next(fskip);
        }

        protected void Prev(bool fskip = false)
        {
            string s;
            int id_rule;
            string word;
            CKY_TableCell[,] cky_tablecells = CKY_TABLECELLS;

            int i = (int) CKY_i;
            int j = (int) CKY_j - 1;       // Get next j
            int k = (int) CKY_k;
            // TableCell (i, k) = (i, j) + (j, k)  
            CKY_TableCell CurTC;
            CKY_TableCell OppositeTC;
            int check;

            // End of k col => Next k
            if (i >= CKY_k - 2 && j <= i)
            {
                CKY_k = (int)CKY_k - 1;
                CKY_i = (int)CKY_k - 2;
                CKY_j = (int)CKY_k - 2;

                word = SENTENCE_WORDS[(int)CKY_k - 1];
                cky_tablecells[(int)CKY_k - 1, (int)CKY_k].Tag = CKY_TableCell.GetTagofWord(word, out id_rule, CNF_RULES);

                s = String.Format("<strong>{0}</strong>", cky_tablecells[(int)CKY_k - 1, (int)CKY_k].Tag);
                SetDataTable((int)CKY_k - 1, (int)CKY_k, s);

                ChangeColor((int)CKY_k - 1, -1, (int)CKY_k, id_rule - 1);

                CKY_TABLECELLS = cky_tablecells;

                return;
            }
            if (FinalCell == true)
                return;
            if (j == k)
            {
                j = i;
                i = i - 1;
            }
            int x, y;
            for (x = i; x >= 0; x--)
            {
                for (y = j; y < k; y++)
                {
                    CurTC = cky_tablecells[x, y];
                    OppositeTC = cky_tablecells[y, k];
                    check = CKY_TableCell.CheckMerge(CurTC, OppositeTC, CNF_RULES);
                    if (check == -1)
                        continue;
                    else
                    {
                        cky_tablecells[x, k].Set(CNF_RULES[check - 1].Left, false, x, y, y, k);

                        s = String.Format("<strong>{0}</strong><br />({1}, {2}) + ({3}, {4})", cky_tablecells[x, k].Tag, x, y, y, k);
                        SetDataTable(x, k, s);

                        ChangeColor(x, y, k, check - 1);

                        CKY_TABLECELLS = cky_tablecells;
                        if (x == 0 && k == N_Word)
                        {
                            FinalCell = true;
                            btnMain_State = "Reset";
                            btnMain.Text = "Reset";
                            btnNext.Enabled = false;
                            CKY_i = x;
                            CKY_j = y;
                            CKY_k = k;
                            return;
                        }
                        if (fskip == false)
                        {
                            CKY_i = x;
                            CKY_j = y;
                            CKY_k = k;
                            return;
                        }
                        else
                        {
                            //RestoreColor(x, y, k, check - 1);
                            CKY_i = x;
                            CKY_j = y;
                            CKY_k = k;
                            Next(fskip);
                            if (FinalCell == true)
                                return;
                        }
                    }
                }
                if (y == k)
                    j = i;

            }

            CKY_k = (int)CKY_k + 1;
            CKY_i = (int)CKY_k - 2;
            CKY_j = (int)CKY_k - 2;
            if ((int)CKY_k > N_Word)
            {
                FinalCell = true;
                btnMain_State = "Reset";
                btnMain.Text = "Reset";
                btnNext.Enabled = false;
                this.BindGrid();
                return;
            }
            word = SENTENCE_WORDS[(int)CKY_k - 1];
            cky_tablecells[(int)CKY_k - 1, (int)CKY_k].Tag = CKY_TableCell.GetTagofWord(word, out id_rule, CNF_RULES);

            s = String.Format("<strong>{0}</strong>", cky_tablecells[(int)CKY_k - 1, (int)CKY_k].Tag);
            SetDataTable((int)CKY_k - 1, (int)CKY_k, s);

            ChangeColor((int)CKY_k - 1, -1, (int)CKY_k, id_rule - 1);

            CKY_TABLECELLS = cky_tablecells;
            if (fskip == true)
                Next(fskip);
        }

        protected void Reset()
        {
            CNF_RULES = new List<CNF_Rule>();
            WORDS = new List<string>();
            SENTENCE_WORDS = new List<string>();
            CKY_i = 0;
            CKY_j = 0;
            CKY_k = 0;
            CKY_TABLECELLS = new CKY_TableCell[1,1];
            //this.Sentence_Text.Value = "";

            N_Word = 0;
            CKY_Grid.Columns.Clear();
            CNF_Grid.Columns.Clear();

            CKY_DATATABLE = new DataTable();
            CNF_DATATABLE = new DataTable();
            btnMain_State = "Start";                   // btnMain_State;
            FinalCell = false;                   // Touch the final cell
        }
        protected void btnMain_Click(object sender, EventArgs e)
        {
            if (btnMain_State== "Start")
            {
                // Reset before Start
                Reset();

                bool check = Start();
                if (check == true)
                {
                    Next();             // Run Next() for first cell
                    btnMain_State = "Skip to Final";

                    // Enable Next button
                    this.btnNext.Enabled = true;
                }
            }
            else if (btnMain_State == "Skip to Final")
            {
                Next(true);
                btnMain_State = "Reset";
                this.btnPrev.Enabled = true;
            }
            else if(btnMain_State == "Reset")
            {
                Reset();
                btnMain_State = "Start";
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
                this.BindGrid();
            }

            this.btnMain.Text = btnMain_State;
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (btnMain_State == "Reset")
            {
                btnMain_State = "Skip to Final";
                this.btnMain.Text = btnMain_State;
            }
            Prev();
            btnNext.Enabled = true;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Next();
            btnPrev.Enabled = true;
        }

        protected void btnDefaulCNF_Click(object sender, EventArgs e)
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"./CKY_nlp/Data/CNF_Rules.txt"));
            CNF_Text.Value = fileContents;
        }

        protected void btnDefaulSentence_Click(object sender, EventArgs e)
        {
            Sentence_Text.Value = "Nam học bài ở trường";
        }
    }
}