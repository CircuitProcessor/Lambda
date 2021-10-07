namespace UnitSystems
{
    using System.Collections.Generic;

    public static class Prefixes
    {
        private static readonly double[] Exponents =
        {
            1E9, 1E6, 1E3, 1E2, 1E1,
            1E0,
            1E-1, 1E-2, 1E-3, 1E-6, 1E-9, 1E-12
        };

        private static readonly Prefix[] PrefixNames =
        {
            Prefix.Giga, Prefix.Mega, Prefix.Kilo, Prefix.Hecto, Prefix.Deca,
            Prefix.None,
            Prefix.Deci, Prefix.Centi, Prefix.Milli, Prefix.Micro, Prefix.Nano, Prefix.Pico
        };

        private static readonly IDictionary<Prefix, double> PrefixFactorDictionary = new Dictionary<Prefix, double>
        {
            { PrefixNames[0], Exponents[0] },
            { PrefixNames[1], Exponents[1] },
            { PrefixNames[2], Exponents[2] },
            { PrefixNames[3], Exponents[3] },
            { PrefixNames[4], Exponents[4] },
            { PrefixNames[5], Exponents[5] },
            { PrefixNames[6], Exponents[6] },
            { PrefixNames[7], Exponents[7] },
            { PrefixNames[8], Exponents[8] },
            { PrefixNames[9], Exponents[9] },
            { PrefixNames[10], Exponents[10] },
            { PrefixNames[11], Exponents[11] }
        };

        public static double GetConversionFactor(Prefix from, Prefix to)
        {
            var factorFrom = PrefixFactorDictionary[from];
            var factorTo = PrefixFactorDictionary[to];

            var powerOf10 = factorFrom / factorTo;
            return powerOf10;
        }
    }

    public enum Prefix
    {
        Giga = 1,
        Mega,
        Kilo,
        Hecto,
        Deca,
        None,
        Deci,
        Centi,
        Milli,
        Micro,
        Nano,
        Pico
    }
}
