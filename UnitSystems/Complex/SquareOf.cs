namespace UnitSystems.Complex
{
    using SI;

    public readonly struct SquareOf<T1> : IUnit, IReplicable<SquareOf<T1>>
        where T1 : struct, IUnit, IReplicable<T1>
    {
        public string Symbol => default(T1).Symbol + "²";
        public double Value { get; }


        public SquareOf(T1 unit)
            : this(unit.Value * unit.Value)
        {
        }

        public SquareOf(double value)
        {
            Value = value;
        }

        public static T1 operator /(SquareOf<T1> square, T1 divider)
        {
            var result = default(T1).ReplicateFrom(square.Value / divider.Value);
            return result;
        }

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

        public SquareOf<T1> ReplicateFrom(double value)
        {
            return new SquareOf<T1>(value);
        }
    }
}