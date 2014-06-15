using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsLib.Common
{
    public class Currency : NTWItemBase
    {
        private readonly IMeasure _baseMeasure;
        private readonly IMeasure _fractionalMeasure;

        public Currency(IMeasure baseMeasure, IMeasure fractionalMeasure)
        {
            _baseMeasure = baseMeasure;
            _fractionalMeasure = fractionalMeasure;
        }

        public IMeasure BaseMeasure { get { return this._baseMeasure; } }
        public IMeasure FractionalMeasure { get { return this._fractionalMeasure; } }
    }
}
