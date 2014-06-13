using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsLib.Common
{
    public interface IChangeByGender
    {
        string Muasculine { get; }

        string Feminine { get; }

        string Plural { get; }

        string Neutral { get; }
    }


    internal class _Masculine : GenderAndCount
    {
        internal override string GetForm(IChangeByGender changeByGender)
        {
            return changeByGender.Muasculine;
        }
    }

    internal class _Feminine : GenderAndCount
    {
        internal override string GetForm(IChangeByGender changeByGender)
        {
            return changeByGender.Feminine;
        }
    }

    internal class _Neutral : GenderAndCount
    {
        internal override string GetForm(IChangeByGender changeByGender)
        {
            return changeByGender.Neutral;
        }
    }

    internal class _Plural : GenderAndCount
    {
        internal override string GetForm(IChangeByGender changeByGender)
        {
            return changeByGender.Plural;
        }
    }
}
