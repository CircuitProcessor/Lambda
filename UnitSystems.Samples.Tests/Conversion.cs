namespace UnitSystems.Samples.Tests
{
    using SI;
    using Xunit;

    public class Conversion
    {
        [Fact]
        public void Unit_Conversion_Showcase()
        {
            Gram g = 1000;                // 1000 g
            Kilogram kg = (Kilogram)g;      // 1000 g = 1 kg

            Metre m = 1;                    // 1 m
            Millimetre mm = (Millimetre)m;    // 1 m = 1000 mm
        }
    }
}