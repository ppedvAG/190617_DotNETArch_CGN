﻿using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vorbereitung für MEF
            var catalog = new DirectoryCatalog("."); // Gibt die Quelle der Libs an
            var container = new CompositionContainer(catalog);

            MSPaint paint = new MSPaint();
            container.ComposeParts(paint); // Ladet alles in pain hinein

            // Variante 1: Klasse
            // paint.Zeichnung.Zeichnen();

            // Variante 2: Methode
            // paint.LogikVonWoanders.Invoke();

            // Variante 3: Alles laden was eine IGrafik ist:

            foreach (var grafik in paint.Zeichnungen)
            {
                grafik.Zeichnen();
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

    class MSPaint
    {
        [Import("Zeichnen_Methode")]
        public Action LogikVonWoanders;

        [ImportMany(typeof(IGrafik))]
        public IGrafik[] Zeichnungen { get; set; }
    }
}
