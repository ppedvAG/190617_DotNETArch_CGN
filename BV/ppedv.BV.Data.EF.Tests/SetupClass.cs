using AutoFixture;
using NUnit.Framework;
using ppedv.BV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.BV.Data.EF.Tests
{
    [SetUpFixture] // Gilt für alle Klassen im Namespace
    public class SetupClass
    {
        public const string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BV_Tests;Trusted_Connection=true;AttachDbFilename=C:\temp\BV_Test.mdf";
        public static Fixture Fixture { get; private set; }

        public static List<BookStore> BookStores;

        [OneTimeSetUp]
        public void RunBeforeAllTests()
        {
            Fixture = new Fixture();
            BookStores = Fixture.CreateMany<BookStore>(10).ToList();
            using (var context = new EFContext(connectionString))
            {
                if (context.Database.Exists())
                    context.Database.Delete();

                context.Database.Create();
            }
        }

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            using (var context = new EFContext(connectionString))
            {
                if (context.Database.Exists())
                    context.Database.Delete();
            }
        }
    }
}
