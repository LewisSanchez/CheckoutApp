using System.Collections.Generic;

namespace CheckoutApp
{
    /// <summary>
    /// Utility class for loading items and their prices.
    /// </summary>
    public static class ItemPriceLoader
    {
        /// <summary>
        /// Loads each item and their respective prices.
        /// </summary>
        /// <returns>Dictionary with the price for each item.</returns>
        public static Dictionary<char, int> Load()
        {
            return new Dictionary<char, int>
            {
                { 'A', 20 },
                { 'B', 50 },
                { 'C', 30 }
            };
        }
    }
}
