using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumbersToWordsLib.Common;
using NumbersToWordsLib.Utilities;

namespace NumbersToWordsLib
{
    public class NumbersToWords : INTWContext
    {
        #region Datas

        public NumberBase[] Numbers { get; private set; }

        public TenNumbersBase[] TenNumbers { get; private set; }

        public IMeasure[] NumberGrades { get; private set; }

        public string[] Hundreds { get; private set; }

        #endregion // datas

        #region Ctors

        public NumbersToWords(
          NumberBase[] numbers,
          TenNumbersBase[] tenNumbers,
          IMeasure[] numberGrades,
          string[] hundreds)
        {
            this.Numbers = numbers;
            this.TenNumbers = tenNumbers;
            this.NumberGrades = numberGrades;
            this.Hundreds = hundreds;

            // set context for items
            SetArrayContent(this.TenNumbers);
        }

        public NumbersToWords(INTWData ntwData)
            : this(ntwData.Numbers, ntwData.TenNumbers, ntwData.NumberGrades, ntwData.Hundreds)
        {

        }

        #endregion // Ctors

        #region Methods

        public StringBuilder Formulation(double number, IMeasure measure, StringBuilder result)
        {
            string error = CheckNumber(number);
            if (error != null) throw new ArgumentException(error, "number");

            if (number <= uint.MaxValue)
            {
                Formulation((uint)number, measure, result);
            }

            return result;
        }

        public StringBuilder Formulation(uint number, IMeasure measure, StringBuilder result)
        {
            ToWordBuilder builder = new ToWordBuilder(result);

            if (number == 0)
            {
                builder.Append("ноль");
                builder.Append(measure.GenderPlural);
            }
            else
            {
                uint div1000 = number / 1000;
                FormulationOfParentGrades(div1000, 0, builder);
                FormulationOfGrade(number - div1000 * 1000, measure, builder);
            }

            return result;
        }

        public void FormulationOfParentGrades(uint number, int numberOfGrade, ToWordBuilder builder)
        {
            if (number == 0) return;

            uint div1000 = number / 1000;
            FormulationOfParentGrades(div1000, numberOfGrade + 1, builder);

            uint unt999 = number - div1000 * 1000;
            if (unt999 == 0) return;

            FormulationOfGrade(unt999, NumberGrades[numberOfGrade], builder);
        }

        public void FormulationOfGrade(uint subnumber, IMeasure grade, ToWordBuilder builder)
        {
            uint nUnit = subnumber % 10;
            uint nTens = (subnumber / 10) % 10;
            uint nHunds = (subnumber / 100) % 10;

            builder.Append(Hundreds[nHunds]);

            if ((subnumber % 100) != 0)
                TenNumbers[nTens].Formulation(builder, nUnit, grade.GenderNCount);

            builder.Append(Reconcile(grade, subnumber));
        }

        string ApplyCaps(StringBuilder stringBuilder, Capitals capitals)
        {
            capitals.Apply(stringBuilder);
            return stringBuilder.ToString();
        }

        #endregion // Methods

        #region Utilities

        private void SetArrayContent(IEnumerable<IHasNTWContext> items)
        {
            foreach (var hasNtwContext in items)
                SetItemContext(hasNtwContext);
        }

        private void SetItemContext(IHasNTWContext item)
        {
            item.SetContext(this);
        }

        private double CalcMaxDouble()
        {
            double max = Math.Pow(1000, NumberGrades.Length + 1);

            double d = 1;

            while (max - d == max)
            {
                d *= 2;
            }

            return max - d;
        }

        private static double maxDouble = 0;
        public double MaxDouble
        {
            get
            {
                if (maxDouble == 0)
                    maxDouble = CalcMaxDouble();

                return maxDouble;
            }
        }

        public string CheckNumber(double number)
        {
            if (number < 0)
                return "Number should be bigger or equals zero.";

            if (number != Math.Floor(number))
                return "Number should not have fractional part";

            if (number > MaxDouble)
                return String.Format("Number should not be bigger then {0}", MaxDouble);

            return null;
        }

        public static string Reconcile(IMeasure measure, uint number)
        {
            uint nUnit = number % 10;
            uint nTens = (number / 10) % 10;

            if (nTens == 1) return measure.GenderPlural;
            switch (nUnit)
            {
                case 1: return measure.NominativeUnit;
                case 2:
                case 3:
                case 4: return measure.GenderUnit;
                default: return measure.GenderPlural;
            }
        }

        #endregion // Utilities

        #region Super

        public string Transform(double n, Currency currency)
        {
            return ApplyCaps(Formulation(n, currency, new StringBuilder()), Capitals.NONE);
        }

        public StringBuilder Formulation(double sum, Currency currency, StringBuilder result)
        {
            double integer = Math.Floor(sum);
            //uint дробная = (uint)(sum * 100) - (uint)(integer * 100);

            Formulation(integer, currency.BaseMeasure, result);

            return result;
        }



        #endregion

    }
}
