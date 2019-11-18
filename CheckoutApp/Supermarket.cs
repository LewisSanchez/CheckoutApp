using System.Collections.Generic;
using System.Linq;

namespace CheckoutApp
{
    public class Supermarket : ISupermarket
    {
        private Dictionary<char, int> _carriedItemPrices;
        private Dictionary<char, ISubtotalCalculatorStrategy> _itemCheckoutCalculators;

        /// <summary>
        /// Creates an instance of a Supermarket with the specified item prices.
        /// </summary>
        /// <param name="itemPrices">Dictionary of items and their prices that will be sold by the Supermarket.</param>
        /// <param name="itemCheckoutCalculators">Dictionary of standard and promotional calculators that applies to each Item.</param>
        public Supermarket(Dictionary<char, int> itemPrices, Dictionary<char, ISubtotalCalculatorStrategy> itemCheckoutCalculators)
        {
            _carriedItemPrices = itemPrices;
            _itemCheckoutCalculators = itemCheckoutCalculators;
        }

        /// <summary>
        /// Determines the total price for a sequence of characters representing
        /// items to be checked out.
        /// </summary>
        /// <param name="items">Character string.</param>
        /// <returns>The total price for the passed in items.</returns>
        public int Checkout(string items)
        {
            var total = 0;

            if (string.IsNullOrWhiteSpace(items))
                return total;

            items = items.ToUpper();

            var checkoutItemQuantities = FindCheckoutItemQuantities(items);
            var checkoutItemList = checkoutItemQuantities.Keys.ToList();

            foreach (var checkoutItem in checkoutItemList)
                total += _itemCheckoutCalculators[checkoutItem].CalculateSubtotal(_carriedItemPrices[checkoutItem], checkoutItemQuantities[checkoutItem]);

            return total;
        }

        /// <summary>
        /// Determines the quantity of each market item that will be checked out.
        /// </summary>
        /// <param name="items">character string.</param>
        /// <returns>The quantity of each item that will be checked out.</returns>
        private Dictionary<char, int> FindCheckoutItemQuantities(string items)
        {
            var itemQuantities = new Dictionary<char, int>();

            foreach (var item in items)
            {
                if (IsValidMarketItem(item))
                {
                    if (!itemQuantities.ContainsKey(item))
                        itemQuantities[item] = 0;

                    itemQuantities[item]++;
                }
            }

            return itemQuantities;
        }

        /// <summary>
        /// Determines if the current item is a valid store item.
        /// </summary>
        /// <param name="item">A character representing an item.</param>
        /// <returns>Indicates whether an item is a valid market item.</returns>
        private bool IsValidMarketItem(char item)
        {
            return _carriedItemPrices.ContainsKey(item);
        }
    }
}
