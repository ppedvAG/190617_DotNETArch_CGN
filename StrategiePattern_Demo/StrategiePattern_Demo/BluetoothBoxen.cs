using System;

namespace StrategiePattern_Demo
{
    class BluetoothBoxen : IAudioSystem
    {
        public void SpieleMusikAb()
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            System.Console.WriteLine("beeeep ");
        }
    }
}
