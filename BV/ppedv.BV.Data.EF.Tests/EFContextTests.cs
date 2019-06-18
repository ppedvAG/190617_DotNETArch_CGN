using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using ppedv.BV.Domain;

namespace ppedv.BV.Data.EF.Tests
{
    [TestFixture]
    public class EFContextTests
    {
        // AAA - Prinzip
        // Arrange, Act, Assert

        // Namensgebung von Testmethoden:
        // NameDerKlasse_NameDerMethode_Szenario_ErwartetesErgebnis
        // Beispiel: Taschenrechner_Sum_2_and_2_results_4

        [Test]
        public void EFContext_can_create_context()
        {
            var context = new EFContext(SetupClass.connectionString);
        }

        [Test]
        public void EFContext_can_create_database()
        {
            using (var context = new EFContext(SetupClass.connectionString))
            {
                if (context.Database.Exists())
                    context.Database.Delete();

                context.Database.Exists().Should().BeFalse();
                //Assert.IsFalse(context.Database.Exists());

                context.Database.Create();


                context.Database.Exists().Should().BeTrue();
                //Assert.IsTrue(context.Database.Exists());
            }
        }

        // CRUD -> Create, Read, Update, Delete

        [Test]
        public void EFContext_can_insert_Book()
        {
            var b1 = SetupClass.BookStores[0].InventoryList.ElementAt(0).Book;

            using(var context = new EFContext(SetupClass.connectionString))
            {
                context.Book.Add(b1);
                context.SaveChanges();
            }

            using (var context = new EFContext(SetupClass.connectionString))
            {
                var loadedBook = context.Book.Find(b1.ID);
                // Assert.AreEqual(loadedBook.ISBN, b1.ISBN);
                loadedBook.Should().BeEquivalentTo(b1); // Vergleicht jedes Property
            }
        }

        [Test]
        public void EFContext_can_update_Book()
        {
            var b1 = SetupClass.BookStores[0].InventoryList.ElementAt(1).Book;
            string newTitle = SetupClass.Fixture.Create<string>();

            using (var context = new EFContext(SetupClass.connectionString))
            {
                context.Book.Add(b1);
                context.SaveChanges();
            }

            using (var context = new EFContext(SetupClass.connectionString))
            {
                var loadedBook = context.Book.Find(b1.ID);
                loadedBook.Title = newTitle;
                context.SaveChanges();
            }

            using (var context = new EFContext(SetupClass.connectionString))
            {
                var loadedBook = context.Book.Find(b1.ID);
                loadedBook.Title.Should().Be(newTitle); 
            }
        }

        [Test]
        public void EFContext_can_delete_Book()
        {
            var b1 = SetupClass.BookStores[0].InventoryList.ElementAt(2).Book;

            using (var context = new EFContext(SetupClass.connectionString))
            {
                context.Book.Add(b1);
                context.SaveChanges();
            }

            using (var context = new EFContext(SetupClass.connectionString))
            {
                var loadedBook = context.Book.Find(b1.ID);
                context.Book.Remove(loadedBook);
                context.SaveChanges();
            }

            using (var context = new EFContext(SetupClass.connectionString))
            {
                var loadedBook = context.Book.Find(b1.ID);
                loadedBook.Should().BeNull();
            }
        }

    }
}
