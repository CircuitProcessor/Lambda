using System;
using UnitSystems.Interfaces;
using UnitSystems.SI;
using UnitSystems.SI.Complex;

namespace UnitSystems
{
    public struct QuotientOf<T1, T2> : IUnit
        where T1 : IUnit
        where T2 : IUnit
    {
        private T1 _unit1;
        private T2 _unit2;
        private double _value;

        public QuotientOf(T1 unit1, T2 unit2)
            : this(unit1, unit2, unit1.Value / unit2.Value)
        {
        }

        public QuotientOf(T1 unit1, T2 unit2, double value)
        {
            _unit1 = unit1;
            _unit2 = unit2;
            _value = value;
        }

        //public static QuotientOf<T1, T2> operator /(T1 divider, T2 divisor)
        //{
            
        //} 


        public static T1 operator *(QuotientOf<Volt, T2> quotient1, QuotientOf<T1, T2> quotient2)
        {
            return default(T1);
        }

        //public static T1 operator *(T2 multiplier, QuotientOf<T1, T2> quotient2)
        //{
        //    var result = (multiplier.Value*quotient2.Dividend.Value)/quotient2.Divider.Value;
        //    var resultUnit = default(T1);
        //    resultUnit.Value = result;
        //    return resultUnit;
        //}

        //public static T1 operator *(QuotientOf<T1, T2> quotient2, T2 multiplier)
        //{
        //    var result = (multiplier.Value * quotient2.Dividend.Value) / quotient2.Divider.Value;
        //    var resultUnit = default(T1);
        //    resultUnit.Value = result;
        //    return resultUnit;
        //}

        public static ProductOf<T1,T2> operator *(QuotientOf<T1, T2> quotient, SquareOf<T2> square)
        {
            var result = new ProductOf<T1, T2>(quotient._unit1, quotient._unit2, quotient.Value*square.Value);
            return result;
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        //public string Symbol()
        //{
        //    return String.Format("{0}/{1}", _unit1.Symbol, _unit2.Symbol);
        //}



        public T1 Dividend { get { return _unit1; } set { /*_unit1 = value;*/ } }
        public T2 Divider { get { return _unit2; } set { /*_unit2 = value;*/ } }

        public string Symbol
        {
            get
            {
                return String.Format("{0}/{1}", _unit1.Symbol, _unit2.Symbol);
            }
        }
    }
}