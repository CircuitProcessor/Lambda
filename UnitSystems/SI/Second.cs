namespace UnitSystems.SI
{
    using System;
    using Complex;

    public struct Second : IUnit, IEquatable<Second>
    {
        //public readonly double Value;

        public Second(double value)
        {
            this.Value = value;
        }

        public static SquareOf<Second> operator *(Second left, Second right)
        {
            return new(left.Value * right.Value);
        }

        #region F = s/Ω
        public static Farad operator /(Second second, Ohm ohm)
        {
            return new(second.Value / ohm.Value);
        }
        #endregion

        #region +/-
        public static Second operator +(Second second1, Second second2)
        {
            return new(second1.Value + second2.Value);
        }
        public static Second operator -(Second second1, Second second2)
        {
            return new(second1.Value - second2.Value);
        }
        #endregion

        #region Casting
        public static implicit operator Second(double value)
        {
            return new(value);
        }
        #endregion


        public string Symbol => "s";

        public double Value { get; }

        public bool Equals(Second other)
        {
            return Value.Equals(other.Value);
        }
    }
}