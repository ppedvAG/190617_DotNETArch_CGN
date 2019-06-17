namespace StrategiePattern_Demo
{
    class Holzklötze : IBremse
    {

        public int Bremsen(int aktuelleGeschwindigkeit)
        {
            if (aktuelleGeschwindigkeit - 5 > 0)
                return aktuelleGeschwindigkeit - 5;
            else
                return 0;
        }
    }
}
