namespace UnitSystems.SI
{
    using System;
    using System.Diagnostics;
    using Complex;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Kilovolt : IUnit, IPrefixable, IReplicable<Kilovolt>, IComparable, IComparable<Kilovolt>,
        IEquatable<Kilovolt>
    {
        public string Symbol => "kV";
        public Prefix Prefix => Prefix.Kilo;
        public double Value { get; }

        public Kilovolt(double value)
        {
            Value = value;
        }

        #region +/-

        public static Kilovolt operator +(Kilovolt left, Kilovolt right)
        {
            return new(left.Value + right.Value);
        }

        public static Kilovolt operator -(Kilovolt left, Kilovolt right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Kilovolt operator *(Kilovolt unit, double multiplier)
        {
            return new Kilovolt(unit.Value * multiplier);
        }

        public static Kilovolt operator *(double multiplier, Kilovolt unit)
        {
            return new Kilovolt(unit.Value * multiplier);
        }

        public static Kilovolt operator /(Kilovolt dividend, double divisor)
        {
            return new Kilovolt(dividend.Value / divisor);
        }

        public static double operator /(Kilovolt dividend, Kilovolt divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region kV² = kV·kV

        public static SquareOf<Kilovolt> operator *(Kilovolt left, Kilovolt right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region kV = kV² / kV

        public static Kilovolt operator /(SquareOf<Kilovolt> left, Kilovolt right)
        {
            return new(left.Value / right.Value);
        }

        #endregion


        #region Casting/Conversion

        public static implicit operator Kilovolt(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Kilovolt ReplicateFrom(double value)
        {
            return new Kilovolt(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Kilovolt other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Kilovolt other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Kilovolt other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Kilovolt left, Kilovolt right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Kilovolt left, Kilovolt right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Kilovolt left, Kilovolt right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Kilovolt left, Kilovolt right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Kilovolt left, Kilovolt right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Kilovolt left, Kilovolt right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}