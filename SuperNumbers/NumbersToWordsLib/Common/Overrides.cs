using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumbersToWordsLib.Utilities;

namespace NumbersToWordsLib.Common
{
    public delegate void FormulationOfGrade(uint subnumber, IMeasure grade, ToWordBuilder builder);
}
