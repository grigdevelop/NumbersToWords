using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsLib.Utilities
{
    public class ToWordBuilder
    {
        public ToWordBuilder(StringBuilder sb)
        {
            this.sb = sb;
        }

        readonly StringBuilder sb;

        bool insertSpace = false;

      
        public void Append(string s, string symb = " ")
        {

            if (string.IsNullOrEmpty(s)) return;

            if (this.insertSpace)           
                this.sb.Append(symb);           
            else           
                this.insertSpace = true;           

            this.sb.Append(s);
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
