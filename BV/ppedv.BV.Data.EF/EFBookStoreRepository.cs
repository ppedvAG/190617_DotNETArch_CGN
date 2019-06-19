using ppedv.BV.Domain;
using ppedv.BV.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.BV.Data.EF
{
    public class EFBookStoreRepository : EFUniversalRepository<BookStore>, IBookStoreRepository
    {
        public EFBookStoreRepository(EFContext context) : base(context){}

        public BookStore GetBookStoreWithHighestInventoryValue()
        {
            return Query()
                   .OrderByDescending(x => x.InventoryList.Sum(inv => inv.Amount * inv.Book.Price))
                   .First();
        }

        public BookStore GetBookStoreWithMostBooksInInventory()
        {
            return Query()
                   .OrderByDescending(x => x.InventoryList.Sum(y => y.Amount))
                   .First();
        }
    }
}
