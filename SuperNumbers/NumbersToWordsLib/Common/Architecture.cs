using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsLib.Common
{
    public interface INTWContext
    {
        NumberBase[] Numbers { get; }

        IMeasure[] NumberGrades { get; }       
    }

    public interface IHasNTWContext
    {
        void SetContext(INTWContext context);
    }

    public abstract class NTWItemBase : IHasNTWContext
    {
        protected INTWContext Context;

        public void SetContext(INTWContext context)
        {
            this.Context = context;
        }
    }
}
