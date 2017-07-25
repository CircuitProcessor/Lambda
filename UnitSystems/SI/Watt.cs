using System;
using UnitSystems.Interfaces;
using UnitSystems.SI.Base;
using UnitSystems.SI.Complex;

namespace UnitSystems.SI
{
    /// <summary>
    /// Represents unit of work. 
    /// See:<see cref="Farad"/>.
    /// </summary>
    public struct Watt : IUnit, IEquatable<Watt>
    {
        //public readonly double Value;

        public Watt(double value)
        {
            this.Value = value;
        }
        public string Symbol => "W";
        public double Value { get; }

        #region J = W∙s
        public static Joule operator *(Watt watt, Second sec)
        {
            return new Joule(watt.Value * sec.Value);
        }
        #endregion

        #region +/-/=

        public static bool operator ==(Watt watt1, Watt watt2)
        {
            return watt1.Value.Equals(watt2.Value);
        }

        public static bool operator !=(Watt watt1, Watt watt2)
        {
            return !(watt1 == watt2);
        }

        public static Watt operator +(Watt watt1, Watt watt2)
        {
            return new Watt(watt1.Value + watt2.Value);
        }

        public static Watt operator -(Watt watt1, Watt watt2)
        {
            return new Watt(watt1.Value - watt2.Value);
        }
        #endregion

        #region W = V∙A
        public static implicit operator ProductOf<Volt, Ampere>(Watt watt)
        {
            return new ProductOf<Volt, Ampere>(new Volt(), new Ampere(), watt.Value);
        }
        public static implicit operator Watt(ProductOf<Volt, Ampere> source)
        {
            return new Watt(source.Value);
        }
        #endregion

        #region W = A²∙Ω
        public static implicit operator ProductOf<SquareOf<Ampere>, Ohm>(Watt watt)
        {
            var amper = new Ampere();
            var resistance = new Ohm();
            return new ProductOf<SquareOf<Ampere>, Ohm>(amper ^ Power.Square, resistance, watt.Value);
        }
        public static implicit operator Watt(ProductOf<SquareOf<Ampere>, Ohm> source)
        {
            return new Watt(source.Value);
        }
        #endregion

        #region Casting
        public static implicit operator Watt(double value)
        {
            return new Watt(value);
        }
        #endregion

        public bool Equals(Watt other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}