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
        public bool fTerminal;
        public ProcessChain(int x, int y, int k, bool fterminal)
        {
            this.i = x;
            this.j = y;
            this.k = k;
            this.fTerminal = fterminal;
        }
    }
}