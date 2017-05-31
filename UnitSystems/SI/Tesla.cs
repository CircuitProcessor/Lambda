using UnitSystems.Interfaces;
using UnitSystems.SI.Base;

namespace UnitSystems.SI
{
    public struct Tesla : IUnit
    {
        public double Value { get; set; }
        public string Symbol
        {
            get { return "T"; }
        }

        public static Tesla operator +(Tesla tesla1, Tesla tesla2)
        {
            return new Tesla() { Value = tesla1.Value + tesla2.Value };
        }
        public static Tesla operator -(Tesla tesla1, Tesla tesla2)
        {
            return new Tesla() { Value = tesla1.Value - tesla2.Value };
        }

        public static implicit operator Tesla(double value)
        {
            return new Tesla() { Value = value };
        }
    }
}