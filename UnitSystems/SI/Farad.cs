namespace UnitSystems.SI
{
    using System;
    using System.Diagnostics;
    using UnitSystems;
    using UnitSystems.Complex;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Farad : IUnit, IPrefixable, IReplicable<Farad>, IComparable, IComparable<Farad>, IEquatable<Farad>
    {
        public string Symbol => "F";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Farad(double value)
        {
            Value = value;
        }

        #region +/-

        public static Farad operator +(Farad left, Farad right)
        {
            return new(left.Value + right.Value);
        }

        public static Farad operator -(Farad left, Farad right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Farad operator *(Farad unit, double multiplier)
        {
            return new Farad(unit.Value * multiplier);
        }

        public static Farad operator *(double multiplier, Farad unit)
        {
            return new Farad(unit.Value * multiplier);
        }

        public static Farad operator /(Farad dividend, double divisor)
        {
            return new Farad(dividend.Value / divisor);
        }

        public static double operator /(Farad dividend, Farad divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region F² = F·F

        public static SquareOf<Farad> operator *(Farad left, Farad right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region F = F² / F

        public static Farad operator /(SquareOf<Farad> left, Farad right)
        {
            return new(left.Value / right.Value);
        }

        #endregion

        #region F = C² / J
        public static implicit operator QuotientOf<SquareOf<Coulomb>, Joule>(Farad farad)
        {
            return new QuotientOf<SquareOf<Coulomb>, Joule>(farad.Value);
        }

        public static implicit operator Farad(QuotientOf<SquareOf<Coulomb>, Joule> unit)
        {
            return new(unit.Value);
        }
        #endregion


        #region Casting/Conversion

        public static implicit operator Farad(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Farad ReplicateFrom(double value)
        {
            return new Farad(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Farad other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Farad other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Farad other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Farad left, Farad right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Farad left, Farad right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Farad left, Farad right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Farad left, Farad right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Farad left, Farad right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Farad left, Farad right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }
}