using UnitSystems.Interfaces;
using UnitSystems.SI.Base;
using UnitSystems.SI.Complex;

namespace UnitSystems.SI
{
    public struct Weber : IUnit
    {
        public Weber(double value)
        {
            Value = value;
        }
        public double Value { get; }
        public string Symbol => "Wb";

        public static implicit operator Weber(ProductOf<Volt, Second> voltageSeconds)
        {
            return new Weber(voltageSeconds.Value);
        }

        public static implicit operator ProductOf<Volt, Second>(Weber weber)
        {
            return new ProductOf<Volt, Second>(new Volt(), new Second(), weber.Value);
        }

        public static implicit operator Weber(double value)
        {
            return new Weber(value);
        }

        public static Tesla operator /(Weber weber, SquareOf<Metre> metre)
        {
            return new Tesla(weber.Value / metre.Value);
        }

        public static Weber operator +(Weber weber1, Weber weber2)
        {
            return new Weber(weber1.Value + weber2.Value);
        }
        public static Weber operator -(Weber weber1, Weber weber2)
        {
            return new Weber(weber1.Value - weber2.Value);
        }

    }
}