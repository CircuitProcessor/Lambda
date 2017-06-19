using UnitSystems.Interfaces;
using UnitSystems.SI.Base;

namespace UnitSystems.SI
{
    public struct Volt : IUnit
    {
        public double Value { get; set; }
        public string Symbol
        {
            get { return "V"; }
        }


        public static ProductOf<Volt, Second> operator *(Volt volt, Second second)
        {
            return new ProductOf<Volt, Second>(volt, second);
        }

        #region C = F∙V
        public static Coulomb operator *(Farad farad, Volt volt)
        {
            return new Coulomb() { Value = farad.Value * volt.Value };
        }
        //operator above does same thing as the one below due to implicit Farad conversion.
        //public static Coulomb operator *(QuotientOf<SquareOf<Coulomb>, Joule> pseudoFarad, Volt volt)
        //{
        //    return new Coulomb() { Value = pseudoFarad.Value * volt.Value };
        //}
        #endregion

        #region W = V∙A
        public static Watt operator *(Volt volt, Ampere ampere)
        {
            return new Watt() { Value = volt.Value * ampere.Value };
        }
        #endregion

        #region Ω = V/A
        public static Ohm operator /(Volt volt, Ampere ampere)
        {
            return new Ohm() { Value = volt.Value / ampere.Value };
        }
        #endregion

        #region A = V/Ω
        public static Ampere operator /(Volt volt, Ohm ohm)
        {
            return new Ampere(volt.Value / ohm.Value);
        }
        #endregion

        #region +/-
        public static Volt operator +(Volt volt1, Volt volt2)
        {
            return new Volt() { Value = volt1.Value + volt2.Value };
        }
        public static Volt operator -(Volt volt1, Volt volt2)
        {
            return new Volt() { Value = volt1.Value - volt2.Value };
        }
        #endregion


        public static implicit operator Volt(double value)
        {
            return new Volt() { Value = value };
        }

        public static SquareOf<Volt> operator ^(Volt source, int expo)
        {
            return new SquareOf<Volt>(source);
        }
    }
}