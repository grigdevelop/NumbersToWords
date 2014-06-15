using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsLib.Common
{
    public interface IMeasure
    {
        string NominativeUnit { get; }

        string GenderUnit { get; }

        string GenderPlural { get; }

        GenderAndCount GenderNCount { get; }
    }

    public class Measure : IMeasure
    {
        readonly GenderAndCount _genderAndCount;
        readonly string _nominativeUnit;
        readonly string _genderUnit;
        readonly string _genderPlural;
        
        public Measure(
            GenderAndCount genderAndCount,
            string nominativeUnit,
            string genderUnit,
            string genderPlural)
        {
            this._genderAndCount = genderAndCount;
            this._nominativeUnit = nominativeUnit;
            this._genderUnit = genderUnit;
            this._genderPlural = genderPlural;
        }
            

        string IMeasure.NominativeUnit
        {
            get { return this._nominativeUnit; }
        }

        string IMeasure.GenderUnit
        {
            get { return this._genderUnit; }
        }

        string IMeasure.GenderPlural
        {
            get { return this._genderPlural; }
        }

        GenderAndCount IMeasure.GenderNCount
        {
            get { return this._genderAndCount; }
        }

       
    }

    public abstract class GenderAndCount : IMeasure
    {
        public string NominativeUnit { get { return null; } }
        public string GenderUnit { get { return null; } }
        public string GenderPlural { get { return null; } }
        public GenderAndCount GenderNCount { get { return this; } }

        #region Genders

        public static readonly GenderAndCount Masculine = new _Masculine();

        public static readonly GenderAndCount Feminine = new _Feminine();

        public static readonly GenderAndCount Neutral = new _Neutral();

        public static readonly GenderAndCount Plural = new _Plural();

        #endregion // Genders


        internal abstract string GetForm(IChangeByGender changeByGender);
    }

}
