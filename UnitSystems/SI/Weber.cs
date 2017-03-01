using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    struct Weber : IUnit
    {
        public double Value { get; set; }
        public string Symbol
        {
            get { return "Wb"; }
        }

        public static implicit operator Weber(ProductOf<Volt, Second> voltageSeconds)
        {
            return new Weber() {Value = voltageSeconds.Value};
        }

        public static implicit operator ProductOf<Volt, Second>(Weber weber)
        {
            return new ProductOf<Volt, Second>(new Volt(), new Second(), weber.Value);
        }

        public static implicit operator Weber(double value)
        {
            return new Weber() { Value = value };
        }

        public static Tesla operator /(Weber weber, SquareOf<Metre> metre)
        {
            return new Tesla() { Value = weber.Value / metre.Value };
        }

        public static Weber operator +(Weber weber1, Weber weber2)
        {
            return new Weber() { Value = weber1.Value + weber2.Value };
        }
        public static Weber operator -(Weber weber1, Weber weber2)
        {
            return new Weber() { Value = weber1.Value - weber2.Value };
        }

    }
}