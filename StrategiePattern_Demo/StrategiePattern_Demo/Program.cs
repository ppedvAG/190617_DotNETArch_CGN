using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategiePattern_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var audi = new Auto(new Holzklötze(), new RasenmäherMotor(), new Kasettenrekorder());

            audi.Beschleunigen();
            audi.Beschleunigen();

            audi.Bremsen();

            Console.WriteLine(audi.Geschwindigkeit);


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
