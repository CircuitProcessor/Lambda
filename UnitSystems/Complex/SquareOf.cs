namespace UnitSystems.SI.Complex
{
    public readonly struct SquareOf<T1> : IUnit where T1 : struct, IUnit
    {
        public SquareOf(T1 unit)
        {
            Value = unit.Value * unit.Value;
        }

        //public static T1 operator /(SquareOf<T1> square, T1 divider)
        //{
        //    var def = default(T1);
        //    def.Value = square.Value / divider.Value;
        //    return def;
        //}

        public static QuotientOf<SquareOf<T1>, Joule> operator /(SquareOf<T1> square, Joule joule)
        {
            return new(square, joule);
        }

        

        public static ProductOf<Kilogram, SquareOf<T1>> operator *(SquareOf<T1> source, Kilogram kilogram)
        {
            return new(kilogram, source);
        }
        public static ProductOf<Kilogram, SquareOf<T1>> operator *(Kilogram kilogram, SquareOf<T1> source)
        {
            return new(kilogram, source);
        }

        public double Value { get; }

        public string Symbol => default(T1).Symbol + "²";
    }
}