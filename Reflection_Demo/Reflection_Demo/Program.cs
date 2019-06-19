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
            object o1 = new object();
            Type info = o1.GetType();

            Console.WriteLine(info);

            int zahl = 42;
            Console.WriteLine(zahl.GetType());

            Type zahlType = zahl.GetType();

            object neueInstanz = Activator.CreateInstance(zahlType);

            Console.WriteLine(neueInstanz);
            Console.WriteLine(neueInstanz.GetType());

            Person generiert = MeinAutoFixture<Person>();

            Console.WriteLine(generiert.Vorname);
            Console.WriteLine(generiert.Nachname);
            Console.WriteLine(generiert.Alter);
            Console.WriteLine(generiert.Kontostand);

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
