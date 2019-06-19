using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Einführung
            //object o1 = new object();
            //Type info = o1.GetType();

            //Console.WriteLine(info);

            //int zahl = 42;
            //Console.WriteLine(zahl.GetType());

            //Type zahlType = zahl.GetType();

            //object neueInstanz = Activator.CreateInstance(zahlType);

            //Console.WriteLine(neueInstanz);
            //Console.WriteLine(neueInstanz.GetType());

            //Person generiert = MeinAutoFixture<Person>();

            //Console.WriteLine(generiert.Vorname);
            //Console.WriteLine(generiert.Nachname);
            //Console.WriteLine(generiert.Alter);
            //Console.WriteLine(generiert.Kontostand); 
            #endregion

            var tr_assembly = Assembly.LoadFrom("./TaschenrechnerLib.dll");

            // 1) Name des Datentyps ist bekannt
            var taschenrechnerTyp = tr_assembly.GetType("TaschenrechnerLib.Taschenrechner");
            // 2) Mit GetTypes() alle Typen holen und dann durchsuchen

            object taschenrechnerInstanz = Activator.CreateInstance(taschenrechnerTyp);
            // Idealfall: Statt object eine Schnittstelle nutzen

            // Mühsamer Weg ohne Schnittstelle:
            var methodenInfo = taschenrechnerTyp.GetRuntimeMethod("Add", new Type[] { typeof(int), typeof(int) });

            var ergebnis = methodenInfo.Invoke(taschenrechnerInstanz, new object[] { 2, 2 });

            Console.WriteLine(ergebnis);
            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        public static T MeinAutoFixture<T>()
        {
            T instance = (T) Activator.CreateInstance(typeof(T));
            foreach (PropertyInfo info in instance.GetType()
                                         .GetProperties()
                                         .Where(x => x.CanWrite == true &&
                                                     x.PropertyType == typeof(string)))
            {
                if (info.Name == "Vorname")
                    info.SetValue(instance, "Max");
                else
                    info.SetValue(instance, Guid.NewGuid().ToString());
            }

            return instance;
        }
    }
}
