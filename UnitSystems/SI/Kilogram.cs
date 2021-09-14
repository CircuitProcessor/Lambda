namespace UnitSystems.SI
{
    using System;
    using Complex;
    using Interfaces;

    public struct Kilogram : IUnit, IEquatable<Kilogram>
    {
        //public readonly double Value;

        public Kilogram(double value)
        {
            Value = value;
        }

        #region Complex
        public static ProductOfKilogramAndSquareMetre operator *(Kilogram kilogram, SquareOf<Metre> squareMetre)
        {
            return new ProductOf<Kilogram, SquareOf<Metre>>(kilogram, squareMetre);
        }
        #endregion

        #region +/-

        public static Kilogram operator +(Kilogram kg1, Kilogram kg2)
        {
            return new Kilogram(kg1.Value + kg2.Value);
        }

        public static Kilogram operator -(Kilogram kg1, Kilogram kg2)
        {
            return new Kilogram(kg1.Value - kg2.Value);
        }

        #endregion

        #region Casting
        public static implicit operator Kilogram(double value)
        {
            return new Kilogram(value);
        }
        #endregion
        public string Symbol => "kg";

        public double Value { get; }

        public bool Equals(Kilogram other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}