using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekorator_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            var meinePizza = new Käse(new Käse(new Schinken(new Pizza())));

            Console.WriteLine(meinePizza.Text);
            Console.WriteLine(meinePizza.Preis);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
