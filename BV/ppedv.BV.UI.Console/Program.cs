using ppedv.BV.Data.EF;
using ppedv.BV.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.BV.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BV_Produktiv;Trusted_Connection=true;AttachDbFilename=C:\temp\BV.mdf";
            var core = new Core(new EFRepository(new EFContext(connectionString)));

            // core.CreateNewBookStore();

            var store = core.GetBookStoreWithHighestInventoryValue();

            System.Console.WriteLine(store.ID);
            System.Console.WriteLine(store.Address);
            foreach (var item in store.InventoryList)
            {
                System.Console.WriteLine($"{item.Book.Title}: {item.Amount}");
            }

            System.Console.WriteLine("---ENDE---");
            System.Console.ReadKey();
        }
    }
}
