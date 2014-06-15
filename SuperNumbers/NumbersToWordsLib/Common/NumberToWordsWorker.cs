using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsLib.Common
{
    public class NumberToWordsWorker : NTWItemBase
    {
        public StringBuilder Formulation(double sum, Currency currency, StringBuilder result)
        {
            double integer = Math.Floor(sum);
            uint дробная = (uint)(sum * 100) - (uint)(integer * 100);


            return result;
        }




    }
}
