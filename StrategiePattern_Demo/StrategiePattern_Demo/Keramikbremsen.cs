namespace StrategiePattern_Demo
{
    class Keramikbremsen : IBremse
    {
        public int Bremsen(int aktuelleGeschwindigkeit)
        {
            if (aktuelleGeschwindigkeit - 50 > 0)
                return aktuelleGeschwindigkeit - 50;
            else
                return 0;
        }
    }
}
