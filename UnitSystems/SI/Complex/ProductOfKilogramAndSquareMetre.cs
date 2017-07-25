using System;
using UnitSystems.Interfaces;
using UnitSystems.SI;
using UnitSystems.SI.Base;

namespace UnitSystems.SI.Complex
{
    public struct ProductOfKilogramAndSquareMetre : IUnit
    {
        public ProductOfKilogramAndSquareMetre(double value)
        {
            Value = value;
        }

        public string Symbol
        {
            get { return "kg*m^2"; }
        }

        public double Value { get; }

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

        public static Weber operator /(ProductOfKilogramAndSquareMetre divisor, ProductOf<Ampere, SquareOf<Second>> divider)
        {
            return new Weber(divisor.Value / divider.Value);
        }
    }
}