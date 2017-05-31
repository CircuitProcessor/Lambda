using System;
using System.Diagnostics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitSystems.SI.Base;

namespace UnitSystems.Tests
{
    [TestClass]
    public class PerformanceTests
    {
        [TestMethod]
        public void Performance_ShouldExecuteInTime_WhenAddingOrSubtracting()
        {
            Action forLoopSI = () =>
            {
                Ampere x = 0;
                for (double i = 1; i < 1000000; i++) // 1 million
                {
                    x += i;
                    x -= i/2;
                }
            };
#if DEBUG
            forLoopSI.ExecutionTime().ShouldNotExceed(TimeSpan.FromMilliseconds(1));
#else
            forLoopSI.ExecutionTime().ShouldNotExceed(TimeSpan.FromMilliseconds(1));
#endif



        }
    }
}
