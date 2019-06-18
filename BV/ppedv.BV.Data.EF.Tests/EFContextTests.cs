using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ppedv.BV.Data.EF.Tests
{
    [TestFixture]
    public class EFContextTests
    {
        private const string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BV_Tests;Trusted_Connection=true;AttachDbFilename=C:\temp\BV_Test.mdf";
        // AAA - Prinzip
        // Arrange, Act, Assert

        // Namensgebung von Testmethoden:
        // NameDerKlasse_NameDerMethode_Szenario_ErwartetesErgebnis
        // Beispiel: Taschenrechner_Sum_2_and_2_results_4

        [Test]
        public void EFContext_can_create_context()
        {
            var context = new EFContext(connectionString);
        }

        [Test]
        public void EFContext_can_create_database()
        {
            using (var context = new EFContext(connectionString))
            {
                if (context.Database.Exists())
                    context.Database.Delete();

                Assert.IsFalse(context.Database.Exists());

                context.Database.Create();

                Assert.IsTrue(context.Database.Exists());
            }
        }


    }
}
