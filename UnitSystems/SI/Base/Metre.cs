using System;
using UnitSystems.Interfaces;

namespace UnitSystems.SI.Base
{
    public struct Metre : IUnit, IEquatable<Metre>
    {
        public readonly double Value;

        public Metre(double value)
        {
            this.Value = value;
        }

        public static Metre operator /(SquareOf<Metre> divisor, Metre divider)
        {
            return new Metre(divisor.Value / divider.Value);
        }

        public static SquareOf<Metre> operator ^(Metre source, Power expo)
        {
            return new SquareOf<Metre>(source);
        }

        #region +/-
        public static Metre operator +(Metre metre1, Metre metre2)
        {
            return new Metre(metre1.Value + metre2.Value);
        }
        public static Metre operator -(Metre metre1, Metre metre2)
        {
            return new Metre(metre1.Value - metre2.Value);
        }
        #endregion

        public static implicit operator Metre(double value)
        {
            return new Metre(value);
        }

        public double GetValue()
        {
            return this.Value;
        }
        public string Symbol
        {
            get { return "m"; }
        }

        public bool Equals(Metre other)
        {
            return this.Value.Equals(other.Value);
        }
    }


    public sealed class Power
    {
        private Power()
        {}

        public static readonly Power Square = new Power();
        //public static readonly Power Cubic = new Power(Level.Cubic);
    }



}