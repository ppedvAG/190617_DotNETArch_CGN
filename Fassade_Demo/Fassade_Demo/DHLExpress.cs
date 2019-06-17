using System;

namespace Fassade_Demo
{
    class DHLExpress
    {
        public void ProduktVersenden()
        {
            Console.WriteLine("Brieftaube wird aus dem Käfig geholt ...");
            Console.Beep();
            Console.Beep();
            Console.WriteLine("Brieftaube ist auf dem Weg");
        }

        public void ProduktVersendenMitTurboschildkröte()
        {
            Console.WriteLine("Schildkröte wird aus dem Terrarium geholt ...");
            Console.Beep();
            Console.Beep();
            Console.WriteLine("Schildkröte ist auf dem Weg");
        }
    }
}
