using Shouldly;
using System;
using Xunit;

namespace UnitSystems.Tests
{
    using SI;

    public class SubtractionTests
    {
        [Fact]
        public void Ampere_ShouldReturnNegativeInt_WhenImplicitlySubtracting()
        {
            //arrange
            Ampere amp1 = 3;
            Ampere amp2 = 12;
            Ampere amp3 = 47;
            //act
            var result = amp1 + amp2 - amp3;
            //assert
            result.Value.ShouldBe(-32, "because 3+12-47=-32");
        }
    }
}
