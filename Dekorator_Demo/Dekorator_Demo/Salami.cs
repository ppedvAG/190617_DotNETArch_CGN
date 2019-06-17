namespace Dekorator_Demo
{
    class Salami : Dekorator
    {
        public Salami(IComponent parent) : base(parent){}
        public override string Text => parent.Text + " Salami";
        public override decimal Preis => parent.Preis + 2m;
    }

}
