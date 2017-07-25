using System;
using UnitSystems.Interfaces;
using UnitSystems.SI.Base;

namespace UnitSystems.SI
{
    public struct Tesla : IUnit, IEquatable<Tesla>
    {
        //public readonly double Value;

        public Tesla(double value)
        {
            this.Value = value;
        }
        public string Symbol => "T";
        public double Value { get; }

        public static Tesla operator +(Tesla tesla1, Tesla tesla2)
        {
            return new Tesla(tesla1.Value + tesla2.Value);
        }
        public static Tesla operator -(Tesla tesla1, Tesla tesla2)
        {
            return new Tesla(tesla1.Value - tesla2.Value);
        }

        #region Casting
        public static implicit operator Tesla(double value)
        {
            return new Tesla(value);
        }
        #endregion

        public bool Equals(Tesla other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}