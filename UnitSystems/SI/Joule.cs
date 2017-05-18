using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    public struct Joule : IUnit
    {
        public double Value { get; set; }
        public string Symbol
        {
            get { return "J"; }
        }

        public static implicit operator ProductOf<Kilogram, QuotientOf<SquareOf<Metre>, SquareOf<Second>>>(Joule source)
        {
            return new ProductOf<Kilogram, QuotientOf<SquareOf<Metre>, SquareOf<Second>>>();
        }

        public static implicit operator Joule(ProductOf<Kilogram, QuotientOf<SquareOf<Metre>, SquareOf<Second>>> source)
        {
            return new Joule();
        }

        public static Weber operator /(Joule joule, Ampere amp)
        {
            return new Weber();
        }


        #region W = J/s
        public static Watt operator /(Joule joule, Second sec)
        {
            return new Watt() { Value = joule.Value * sec.Value };
        }
        #endregion

        #region +/-
        public static Joule operator +(Joule joule1, Joule joule2)
        {
            return new Joule() { Value = joule1.Value + joule2.Value };
        }
        public static Joule operator -(Joule joule1, Joule joule2)
        {
            return new Joule() { Value = joule1.Value - joule2.Value };
        }
        #endregion

        public static implicit operator Joule(double value)
        {
            return new Joule() { Value = value };
        }
    }
}
