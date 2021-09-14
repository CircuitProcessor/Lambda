using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UnitSystems.Interfaces;
using UnitSystems.SI.Complex;

namespace UnitSystems.SI
{
    public struct Joule : IUnit, IEquatable<Hertz>
    {
        //public readonly double Value;

        public Joule(double value)
        {
            this.Value = value;
        }
        public string Symbol => "J";

        public double Value { get; }

        public static implicit operator ProductOf<Kilogram, QuotientOf<SquareOf<Metre>, SquareOf<Second>>>(Joule source)
        {
            return new ProductOf<Kilogram, QuotientOf<SquareOf<Metre>, SquareOf<Second>>>();
        }

        #region Casting
        public static implicit operator Joule(ProductOf<Kilogram, QuotientOf<SquareOf<Metre>, SquareOf<Second>>> source)
        {
            return new Joule();
        }
        #endregion

        public static Weber operator /(Joule joule, Ampere amp)
        {
            return new Weber();
        }


        #region W = J/s
        public static Watt operator /(Joule joule, Second sec)
        {
            return new Watt(joule.Value * sec.Value);
        }
        #endregion

        #region +/-
        public static Joule operator +(Joule joule1, Joule joule2)
        {
            return new Joule(joule1.Value + joule2.Value);
        }
        public static Joule operator -(Joule joule1, Joule joule2)
        {
            return new Joule(joule1.Value - joule2.Value);
        }
        #endregion

        public static implicit operator Joule(double value)
        {
            return new Joule(value);
        }

        public bool Equals(Hertz other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}
