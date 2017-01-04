using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    struct Hertz : IUnit
    {
        public double Value { get; set; }

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
            return new Hertz() {Value = value};
        }

         
    }
}