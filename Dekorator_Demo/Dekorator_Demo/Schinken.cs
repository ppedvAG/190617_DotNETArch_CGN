namespace Dekorator_Demo
{
    class Schinken : Dekorator
    {
        public Schinken(IComponent parent) : base(parent) { }
        public override string Text => parent.Text + " Schinken";
        public override decimal Preis => parent.Preis + 3m;
    }

}
