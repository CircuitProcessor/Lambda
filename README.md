# UnitSystems

A library that provides strongly typed units of measure. Extremely fast and easy to use. 
No more runtime exceptions when it comes to units calculation and/or conversion.

## Samples
```C#
Volt V = 20;
Ohm R = 10;
Ampere I = 4;

// Ohm's Law
Volt Vz = I * R;  // 40 V
Ohm Rz = V / I;   // 5 Ω
Ampere Iz = V / R;  // 2 A

Metre m = 1;
Coulomb C = 1;
Joule J = 1;

// Farad in base SI = C^2/J
QuotientOf<SquareOf<Coulomb>, Joule> farad_SI = (C * C) / J;
// Farad times Volt = Coulomb (even if multiplied in base SI representation)
Coulomb coulomb = farad_SI * V;

// W = (A^2)*R
Watt watt = (I * I) * R;
```