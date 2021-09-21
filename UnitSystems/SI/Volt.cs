using System;
using UnitSystems.SI.Complex;

namespace UnitSystems.SI
{
    public readonly struct Volt : IUnit, IEquatable<Volt>, IComparable<Volt>, IComparable, IPrefixable
    {
        //public readonly double Value;

        public Volt(double value)
        {
            Value = value;
        }
        public string Symbol => "V";
        public double Value { get; }
        public static ProductOf<Volt, Second> operator *(Volt volt, Second second)
        {
            return new(volt, second);
        }

        public static SquareOf<Volt> operator *(Volt left, Volt right)
        {
            return new(left.Value * right.Value);
        }

        #region C = F∙V
        public static Coulomb operator *(Farad farad, Volt volt)
        {
            return new(farad.Value * volt.Value);
        }
        //operator above does same thing as the one below due to implicit Farad conversion.
        //public static Coulomb operator *(QuotientOf<SquareOf<Coulomb>, Joule> pseudoFarad, Volt volt)
        //{
        //    return new Coulomb() { Value = pseudoFarad.Value * volt.Value };
        //}
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

        #region +/-
        public static Volt operator +(Volt volt1, Volt volt2)
        {
            return new(volt1.Value + volt2.Value);
        }
        public static Volt operator -(Volt volt1, Volt volt2)
        {
            return new(volt1.Value - volt2.Value);
        }
        #endregion

        #region Casting
        public static implicit operator Volt(double value)
        {
            return new(value);
        }
        #endregion

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
            return Symbol.GetHashCode() ^ Value.GetHashCode() ^ 397;
        }

        public static bool operator ==(Volt left, Volt right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Volt left, Volt right)
        {
            return !left.Equals(right);
        }

        public int CompareTo(Volt other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            return obj is Volt other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Volt)}");
        }

        public static bool operator <(Volt left, Volt right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Volt left, Volt right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Volt left, Volt right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Volt left, Volt right)
        {
            return left.CompareTo(right) >= 0;
        }

        public Prefix Prefix => Prefix.None;
    }
}