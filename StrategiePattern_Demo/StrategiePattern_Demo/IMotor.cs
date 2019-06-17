using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategiePattern_Demo
{
    interface IMotor
    {
        int Beschleunigen(int aktuelleGeschwindigkeit);
    }
}
