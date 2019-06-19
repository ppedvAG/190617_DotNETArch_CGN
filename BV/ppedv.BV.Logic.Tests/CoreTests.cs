using AutoFixture;
using FluentAssertions;
using Moq;
using ppedv.BV.Data.EF;
using ppedv.BV.Domain;
using ppedv.BV.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ppedv.BV.Logic.Tests
{

    public class CoreTests
    {
        public const string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BV_Tests;Trusted_Connection=true;AttachDbFilename=C:\temp\BV_Test.mdf";

        [Fact]
        [Trait("Unittest","")]
        public void Core_CreateNewBookStore_calls_RepositoryAdd_5_times_and_saves_changes()
        {
            var mock = new Mock<IUnitOfWork>(); // Fakeimplementierung der Schnittstelle
            var repository = new Mock<IBookStoreRepository>(); // Fakeimplementierung der Schnittstelle
            mock.Setup(x => x.BookStoreRepository)
                .Returns(() => repository.Object);

            var core = new Core(mock.Object);

            core.CreateNewBookStore();
            // Irgendwie prüfen, dass vom Repository 5 mal "Add()" ausgeführt wurde und dass gespeichert wurde

            repository.Verify(x => x.Add(It.IsAny<BookStore>()), Times.Exactly(5));
            mock.Verify(x => x.Save(), Times.AtLeastOnce());
        }

        [Fact]
        [Trait("Integrationstest","")]
        public void Core_can_CreateNewBookStore()
        {
            var unitOfWork = new EFUnitOfWork(new EFContext(connectionString));
            var core = new Core(unitOfWork);

            var oldCount = unitOfWork.BookStoreRepository.Query().Count(); 
            core.CreateNewBookStore();
            var newCount = unitOfWork.BookStoreRepository.Query().Count();

            newCount.Should().Be(oldCount + 5);
        }

        [Fact]
        [Trait("Unittest","")]
        public void Core_GetBookStoreWithHighestInventoryValue_returns_correct_result()
        {
            Fixture fix = new Fixture();
            var mockData = fix.CreateMany<BookStore>(3);
            // Ergebnis:
            mockData.ElementAt(2).InventoryList.ElementAt(0).Book.Price = 999999999999m;
            mockData.ElementAt(2).InventoryList.ElementAt(0).Amount = Int32.MaxValue;

            var mock = new Mock<IUnitOfWork>(); // Fakeimplementierung der Schnittstelle
            mock.Setup(x => x.BookStoreRepository.Query())
                .Returns(() => mockData.AsQueryable());

            var core = new Core(mock.Object);

            var result = core.GetBookStoreWithHighestInventoryValue();
            // Irgendwie prüfen, dass vom Repository 5 mal "Add()" ausgeführt wurde und dass gespeichert wurde

            result.Should().Be(mockData.ElementAt(2));
            mock.Verify(x => x.BookStoreRepository.Query(), Times.AtLeastOnce());
        }

    }
}
