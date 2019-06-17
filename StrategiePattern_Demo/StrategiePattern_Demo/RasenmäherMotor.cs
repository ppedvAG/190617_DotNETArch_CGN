namespace StrategiePattern_Demo
{
    class RasenmäherMotor : IMotor
    {
        private const int max_geschwindigkeit = 30;
        public int Beschleunigen(int aktuelleGeschwindigkeit)
        {
            if (aktuelleGeschwindigkeit + 3 < max_geschwindigkeit)
                return aktuelleGeschwindigkeit + 3;
            else
                return max_geschwindigkeit;
        }
    }
}
