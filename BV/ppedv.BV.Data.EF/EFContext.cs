using ppedv.BV.Domain;
using System;
using System.Data.Entity;
using System.Reflection;

namespace ppedv.BV.Data.EF
{
    public class EFContext : DbContext
    {
        public EFContext() : this(@"Server=(localdb)\MSSQLLocalDB;Database=BV;Trusted_Connection=true;AttachDbFilename=C:\temp\BV.mdf") { }
        public EFContext(string connectionString) : base(connectionString) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<BookStore> BookStore { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // https://stackoverflow.com/questions/37025216/code-first-in-entity-framework-set-column-to-type-datetime2-in-sql-server
            modelBuilder.Entity<Book>()
                        .Property(p => p.PublishedDate)
                        .HasColumnType("datetime2");

            // ToDo: Per Reflection alle Datentypen in der Domain prüfen ob die ein Prop. als DateTime haben
            // und dann überall den ColumnType wie oben setzen
        }
    }
}
