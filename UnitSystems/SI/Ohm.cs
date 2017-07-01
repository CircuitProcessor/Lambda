﻿using System;
using UnitSystems.Interfaces;
using UnitSystems.SI.Base;

namespace UnitSystems.SI
{
    public struct Ohm : IUnit, IEquatable<Ohm>
    {
        public readonly double Value;

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

        public static QuotientOf<Ohm, Metre> operator /(Ohm ohm, Metre metre)
        {
            return new QuotientOf<Ohm, Metre>(ohm, metre);
        }

        public static Watt operator /(SquareOf<Volt> squareVolt, Ohm ohm)
        {
            return new Watt() { Value = squareVolt.Value / ohm.Value };
        }

        public static Watt operator *(SquareOf<Ampere> squareAmper, Ohm ohm)
        {
            return new Watt() { Value = squareAmper.Value * ohm.Value };
        }

        #region +/-
        public static Ohm operator +(Ohm ohm1, Ohm ohm2)
        {
            return new Ohm(ohm1.Value + ohm2.Value);
        }
        public static Ohm operator -(Ohm ohm1, Ohm ohm2)
        {
            return new Ohm(ohm1.Value - ohm2.Value);
        }
        #endregion

        public static implicit operator Ohm(double value)
        {
            return new Ohm(value);
        }

        public double GetValue()
        {
            return Value;
        }

        public bool Equals(Ohm other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}