using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumbersToWordsLib.Utilities;

namespace NumbersToWordsLib.Common
{
    public abstract class NumberBase
    {
        public abstract string Formulation(GenderAndCount genderAndCount);
    }

    public class NumberWithConstantGender : NumberBase
    {
        private readonly string _formulation;

        public NumberWithConstantGender(string formulation)
        {
            _formulation = formulation;
        }      

        public override string Formulation(GenderAndCount genderAndCount)
        {
            return _formulation;
        }
    }

    public class NumberWithNonConstantGender : NumberBase, IChangeByGender
    {
        private readonly string _muasculine;
        private readonly string _feminine;
        private readonly string _neutral;
        private readonly string _plural;

        public NumberWithNonConstantGender(string muasculine, string feminine, string neutral, string plural)
        {
            _muasculine = muasculine;
            _feminine = feminine;
            _neutral = neutral;
            _plural = plural;
        }

        public NumberWithNonConstantGender(string singular, string plural)
            : this(singular, singular, singular, plural)
        {

        }

        public override string Formulation(GenderAndCount genderAndCount)
        {
            return genderAndCount.GetForm(this);
        }

        public string Muasculine { get { return _muasculine; } }
        public string Feminine { get { return _feminine; } }
        public string Plural { get { return _plural; } }
        public string Neutral { get { return _neutral; } }
    }

    public abstract class TenNumbersBase : NTWItemBase
    {

        public abstract void Formulation(ToWordBuilder toWordBuilder, uint numberOfUnits, GenderAndCount gender);


        protected virtual string FormulationOfNumber(uint number, GenderAndCount gender)
        {
            return Context.Numbers[number].Formulation(gender);
        }
    }

    public class StandardTenNumbers : TenNumbersBase
    {
        private readonly string _name;

        public StandardTenNumbers(string name)
        {
            _name = name;
        }

        public override void Formulation(ToWordBuilder toWordBuilder, uint numberOfUnits, GenderAndCount gender)
        {
            toWordBuilder.Append(this._name);

            if (numberOfUnits == 0) { }
            //
            else
                toWordBuilder.Append(FormulationOfNumber(numberOfUnits, gender));
        }
    }

    public class Grade : IMeasure
    {
        private readonly string _rootName;

        public Grade(string rootName)
        {
            _rootName = rootName;
        }

        public string NominativeUnit { get { return _rootName; } }
        public string GenderUnit { get { return _rootName; } }
        public string GenderPlural { get { return _rootName; } }
        public GenderAndCount GenderNCount { get { return GenderAndCount.Masculine; } }
    }


}
