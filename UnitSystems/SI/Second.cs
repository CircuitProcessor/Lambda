namespace UnitSystems.SI
{
    using Complex;
    using System;
    using System.Diagnostics;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Second : IUnit, IPrefixable, IReplicable<Second>, IComparable, IComparable<Second>,
        IEquatable<Second>
    {
        public string Symbol => "s";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Second(double value)
        {
            Value = value;
        }

        #region +/-

        public static Second operator +(Second left, Second right)
        {
            return new(left.Value + right.Value);
        }

        public static Second operator -(Second left, Second right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Second operator *(Second unit, double multiplier)
        {
            return new Second(unit.Value * multiplier);
        }

        public static Second operator *(double multiplier, Second unit)
        {
            return new Second(unit.Value * multiplier);
        }

        public static Second operator /(Second dividend, double divisor)
        {
            return new Second(dividend.Value / divisor);
        }

        public static double operator /(Second dividend, Second divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region s² = s·s

        public static SquareOf<Second> operator *(Second left, Second right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region s = s² / s

        public static Second operator /(SquareOf<Second> left, Second right)
        {
            return new(left.Value / right.Value);
        }

        #endregion

        #region F = s/Ω
        public static Farad operator /(Second second, Ohm ohm)
        {
            return new(second.Value / ohm.Value);
        }
        #endregion


        #region Casting/Conversion

        public static implicit operator Second(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Second ReplicateFrom(double value)
        {
            return new Second(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Second other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Second other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Second other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Second left, Second right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Second left, Second right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Second left, Second right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Second left, Second right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Second left, Second right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Second left, Second right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}