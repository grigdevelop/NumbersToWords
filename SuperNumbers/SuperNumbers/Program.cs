using System;
using System.Windows.Forms;
using NumbersToWordsLib;
using SuperNumbers.Languages;

namespace SuperNumbers
{
    class Program
    {
                    
        static void Main(string[] args)
        {           
            double a = 22, b = 203962000.1, c = 1;
                        
            var ntw = new NumbersToWords(new NTW_AM());
            var ntwr = new NumbersToWords(new NTW_RU());
            var ntwen = new NumbersToWords(new NTW_EN());
           
            MessageBox.Show(string.Format("{0}\n{1}\n{2}\n", ntw.Transform(a, NTW_AM.Dollars), ntw.Transform(b, NTW_AM.Dollars), ntw.Transform(c, NTW_AM.Dollars)));
            MessageBox.Show(string.Format("{0}\n{1}\n{2}\n", ntwr.Transform(a, NTW_RU.Dollars), ntwr.Transform(b, NTW_RU.Dollars), ntwr.Transform(c, NTW_RU.Dollars)));
            MessageBox.Show(string.Format("{0}\n{1}\n{2}\n", ntwen.Transform(a, NTW_EN.Dollars), ntwen.Transform(b, NTW_EN.Dollars), ntwen.Transform(c, NTW_EN.Dollars)));

            Console.ReadLine();
        }
      
    }


  
   

  
}
