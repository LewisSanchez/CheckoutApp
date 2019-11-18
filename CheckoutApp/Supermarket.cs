using System.Collections.Generic;
using System.Linq;

namespace CheckoutApp
{
    public class Supermarket : ISupermarket
    {
        private Dictionary<char, int> _carriedItemPrices;

        /// <summary>
        /// Creates an instance of a Supermarket with the specified item prices.
        /// </summary>
        /// <param name="itemPrices">List of items and their prices that will be sold by the Supermarket.</param>
        public Supermarket(Dictionary<char, int> itemPrices)
        {
            _carriedItemPrices = itemPrices;
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

            var purchasedItemQuantities = FindPurchasedItemQuantities(items);
            var purchasedItemList = purchasedItemQuantities.Keys.ToList();

            foreach (var purchasedItem in purchasedItemList)
            {
                if (purchasedItem == 'B')
                {
                    var reducedPricedGroupCount = purchasedItemQuantities[purchasedItem] / 5;
                    var regularPricedCount = purchasedItemQuantities[purchasedItem] % 5;

                    total += 3 * 50 * reducedPricedGroupCount;
                    total += _carriedItemPrices[purchasedItem] * regularPricedCount;
                }
                else
                    total += _carriedItemPrices[purchasedItem] * purchasedItemQuantities[purchasedItem];
            }

            return total;
        }

        /// <summary>
        /// Determines the quantity of each market item that will be checked out.
        /// </summary>
        /// <param name="items">character string.</param>
        /// <returns>The quantity of each item that will be checked out.</returns>
        private Dictionary<char, int> FindPurchasedItemQuantities(string items)
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
