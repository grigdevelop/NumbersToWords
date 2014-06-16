using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumbersToWordsLib.Utilities;

namespace NumbersToWordsLib.Common
{
    public interface INTWData
    {
        double CurrentNumber { get; set; }

        NumberBase[] Numbers { get; }

        TenNumbersBase[] TenNumbers { get; }

        IMeasure[] NumberGrades { get; }

        string[] Hundreds { get; }

        FormulationOfGrade FormulationOfGradeOvr { get; }
    }
}
