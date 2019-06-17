using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Logger().Log("Hallo Welt");
            new Logger().Log("Das ist ein Test");
            new Logger().Log("Demo ...");



            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
