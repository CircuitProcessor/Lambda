using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitSystems.Interfaces;

namespace UnitSystems.SI
{
    struct Joule : IUnit
    {
        public double Value { get; set; }
        public string Symbol()
        {
            return "J";
        }

        #region W = J/s
        public static Watt operator /(Joule joule, Second sec)
        {
            return new Watt() { Value = joule.Value * sec.Value };
        }
        #endregion

        #region +/-
        public static Joule operator +(Joule joule1, Joule joule2)
        {
            return new Joule() { Value = joule1.Value + joule2.Value };
        }
        public static Joule operator -(Joule joule1, Joule joule2)
        {
            return new Joule() { Value = joule1.Value - joule2.Value };
        }
        #endregion

        public static implicit operator Joule(double value)
        {
            return new Joule() { Value = value };
        }
    }
}
