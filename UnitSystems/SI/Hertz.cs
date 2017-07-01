using System;
using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    public struct Hertz : IUnit, IEquatable<Hertz>
    {
        public readonly double Value;

        public Hertz(double value)
        {
            this.Value = value;
        }

        public string Symbol
        {
            get { return "Hz"; }
        }

        #region +/-

        public static Hertz operator +(Hertz input1, Hertz input2)
        {
            return new Hertz() {Value = input1.Value + input2.Value};
        }

        public static Hertz operator -(Hertz input1, Hertz input2)
        {
            return new Hertz() {Value = input1.Value - input2.Value};
        }

        #endregion

        public static implicit operator Hertz(double value)
        {
            return new Hertz(value);
        }

        public double GetValue()
        {
            return Value;
        }

        public bool Equals(Hertz other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}