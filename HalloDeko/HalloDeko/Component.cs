namespace HalloDeko
{
    internal interface IComponent
    {
        string Name { get; }
        decimal Price { get; }
    }

    class Pizza : IComponent
    {
        public string Name => "Pizza";

        public decimal Price => 7m;
    }

    class Brot : IComponent
    {
        public string Name => "Brot";

        public decimal Price => 3m;
    }

    abstract class Deco : IComponent
    {
        protected readonly IComponent _parent;

        protected Deco(IComponent parent)
        {
            _parent = parent;
        }

        public abstract string Name { get; }
        public abstract decimal Price { get; }
    }

    class Käse : Deco
    {
        public Käse(IComponent parent) : base(parent)
        { }

        public override string Name => _parent.Name + " Käse";

        public override decimal Price => _parent.Price + 3m;
    }
    class Salami : Deco
    {
        public Salami(IComponent parent) : base(parent)
        { }

        public override string Name => _parent.Name + " Salami";

        public override decimal Price => _parent.Price + 4m;
    }
}
