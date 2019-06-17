using System;
using System.Threading;

namespace Fassade_Demo
{
    class RechnungsService
    {
        private Random r = new Random();
        public bool PrüfeBonität()
        {
            Console.WriteLine("Prüfe auf unbezahlte Rechnungen ...");
            Thread.Sleep(3000);
            return r.Next(0, 10) > 5;
        }

        public void ZahlungAbwickeln()
        {
            Console.WriteLine("Bezahle......... haben sie Payback ?");
        }
    }
}
