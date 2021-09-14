using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitSystems.SI;
using UnitSystems.SI.Base;

namespace UnitSystems.Tests
{
    //<method>_Should<expected>_When<condition>

    [TestClass]
    public class AdditionTests
    {
        [TestMethod]
        public void Ampere_ShouldReturnSumInt_WhenImplicitlyAdding()
        {
            //arrange
            Ampere amp1 = 3;
            Ampere amp2 = 4;
            Ampere amp3 = 0.2;
            //act
            var result = amp1 + amp2 + amp3;
            //assert
            result.Value.Should().Be(7.2, "because 3A + 4A + .2A = 7.2A");
        }


    }
}
