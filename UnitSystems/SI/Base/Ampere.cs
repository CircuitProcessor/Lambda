using System;
using UnitSystems.Interfaces;

namespace UnitSystems.SI.Base
{
    public struct Ampere : IUnit, IEquatable<Ampere>
    {
        public readonly double Value;

        public Ampere(double value)
        {
            this.Value = value;
        }

        #region V = A·R
        public static Volt operator *(Ampere ampers, Ohm ohms)
        {
            return new Volt() { Value = ampers.Value * ohms.Value };
        }
        #endregion

        #region Wb = J/A
        public static Weber operator /(Joule joule, Ampere amp)
        {
            return new Weber();
        }
        #endregion

        #region +/-
        public static Ampere operator +(Ampere ampere1, Ampere ampere2)
        {
            return new Ampere(ampere1.Value + ampere2.Value);
        }
        public static Ampere operator -(Ampere ampere1, Ampere ampere2)
        {
            return new Ampere(ampere1.Value - ampere2.Value);
        }
        #endregion

        #region Complex
        public static ProductOf<Ampere, SquareOf<Second>> operator *(Ampere amp, SquareOf<Second> second)
        {
            return new ProductOf<Ampere, SquareOf<Second>>();
        }
        public static SquareOf<Ampere> operator ^(Ampere source, Power expo)
        {
            if (expo == Power.Square)
                return new SquareOf<Ampere>(source);
            throw new ArgumentException("Wrong Exponent.", nameof(expo));
        }
        #endregion

        public static implicit operator Ampere(double value)
        {
            return new Ampere(value);
        }

        public double GetValue()
        {
            return this.Value;
        }

        public string Symbol
        {
            get { return "A"; }
        }

        public bool Equals(Ampere other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}