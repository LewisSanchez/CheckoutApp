using System.Collections.Generic;

namespace CheckoutApp
{
    /// <summary>
    /// Utility class for loading items and their prices.
    /// </summary>
    public static class Loader
    {
        /// <summary>
        /// Loads each item and their respective prices.
        /// </summary>
        /// <returns>Dictionary with the price for each item.</returns>
        public static Dictionary<char, int> LoadItems()
        {
            return new Dictionary<char, int>
            {
                { 'A', 20 },
                { 'B', 50 },
                { 'C', 30 }
            };
        }

        /// <summary>
        /// Loads a calculator for each item, so that each item can be priced normally or promotionally.
        /// </summary>
        /// <returns>Dictionary with the subtotal calculator for each item.</returns>
        public static Dictionary<char, ISubtotalCalculatorStrategy> LoadSubtotalCalculators()
        {
            var standardSubtotalCalculator = new StandardSubtotalCalculator();
            var FiveForThreePromotionalCalculator = new FiveForThreePromotionalCalculator();

            return new Dictionary<char, ISubtotalCalculatorStrategy>
            {
                { 'A', standardSubtotalCalculator },
                { 'B', FiveForThreePromotionalCalculator },
                { 'C', standardSubtotalCalculator }
            };
        }
    }
}
