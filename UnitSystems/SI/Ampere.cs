namespace UnitSystems.SI
{
    using System;
    using Complex;

    public readonly struct Ampere : IUnit, IEquatable<Ampere>
    {
        //public readonly double Value;

        public Ampere(double value)
        {
            Value = value;
        }

        #region V = A·R
        public static Volt operator *(Ampere ampere, Ohm ohm)
        {
            return new(ampere.Value * ohm.Value);
        }


        //
        public static SquareOf<Ampere> operator *(Ampere left, Ampere right)
        {
            return new(left.Value * right.Value);
        }


        #endregion



        #region +/-
        public static Ampere operator +(Ampere left, Ampere right)
        {
            return new(left.Value + right.Value);
        }
        public static Ampere operator -(Ampere left, Ampere right)
        {
            return new(left.Value - right.Value);
        }
        #endregion

        #region Complex
        public static ProductOf<Ampere, SquareOf<Second>> operator *(Ampere amp, SquareOf<Second> second)
        {
            return new();
        }

        #endregion

        #region Casting
        public static implicit operator Ampere(double value)
        {
            return new(value);
        }
        #endregion
        public string Symbol => "A";

        public double Value { get; }

        public bool Equals(Ampere other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}