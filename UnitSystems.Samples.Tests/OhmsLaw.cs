using UnitSystems.SI;
using Xunit;

namespace UnitSystems.Samples.Tests
{
    public class OhmsLaw
    {
        [Fact]
        public void Ohms_Law_Showcase()
        {
            // Ohm's Law
            Volt v = 20;
            Ohm r = 10;
            Ampere i = 4;

            Volt volt = i * r;      // volt = 40 V
            Ohm ohm = v / i;        // ohm = 5 Ω
            Ampere ampere = v / r;  // ampere = 2 A
        }
    }
}
