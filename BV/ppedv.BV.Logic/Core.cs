using AutoFixture;
using ppedv.BV.Domain;
using ppedv.BV.Domain.Interfaces;
using System;
using System.Linq;

namespace ppedv.BV.Logic
{
    public class Core
    {
        public Core(IUnitOfWork unitOfWork)
        {
            this.fixture = new Fixture();
            this.UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public readonly IUnitOfWork UnitOfWork;
        private readonly Fixture fixture;

        // Geschäftslogik:
        public void CreateNewBookStore()
        {
            var newBookStores = fixture.CreateMany<BookStore>(5);
            foreach (var store in newBookStores)
            {
                UnitOfWork.BookStoreRepository.Add(store); // Variante 1) SpezialRepository
                // unitOfWork.GetRepository<BookStore>().Add(store); // Variante 2) Allgemeines Repository
            }
            UnitOfWork.Save();
        }
        public BookStore GetBookStoreWithHighestInventoryValue()
        {
            var result = UnitOfWork.BookStoreRepository
                                   .Query()
                                   .OrderByDescending(x => x.InventoryList.Sum(inv => inv.Amount * inv.Book.Price))
                                   .First();
            return result;
        }
    }
}
