using Domain;
using System;
using System.ComponentModel.Composition;

namespace Logic
{
    [Export(typeof(IGrafik))]
    public class Rechteck : IGrafik
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Zeichnen()
        {
            Console.WriteLine($"Ein Rechteck mit den Koordinaten {X}/{Y} wird gezeichnet");
        }
    }
}
