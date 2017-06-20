using System;
using UnitSystems.Interfaces;
using UnitSystems.SI.Complex;

namespace UnitSystems.SI.Base
{
    public struct Kilogram : IUnit, IEquatable<Kilogram>
    {
        public readonly double Value;

        public Kilogram(double value)
        {
            this.Value = value;
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
            return new Kilogram() { Value = kg1.Value + kg2.Value };
        }

        public static Kilogram operator -(Kilogram kg1, Kilogram kg2)
        {
            return new Kilogram() { Value = kg1.Value - kg2.Value };
        }

        #endregion

        public static implicit operator Kilogram(double value)
        {
            return new Kilogram(value);
        }

        public double GetValue()
        {
            return this.Value;
        }

        public string Symbol
        {
            get { return "kg"; }
        }

        public bool Equals(Kilogram other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}