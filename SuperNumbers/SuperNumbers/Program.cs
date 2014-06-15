using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumbersToWordsLib;
using NumbersToWordsLib.Common;
using NumbersToWordsLib.Utilities;

namespace SuperNumbers
{
    class Program
    {
        public static readonly Currency Dollars = new Currency(
            new Measure(GenderAndCount.Masculine, "доллар США", "доллара США", "долларов США"),
            new Measure(GenderAndCount.Masculine, "цент", "цента", "центов"));

        static void Main(string[] args)
        {
            // 
            var ntw = new NumbersToWords(new NTW_RU());
            Console.WriteLine(ntw.Transform(100, Dollars));
            Console.WriteLine(ntw.Transform(255689, Dollars));
            Console.WriteLine(ntw.Transform(1, Dollars));

            Console.ReadLine();
        }
      

    }


    class NTW_RU : INTWData
    {
        public NumberBase[] Numbers
        {
            get
            {
                return new NumberBase[]
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
            }
        }

        public TenNumbersBase[] TenNumbers
        {
            get
            {
                return new TenNumbersBase[]
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
            }
        }

        public IMeasure[] NumberGrades
        {
            get
            {
                return new IMeasure[]
                {
                    new GradeRuThousand(), 
                    new GradeRu("миллион"),                     
                    new GradeRu("миллиард"),                     
                    new GradeRu("триллион")                  
                };
            }
        }

        public string[] Hundreds
        {
            get
            {
                return new[]
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
        }

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
                toWordBuilder.Append(_tens[numberOfUnits]);
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
