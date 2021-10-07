namespace UnitSystems.SI
{
    using Complex;
    using System;
    using System.Diagnostics;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Tesla : IUnit, IPrefixable, IReplicable<Tesla>, IComparable, IComparable<Tesla>,
        IEquatable<Tesla>
    {
        public string Symbol => "T";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Tesla(double value)
        {
            Value = value;
        }

        #region +/-

        public static Tesla operator +(Tesla left, Tesla right)
        {
            return new(left.Value + right.Value);
        }

        public static Tesla operator -(Tesla left, Tesla right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Tesla operator *(Tesla unit, double multiplier)
        {
            return new Tesla(unit.Value * multiplier);
        }

        public static Tesla operator *(double multiplier, Tesla unit)
        {
            return new Tesla(unit.Value * multiplier);
        }

        public static Tesla operator /(Tesla dividend, double divisor)
        {
            return new Tesla(dividend.Value / divisor);
        }

        public static double operator /(Tesla dividend, Tesla divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region T² = T·T

        public static SquareOf<Tesla> operator *(Tesla left, Tesla right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region T = T² / T

        public static Tesla operator /(SquareOf<Tesla> left, Tesla right)
        {
            return new(left.Value / right.Value);
        }

        #endregion


        #region Casting/Conversion

        public static implicit operator Tesla(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Tesla ReplicateFrom(double value)
        {
            return new Tesla(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Tesla other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Tesla other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Tesla other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Tesla left, Tesla right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Tesla left, Tesla right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Tesla left, Tesla right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Tesla left, Tesla right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Tesla left, Tesla right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Tesla left, Tesla right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}