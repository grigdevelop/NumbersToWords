using NumbersToWordsLib.Common;
using NumbersToWordsLib.Utilities;

namespace SuperNumbers.Languages
{
    class NTW_EN : INTWData
    {
        public static readonly Currency Dollars = new Currency(
         new Measure(GenderAndCount.Masculine, "dollar", "dollar", "dollars"), new Measure(null, null, null, null));

        private void DataSetup()
        {
            this.TenNumbers = new TenNumbersBase[]
                {
                    new FirstTens(), 
                    new SecondTens(), 
                    new AmTenNumbers("twenty"), 
                    new AmTenNumbers ("thirty"),
                    new AmTenNumbers ("fourty"),
                    new AmTenNumbers ("fifty"),
                    new AmTenNumbers ("sixty"),
                    new AmTenNumbers ("seventy"),
                    new AmTenNumbers ("eighty"),
                    new AmTenNumbers ("ninty")
                };
            this.Numbers = new NumberBase[]
                {
                    null,              
                    new NumberWithConstantGender("one"),
                    new NumberWithConstantGender("two"),
                    new NumberWithConstantGender("three"),
                    new NumberWithConstantGender("four"),
                    new NumberWithConstantGender("five"),
                    new NumberWithConstantGender("six"),
                    new NumberWithConstantGender("seven"),
                    new NumberWithConstantGender("eight"),
                    new NumberWithConstantGender("nine"),
                };
            this.NumberGrades = new IMeasure[]
                {                    
                    new Grade("thousand"),                     
                    new Grade("million"),                     
                    new Grade("billion")                  
                };
            this.Hundreds = new[]
                {
                    null,
                    "one hundred",
                    "two hundred",
                    "three hundred",
                    "four hundred",
                    "five hundred",
                    "six hundred",
                    "seven hundred",
                    "eight hundred",
                    "nine hundred"
                };


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
                case 4: return measure.GenderPlural;
                default: return measure.GenderPlural;
            }
        }

        public NTW_EN()
        {
            DataSetup();
        }

        public double CurrentNumber { get; set; }
        public NumberBase[] Numbers { get; private set; }

        public TenNumbersBase[] TenNumbers { get; private set; }

        class AmTenNumbers : TenNumbersBase
        {
            private readonly string _name;

            public AmTenNumbers(string name)
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

        public IMeasure[] NumberGrades { get; private set; }
        public string[] Hundreds { get; private set; }

        public FormulationOfGrade FormulationOfGradeOvr { get; private set; }

        public class FirstTens : TenNumbersBase
        {
            public override void Formulation(ToWordBuilder toWordBuilder, uint numberOfUnits, GenderAndCount gender)
            {
                toWordBuilder.Append(FormulationOfNumber(numberOfUnits, gender));
            }
        }

        public class SecondTens : TenNumbersBase
        {
            private readonly string[] _tens =
            {
                "ten",
                "eleven",
                "twelve",
                "thirteen",
                "fourteen",
                "fifteen",
                "sixteen",
                "seventeen",
                "eighteen",
                "nineteen"
            };

            public override void Formulation(ToWordBuilder toWordBuilder, uint numberOfUnits, GenderAndCount gender)
            {
                toWordBuilder.Append(_tens[numberOfUnits]);
            }
        }


    }
}
