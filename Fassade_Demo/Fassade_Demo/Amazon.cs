using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fassade_Demo
{
    class Amazon // Fassade
    {
        public Amazon()
        {
            // Kontrollfreak-Antipattern:
            emailService = new EmailService();
            lagerSystem = new LagerSystem();
            versanddienstleister = new DHLExpress();
            rechnungsService = new RechnungsService();
        }

        private readonly EmailService emailService;
        private readonly LagerSystem lagerSystem;
        private readonly DHLExpress versanddienstleister;
        private readonly RechnungsService rechnungsService;
        public bool Bestellen(string produkt)
        {
            Console.WriteLine("Amazon-Bestellung aufgeben:");
            if (lagerSystem.IstProduktAufLager() == false)
            {
                Console.WriteLine("leider nicht mehr auf lager :( ");
                Console.ReadKey();
                return false;
            }
            if (rechnungsService.PrüfeBonität() == false)
            {
                Console.WriteLine("zahl erstmal deine Rechnungen !!!!! ");
                Console.ReadKey();
                return false;
            }

            rechnungsService.ZahlungAbwickeln();
            versanddienstleister.ProduktVersenden();
            emailService.SendeBestätigungsmail();
            Console.WriteLine($"Ihr Produkt: '{produkt}' wurde erfolgreich bestellt");

            return true;
        }
    }
}
