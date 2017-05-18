using System;
using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    public struct Metre : IUnit
    {
        public double Value { get; set; }
        public string Symbol
        {
            get { return "m"; }
        }


        public static Metre operator +(Metre metre1, Metre metre2)
        {
            return new Metre() { Value = metre1.Value + metre2.Value };
        }
        public static Metre operator -(Metre metre1, Metre metre2)
        {
            return new Metre() { Value = metre1.Value - metre2.Value };
        }


        public static implicit operator Metre(double value)
        {
            return new Metre() { Value = value };
        }

        public static SquareOf<Metre> operator ^(Metre source, int expo)
        {
            if (expo == 2)
                return new SquareOf<Metre>(source);
            throw new ArgumentException("Wrong Exponent.", nameof(expo));
        }

        public static SquareOf<Metre> operator ^(Metre source, Power expo)
        {
            if (expo == Power.Square)
                return new SquareOf<Metre>(source);
            throw new ArgumentException("Wrong Exponent.", nameof(expo));
        }

    }


    public sealed class Power
    {
        private enum Level
        {
            Square,
            Cubic
        }
        private Power(Level level)
        {
            _level = level;
        }

        private readonly Level _level;
        public static readonly Power Square = new Power(Level.Square);
        //public static readonly Power Cubic = new Power(Level.Cubic);
    }



}