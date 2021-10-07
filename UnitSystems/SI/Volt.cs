namespace UnitSystems.SI
{
    using Complex;
    using System;
    using System.Diagnostics;
    using UnitSystems;

    [DebuggerDisplay("Value = {Value} {Symbol,nq}")]
    public readonly struct Volt : IUnit, IPrefixable, IReplicable<Volt>, IComparable, IComparable<Volt>,
        IEquatable<Volt>
    {
        public string Symbol => "V";
        public Prefix Prefix => Prefix.None;
        public double Value { get; }

        public Volt(double value)
        {
            Value = value;
        }

        #region +/-

        public static Volt operator +(Volt left, Volt right)
        {
            return new(left.Value + right.Value);
        }

        public static Volt operator -(Volt left, Volt right)
        {
            return new(left.Value - right.Value);
        }

        #endregion

        #region */÷

        public static Volt operator *(Volt unit, double multiplier)
        {
            return new Volt(unit.Value * multiplier);
        }

        public static Volt operator *(double multiplier, Volt unit)
        {
            return new Volt(unit.Value * multiplier);
        }

        public static Volt operator /(Volt dividend, double divisor)
        {
            return new Volt(dividend.Value / divisor);
        }

        public static double operator /(Volt dividend, Volt divisor)
        {
            return dividend.Value / divisor.Value;
        }

        #endregion */÷

        #region V² = V·V

        public static SquareOf<Volt> operator *(Volt left, Volt right)
        {
            return new(left.Value * right.Value);
        }

        #endregion

        #region V = V² / V

        public static Volt operator /(SquareOf<Volt> left, Volt right)
        {
            return new(left.Value / right.Value);
        }

        #endregion

        #region V∙s

        public static ProductOf<Volt, Second> operator *(Volt volt, Second second)
        {
            return new(volt, second);
        }

        #endregion

        #region C = F∙V
        public static Coulomb operator *(Farad farad, Volt volt)
        {
            return new(farad.Value * volt.Value);
        }
        //operator above does same thing as the one below due to implicit Farad conversion.
        public static Coulomb operator *(QuotientOf<SquareOf<Coulomb>, Joule> pseudoFarad, Volt volt)
        {
            return new Coulomb(pseudoFarad.Value * volt.Value);
        }
        #endregion

        #region W = V∙A
        public static Watt operator *(Volt volt, Ampere ampere)
        {
            return new(volt.Value * ampere.Value);
        }
        #endregion

        #region Ω = V/A
        public static Ohm operator /(Volt volt, Ampere ampere)
        {
            return new(volt.Value / ampere.Value);
        }
        #endregion

        #region A = V/Ω
        public static Ampere operator /(Volt volt, Ohm ohm)
        {
            return new(volt.Value / ohm.Value);
        }
        #endregion


        #region Casting/Conversion

        public static implicit operator Volt(double value)
        {
            return new(value);
        }

        #endregion

        #region IReplicable implementation

        public Volt ReplicateFrom(double value)
        {
            return new Volt(value);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Volt other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Volt other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Prefix, Symbol);
        }

        #endregion

        #region IComparable implementation

        public int CompareTo(Volt other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public static bool operator ==(Volt left, Volt right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Volt left, Volt right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Volt left, Volt right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Volt left, Volt right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Volt left, Volt right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Volt left, Volt right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion
    }

}