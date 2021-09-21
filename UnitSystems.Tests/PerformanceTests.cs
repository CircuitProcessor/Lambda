using System;
using Xunit;
using Shouldly;

namespace UnitSystems.Tests
{
    using Extensions;
    using SI;

    public class PerformanceTests
    {
        [Fact]
        public void Performance_ShouldExecuteInTime_WhenAddingOrSubtracting()
        {
            Action unitActions = () =>
            {
                for (double i = 1; i < 1_000_000; i++) // 1 million
                {
                    // implicit assign
                    Ampere ampere = i;
                    
                    // sum
                    Ampere sum = ampere + ampere;

                    // subtract
                    Ampere sub = sum - sum;
                }
            };
#if DEBUG
            unitActions.MeasureExecutionTime().ShouldBeLessThan(TimeSpan.FromMilliseconds(5));
#else
            unitActions.MeasureExecutionTime().ShouldBeLessThan(TimeSpan.FromMilliseconds(1));
#endif
        }
    }
}