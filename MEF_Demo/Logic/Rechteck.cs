using Domain;
using System;

namespace Logic
{
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
