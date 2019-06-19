using ppedv.BV.Domain;
using ppedv.BV.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.BV.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public EFUnitOfWork(EFContext context)
        {
            this.context = context;
        }
        private readonly EFContext context;


        // Variante 1) immer wieder eine neue Instanz zurückgeben
        public IBookRepository BookRepository => new EFBookRepository(context); // Alternative: IoC
        // Variante 2) Singleton
        private IBookStoreRepository bookStoreRepository;
        public IBookStoreRepository BookStoreRepository
        {
            get // Hausaufgabe: Locken und Threadsicher machen ;)
            {
                if (bookStoreRepository != null)
                    bookStoreRepository = new EFBookStoreRepository(context);

                return bookStoreRepository;
            }
        }

        public IUniversalRepository<T> GetRepository<T>() where T : Entity
        {
            return new EFUniversalRepository<T>(context);
            // Hausaufgabe: Jedes Repository nur 1 mal erstellen, Bei z.B. "Book" das Spezialsrepo zurückgeben ...
        }

        public void Save() => context.SaveChanges();
    }
}
