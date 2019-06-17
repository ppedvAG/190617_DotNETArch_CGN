using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton_Demo
{
    class Logger
    {
        private Logger()
        {
            instanceCounter++;
        }

        private static object lockObject = new object();
        private static int instanceCounter;
        private static Logger instance;
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                            instance = new Logger();
                    }
                }

                return instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] [{instanceCounter}]: {message}");
        }
    }
}
