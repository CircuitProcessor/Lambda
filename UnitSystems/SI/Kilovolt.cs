namespace UnitSystems.SI
{
    using System;
    using System.Diagnostics;
    using UnitSystems;

    [DebuggerDisplay("Value = {_value} {Symbol,nq}")]
    public readonly struct Kilovolt : IUnit, IEquatable<Kilovolt>, IComparable<Kilovolt>, IPrefixable, IReplicable<Kilovolt>
    {
        private readonly double _value;

        double IUnit.Value => _value;

        public string Symbol => "kV";

        public Kilovolt(double value)
        {
            _value = value;
        }

        public Kilovolt(Volt volt)
            : this(volt.Value, volt.Prefix)
        {
        }


        private Kilovolt(double value, Prefix from)
        {
            _value = value * Prefixes.GetConversionFactor(from, to: Prefix.Kilo);
        }

        #region */÷

        public static Kilovolt operator *(Kilovolt value, double multiplier)
        {
            return new Kilovolt(value._value * multiplier);
        }

        public static Kilovolt operator *(double multiplier, Kilovolt value)
        {
            return new Kilovolt(value._value * multiplier);
        }

        public static Kilovolt operator /(Kilovolt dividend, double divisor)
        {
            return new Kilovolt(dividend._value / divisor);
        }

        public static double operator /(Kilovolt dividend, Kilovolt divisor)
        {
            return dividend._value / divisor._value;
        }

        public static Farad operator /(ProductOf<Kilovolt, Farad> dividend, Kilovolt divisor)
        {
            return new Farad(dividend.Value / divisor._value);
        }

        public static Farad operator /(ProductOf<Farad, Kilovolt> dividend, Kilovolt divisor)
        {
            return new Farad(dividend.Value / divisor._value);
        }

        #endregion */÷

        #region +/-

        public static Kilovolt operator +(Kilovolt left, Kilovolt right)
        {
            return new Kilovolt(left._value + right._value);
        }

        public static Kilovolt operator -(Kilovolt left, Kilovolt right)
        {
            return new Kilovolt(left._value - right._value);
        }

        #endregion +/-

        #region Casting operators

        public static explicit operator double(Kilovolt value)
        {
            return value._value;
        }

        public static implicit operator Kilovolt(double value)
        {
            return new Kilovolt(value);
        }

        public static implicit operator Kilovolt(Volt value)
        {
            return new Kilovolt(value);
        }


        #endregion Casting operators

        #region IEquatable implementation

        public bool Equals(Kilovolt other) => _value.Equals(other._value);

        public override bool Equals(object obj)
        {
            if (obj is Kilovolt other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int baseHashCode = -2_039_883_636;
                const int multiplier = -1_521_134_295;
                var hashCode = baseHashCode * multiplier ^ _value.GetHashCode();
                hashCode = hashCode * multiplier ^ Symbol.GetHashCode();
                hashCode = hashCode * multiplier ^ Prefix.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Kilovolt left, Kilovolt right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Kilovolt left, Kilovolt right)
        {
            return !left.Equals(right);
        }

        #endregion IEquatable implementation

        #region IComparable implementation

        public int CompareTo(Kilovolt other) => _value.CompareTo(other._value);

        public static bool operator <(Kilovolt left, Kilovolt right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Kilovolt left, Kilovolt right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Kilovolt left, Kilovolt right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Kilovolt left, Kilovolt right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion IComparable implementation

        #region IPrefixable implementation

        public Prefix Prefix => Prefix.Kilo;

        #endregion IPrefixable implementation

        #region IReplicable implementation

        public Kilovolt ReplicateFrom(double value) => value;

        #endregion IReplicable implementation
    }
}
