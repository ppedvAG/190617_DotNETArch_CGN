using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Demo
{
    class Program
    {
        //static Program()
        //{
        //    logger = new Logger();
        //    logger = new Logger();
        //    logger = new Logger();
        //    logger = new Logger();
        //    logger = new Logger();
        //}
        //private static readonly Logger logger;

        static void Main(string[] args)
        {
            Parallel.For(0, 100000, i =>
              {
                  Logger.Instance.Log($"Hallo Welt {i}");
              });


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
