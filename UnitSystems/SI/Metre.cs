namespace UnitSystems.SI
{
    using System;
    using Complex;
    using Interfaces;

    public struct Metre : IUnit, IEquatable<Metre>
    {
        //public readonly double Value;

        public Metre(double value)
        {
            this.Value = value;
        }

        public static Metre operator /(SquareOf<Metre> divisor, Metre divider)
        {
            return new Metre(divisor.Value / divider.Value);
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

        #region Casting
        public static implicit operator Metre(double value)
        {
            return new Metre(value);
        }
        #endregion
        public string Symbol => "m";
        public double Value { get; }

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