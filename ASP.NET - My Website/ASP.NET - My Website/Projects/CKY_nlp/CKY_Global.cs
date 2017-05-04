using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ASP.NET___My_Website.Projects.CKY_nlp
{
    /// <summary>
    /// CKY algorithm Global Variables
    /// </summary>
    public static class CKY_Global
    {
        // All Words from CNF rules
        public static List<string> WORDS = new List<string>();
        // List of CNF Rules (Terminal + Non-Terminal)
        public static List<CNF_Rule> CNF_RULES = new List<CNF_Rule>();
        // All Words from theSentence
        public static List<string> SENTENCE_WORDS = new List<string>();

        // CKY: current column k
        public static int k = 0;
        // CKY: position (x,y) of current cell
        public static int i = 0, j = 0;

        // Number of words in the Sentence

        public static int N_Word = 0;

        // CKY: Table Cell Matrix   - Use to Tracing Parse-Tree
        public static CKY_TableCell[,] CKY_TABLECELLS;

        // Gridview Datatable
        public static DataTable CKY_GRID_DATATABLE = new DataTable();
        public static DataTable CNF_GRID_DATATABLE = new DataTable();

    }
}