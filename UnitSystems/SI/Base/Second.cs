using System;
using UnitSystems.Interfaces;

namespace UnitSystems.SI.Base
{
    public struct Second : IUnit
    {
        public double Value { get; set; }
        public string Symbol
        {
            get { return "s"; }
        }

        #region F = s/Ω
        public static Farad operator /(Second second, Ohm ohm)
        {
            return new Farad() { Value = second.Value / ohm.Value };
        }
        #endregion

        #region +/-
        public static Second operator +(Second second1, Second second2)
        {
            return new Second() { Value = second1.Value + second2.Value };
        }
        public static Second operator -(Second second1, Second second2)
        {
            return new Second() { Value = second1.Value - second2.Value };
        }
        #endregion

        public static implicit operator Second(double value)
        {
            return new Second() { Value = value };
        }

        public static SquareOf<Second> operator ^(Second source, int expo)
        {
            return new SquareOf<Second>(source);
        }

        public static SquareOf<Second> operator ^(Second source, Power expo)
        {
            if (expo == Power.Square)
                return new SquareOf<Second>(source);
            throw new ArgumentException("Wrong Exponent.", nameof(expo));
        }

    }
}