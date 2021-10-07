using System.Diagnostics;

namespace UnitSystems.SI
{
    using System;
    using Complex;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Kilogram : IUnit, IPrefixable, IReplicable<Kilogram>, IEquatable<Kilogram>, IComparable, IComparable<Kilogram>
    {
        public string Symbol => "kg";
        public Prefix Prefix => Prefix.Kilo;
        public double Value { get; }

        public Kilogram(double value)
        {
            Value = value;
        }

        public Kilogram(Gram value)
        : this()
        {
            Value = Prefixes.GetConversionFactor(value.Prefix, Prefix) * value.Value;
        }

        #region +/-

        public static Kilogram operator +(Kilogram kg1, Kilogram kg2)
        {
            return new(kg1.Value + kg2.Value);
        }

        public static Kilogram operator -(Kilogram kg1, Kilogram kg2)
        {
            return new(kg1.Value - kg2.Value);
        }

        #endregion

        #region */÷

        public static Kilogram operator *(Kilogram value, double multiplier)
        {
            return new Kilogram(value.Value * multiplier);
        }

        public static Kilogram operator *(double multiplier, Kilogram value)
        {
            return new Kilogram(value.Value * multiplier);
        }

        public static Kilogram operator /(Kilogram dividend, double divisor)
        {
            return new Kilogram(dividend.Value / divisor);
        }

        public static double operator /(Kilogram dividend, Kilogram divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region kg² = kg·kg

        public static SquareOf<Kilogram> operator *(Kilogram left, Kilogram right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region kg = kg² / kg

        public static Kilogram operator /(SquareOf<Kilogram> left, Kilogram right)
        {
            return new(left.Value / right.Value);
        }

        #endregion


        #region Casting/Conversion

        public static implicit operator Kilogram(double value)
        {
            return new(value);
        }

        public static explicit operator Kilogram(Gram value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation
        public Kilogram ReplicateFrom(double value)
        {
            return new Kilogram(value);
        }
        #endregion

        #region IEquatable implementation
        public bool Equals(Kilogram other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Kilogram other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }
        #endregion

        #region IComparable implementation
        public int CompareTo(Kilogram other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Kilogram left, Kilogram right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Kilogram left, Kilogram right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Kilogram left, Kilogram right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Kilogram left, Kilogram right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Kilogram left, Kilogram right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Kilogram left, Kilogram right)
        {
            return left.CompareTo(right) >= 0;
        }
        #endregion
    }
}