using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitSystems.SI.Base;

namespace UnitSystems.Tests
{
    [TestClass]
    public class ExponentiationTests
    {
        [TestMethod]
        public void Metre_ShouldThrowException_WhenNullPassedAsExponent()
        {
            //arrange
            Metre metre = 3;
            //act
            Action badExponentAction = () => { var result = metre ^ null; };
            //assert
            badExponentAction.ShouldThrowExactly<ArgumentException>("because null exponent was passed");
        }

        [TestMethod]
        public void Metre_ShouldReturnSquareMetre_WhenRaisingIntToPowerOfTwo()
        {
            //arrange
            Metre metre = 3;
            //act
            SquareOf<Metre> result = metre ^ Power.Square;
            //assert
            result.Value.Should().Be(9, "because 3^2=9");
        }

        [TestMethod]
        public void Metre_ShouldReturnSquareMetre_WhenRaisingDoubleToPowerOfTwo()
        {
            //arrange
            Metre metre = 2.5;
            //act
            var result = metre ^ Power.Square;
            //assert
            result.Value.Should().Be(6.25, "because 2.5^2=6.25");
        }

        [TestMethod]
        public void Metre_ShouldReturnSquareMetre_WhenRaisingNegativeIntToPowerOfTwo()
        {
            //arrange
            Metre metre = -44;
            //act
            var result = metre ^ Power.Square;
            //assert
            result.Value.Should().Be(1936, "because -44^2=1936");
        }

        [TestMethod]
        public void Metre_ShouldReturnSquareMetre_WhenRaisingNegativeDoubleToPowerOfTwo()
        {
            //arrange
            Metre metre = -12.33;
            //act
            var result = metre ^ Power.Square;
            //assert
            result.Value.Should().Be(152.0289, "because -12.33^2=-152.0289");
        }
    }
}
