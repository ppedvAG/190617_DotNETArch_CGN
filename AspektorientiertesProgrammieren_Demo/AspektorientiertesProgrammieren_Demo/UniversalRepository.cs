using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektorientiertesProgrammieren_Demo
{
    class UniversalRepository<T> : IRepository<T>
    {
        public void Add(T item)
        {
            Console.WriteLine($"Füge Element hinzu: {item}");
        }

        public void Delete(T item)
        {
            Console.WriteLine($"Lösche Element: {item}");
        }

        public IEnumerable<T> GetAll()
        {
            Console.WriteLine($"Gebe alle Elemente aus");
            return null;
        }

        public T GetByID(int id)
        {
            Console.WriteLine($"Suche nach Element mit der ID {id}");
            return default(T);
        }

        public void Save()
        {
            Console.WriteLine($"Speichern ...");
        }

        public void Update(T item)
        {
            Console.WriteLine($"Update für das Element {item}");
        }
    }
}
