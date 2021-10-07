namespace UnitSystems.SI
{
    using Complex;
    using System;
    using System.Diagnostics;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Weber : IUnit, IPrefixable, IReplicable<Weber>, IComparable, IComparable<Weber>,
        IEquatable<Weber>
    {
        public string Symbol => "Wb";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Weber(double value)
        {
            Value = value;
        }

        #region +/-

        public static Weber operator +(Weber left, Weber right)
        {
            return new(left.Value + right.Value);
        }

        public static Weber operator -(Weber left, Weber right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Weber operator *(Weber unit, double multiplier)
        {
            return new Weber(unit.Value * multiplier);
        }

        public static Weber operator *(double multiplier, Weber unit)
        {
            return new Weber(unit.Value * multiplier);
        }

        public static Weber operator /(Weber dividend, double divisor)
        {
            return new Weber(dividend.Value / divisor);
        }

        public static double operator /(Weber dividend, Weber divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region Wb² = Wb·Wb

        public static SquareOf<Weber> operator *(Weber left, Weber right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region Wb = Wb² / Wb

        public static Weber operator /(SquareOf<Weber> left, Weber right)
        {
            return new(left.Value / right.Value);
        }

        #endregion

        #region Wb = V·s

        public static implicit operator Weber(ProductOf<Volt, Second> voltageSeconds)
        {
            return new(voltageSeconds.Value);
        }

        public static implicit operator ProductOf<Volt, Second>(Weber weber)
        {
            return new(weber.Value);
        }

        #endregion

        #region T = Wb/m²

        public static Tesla operator /(Weber weber, SquareOf<Metre> metre)
        {
            return new(weber.Value / metre.Value);
        }

        #endregion


        #region Casting/Conversion

        public static implicit operator Weber(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Weber ReplicateFrom(double value)
        {
            return new Weber(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Weber other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Weber other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Weber other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Weber left, Weber right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Weber left, Weber right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Weber left, Weber right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Weber left, Weber right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Weber left, Weber right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Weber left, Weber right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}