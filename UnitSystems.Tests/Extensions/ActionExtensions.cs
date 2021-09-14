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
            for (int i = 1; i < 100; i++)
            {
                action();
                average = (average + stopWatch.ElapsedMilliseconds) / i;
                stopWatch.Restart();
            }
            stopWatch.Stop();

            return TimeSpan.FromMilliseconds(average);
        }
    }
}
