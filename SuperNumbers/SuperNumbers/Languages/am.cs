using NumbersToWordsLib.Common;
using NumbersToWordsLib.Utilities;

namespace SuperNumbers.Languages
{
    class NTW_AM : INTWData
    {
        public static readonly Currency Dollars = new Currency(
         new Measure(GenderAndCount.Masculine, "դոլլար", "դոլլար", "դոլլար"), new Measure(null, null, null, null));

        public NTW_AM()
        {
            DataSetup();
        }

        private void DataSetup()
        {
            this.Numbers = new NumberBase[]
                {
                    null,              
                    new NumberWithConstantGender("մեկ"),
                    new NumberWithConstantGender("երկու"),
                    new NumberWithConstantGender("երեք"),
                    new NumberWithConstantGender("չորս"),
                    new NumberWithConstantGender("հինգ"),
                    new NumberWithConstantGender("վեց"),
                    new NumberWithConstantGender("յոթ"),
                    new NumberWithConstantGender("ութ"),
                    new NumberWithConstantGender("ինը"),
                };
            this.TenNumbers = new TenNumbersBase[]
                {
                    new FirstTens(), 
                    new SecondTens(), 
                    new AmTenNumbers("քսան"), 
                    new AmTenNumbers ("երեսուն"),
                    new AmTenNumbers ("քառասուն"),
                    new AmTenNumbers ("հիսուն"),
                    new AmTenNumbers ("վաթսուն"),
                    new AmTenNumbers ("յոթանասուն"),
                    new AmTenNumbers ("ութանասուն"),
                    new AmTenNumbers ("ինսուն")
                };
            this.NumberGrades = new IMeasure[]
                {                    
                    new Grade("հազար"),                     
                    new Grade("միլիոն"),                     
                    new Grade("միլիարդ")                  
                };
            this.Hundreds = new[]
                {
                    null,
                    "հարյուր",
                    "երկու հարյուր",
                    "երեք հարյուր",
                    "չորս հարյուր",
                    "հինգ հարյուր",
                    "վեց հարյուր",
                    "յոթ հարյուր",
                    "ութ հարյուր",
                    "ինը հարյուր"
                };
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
                    toWordBuilder.Append(FormulationOfNumber(numberOfUnits, gender), string.Empty);
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
                "տաս",
                "տասնմեկ",
                "տասներկու",
                "տասներեք",
                "տասնչորս",
                "տասնհինգ",
                "տասնվեց",
                "տասնյոթ",
                "տասնութ",
                "տասնինը"
            };

            public override void Formulation(ToWordBuilder toWordBuilder, uint numberOfUnits, GenderAndCount gender)
            {
                toWordBuilder.Append(_tens[numberOfUnits]);
            }
        }


    }
}
