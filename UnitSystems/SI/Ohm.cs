using System;
using UnitSystems.SI.Complex;

namespace UnitSystems.SI
{
    public struct Ohm : IUnit, IEquatable<Ohm>
    {
        //public readonly double Value;

        public Ohm(double value)
        {
            this.Value = value;
        }
        public string Symbol
        {
            get
            {
                return "Ω";
                return Char.ToString((char)0x2126);
            }
        }

        public double Value { get; }

        public static QuotientOf<Ohm, Metre> operator /(Ohm ohm, Metre metre)
        {
            return new(ohm, metre);
        }

        public static Watt operator /(SquareOf<Volt> squareVolt, Ohm ohm)
        {
            return new(squareVolt.Value / ohm.Value);
        }

        public static Watt operator *(SquareOf<Ampere> squareAmper, Ohm ohm)
        {
            return new(squareAmper.Value * ohm.Value);
        }

        #region +/-
        public static Ohm operator +(Ohm ohm1, Ohm ohm2)
        {
            return new(ohm1.Value + ohm2.Value);
        }
        public static Ohm operator -(Ohm ohm1, Ohm ohm2)
        {
            return new(ohm1.Value - ohm2.Value);
        }
        #endregion

        public static implicit operator Ohm(double value)
        {
            return new(value);
        }
        
        public bool Equals(Ohm other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}