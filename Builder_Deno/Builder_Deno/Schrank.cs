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

        public static SchrankBauer BaueSchrank() => new SchrankBauer();

        public class SchrankBauer
        {
            public SchrankBauer()
            {
                zuBauenderSchrank = new Schrank();
            }
            private Schrank zuBauenderSchrank;

            public SchrankBauer MitOberfläche(Oberflächenart gewünschteOberflächenart)
            {
                zuBauenderSchrank.Oberfläche = gewünschteOberflächenart;
                return this; // Aufruf verketten
            }
            public SchrankBauer InFarbe(string gewünschteFarbe)
            {
                zuBauenderSchrank.Farbe = gewünschteFarbe;
                return this;
            }
            public SchrankBauer MitMetallschienen(bool metallschienen)
            {
                zuBauenderSchrank.Metallschiene = metallschienen;
                return this;
            }
            public SchrankBauer MitKleiderstange(bool kleiderstange)
            {
                zuBauenderSchrank.Kleiderstange = kleiderstange;
                return this;
            }
            public SchrankBauer MitBöden(int anzahlBöden)
            {
                zuBauenderSchrank.AnzahlBöden = anzahlBöden;
                return this;
            }
            public SchrankBauer MitTüren(int anzahlTüren)
            {
                zuBauenderSchrank.AnzahlTüren = anzahlTüren;
                return this;
            }

            public Schrank Konstruieren()
            {
                // Variante 1) Validierung
                if (zuBauenderSchrank.AnzahlTüren < 2 || zuBauenderSchrank.AnzahlTüren > 7)
                    throw new InvalidOperationException("Ungültige Anzahl der Türen");
                if (zuBauenderSchrank.AnzahlBöden < 0 || zuBauenderSchrank.AnzahlBöden > 6)
                    throw new InvalidOperationException("Ungültige Anzahl der Böden");
                if (zuBauenderSchrank.Farbe != string.Empty && zuBauenderSchrank.Oberfläche != Oberflächenart.Lackiert)
                    throw new InvalidOperationException("Nur lackierte Schränke dürfen eine Farbe haben");

                return zuBauenderSchrank;
            }

        }

    }
}
