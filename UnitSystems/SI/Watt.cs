namespace UnitSystems.SI
{
    using Complex;
    using System;
    using System.Diagnostics;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Watt : IUnit, IPrefixable, IReplicable<Watt>, IComparable, IComparable<Watt>,
        IEquatable<Watt>
    {
        public string Symbol => "W";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Watt(double value)
        {
            Value = value;
        }

        #region +/-

        public static Watt operator +(Watt left, Watt right)
        {
            return new(left.Value + right.Value);
        }

        public static Watt operator -(Watt left, Watt right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Watt operator *(Watt unit, double multiplier)
        {
            return new Watt(unit.Value * multiplier);
        }

        public static Watt operator *(double multiplier, Watt unit)
        {
            return new Watt(unit.Value * multiplier);
        }

        public static Watt operator /(Watt dividend, double divisor)
        {
            return new Watt(dividend.Value / divisor);
        }

        public static double operator /(Watt dividend, Watt divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region W² = W·W

        public static SquareOf<Watt> operator *(Watt left, Watt right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region W = W² / W

        public static Watt operator /(SquareOf<Watt> left, Watt right)
        {
            return new(left.Value / right.Value);
        }

        #endregion

        #region J = W∙s
        public static Joule operator *(Watt watt, Second sec)
        {
            return new(watt.Value * sec.Value);
        }
        #endregion

        #region V∙A = W
        public static implicit operator ProductOf<Volt, Ampere>(Watt watt)
        {
            return new(watt.Value);
        }
        public static implicit operator Watt(ProductOf<Volt, Ampere> source)
        {
            return new(source.Value);
        }
        #endregion

        #region A²∙Ω = W
        public static implicit operator ProductOf<SquareOf<Ampere>, Ohm>(Watt watt)
        {
            return new ProductOf<SquareOf<Ampere>, Ohm>(watt.Value);
        }

        public static implicit operator Watt(ProductOf<SquareOf<Ampere>, Ohm> source)
        {
            return new(source.Value);
        }
        #endregion


        #region Casting/Conversion

        public static implicit operator Watt(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Watt ReplicateFrom(double value)
        {
            return new Watt(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Watt other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Watt other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Watt other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Watt left, Watt right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Watt left, Watt right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Watt left, Watt right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Watt left, Watt right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Watt left, Watt right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Watt left, Watt right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}