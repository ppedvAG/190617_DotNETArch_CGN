using System;
using System.Threading;

namespace Fassade_Demo
{
    class LagerSystem
    {
        public bool IstProduktAufLager()
        {
            Console.WriteLine("Prüfe auf Verfügbarkeit ....");
            Thread.Sleep(5000);
            return true;
        }
    }
}
