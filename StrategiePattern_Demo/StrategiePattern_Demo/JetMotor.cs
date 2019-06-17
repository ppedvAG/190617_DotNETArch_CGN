namespace StrategiePattern_Demo
{
    class JetMotor : IMotor
    {
        private const int max_geschwindigkeit = 2000;
        public int Beschleunigen(int aktuelleGeschwindigkeit)
        {
            if (aktuelleGeschwindigkeit + 100 < max_geschwindigkeit)
                return aktuelleGeschwindigkeit + 100;
            else
                return max_geschwindigkeit;
        }
    }
}
