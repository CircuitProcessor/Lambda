using System;
using UnitSystems.Interfaces;
using UnitSystems.SI.Complex;

namespace UnitSystems.SI
{
    public struct Volt : IUnit, IEquatable<Volt>
    {
        //public readonly double Value;

        public Volt(double value)
        {
            this.Value = value;
        }
        public string Symbol => "V";
        public double Value { get; }
        public static ProductOf<Volt, Second> operator *(Volt volt, Second second)
        {
            return new ProductOf<Volt, Second>(volt, second);
        }

        #region C = F∙V
        public static Coulomb operator *(Farad farad, Volt volt)
        {
            return new Coulomb(farad.Value * volt.Value);
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
            return new Watt(volt.Value * ampere.Value);
        }
        #endregion

        #region Ω = V/A
        public static Ohm operator /(Volt volt, Ampere ampere)
        {
            return new Ohm(volt.Value / ampere.Value);
        }
        #endregion

        #region A = V/Ω
        public static Ampere operator /(Volt volt, Ohm ohm)
        {
            return new Ampere(volt.Value / ohm.Value);
        }
        #endregion

        #region +/-
        public static Volt operator +(Volt volt1, Volt volt2)
        {
            return new Volt(volt1.Value + volt2.Value);
        }
        public static Volt operator -(Volt volt1, Volt volt2)
        {
            return new Volt(volt1.Value - volt2.Value);
        }
        #endregion

        #region Casting
        public static implicit operator Volt(double value)
        {
            return new Volt(value);
        }
        #endregion

        public static SquareOf<Volt> operator ^(Volt source, int expo)
        {
            return new SquareOf<Volt>(source);
        }

        public bool Equals(Volt other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}