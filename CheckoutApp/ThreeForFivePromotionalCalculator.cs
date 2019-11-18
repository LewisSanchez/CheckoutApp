namespace CheckoutApp
{
    /// <summary>
    /// Class that assists with the subtotal calculation for any items that are on a 5 for 3 sale.
    /// </summary>
    public class FiveForThreePromotionalCalculator : ISubtotalCalculatorStrategy
    {
        private const int DISCOUNT_SCALER = 3;
        private const int DISCOUNT_ITEM_QUANTITY = 5;

        public FiveForThreePromotionalCalculator()
        {

        }

        /// <summary>
        /// Calculates the promotional 5 for the price of 3 subtotal, and/or the standard subtotal when the
        /// item quantity doesn't divide evenly by 5.
        /// </summary>
        /// <param name="price">The price of an item.</param>
        /// <param name="checkoutQuantity">The checkout quantity of an item.</param>
        /// <returns></returns>
        public int CalculateSubtotal(int price, int checkoutQuantity)
        {
            var subtotal = 0;
            var numberOfDiscountedGroups = checkoutQuantity / DISCOUNT_ITEM_QUANTITY;
            var numberOfRegularPricedItems = checkoutQuantity % DISCOUNT_ITEM_QUANTITY;

            subtotal += DISCOUNT_SCALER * price * numberOfDiscountedGroups;
            subtotal += price * numberOfRegularPricedItems;

            return subtotal;
        }
    }
}
