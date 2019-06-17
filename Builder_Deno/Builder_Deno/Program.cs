using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Deno
{
    class Program
    {
        static void Main(string[] args)
        {
            Schrank schwedischerSchrank = Schrank.BaueSchrank()
                                                 .MitOberfläche(Oberflächenart.Lackiert)
                                                 .InFarbe("Rot")
                                                 .MitTüren(5)
                                                 .MitBöden(2)
                                                 .MitBöden(5)
                                                 .MitOberfläche(Oberflächenart.Gewachst)
                                                 .Konstruieren();


            Console.WriteLine("---ENDE ❤❤❤❤---");
            Console.ReadKey();
        }
    }
}
