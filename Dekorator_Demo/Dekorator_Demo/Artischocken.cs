namespace Dekorator_Demo
{
    class Artischocken : Dekorator
    {
        public Artischocken(IComponent parent) : base(parent) { }
        public override string Text => parent.Text + " Artischocken";
        public override decimal Preis => parent.Preis + 10m;
    }

}
