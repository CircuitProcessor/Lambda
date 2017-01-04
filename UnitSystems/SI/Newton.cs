using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    struct Newton : IUnit
    {
        public double Value { get; set; }
        public string Symbol
        {
            get { return "N"; }
        }

        #region J = N∙m
        public static Joule operator *(Newton newton, Metre metre)
        {
            return new Joule() { Value = newton.Value * metre.Value };
        }
        #endregion

        #region T = N/A∙m
        public static Tesla operator /(Newton newton, ProductOf<Ampere, Metre> ampereMetre)
        {
            return new Tesla() { Value = newton.Value / ampereMetre.Value };
        }
        #endregion

        #region N = kg∙m/s² (SI Base)
        public static implicit operator ProductOf<Kilogram, QuotientOf<Metre, SquareOf<Second>>>(Newton value)
        {
            return new ProductOf<Kilogram, QuotientOf<Metre, SquareOf<Second>>>();
        }

        public static implicit operator Newton(ProductOf<Kilogram, QuotientOf<Metre, SquareOf<Second>>> input)
        {
            return new Newton() { Value = input.Value };
        }
        #endregion

        #region +/-
        public static Newton operator +(Newton newton1, Newton newton2)
        {
            return new Newton() { Value = newton1.Value + newton2.Value };
        }
        public static Newton operator -(Newton newton1, Newton newton2)
        {
            return new Newton() { Value = newton1.Value - newton2.Value };
        }
        #endregion

        public static implicit operator Newton(double value)
        {
            return new Newton() { Value = value };
        }

    }
}