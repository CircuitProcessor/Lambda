using System;
using UnitSystems.Interfaces;
using UnitSystems.SI.Complex;

namespace UnitSystems.SI
{
    public struct Farad : IUnit, IEquatable<Farad>
    {
        //public readonly double Value;

        public Farad(double value)
        {
            this.Value = value;
        }

        public string Symbol => "F";

        public double Value { get; }

        public static implicit operator QuotientOf<SquareOf<Coulomb>, Joule>(Farad farad)
        {
            return new QuotientOf<SquareOf<Coulomb>, Joule>(new SquareOf<Coulomb>(new Coulomb()), new Joule(), farad.Value);
        }
        public static implicit operator Farad(QuotientOf<SquareOf<Coulomb>, Joule> input)
        {
            return new Farad(input.Value);
        }


        public static Coulomb operator *(Farad farad, Volt volt)
        {
            return new Coulomb(farad.Value * volt.Value);
        }

        #region +/-

        public static Farad operator +(Farad input1, Farad input2)
        {
            return new Farad(input1.Value + input2.Value);
        }

        public static Farad operator -(Farad input1, Farad input2)
        {
            return new Farad(input1.Value - input2.Value);
        }

        #endregion

        public static implicit operator Farad(double value)
        {
            return new Farad(value);
        }

        public bool Equals(Farad other)
        {
            return Value.Equals(other.Value);
        }
    }
}