# UnitSystems

A library that provides strongly typed units of measure. Extremely fast, easy to extend and easy to use. Provides on-the-fly units conversion in magnitude and different representations.

No more runtime exceptions when it comes to units calculation and/or conversion.

## Samples

Samples below show some of the possibilities that can be achieved by using the library. They are not limited only to presented cases although some of them may need additional rules implemented according to the law of physics.

R# template is available for quick new units creation. It is available under:

`Add -> New from Template -> All Templates -> Unit`

## Basics

Let's start from simple case:

```C#
// Implicit or traditional style declaration
Volt volt0;
Volt volt1 = 1.0;
Volt volt2 = new Volt(1);

// Build-in standard comparison operators present in ordinary types such as int
bool equal = volt1 == volt2;                // true
bool notEqual = volt1 != volt2;             // false
bool greaterThan = volt1 > volt2;           // false
bool smallerThan = volt1 < volt2;           // false
bool graterThanOrEqual = volt1 >= volt2;    // true
bool smallerThanOrEqual = volt1 <= volt2;   // true

// Addition and subtraction
Volt sum = volt1 + volt2;   // sum = 2 V
Volt diff = volt1 - volt2;  // diff = 0 V
```

## Conversions

Conversion in magnitude:

```C#
Gram g = 1000;                // 1000 g
Kilogram kg = (Kilogram)g;      // 1000 g = 1 kg

Metre m = 1;                    // 1 m
Millimetre mm = (Millimetre)m;    // 1 m = 1000 mm
```

Conversion in representation:

```C#
Newton N = 1;
Metre m = 1;

Joule joule = N * m;
```

## Advanced

More complicated cases when on-the-fly conversions comes in:

```C#
Metre m = 1;
Ampere I = 4;
Ohm R = 10;

// Metre times Metre is Metre Squared: m · m = m²
SquareOf<Metre> metreSquared = m * m;

// Square metre divided by metre is.. metre!
Metre metre = (m * m) / m;

// Watt unit composition: W = (A²)*R
Watt watt = (I * I) * R;
```

Not explicitly defined unit in SI representation can also be used to define rules for unit conversions:

```C#
Coulomb C = 1;
Joule J = 1;
Volt V = 20;

// Farad in base SI = C²/J
QuotientOf<SquareOf<Coulomb>, Joule> faradSi = (C * C) / J;

// Farad times Volt = Coulomb (even if multiplied in base SI representation)
Coulomb coulomb = faradSi * V;
```

Simple rules between different units can result in complex dependencies:

```C#
Newton N = 1;
Metre m = 1;
Volt V = 20;
Ohm R = 10;

// Nested multiple implicit unit resolution
// Wb = J/A | J = N∙m | A = V/R
Weber weber = (N * m) / (V / R);
```

## Real case scenario

Ohm's law:

```C#
// Ohm's Law
Volt v = 20;
Ohm r = 10;
Ampere i = 4;

Volt volt = i * r;      // volt = 40 V
Ohm ohm = v / i;        // ohm = 5 Ω
Ampere ampere = v / r;  // ampere = 2 A
```
