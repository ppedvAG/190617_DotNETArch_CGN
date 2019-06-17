using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Demo
{
    class Logger
    {

        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}]: {message}");
        }
    }
}
