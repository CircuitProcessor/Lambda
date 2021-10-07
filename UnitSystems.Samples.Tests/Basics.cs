using UnitSystems.SI;
using Xunit;

namespace UnitSystems.Samples.Tests
{
    public class Basics
    {
        [Fact]
        public void Basics_Showcase()
        {
            // Implicit or traditional style declaration
            Volt volt0;
            Volt volt1 = 1.0;
            Volt volt2 = new Volt(1);

            // Build-in standard comparison operators present in ordinary types such as int
            bool equal = volt1 == volt2;                // true
            bool notEqual = volt1 != volt2;             // false
            bool greaterThan = volt1 > volt2;           // false
            bool smallerThan = volt1 < volt2;           // false
            bool graterThanOrEqual = volt1 >= volt2;    // true
            bool smallerThanOrEqual = volt1 <= volt2;   // true

            // Addition and subtraction
            Volt sum = volt1 + volt2;   // sum = 2 V
            Volt diff = volt1 - volt2;  // diff = 0 V
        }
    }
}