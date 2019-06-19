using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.BV.Domain.Interfaces
{
    public interface IBookRepository : IUniversalRepository<Book>
    {
        Book GetBookWithHighestPrice();
        int GetTotalAmountOfBooksInCirculation(Book b);
    }
}
