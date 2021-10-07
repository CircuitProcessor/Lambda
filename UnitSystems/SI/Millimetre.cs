namespace UnitSystems.SI
{
    using System;
    using System.Diagnostics;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Millimetre : IUnit, IPrefixable, IReplicable<Millimetre>, IComparable, IComparable<Millimetre>, IEquatable<Millimetre>
    {
        public string Symbol => "mm";
        public Prefix Prefix => Prefix.Milli;
        public double Value { get; }

        public Millimetre(double value)
        {
            Value = value;
        }

        internal Millimetre(Metre unit)
            : this()
        {
            Value = Prefixes.GetConversionFactor(unit.Prefix, Prefix) * unit.Value;
        }

        #region +/-

        public static Millimetre operator +(Millimetre left, Millimetre right)
        {
            return new(left.Value + right.Value);
        }

        public static Millimetre operator -(Millimetre left, Millimetre right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Millimetre operator *(Millimetre unit, double multiplier)
        {
            return new Millimetre(unit.Value * multiplier);
        }

        public static Millimetre operator *(double multiplier, Millimetre unit)
        {
            return new Millimetre(unit.Value * multiplier);
        }

        public static Millimetre operator /(Millimetre dividend, double divisor)
        {
            return new Millimetre(dividend.Value / divisor);
        }

        public static double operator /(Millimetre dividend, Millimetre divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region Casting/Conversion

        public static implicit operator Millimetre(double value)
        {
            return new(value);
        }

        public static explicit operator Millimetre(Metre unit)
        {
            return new Millimetre(unit);
        }

        #endregion


        #region IReplicable implementation

        public Millimetre ReplicateFrom(double value)
        {
            return new Millimetre(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Millimetre other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Millimetre other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Millimetre other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Millimetre left, Millimetre right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Millimetre left, Millimetre right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Millimetre left, Millimetre right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Millimetre left, Millimetre right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Millimetre left, Millimetre right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Millimetre left, Millimetre right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}