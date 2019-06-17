using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Deno
{
    enum Oberflächenart { Unbehandelt,Gewachst,Lackiert}

    class Schrank
    {
        private Schrank(){}

        public int AnzahlTüren { get; set; } // Min 2, Max 7
        public Oberflächenart Oberfläche { get; set; }
        public string Farbe { get; set; }
        public bool Metallschiene { get; set; }
        public int AnzahlBöden { get; set; } // Min 0, Max 6
        public bool Kleiderstange { get; set; }


    }
}
