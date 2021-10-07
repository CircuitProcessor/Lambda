namespace UnitSystems.Complex
{
    public struct QuotientOf<T1, T2> : IUnit, IReplicable<QuotientOf<T1,T2>>
        where T1 : struct, IUnit, IReplicable<T1>
        where T2 : struct, IUnit, IReplicable<T2>
    {
        public string Symbol => $"{_unit1.Symbol}/{_unit2.Symbol}";
        public double Value { get; }

        private T1 _unit1;
        private T2 _unit2;


        public QuotientOf(T1 unit1, T2 unit2)
            : this(unit1.Value / unit2.Value)
        {
        }

        public QuotientOf(double value)
        {
            _unit1 = default;
            _unit2 = default;
            Value = value;
        }

        public static T1 operator *(T2 left, QuotientOf<T1, T2> right)
        {
            var result = right.Value * left.Value;
            var resultUnit = default(T1).ReplicateFrom(result);
            return resultUnit;
        }

        public static T1 operator *(QuotientOf<T1, T2> left, T2 right)
        {
            var result = left.Value * right.Value;
            var resultUnit = default(T1).ReplicateFrom(result);
            return resultUnit;
        }


        public static ProductOf<T1, T2> operator *(QuotientOf<T1, T2> quotient, SquareOf<T2> square)
        {
            var result = new ProductOf<T1, T2>(quotient.Value * square.Value);
            return result;
        }


        public QuotientOf<T1, T2> ReplicateFrom(double value)
        {
            return new QuotientOf<T1, T2>(value);
        }
    }
}