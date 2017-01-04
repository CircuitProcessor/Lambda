using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    struct Metre : IUnit
    {
        public double Value { get; set; }
        public string Symbol
        {
            get { return "m"; }
        }


        public static Metre operator +(Metre metre1, Metre metre2)
        {
            return new Metre() { Value = metre1.Value + metre2.Value };
        }
        public static Metre operator -(Metre metre1, Metre metre2)
        {
            return new Metre() { Value = metre1.Value - metre2.Value };
        }


        public static implicit operator Metre(double value)
        {
            return new Metre() { Value = value };
        }

        public static SquareOf<Metre> operator ^(Metre source, int expo)
        {
            return new SquareOf<Metre>(source);
        }
    }
}