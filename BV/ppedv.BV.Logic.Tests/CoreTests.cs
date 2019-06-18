using Moq;
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
        [Fact]
        [Trait("Unittest","")]
        public void Core_CreateNewBookStore_calls_RepositoryAdd_5_times_and_saves_changes()
        {
            var mock = new Mock<IRepository>(); // Fakeimplementierung der Schnittstelle
            var core = new Core(mock.Object);

            core.CreateNewBookStore();
            // Irgendwie prüfen, dass vom Repository 5 mal "Add()" ausgeführt wurde und dass gespeichert wurde

            mock.Verify(x => x.Add(It.IsAny<BookStore>()), Times.Exactly(5));
            mock.Verify(x => x.Save(), Times.AtLeastOnce());
        }
    }
}
