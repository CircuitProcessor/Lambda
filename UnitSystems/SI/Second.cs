namespace UnitSystems.SI
{
    using System;
    using Complex;
    using Interfaces;

    public struct Second : IUnit, IEquatable<Second>
    {
        //public readonly double Value;

        public Second(double value)
        {
            this.Value = value;
        }


        #region F = s/Ω
        public static Farad operator /(Second second, Ohm ohm)
        {
            return new Farad(second.Value / ohm.Value);
        }
        #endregion

        #region +/-
        public static Second operator +(Second second1, Second second2)
        {
            return new Second(second1.Value + second2.Value);
        }
        public static Second operator -(Second second1, Second second2)
        {
            return new Second(second1.Value - second2.Value);
        }
        #endregion

        #region Casting
        public static implicit operator Second(double value)
        {
            return new Second(value);
        }
        #endregion

        public static SquareOf<Second> operator ^(Second source, Power expo)
        {
            if (expo == Power.Square)
                return new SquareOf<Second>(source);
            throw new ArgumentException("Wrong Exponent.", nameof(expo));
        }

        public string Symbol => "s";

        public double Value { get; }

        public bool Equals(Second other)
        {
            return Value.Equals(other.Value);
        }
    }
}