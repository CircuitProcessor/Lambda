using System;
using UnitSystems.Interfaces;
using UnitSystems.SI;
using UnitSystems.SI.Base;

namespace UnitSystems.SI.Complex
{
    public struct ProductOfKilogramAndSquareMetre : IUnit, IProductOf<Kilogram, SquareOf<Metre>>
    {
        public double Value
        {
            get{throw new NotImplementedException();}
            set{ throw new NotImplementedException();}
        }

        public string Symbol
        {
            get{throw new NotImplementedException();}
        }


        public static ProductOf<Kilogram, QuotientOf<SquareOf<Metre>, SquareOf<Second>>> operator /(ProductOfKilogramAndSquareMetre source, SquareOf<Second> squareSecond)
        {
            return new ProductOf<Kilogram, QuotientOf<SquareOf<Metre>, SquareOf<Second>>>();
        }

        public static implicit operator ProductOf<Kilogram, SquareOf<Metre>> (ProductOfKilogramAndSquareMetre from)
        {
            return new ProductOf<Kilogram, SquareOf<Metre>>();
        }
        public static implicit operator ProductOfKilogramAndSquareMetre(ProductOf<Kilogram, SquareOf<Metre>> from)
        {
            return new ProductOfKilogramAndSquareMetre();
        }

        //public static Weber operator /(ProductOfKilogramSquareMetre divisor, SquareSecondTimesAmpere divider)
        //{
        //    return new Weber() { Value = divisor.Value / divider.Value };
        //}

        public static Weber operator /(ProductOfKilogramAndSquareMetre divisor, ProductOf<Ampere, SquareOf<Second>> divider)
        {
            return new Weber() { Value = divisor.Value / divider.Value };
        }
    }
}