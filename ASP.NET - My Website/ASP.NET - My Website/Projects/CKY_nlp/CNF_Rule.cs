using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace ASP.NET___My_Website.Projects.CKY_nlp
{
    [Serializable]
    public class CNF_Rule
    {
        public int ID;
        public string Left;
        public string[] Right = new string[2];
        public bool fTerminal;

        public CNF_Rule(int id, string CNF_line, List<string> WORDS)
        {
            this.ID = id;

            Regex lineSplitter = new Regex(@"[^\w]");
            string[] splits = lineSplitter.Split(CNF_line).Where(s => s != string.Empty).ToArray();

            if (splits.Length == 2)        // Terminal:   Np --> Nam
            {
                this.Left = splits[0];
                this.Right[0] = splits[1];
                this.fTerminal = true;
                WORDS.Add(this.Right[0]);
            }
            else if (splits.Length == 3)    // Non-Terminal:  S --> NP VP
            {
                this.Left = splits[0];
                this.Right[0] = splits[1];
                this.Right[1] = splits[2];
                this.fTerminal = false;
            }
        }
    }
}