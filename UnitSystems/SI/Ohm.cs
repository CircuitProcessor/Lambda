namespace UnitSystems.SI
{
    using Complex;
    using System;
    using System.Diagnostics;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Ohm : IUnit, IPrefixable, IReplicable<Ohm>, IComparable, IComparable<Ohm>, IEquatable<Ohm>
    {
        public string Symbol => "Ω";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Ohm(double value)
        {
            Value = value;
        }

        #region +/-

        public static Ohm operator +(Ohm left, Ohm right)
        {
            return new(left.Value + right.Value);
        }

        public static Ohm operator -(Ohm left, Ohm right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Ohm operator *(Ohm unit, double multiplier)
        {
            return new Ohm(unit.Value * multiplier);
        }

        public static Ohm operator *(double multiplier, Ohm unit)
        {
            return new Ohm(unit.Value * multiplier);
        }

        public static Ohm operator /(Ohm dividend, double divisor)
        {
            return new Ohm(dividend.Value / divisor);
        }

        public static double operator /(Ohm dividend, Ohm divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region Ω² = Ω·Ω

        public static SquareOf<Ohm> operator *(Ohm left, Ohm right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region Ω = Ω² / Ω

        public static Ohm operator /(SquareOf<Ohm> left, Ohm right)
        {
            return new(left.Value / right.Value);
        }

        #endregion

        #region Ω / m 

        public static QuotientOf<Ohm, Metre> operator /(Ohm ohm, Metre metre)
        {
            return new(ohm, metre);
        }

        #endregion

        #region W = V² / Ω

        public static Watt operator /(SquareOf<Volt> squareVolt, Ohm ohm)
        {
            return new(squareVolt.Value / ohm.Value);
        }

        #endregion

        #region W = A² * Ω

        public static Watt operator *(SquareOf<Ampere> squareAmpere, Ohm ohm)
        {
            return new(squareAmpere.Value * ohm.Value);
        }

        #endregion



        #region Casting/Conversion

        public static implicit operator Ohm(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Ohm ReplicateFrom(double value)
        {
            return new Ohm(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Ohm other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Ohm other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Ohm other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Ohm left, Ohm right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Ohm left, Ohm right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Ohm left, Ohm right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Ohm left, Ohm right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Ohm left, Ohm right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Ohm left, Ohm right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}