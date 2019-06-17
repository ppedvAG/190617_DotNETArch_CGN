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
            var emailService = new EmailService();
            var lagerSystem = new LagerSystem();
            var dhl = new DHLExpress();
            var rechnungsService = new RechnungsService();

            Console.WriteLine("Amazon-Bestellung aufgeben:");
            if(lagerSystem.IstProduktAufLager() == false)
            {
                Console.WriteLine("leider nicht mehr auf lager :( ");
                Console.ReadKey();
                return;
            }
            if (rechnungsService.PrüfeBonität() == false)
            {
                Console.WriteLine("zahl erstmal deine Rechnungen !!!!! ");
                Console.ReadKey();
                return;
            }

            rechnungsService.ZahlungAbwickeln();
            dhl.ProduktVersenden();
            emailService.SendeBestätigungsmail();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
