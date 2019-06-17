namespace Dekorator_Demo
{
    class Pizza : IComponent // Root-Element
    {
        public string Text => "Pizza";
        public decimal Preis => 5m;
    }

}
