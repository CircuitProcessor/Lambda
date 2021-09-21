namespace UnitSystems.SI
{
    using System;
    using Complex;

    public struct Kilogram : IUnit, IEquatable<Kilogram>
    {
        //public readonly double Value;

        public Kilogram(double value)
        {
            Value = value;
        }


        #region +/-

        public static Kilogram operator +(Kilogram kg1, Kilogram kg2)
        {
            return new(kg1.Value + kg2.Value);
        }

        public static Kilogram operator -(Kilogram kg1, Kilogram kg2)
        {
            return new(kg1.Value - kg2.Value);
        }

        #endregion

        #region Casting
        public static implicit operator Kilogram(double value)
        {
            return new(value);
        }
        #endregion
        public string Symbol => "kg";

        public double Value { get; }

        public bool Equals(Kilogram other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}