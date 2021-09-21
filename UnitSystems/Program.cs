using System;
using System.Text;
using UnitSystems.SI;
using UnitSystems.SI.Complex;

namespace UnitSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implicit or traditional style declaration
            Volt volt1 = 1.0;
            Volt volt2 = new Volt(1);

            // Build-in standard comparison operators present in ordinary types such as int
            bool equal = volt1 == volt2;
            bool notEqual = volt1 != volt2;
            bool greaterThan = volt1 > volt2;
            bool graterThanOrEqual = volt1 >= volt2;
            // ..and so on. You get the idea.

            // Addition and subtraction
            Volt sum = volt1 + volt2;
            Volt diff = volt1 - volt2;

            // Conversion



            Volt V = 20;
            Ohm R = 10;
            Ampere I = 4;

            // Ohm's Law
            Volt Vz = I * R;  // 40 V
            Ohm Rz = V / I;   // 5 Ω
            Ampere Iz = V / R;  // 2 A

            Metre m = 1;
            Newton N = 1;
            Coulomb C = 1;
            Joule J = 1;

            // Farad in base SI = C^2/J
            QuotientOf<SquareOf<Coulomb>, Joule> farad_SI = (C * C) / J;
            // Farad times Volt = Coulomb (even if multiplied in base SI representation)
            Coulomb coulomb = farad_SI * V;

            // W = (A^2)*R
            Watt watt = (I * I) * R;

            // Square meter divided by meter is.. meter!
            Metre metre = (m * m) / m;

            // For the series circuit with given parameters:
            Ohm R1 = 1000;
            Ohm R2 = 3000;
            Ohm R3 = 2000;
            Volt Vs = 36;

            // 1. Determine the total resistance Rt
            Ohm Rt = R1 + R2 + R3; // Rt = 6000 Ω = 6 kΩ

            // 2. Calculate the current Is
            Ampere Is = Vs / Rt; // Is = 0.006 A = 6 mA

            // 3. Determine the voltage across each resistor
            Volt V1 = Is * R1; // 6V
            Volt V2 = Is * R2; // 18V
            Volt V3 = Is * R3; // 12V

            // 4. Find the power supplied by the battery
            Watt Pe = Vs * Is; // 36 V * 6 mA = 216 mW

            // 5. Determine the power dissipated by each resistor
            Watt P1 = V1 * Is; // 36 mW
            Watt P2 = (Is * Is) * R2; // (6 mA)^2 * 3 kΩ = 108 mW
            Watt P3 = (V3 * V3) / R3; // (12 V)^2 / 2 kΩ = 72 mW

            // 6. Check if the total power supplied equals the total power dissipated
            bool powerSuppliedEqualsDissipated = Pe == P1 + P2 + P3; // true: 216 mW == 36 mW + 108 mW + 72 mW


            Ampere amp = 1;
            Weber Wb = 1;
            Kilogram kg = 1;
            Second s = 1;

            //Nested resolution
            // Wb = J/A | J = N∙m | A = V/R
            Weber weber = (N * m) / (V / R);

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("{0}·{1}·{2}");
            Console.ReadLine();
        }
    }

    /*  √2 ² ·
     *     http://en.wikipedia.org/wiki/Category:SI_units 
           SI base units
               Name        Symbol  Measure
               metre       m       length 
               kilogram    kg      mass
               second      s       time
               ampere      A       electric current
               kelvin      K       thermodynamic temperature
               mole        mol     amount of substance 
               candela     cd      luminous intensity 
          
           http://en.wikipedia.org/wiki/SI_derived_unit
           Named units derived from SI base units 
               Name        Symbol  Quantity                            Expression in terms of other units      Expression in terms of SI base units 
               hertz       Hz      frequency                           1/s                                     s-1 
               radian      rad     angle                               m∙m-1                                   dimensionless 
               steradian   sr      solid angle                         m2∙m-2                                  dimensionless 
               newton      N       force, weight                       kg∙m/s2                                 kg∙m∙s−2 
               pascal      Pa      pressure, stress                    N/m2                                    m−1∙kg∙s−2 
               joule       J       energy, work, heat                  N∙m = C·V = W·s                         m2∙kg∙s−2 
               watt        W       power, radiant flux                 J/s = V·A                               m2∙kg∙s−3 
               coulomb     C       electric charge or electric flux    s∙A                                     s∙A 
               volt        V       voltage, 
                                   electrical potential difference, 
                                   electromotive force                 W/A = J/C                               m2∙kg∙s−3∙A−1 
               farad       F       electric capacitance                C/V                                     m−2∙kg−1∙s4∙A2 
               ohm         Ω       electric resistance,
                                   impedance, reactance                V/A                                     m2∙kg∙s−3∙A−2 
               siemens     S       electrical conductance              1/Ω                                     m−2∙kg−1∙s3∙A2 
               weber       Wb      magnetic flux                       J/A                                     m2∙kg∙s−2∙A−1 
               tesla       T       magnetic field strength, 
                                   magnetic flux density               V∙s/m2 = Wb/m2 = N/(A∙m)                kg∙s−2∙A−1 
               henry       H       inductance                          V∙s/A = Wb/A                            m2∙kg∙s−2∙A−2 
         
        
               Celsius     C       temperature                         K − 273.15                              K − 273.15 
               lumen       lm      luminous flux                       lx·m2                                   cd·sr 
               lux         lx      illuminance                         lm/m2                                   m−2∙cd∙sr 
               becquerel   Bq      radioactivity 
                                   (decays per unit time)              1/s                                     s−1 
               gray        Gy      absorbed dose 
                                   (of ionizing radiation)             J/kg                                    m2∙s−2 
               sievert     Sv      equivalent dose 
                                   (of ionizing radiation)             J/kg                                    m2∙s−2 
               katal       kat     catalytic activity                  mol/s                                   s−1∙mol 
         
       */


}
