using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektorientiertesProgrammieren_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Programmstart (ohne logging)---");

            IRepository<Person> personenRepo = new AuthRepositoriy<Person>(
                                                   new LoggingRepository<Person>(
                                                       new UniversalRepository<Person>()), User.Admin);
            // Zusammensetzen mit anderen Patterns
            // FactoryMethod: RepoFactory.GetLoggingRepo<Person>();
            // Builder: GetUniversalRepo()
            //         .WithLogger()
            //         .WithAuth(readonly)
            //         .Get();

            var person = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100000000 };

            personenRepo.Add(person);
            personenRepo.Update(person);
            personenRepo.Delete(person);

            Console.WriteLine("---Programmende (ohne logging)---");
            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
