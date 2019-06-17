using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fassade_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Amazon meinAmazonPrime = new Amazon();

            meinAmazonPrime.Bestellen("TShirt");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
