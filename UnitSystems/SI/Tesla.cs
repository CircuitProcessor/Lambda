using System;
using UnitSystems.Interfaces;
using UnitSystems.SI.Base;

namespace UnitSystems.SI
{
    public struct Tesla : IUnit, IEquatable<Tesla>
    {
        public readonly double Value;

        public Tesla(double value)
        {
            this.Value = value;
        }
        public string Symbol
        {
            get { return "T"; }
        }

        public static Tesla operator +(Tesla tesla1, Tesla tesla2)
        {
            return new Tesla(tesla1.Value + tesla2.Value);
        }
        public static Tesla operator -(Tesla tesla1, Tesla tesla2)
        {
            return new Tesla(tesla1.Value - tesla2.Value);
        }

        public static implicit operator Tesla(double value)
        {
            return new Tesla(value);
        }

        public double GetValue()
        {
            return Value;
        }

        public bool Equals(Tesla other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}