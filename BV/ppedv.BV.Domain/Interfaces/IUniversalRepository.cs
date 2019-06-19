using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.BV.Domain.Interfaces
{
    public interface IUniversalRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T GetByID(int ID);
        IQueryable<T>Query();
        void Add(T item);
        void Delete(T item);
        void Update(T item);
    }
}
