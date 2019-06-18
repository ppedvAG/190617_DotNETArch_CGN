using System.Collections.Generic;
using PersonenVerwaltung.Model;

namespace PersonenVerwaltung.Model
{
    public interface IPersonenService
    {
        List<Person> GetPersonen();
    }
}