using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitSystems.SI.Base
{
    public struct WeberSI
    {
        internal QuotientOf<ProductOf<Kilogram,SquareOf<Metre>>, ProductOf<SquareOf<Second>,Ampere>> Value { get; set; }    // (kg*m^2 / s^2*A)


        //public double Value { get; set; }

    }

    public struct KilogramTimesSquareMetre
    {
        public double Value { get; set; }

        public static implicit operator ProductOf<Kilogram, SquareOf<Metre>>(KilogramTimesSquareMetre unit)
        {
            return new ProductOf<Kilogram, SquareOf<Metre>>() { Value = unit.Value};
        }

        public static implicit operator KilogramTimesSquareMetre(ProductOf<Kilogram, SquareOf<Metre>> unit)
        {
            return new KilogramTimesSquareMetre { Value = unit.Value };
        }   

        public static Weber operator /(KilogramTimesSquareMetre divisor, SquareSecondTimesAmpere divider)
        {
            return new Weber() { Value = divisor.Value/divider.Value};
        }
    }

    public struct SquareSecondTimesAmpere
    {
        public double Value { get; set; }

        public static implicit operator ProductOf<SquareOf<Second>, Ampere>(SquareSecondTimesAmpere unit)
        {
            return new ProductOf<SquareOf<Second>, Ampere> () { Value = unit.Value };
        }

        public static implicit operator SquareSecondTimesAmpere(ProductOf<SquareOf<Second>, Ampere> unit)
        {
            return new SquareSecondTimesAmpere { Value = unit.Value };
        }
    }
}
