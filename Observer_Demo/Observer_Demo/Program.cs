using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Thermostat t = new Thermostat();
            Jalousie j = new Jalousie();

            // Situation: Jalousie wird heruntergefahren wenn es zu Heiß ist:
            t.ZuHeiß += j.Herunterlassen;

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
