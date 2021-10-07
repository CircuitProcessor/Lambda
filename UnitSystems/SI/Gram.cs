namespace UnitSystems.SI
{
    using System;
    using System.Diagnostics;
    using Complex;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Gram : IUnit, IPrefixable, IReplicable<Gram>, IComparable, IComparable<Gram>, IEquatable<Gram>
    {
        public string Symbol => "g";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Gram(double value)
        {
            Value = value;
        }

        internal Gram(Kilogram unit)
            : this()
        {
            Value = Prefixes.GetConversionFactor(unit.Prefix, Prefix) * unit.Value;
        }

        #region +/-

        public static Gram operator +(Gram left, Gram right)
        {
            return new(left.Value + right.Value);
        }

        public static Gram operator -(Gram left, Gram right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Gram operator *(Gram unit, double multiplier)
        {
            return new Gram(unit.Value * multiplier);
        }

        public static Gram operator *(double multiplier, Gram unit)
        {
            return new Gram(unit.Value * multiplier);
        }

        public static Gram operator /(Gram dividend, double divisor)
        {
            return new Gram(dividend.Value / divisor);
        }

        public static double operator /(Gram dividend, Gram divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region g² = g·g

        public static SquareOf<Farad> operator *(Gram left, Gram right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region g = g² / g

        public static Gram operator /(SquareOf<Gram> left, Gram right)
        {
            return new(left.Value / right.Value);
        }

        #endregion


        #region Casting/Conversion

        public static implicit operator Gram(double value)
        {
            return new(value);
        }

        public static explicit operator Gram(Kilogram unit)
        {
            return new Gram(unit);
        }

        #endregion

        #region IReplicable implementation

        public Gram ReplicateFrom(double value)
        {
            return new Gram(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Gram other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Gram other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Gram other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Gram left, Gram right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Gram left, Gram right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Gram left, Gram right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Gram left, Gram right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Gram left, Gram right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Gram left, Gram right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}