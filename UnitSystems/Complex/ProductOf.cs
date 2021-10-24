namespace UnitSystems.Complex
{
    using System.Diagnostics;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct ProductOf<T1, T2> : IUnit, IReplicable<ProductOf<T1, T2>>
        where T1 : struct, IUnit, IReplicable<T1>
        where T2 : struct, IUnit, IReplicable<T2>
    {
        public string Symbol => $"{default(T1).Symbol}·{default(T2).Symbol}";
        public double Value { get; }

        public ProductOf(T1 unit1, T2 unit2)
            : this(unit1.Value * unit2.Value)
        {
        }

        public ProductOf(double value)
        {
            Value = value;
        }

        public static T1 operator /(ProductOf<T1, T2> left, T2 right)
        {
            var result = default(T1).ReplicateFrom(left.Value / right.Value);
            return result;
        }

        public static T2 operator /(ProductOf<T1, T2> source, T1 unit)
        {
            var result = default(T2).ReplicateFrom(source.Value / unit.Value);
            return result;
        }

        public ProductOf<T1, T2> ReplicateFrom(double value)
        {
            return new(value);
        }
    }
}