namespace UnitSystems.SI
{
    using Complex;
    using System;
    using System.Diagnostics;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Newton : IUnit, IPrefixable, IReplicable<Newton>, IComparable, IComparable<Newton>,
        IEquatable<Newton>
    {
        public string Symbol => "N";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Newton(double value)
        {
            Value = value;
        }

        #region +/-

        public static Newton operator +(Newton left, Newton right)
        {
            return new(left.Value + right.Value);
        }

        public static Newton operator -(Newton left, Newton right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Newton operator *(Newton unit, double multiplier)
        {
            return new Newton(unit.Value * multiplier);
        }

        public static Newton operator *(double multiplier, Newton unit)
        {
            return new Newton(unit.Value * multiplier);
        }

        public static Newton operator /(Newton dividend, double divisor)
        {
            return new Newton(dividend.Value / divisor);
        }

        public static double operator /(Newton dividend, Newton divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region N² = N·N

        public static SquareOf<Newton> operator *(Newton left, Newton right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region N = N² / N

        public static Newton operator /(SquareOf<Newton> left, Newton right)
        {
            return new(left.Value / right.Value);
        }

        #endregion

        #region J = N∙m
        public static Joule operator *(Newton newton, Metre metre)
        {
            return new(newton.Value * metre.Value);
        }
        #endregion

        #region T = N/A∙m
        public static Tesla operator /(Newton newton, ProductOf<Ampere, Metre> ampereMetre)
        {
            return new(newton.Value / ampereMetre.Value);
        }
        #endregion

        #region N = kg∙m/s² (SI Base)
        public static implicit operator ProductOf<Kilogram, QuotientOf<Metre, SquareOf<Second>>>(Newton unit)
        {
            return new(unit.Value);
        }

        public static implicit operator Newton(ProductOf<Kilogram, QuotientOf<Metre, SquareOf<Second>>> unit)
        {
            return new(unit.Value);
        }
        #endregion


        #region Casting/Conversion

        public static implicit operator Newton(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Newton ReplicateFrom(double value)
        {
            return new Newton(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Newton other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Newton other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Newton other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Newton left, Newton right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Newton left, Newton right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Newton left, Newton right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Newton left, Newton right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Newton left, Newton right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Newton left, Newton right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}