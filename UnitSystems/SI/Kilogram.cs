using System;
using UnitSystems.Interfaces;
using UnitSystems.SI.Base;

namespace UnitSystems.SI
{
    public struct Kilogram : IUnit, IEquatable<Kilogram>
    {
        public double Value { get; set; }
        public string Symbol
        {
            get { return "kg"; }
        }


        public static SquareSecondTimesAmpere operator *(Kilogram kilogram, SquareOf<Second> second)
        {
            return new SquareSecondTimesAmpere();
        }
        public static ProductOf<Kilogram, Second> operator *(Kilogram kilogram, Second second)
        {
            return new ProductOf<Kilogram, Second>(kilogram, second);
        }

        public static ProductOf<Kilogram, Metre> operator *(Kilogram kilogram, Metre metre)
        {
            return new ProductOf<Kilogram, Metre>(kilogram, metre);
        }

        //public static ProductOf<Kilogram, SquareOf<Metre>> operator *(Kilogram kilogram, SquareOf<Metre> squareMetre)
        //{
        //    return new ProductOf<Kilogram, SquareOf<Metre>>(kilogram, squareMetre);
        //}

        public static KilogramTimesSquareMetre operator *(Kilogram kilogram, SquareOf<Metre> squareMetre)
        {
            return new ProductOf<Kilogram, SquareOf<Metre>>(kilogram, squareMetre);
        }

        #region +/-
        public static Kilogram operator +(Kilogram kg1, Kilogram kg2)
        {
            return new Kilogram() { Value = kg1.Value + kg2.Value };
        }
        public static Kilogram operator -(Kilogram kg1, Kilogram kg2)
        {
            return new Kilogram() { Value = kg1.Value - kg2.Value };
        }
        #endregion

        public static implicit operator Kilogram(double value)
        {
            return new Kilogram() { Value = value };
        }


        public bool Equals(Kilogram other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}