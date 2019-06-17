using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_Demo
{
    class Kantine
    {
        public IEssen GibEssen() => GibEssen(DateTime.Now);
        public IEssen GibEssen(DateTime currentTime)
        {
            switch (currentTime.Hour)
            {
                case int h when h >= 6 && h < 11:
                    return new Frühstück();
                case int h when h >= 11 && h < 16:
                    return new Mittagessen();
                case int h when h >= 16 && h < 22:
                    return new Abendessen();
                default:
                    return new KeinEssen(); // Tür zu
            }
        }
    }
}
