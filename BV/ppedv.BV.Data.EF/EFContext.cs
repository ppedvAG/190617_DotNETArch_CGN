using ppedv.BV.Domain;
using System;
using System.Data.Entity;

namespace ppedv.BV.Data.EF
{
    public class EFContext : DbContext
    {
        public EFContext() : this(@"Server=(localdb)\MSSQLLocalDB;Database=BV;Trusted_Connection=true") {}
        public EFContext(string connectionString) : base(connectionString){}

        public DbSet<Book> Book { get; set; }
        public DbSet<BookStore> BookStore { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
    }
}
