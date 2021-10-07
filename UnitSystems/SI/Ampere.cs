namespace UnitSystems.SI
{
    using System;
    using System.Diagnostics;
    using Complex;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Ampere : IUnit, IPrefixable, IReplicable<Ampere>, IComparable, IComparable<Ampere>, IEquatable<Ampere>
    {
        public string Symbol => "symbol";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Ampere(double value)
        {
            Value = value;
        }

        #region +/-

        public static Ampere operator +(Ampere left, Ampere right)
        {
            return new(left.Value + right.Value);
        }

        public static Ampere operator -(Ampere left, Ampere right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Ampere operator *(Ampere unit, double multiplier)
        {
            return new Ampere(unit.Value * multiplier);
        }

        public static Ampere operator *(double multiplier, Ampere unit)
        {
            return new Ampere(unit.Value * multiplier);
        }

        public static Ampere operator /(Ampere dividend, double divisor)
        {
            return new Ampere(dividend.Value / divisor);
        }

        public static double operator /(Ampere dividend, Ampere divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region V = A·Ω
        public static Volt operator *(Ampere ampere, Ohm ohm)
        {
            return new(ampere.Value * ohm.Value);
        }
        #endregion

        #region A² = A·A
        public static SquareOf<Ampere> operator *(Ampere left, Ampere right)
        {
            return new(left.Value * right.Value);
        }
        #endregion


        #region Casting/Conversion

        public static implicit operator Ampere(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Ampere ReplicateFrom(double value)
        {
            return new Ampere(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Ampere other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Ampere other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Ampere other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Ampere left, Ampere right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Ampere left, Ampere right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Ampere left, Ampere right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Ampere left, Ampere right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Ampere left, Ampere right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Ampere left, Ampere right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}