using UnitSystems.Complex;
using UnitSystems.SI;
using Xunit;

namespace UnitSystems.Samples.Tests
{
    public class Advanced
    {
        [Fact]
        public void Advanced_Basic_Conversions_Showcase()
        {
            Metre m = 1;
            Ampere I = 4;
            Ohm R = 10;

            // Metre times Metre is Metre Squared: m · m = m²
            SquareOf<Metre> metreSquared = m * m;

            // Square metre divided by metre is.. metre!
            Metre metre = (m * m) / m;

            // Watt unit composition: W = (A²)*R
            Watt watt = (I * I) * R;
        }

        [Fact]
        public void Advanced_Complex_Conversions_Showcase()
        {
            Coulomb C = 1;
            Joule J = 1;
            Volt V = 20;

            // Farad in base SI = C²/J
            QuotientOf<SquareOf<Coulomb>, Joule> faradSi = (C * C) / J;

            // Farad times Volt = Coulomb (even if multiplied in base SI representation)
            Coulomb coulomb = faradSi * V;
        }

        [Fact]
        public void Advanced_Nested_Conversions_Showcase()
        {
            Newton N = 1;
            Metre m = 1;
            Volt V = 20;
            Ohm R = 10;

            // Nested multiple implicit unit resolution
            // Wb = J/A | J = N∙m | A = V/R
            Weber weber = (N * m) / (V / R);
        }
    }
}