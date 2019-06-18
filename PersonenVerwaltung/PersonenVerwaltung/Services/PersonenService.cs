using PersonenVerwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenVerwaltung.Services
{
    public class PersonenService : IPersonenService
    {
        public List<Person> GetPersonen()
        {
            return new List<Person>()
            {
                new Person{Vorname="Tom",Nachname="Ate",Alter=10,Kontostand=100},
                new Person{Vorname="Anna",Nachname="Nass",Alter=20,Kontostand=200},
                new Person{Vorname="Peter",Nachname="Silie",Alter=30,Kontostand=300000},
                new Person{Vorname="Franz",Nachname="Ose",Alter=40,Kontostand=-444400},
                new Person{Vorname="Martha",Nachname="Pfahl",Alter=50,Kontostand=12345},
                new Person{Vorname="Klara",Nachname="Fall",Alter=60,Kontostand=66600},
                new Person{Vorname="Clair",Nachname="Grube",Alter=70,Kontostand=-98765},
                new Person{Vorname="Anna",Nachname="Bolika",Alter=80,Kontostand=54367},
                new Person{Vorname="Rainer",Nachname="Zufall",Alter=90,Kontostand=-76431},
                new Person{Vorname="Frank N",Nachname="Stein",Alter=100,Kontostand=1000000},
            };
        }
    }
}
