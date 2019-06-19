using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspektorientiertesProgrammieren_Demo
{
    interface IRepository<T>
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Save();
    }
}
