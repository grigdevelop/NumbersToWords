using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumbersToWordsLib.Common;
using NumbersToWordsLib.Utilities;

namespace SuperNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberBase[] numbers = new NumberBase[]
            {
                null,
                new NumberWithConstantGender("one"),
                new NumberWithNonConstantGender("twoMus", "twoJen", "twoNetr", "plplTwo"), 
                new NumberWithConstantGender("three"), 
                new NumberWithConstantGender("Four"), 
                new NumberWithConstantGender("Five"), 
                new NumberWithConstantGender("Six"), 
                new NumberWithConstantGender("Seven"), 
                new NumberWithConstantGender("eight"), 
                new NumberWithConstantGender("nine"), 
                new NumberWithConstantGender("ten"), 
            };

            TenNumbersBase[] tens = new TenNumbersBase[]
            {
                new StandardTenNumbers(numbers, "ten"), 
                new StandardTenNumbers(numbers, "eleven"), 
            };

            var st = new ToWordBuilder(new StringBuilder());
            tens[0].Formulation(st, 5, GenderAndCount.Masculine);
            Console.WriteLine(st.ToString());
            Console.ReadLine();
        }
    }
}
