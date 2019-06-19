using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.Composition; // MEF
namespace Logic
{
    [Export(typeof(IGrafik))] // Klasse Exportieren
    public class Kreis : IGrafik
    {
        public int X { get; set; }
        public int Y { get; set; }

        [Export("Zeichnen_Methode")] // Logik unter dem Namen XYZ exportieren
        public void Zeichnen()
        {
            Console.WriteLine($"Ein Kreis mit den Koordinaten {X}/{Y} wird gezeichnet");
        }
    }
}
