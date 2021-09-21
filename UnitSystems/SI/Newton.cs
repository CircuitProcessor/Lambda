using System;
using UnitSystems.SI.Complex;

namespace UnitSystems.SI
{
    public struct Newton : IUnit, IEquatable<Newton>
    {
        //public readonly double Value;

        public Newton(double value)
        {
            this.Value = value;
        }
        public string Symbol => "N";

        public double Value { get; }

        #region J = N∙m
        public static Joule operator *(Newton newton, Metre metre)
        {
            return new(newton.Value * metre.Value);
        }
        #endregion

        #region T = N/A∙m
        public static Tesla operator /(Newton newton, ProductOf<Ampere, Metre> ampereMetre)
        {
            return new(newton.Value / ampereMetre.Value);
        }
        #endregion

        #region N = kg∙m/s² (SI Base)
        public static implicit operator ProductOf<Kilogram, QuotientOf<Metre, SquareOf<Second>>>(Newton value)
        {
            return new();
        }

        public static implicit operator Newton(ProductOf<Kilogram, QuotientOf<Metre, SquareOf<Second>>> input)
        {
            return new(input.Value);
        }
        #endregion

        #region +/-
        public static Newton operator +(Newton newton1, Newton newton2)
        {
            return new(newton1.Value + newton2.Value);
        }
        public static Newton operator -(Newton newton1, Newton newton2)
        {
            return new(newton1.Value - newton2.Value);
        }
        #endregion

        #region Casting
        public static implicit operator Newton(double value)
        {
            return new(value);
        }
        #endregion

        public bool Equals(Newton other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}