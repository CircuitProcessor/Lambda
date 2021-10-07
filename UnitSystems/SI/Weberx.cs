//namespace UnitSystems.SI
//{
//    using UnitSystems.Complex;

//    public struct Weber : IUnit
//    {
//        public Weber(double value)
//        {
//            Value = value;
//        }
//        public double Value { get; }
//        public string Symbol => "Wb";

//        public static implicit operator Weber(ProductOf<Volt, Second> voltageSeconds)
//        {
//            return new(voltageSeconds.Value);
//        }

//        public static implicit operator ProductOf<Volt, Second>(Weber weber)
//        {
//            return new(new Volt(), new Second(), weber.Value);
//        }


//        public static Tesla operator /(Weber weber, SquareOf<Metre> metre)
//        {
//            return new(weber.Value / metre.Value);
//        }



//    }
//}