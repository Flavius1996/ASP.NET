using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET___My_Website.Projects.CKY_nlp
{
    /// <summary>
    /// CKY Table Cell Class:
    ///     A cell in CKY Table can create by rule:
    ///         Example: Cell at (1,2) can have this description:
    ///             NP (1, 2) + (2, 2)
    ///         It will represent by:  
    ///             <Tag> (<X1>,<Y1>) + (<X2>,<Y2>)
    ///         Otherwise, if cell is Terminal it only has Tag:
    ///             <Tag>  and fTerminal is true
    ///  
    /// This class is mainly used to Tracing for Parsing Tree.
    /// </summary>
    public class CKY_TableCell
    {
        public string Tag;
        public int X1, Y1;
        public int X2, Y2;
        public bool fTerminal;

        // Default Construction
        public CKY_TableCell()
        {   
            this.Tag = "";          // Empty
            this.fTerminal = false;
            this.X1 = 0;
            this.Y1 = 0;
            this.X2 = 0;
            this.Y2 = 0;
        }
        // Construction with arguments
        public void Set(string tag, bool fterminal, int x1 = 0, int y1 = 0, int x2 = 0, int y2 = 0)
        {
            this.Tag = tag;
            this.fTerminal = fterminal;
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        /// <summary>
        /// Check if 2 TableCell can Merge together
        /// Return: <ID of rule> can merge 2 TableCell
        ///         -1 if can't merge
        /// </summary>
        public static int CheckMerge(CKY_TableCell TC1, CKY_TableCell TC2)
        {
            // Not asigned
            if (TC1.Tag == "" || TC2.Tag == "")
                return -1;

            foreach (CNF_Rule r in CKY_Global.CNF_RULES)
            {
                if (r.fTerminal == false) // Rule must be a non-terminal
                    if (r.Right[0] == TC1.Tag && r.Right[1] == TC2.Tag)
                        return r.ID;
            }
            return -1;
        }
        public static string GetTagofWord(string word, out int id)
        {
            foreach (CNF_Rule r in CKY_Global.CNF_RULES)
                if (r.fTerminal)
                    if (r.Right[0] == word)
                    {
                        id = r.ID;
                        return r.Left;
                    }
            // Not exist
            id = -1;
            return "";
        }
    }
}