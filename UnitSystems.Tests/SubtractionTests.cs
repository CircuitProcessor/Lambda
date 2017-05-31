using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitSystems.SI.Base;

namespace UnitSystems.Tests
{
    [TestClass]
    public class SubtractionTests
    {
        [TestMethod]
        public void Ampere_ShouldReturnNegativeInt_WhenImplicitlySubtracting()
        {
            //arrange
            Ampere amp1 = 3;
            Ampere amp2 = 12;
            Ampere amp3 = 47;
            //act
            var result = amp1 + amp2 - amp3;
            //assert
            result.Value.Should().BeNegative().And.Be(-32, "because 3+12-47=-32");
        }
    }
}
