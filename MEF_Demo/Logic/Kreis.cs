using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Kreis : IGrafik
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Zeichnen()
        {
            Console.WriteLine($"Ein Kreis mit den Koordinaten {X}/{Y} wird gezeichnet");
        }
    }
}
