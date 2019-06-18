using AutoFixture;
using ppedv.BV.Domain;
using ppedv.BV.Domain.Interfaces;
using System;
using System.Linq;

namespace ppedv.BV.Logic
{
    public class Core
    {
        public Core(IRepository repository)
        {
            this.fixture = new Fixture();
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private readonly IRepository repository;
        private readonly Fixture fixture;

        // Geschäftslogik:
        public void CreateNewBookStore()
        {
            var newBookStores = fixture.CreateMany<BookStore>(5);
            foreach (var store in newBookStores)
            {
                repository.Add(store);
            }
            repository.Save();
        }

        public BookStore GetBookStoreWithHighestInventoryValue()
        {
            var result = repository.Query<BookStore>()
                                   .OrderByDescending(x => x.InventoryList.Sum(inv => inv.Amount * inv.Book.Price))
                                   .First();
            return result;
        }
    }
}
