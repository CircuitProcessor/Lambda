namespace UnitSystems.SI
{
    using System;
    using System.Diagnostics;
    using Complex;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Coulomb : IUnit, IPrefixable, IReplicable<Coulomb>, IComparable, IComparable<Coulomb>, IEquatable<Coulomb>
    {
        public string Symbol => "C";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Coulomb(double value)
        {
            Value = value;
        }

        #region +/-

        public static Coulomb operator +(Coulomb left, Coulomb right)
        {
            return new(left.Value + right.Value);
        }

        public static Coulomb operator -(Coulomb left, Coulomb right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Coulomb operator *(Coulomb unit, double multiplier)
        {
            return new Coulomb(unit.Value * multiplier);
        }

        public static Coulomb operator *(double multiplier, Coulomb unit)
        {
            return new Coulomb(unit.Value * multiplier);
        }

        public static Coulomb operator /(Coulomb dividend, double divisor)
        {
            return new Coulomb(dividend.Value / divisor);
        }

        public static double operator /(Coulomb dividend, Coulomb divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region C² = C·C

        public static SquareOf<Coulomb> operator *(Coulomb left, Coulomb right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region C = C² / C

        public static Coulomb operator /(SquareOf<Coulomb> left, Coulomb right)
        {
            return new(left.Value / right.Value);
        }

        #endregion

        #region F = C/V
        public static Farad operator /(Coulomb coulomb, Volt volt)
        {
            return new(coulomb.Value / volt.Value);
        }
        #endregion

        #region J = C·V
        public static Joule operator *(Coulomb coulomb, Volt volt)
        {
            return new(coulomb.Value * volt.Value);
        }
        #endregion


        #region Casting/Conversion

        public static implicit operator Coulomb(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Coulomb ReplicateFrom(double value)
        {
            return new Coulomb(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Coulomb other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Coulomb other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Coulomb other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Coulomb left, Coulomb right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Coulomb left, Coulomb right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Coulomb left, Coulomb right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Coulomb left, Coulomb right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Coulomb left, Coulomb right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Coulomb left, Coulomb right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}