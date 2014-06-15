using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsLib.Common
{
    public interface INTWData
    {
        NumberBase[] Numbers { get; }

        TenNumbersBase[] TenNumbers { get; }

        IMeasure[] NumberGrades { get; }

        string[] Hundreds { get; }
    }
}
