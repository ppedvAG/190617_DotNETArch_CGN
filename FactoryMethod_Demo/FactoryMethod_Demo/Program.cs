using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Kantine zumKölscherBua = new Kantine();

            var lecker = zumKölscherBua.GibEssen();

            Console.WriteLine(lecker.Beschreibung);

            var mjam = zumKölscherBua.GibEssen(new DateTime(1848,12,15,20,14,55));
            Console.WriteLine(mjam.Beschreibung);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
