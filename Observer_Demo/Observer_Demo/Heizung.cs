using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Observer_Demo
{
    class Heizung
    {
        public double Temperatur { get; set; }

        public void TempErhöhen()
        {
            Temperatur += 5;
        }
        public void TempVerringern()
        {
            Temperatur -= 5;
        }
    }

    class Thermostat
    {
        public Thermostat()
        {
            Gebäudeheizung = new Heizung();
            Gebäudeheizung.Temperatur = 20;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += CheckTemp;
            timer.Start();
        }
        private readonly Timer timer;

        private void CheckTemp(object sender, ElapsedEventArgs e)
        {
            if (Gebäudeheizung.Temperatur > 36)
            {
                Console.WriteLine("UFFFFFF");
                ZuHeiß?.Invoke();
            }
            else if (Gebäudeheizung.Temperatur < 15)
            {
                Console.WriteLine("BRRRRR");
                ZuKalt?.Invoke();
            }
            else
                Console.WriteLine("Temperatur passt ...");
        }

        public Heizung Gebäudeheizung { get; set; }
        public event Action ZuHeiß;
        public event Action ZuKalt;
    }

}
