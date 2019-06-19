using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF_Demo
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

    class MSPaint
    {
        public IGrafik Zeichnung { get; set; }
    }
}
