using NumbersToWordsLib.Common;
using NumbersToWordsLib.Utilities;

namespace SuperNumbers.Languages
{
    class NTW_RU : INTWData
    {
        public static readonly Currency Dollars = new Currency(
           new Measure(GenderAndCount.Masculine, "доллар США", "доллара США", "долларов США"),
           new Measure(GenderAndCount.Masculine, "цент", "цента", "центов"));

        private void DataSetup()
        {
            this.Numbers = new NumberBase[]
                {
                    null,
                    new NumberWithNonConstantGender("один", "одна", "одно", "одни"), 
                    new NumberWithNonConstantGender("два", "две", "два", "двое"), 
                    new NumberWithNonConstantGender("три", "трое"), 
                    new NumberWithNonConstantGender("четыре", "четверо"), 
                    new NumberWithConstantGender("пять"), 
                    new NumberWithConstantGender("шесть"), 
                    new NumberWithConstantGender("семь"), 
                    new NumberWithConstantGender("восемь"), 
                    new NumberWithConstantGender("девять"),
                };
            this.TenNumbers = new TenNumbersBase[]
                {
                    new FirstTens(), 
                    new SecondTens(), 
                    new StandardTenNumbers("двадцать"),
                    new StandardTenNumbers ("тридцать"),
                    new StandardTenNumbers ("сорок"),
                    new StandardTenNumbers ("пятьдесят"),
                    new StandardTenNumbers ("шестьдесят"),
                    new StandardTenNumbers ("семьдесят"),
                    new StandardTenNumbers ("восемьдесят"),
                    new StandardTenNumbers ("девяносто")
                };
            this.NumberGrades = new IMeasure[]
                {
                    new GradeRuThousand(), 
                    new GradeRu("миллион"),                     
                    new GradeRu("миллиард"),                     
                    new GradeRu("триллион")                  
                };
            this.Hundreds = new[]
                {
                    null,
                    "сто",
                    "двести",
                    "триста",
                    "четыреста",
                    "пятьсот",
                    "шестьсот",
                    "семьсот",
                    "восемьсот",
                    "девятьсот"
                };
        }

        public NTW_RU()
        {
            DataSetup();
        }

        public double CurrentNumber { get; set; }
        public NumberBase[] Numbers { get; private set; }

        public TenNumbersBase[] TenNumbers { get; private set; }

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
                "десять",
                "одиннадцать",
                "двенадцать",
                "тринадцать",
                "четырнадцать",
                "пятнадцать",
                "шестнадцать",
                "семнадцать",
                "восемнадцать",
                "девятнадцать"
            };

            public override void Formulation(ToWordBuilder toWordBuilder, uint numberOfUnits, GenderAndCount gender)
            {
                toWordBuilder.Append(_tens[numberOfUnits], " ");
            }
        }

        public class GradeRu : IMeasure
        {
            private readonly string _rootName;

            public GradeRu(string rootName)
            {
                _rootName = rootName;
            }

            public string NominativeUnit { get { return _rootName; } }
            public string GenderUnit { get { return _rootName + "а"; } }
            public string GenderPlural { get { return _rootName + "ов"; } }
            public GenderAndCount GenderNCount { get { return GenderAndCount.Masculine; } }
        }

        public class GradeRuThousand : IMeasure
        {
            public string NominativeUnit { get { return "тысяча"; } }
            public string GenderUnit { get { return "тысячи"; } }
            public string GenderPlural { get { return "тысяч"; } }
            public GenderAndCount GenderNCount { get { return GenderAndCount.Feminine; } }
        }
    }

}
