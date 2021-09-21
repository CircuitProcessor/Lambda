using Shouldly;
using Xunit;

namespace UnitSystems.Tests
{
    using SI;

    public class SubtractionTests
    {
        [Fact]
        public void Ampere_ShouldReturn0_WhenImplicitlySubtracting()
        {
            //arrange
            Ampere amp1 = 1;
            Ampere amp2 = 2;
            Ampere amp3 = 3;
            //act
            var result = amp3 - amp2 - amp1;
            //assert
            Ampere expected = 0;
            result.ShouldBe(expected, $"because {amp3}-{amp2}-{amp1}={expected}");
        }
    }
}
