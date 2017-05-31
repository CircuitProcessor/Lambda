using UnitSystems.Interfaces;
using UnitSystems.SI.Base;

namespace UnitSystems.SI
{
    /// <summary>
    /// Represents unit of work. 
    /// See:<see cref="Farad"/>.
    /// </summary>
    public struct Watt : IUnit
    {
        /// <summary>Here is an example of a bulleted list:
        /// <list type="table">
        /// <item>
        /// <description>Item 1.</description>
        /// </item>
        /// <item>
        /// <description>Item 2.</description>
        /// </item>
        /// </list>
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// The GetZero method.
        /// </summary>
        /// <example> 
        /// This sample shows how to call the <see cref="Symbol"/> method.
        /// <code>
        /// class TestClass 
        /// {
        ///     static int Main() 
        ///     {
        ///         return GetZero();
        ///     }
        /// }
        /// </code>
        /// </example>
        public string Symbol
        {
            get { return "W"; }
        }

        #region J = W∙s
        public static Joule operator *(Watt watt, Second sec)
        {
            return new Joule() { Value = watt.Value * sec.Value };
        }
        #endregion

        #region +/-/=

        public static bool operator ==(Watt watt1, Watt watt2)
        {
            return watt1.Value.Equals(watt2.Value);
        }

        public static bool operator !=(Watt watt1, Watt watt2)
        {
            return !(watt1 == watt2);
        }

        public static Watt operator +(Watt watt1, Watt watt2)
        {
            return new Watt() { Value = watt1.Value + watt2.Value };
        }

        public static Watt operator -(Watt watt1, Watt watt2)
        {
            return new Watt() { Value = watt1.Value - watt2.Value };
        }
        #endregion

        #region W = V∙A
        public static implicit operator ProductOf<Volt, Ampere>(Watt watt)
        {
            return new ProductOf<Volt, Ampere>(new Volt(), new Ampere(), watt.Value);
        }
        public static implicit operator Watt(ProductOf<Volt, Ampere> source)
        {
            return new Watt() { Value = source.Value };
        }
        #endregion

        #region W = A²∙Ω
        public static implicit operator ProductOf<SquareOf<Ampere>, Ohm>(Watt watt)
        {
            var amper = new Ampere();
            var resistance = new Ohm();
            return new ProductOf<SquareOf<Ampere>, Ohm>(amper ^ 2, resistance, watt.Value);
        }
        public static implicit operator Watt(ProductOf<SquareOf<Ampere>, Ohm> source)
        {
            return new Watt() { Value = source.Value };
        }
        #endregion

        public static implicit operator Watt(double value)
        {
            return new Watt() { Value = value };
        }


    }
}