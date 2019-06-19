using ppedv.BV.Domain;
using ppedv.BV.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.BV.Data.EF
{
    public class EFBookRepository : EFUniversalRepository<Book>, IBookRepository 
    {
        public EFBookRepository(EFContext context) : base(context){}

        public Book GetBookWithHighestPrice()
        {
            return Query()
                   .OrderByDescending(x => x.Price)
                   .First();
        }

        public int GetTotalAmountOfBooksInCirculation(Book b)
        {
            return context.Inventory
                          .Where(x => x.ID == b.ID)
                          .Sum(x => x.Amount);
        }
    }
}
