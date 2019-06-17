namespace Dekorator_Demo
{
    abstract class Dekorator : IComponent
    {
        public Dekorator(IComponent parent)
        {
            this.parent = parent;
        }
        protected readonly IComponent parent;

        public abstract string Text { get; }
        public abstract decimal Preis { get; }
    }

}
