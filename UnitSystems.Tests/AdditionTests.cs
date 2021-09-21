using Shouldly;
using UnitSystems.SI;
using Xunit;

namespace UnitSystems.Tests
{
    public class AdditionTests
    {
        [Fact]
        public void Ampere_ShouldReturnSumInt_WhenImplicitlyAdding()
        {
            //arrange
            Ampere amp1 = 3;
            Ampere amp2 = 4;
            Ampere amp3 = 0.2;
            //act
            var result = amp1 + amp2 + amp3;
            //assert
            result.Value.ShouldBe(7.2, "because 3A + 4A + .2A = 7.2A");
        }
    }
}
