namespace ppedv.BV.Domain.Interfaces
{
    public interface IBookStoreRepository : IUniversalRepository<BookStore>
    {
        BookStore GetBookStoreWithHighestInventoryValue();
        BookStore GetBookStoreWithMostBooksInInventory();
    }
}
