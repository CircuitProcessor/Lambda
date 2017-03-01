using UnitSystems.Interfaces;
using UnitSystems.SI;

namespace UnitSystems
{
    struct SquareOf<T1> : IUnit where T1 : IUnit
    {
        private readonly T1 _unit1;
        public double _value;

        public SquareOf(T1 unit) : this(unit, unit.Value * unit.Value)
        {
            //unit²
        }

        public SquareOf(T1 unit1, double value)
        {
            _unit1 = unit1;
            _value = value;
        }

        public static T1 operator /(SquareOf<T1> square, T1 divider)
        {
            var def = default(T1);
            def.Value = square.Value / divider.Value;
            return def;
        }

        public static QuotientOf<SquareOf<T1>, Joule> operator /(SquareOf<T1> square, Joule joule)
        {
            return new QuotientOf<SquareOf<T1>, Joule>(square, joule);
        }

        public static ProductOf<Kilogram, SquareOf<T1>> operator *(SquareOf<T1> source, Kilogram kilogram)
        {
            return new ProductOf<Kilogram, SquareOf<T1>>(kilogram, source);
        }
        public static ProductOf<Kilogram, SquareOf<T1>> operator *(Kilogram kilogram, SquareOf<T1> source)
        {
            return new ProductOf<Kilogram, SquareOf<T1>>(kilogram, source);
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string Symbol
        {
            get { return _unit1.Symbol + "^2"; }
        }

    }
}