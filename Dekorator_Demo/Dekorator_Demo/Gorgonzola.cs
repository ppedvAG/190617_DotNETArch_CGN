namespace Dekorator_Demo
{
    class Gorgonzola : Dekorator
    {
        public Gorgonzola(IComponent parent) : base(parent) { }
        public override string Text => parent.Text + " Gorgonzola";
        public override decimal Preis => parent.Preis + 3.55m;
    }

}
