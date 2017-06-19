using System;
using System.Collections;
using System.ComponentModel;
using UnitSystems.Interfaces;
using UnitSystems.SI;
using UnitSystems.SI.Base;

namespace UnitSystems
{

    public struct ProductOf<T1, T2> : IUnit
        where T1 : IUnit
        where T2 : IUnit
    {
        private readonly T1 _unit1;
        private readonly T2 _unit2;
        private double _value;

        public ProductOf(T1 unit1, T2 unit2)
            : this(unit1, unit2, unit1.Value * unit2.Value)
        {
        }

        public ProductOf(T1 unit1, T2 unit2, double value)
        {
            _unit1 = unit1;
            _unit2 = unit2;
            _value = value;
        }


        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Symbol
        {
            get
            {
                return String.Format("{0}·{1}", _unit1.Symbol, _unit2.Symbol);
            }
        }

        //public string Symbol()
        //{
        //    return String.Format("{0}·{1}", _unit1.Symbol, _unit2.Symbol);
        //}

        public static T1 operator /(ProductOf<T1, T2> source, T2 unit)
        {
            var result = default(T1);
            result.Value = source.Value / unit.Value;
            return result;
        }

        public static QuotientOf<ProductOf<T1, T2>, Second> operator /(ProductOf<T1, T2> source, Second second)
        {
            var q = new QuotientOf<ProductOf<T1, T2>, Second>(new ProductOf<T1, T2>(default(T1), default(T2)), second,
                source.Value/second.Value);
            return q;
        }

        public static QuotientOf<ProductOf<T1, T2>, Kilogram> operator /(ProductOf<T1, T2> source, Kilogram kilogram)
        {
            var q = new QuotientOf<ProductOf<T1, T2>, Kilogram>(new ProductOf<T1, T2>(default(T1), default(T2)), kilogram,
                source.Value / kilogram.Value);
            return q;
        }


        public static QuotientOf<ProductOf<T1, T2>, Metre> operator /(ProductOf<T1, T2> source, Metre metre)
        {
            var q = new QuotientOf<ProductOf<T1, T2>, Metre>(new ProductOf<T1, T2>(default(T1), default(T2)), metre,
                source.Value / metre.Value);
            return q;
        }

        public static QuotientOf<ProductOf<T1, T2>, Ampere> operator /(ProductOf<T1, T2> source, Ampere ampere)
        {
            var q = new QuotientOf<ProductOf<T1, T2>, Ampere>(new ProductOf<T1, T2>(default(T1), default(T2)), ampere,
                source.Value / ampere.Value);
            return q;
        }


        public static ProductOf<T1, T2, Second> operator *(ProductOf<T1, T2> source, Second second)
        {
            var q = new ProductOf<T1, T2, Second>(default(T1), default(T2), second, source.Value * second.Value);
            return q;
        }

        public static ProductOf<T1, T2, Kilogram> operator *(ProductOf<T1, T2> source, Kilogram kilogram)
        {
            var q = new ProductOf<T1, T2, Kilogram>(default(T1), default(T2), kilogram, source.Value * kilogram.Value);
            return q;
        }

        public static ProductOf<T1, T2, Metre> operator *(ProductOf<T1, T2> source, Metre metre)
        {
            var q = new ProductOf<T1, T2, Metre>(default(T1), default(T2), metre, source.Value * metre.Value);
            return q;
        }

        public static ProductOf<T1, T2, Ampere> operator *(ProductOf<T1, T2> source, Ampere ampere)
        {
            var q = new ProductOf<T1, T2, Ampere>(default(T1), default(T2), ampere, source.Value * ampere.Value);
            return q;
        }

        public static T2 operator /(ProductOf<T1, T2> source, T1 unit)
        {
            var result = default(T2);
            result.Value = source.Value / unit.Value;
            return result;
        }


        public static ProductOf<T1, T2> operator /(int value, ProductOf<T1, T2> source)
        {
            return new ProductOf<T1, T2>(source._unit1, source._unit2, value / source.Value);
        }


        public override string ToString()
        {
            return String.Format("{0} {1}", Value, Symbol);
        }
    }


    public struct ProductOf<T1, T2, T3> : IUnit
        where T1 : IUnit
        where T2 : IUnit
        where T3 : IUnit
    {
        private readonly T1 _unit1;
        private readonly T2 _unit2;
        private readonly T3 _unit3;
        private double _value;

        public ProductOf(T1 unit1, T2 unit2, T3 unit3)
            : this(unit1, unit2, unit3, unit1.Value * unit2.Value * unit3.Value)
        {
        }

        public ProductOf(T1 unit1, T2 unit2, T3 unit3, double value)
        {
            _unit1 = unit1;
            _unit2 = unit2;
            _value = value;
            _unit3 = unit3;
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        string IUnit.Symbol
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Symbol()
        {
            return String.Format("{0}·{1}·{2}", _unit1.Symbol, _unit2.Symbol, _unit3.Symbol);
        }
    }


}