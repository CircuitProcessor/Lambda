namespace UnitSystems.SI
{
    using System;
    using System.Diagnostics;
    using Complex;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Joule : IUnit, IPrefixable, IReplicable<Joule>, IComparable, IComparable<Joule>,
        IEquatable<Joule>
    {
        public string Symbol => "J";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Joule(double value)
        {
            Value = value;
        }

        #region +/-

        public static Joule operator +(Joule left, Joule right)
        {
            return new(left.Value + right.Value);
        }

        public static Joule operator -(Joule left, Joule right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Joule operator *(Joule unit, double multiplier)
        {
            return new Joule(unit.Value * multiplier);
        }

        public static Joule operator *(double multiplier, Joule unit)
        {
            return new Joule(unit.Value * multiplier);
        }

        public static Joule operator /(Joule dividend, double divisor)
        {
            return new Joule(dividend.Value / divisor);
        }

        public static double operator /(Joule dividend, Joule divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region J² = J·J

        public static SquareOf<Joule> operator *(Joule left, Joule right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region J = J² / J

        public static Joule operator /(SquareOf<Joule> left, Joule right)
        {
            return new(left.Value / right.Value);
        }

        #endregion

        #region W = J/s
        public static Watt operator /(Joule joule, Second sec)
        {
            return new(joule.Value * sec.Value);
        }
        #endregion

        #region W = J/A
        public static Weber operator /(Joule joule, Ampere ampere)
        {
            return new(joule.Value / ampere.Value);
        }
        #endregion


        #region Casting/Conversion

        public static implicit operator Joule(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Joule ReplicateFrom(double value)
        {
            return new Joule(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Joule other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Joule other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Joule other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Joule left, Joule right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Joule left, Joule right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Joule left, Joule right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Joule left, Joule right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Joule left, Joule right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Joule left, Joule right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}