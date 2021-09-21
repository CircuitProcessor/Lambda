namespace UnitSystems.Tests.Extensions
{
    using System;
    using System.Diagnostics;

    public static class ActionExtensions
    {
        public static TimeSpan MeasureExecutionTime(this Action action)
        {
            double average = 0;
            var stopWatch = Stopwatch.StartNew();
            for (int i = 1; i < 10; i++)
            {
                action();
                var elapsedTime = stopWatch.ElapsedMilliseconds;
                average = (average + elapsedTime) / i;
                stopWatch.Restart();
            }
            stopWatch.Stop();

            return TimeSpan.FromMilliseconds(average);
        }
    }
}
