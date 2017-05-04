using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET___My_Website.Projects.CKY_nlp
{
    /// <summary>
    /// Process Chain used for Prev() Process
    /// </summary>
    [Serializable]
    public class ProcessChain
    {
        public int i;
        public int j;
        public int k;
        public int id_rule;
        public bool fTerminal;
        public ProcessChain(int x, int y, int k, int id, bool fterminal)
        {
            this.i = x;
            this.j = y;
            this.k = k;
            this.id_rule = id;
            this.fTerminal = fterminal;
        }
    }
}