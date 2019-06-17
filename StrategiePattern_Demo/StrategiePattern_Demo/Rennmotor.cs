namespace StrategiePattern_Demo
{
    class Rennmotor : IMotor
    {
        private const int max_geschwindigkeit = 300;
        public int Beschleunigen(int aktuelleGeschwindigkeit)
        {
            if (aktuelleGeschwindigkeit + 30 < max_geschwindigkeit)
                return aktuelleGeschwindigkeit + 30;
            else
                return max_geschwindigkeit;
        }
    }
}
