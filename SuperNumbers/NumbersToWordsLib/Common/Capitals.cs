using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsLib.Common
{
    public abstract class Capitals
    {
       
        public abstract void Apply(StringBuilder sb);

        class _ALL : Capitals
        {
            public override void Apply(StringBuilder sb)
            {
                for (int i = 0; i < sb.Length; ++i)
                {
                    sb[i] = char.ToUpperInvariant(sb[i]);
                }
            }
        }

        class _NONE : Capitals
        {
            public override void Apply(StringBuilder sb)
            {
            }
        }

        class _FIRST : Capitals
        {
            public override void Apply(StringBuilder sb)
            {
                sb[0] = char.ToUpperInvariant(sb[0]);
            }
        }

        public static readonly Capitals ALL = new _ALL();
        public static readonly Capitals NONE = new _NONE();
        public static readonly Capitals FIRST = new _FIRST();
    }
}
