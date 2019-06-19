namespace ppedv.BV.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IBookStoreRepository BookStoreRepository { get; }
        IUniversalRepository<T> GetRepository<T>() where T : Entity;
        void Save();
    }
}
