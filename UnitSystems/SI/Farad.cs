using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    public struct Farad : IUnit
    {
        public double Value { get; set; }

        public string Symbol
        {
            get { return "F"; }
        }

        public static implicit operator QuotientOf<SquareOf<Coulomb>, Joule>(Farad farad)
        {
            return new QuotientOf<SquareOf<Coulomb>, Joule>(new SquareOf<Coulomb>(new Coulomb()), new Joule(), farad.Value);
        }
        public static implicit operator Farad(QuotientOf<SquareOf<Coulomb>, Joule> input)
        {
            return new Farad() { Value = input.Value };
        }


        public static Coulomb operator *(Farad farad, Volt volt)
        {
            return new Coulomb() { Value = farad.Value * volt.Value };
        }

        #region +/-

        public static Farad operator +(Farad input1, Farad input2)
        {
            return new Farad() { Value = input1.Value + input2.Value };
        }

        public static Farad operator -(Farad input1, Farad input2)
        {
            return new Farad() { Value = input1.Value - input2.Value };
        }

        #endregion

        public static implicit operator Farad(double value)
        {
            return new Farad() { Value = value };
        }


    }
}