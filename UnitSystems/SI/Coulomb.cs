using System;
using UnitSystems.SI.Complex;

namespace UnitSystems.SI
{
    public struct Coulomb : IUnit, IEquatable<Coulomb>
    {
        //public readonly double Value;

        public Coulomb(double value)
        {
            this.Value = value;
        }

        public string Symbol => "C";

        public double Value { get; }

        public bool Equals(Coulomb other)
        {
            return this.Value.Equals(other.Value);
        }

        #region F = C/V
        public static Farad operator /(Coulomb coulomb, Volt volt)
        {
            return new(coulomb.Value / volt.Value);
        }
        #endregion

        #region J = C·V
        public static Joule operator *(Coulomb coulomb, Volt volt)
        {
            return new(coulomb.Value * volt.Value);
        }
        #endregion

        public static SquareOf<Coulomb> operator *(Coulomb left, Coulomb right)
        {
            return new(left.Value * right.Value);
        }

        #region +/-

        public static Coulomb operator +(Coulomb input1, Coulomb input2)
        {
            return new(input1.Value + input2.Value);
        }

        public static Coulomb operator -(Coulomb input1, Coulomb input2)
        {
            return new(input1.Value - input2.Value);
        }

        #endregion

        public static implicit operator Coulomb(double value)
        {
            return new(value);
        }

    }
}