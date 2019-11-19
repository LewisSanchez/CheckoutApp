namespace CheckoutApp
{
    /// <summary>
    /// Class that assists with the subtotal calculation for any items that are on a 5 for 3 sale.
    /// </summary>
    public class FiveForThreePromotionalCalculator : ISubtotalCalculatorStrategy
    {
        private const int WHAT_YOU_PAY_QUANTITY = 3;
        private const int PROMO_TAKE_HOME_QUANTITY = 5;

        public FiveForThreePromotionalCalculator()
        {

        }

        /// <summary>
        /// Calculates the promotional 5 for the price of 3 subtotal, and/or the standard subtotal when the
        /// item quantity doesn't divide evenly by 5.
        /// </summary>
        /// <param name="price">The price of an item.</param>
        /// <param name="checkoutQuantity">The checkout quantity of an item.</param>
        /// <returns>The checkout total for the item.</returns>
        public int CalculateSubtotal(int price, int checkoutQuantity)
        {
            var subtotal = 0;
            var numberOfDiscounts = checkoutQuantity / PROMO_TAKE_HOME_QUANTITY;
            var numberOfRegularPricedItems = checkoutQuantity % PROMO_TAKE_HOME_QUANTITY;

            subtotal += WHAT_YOU_PAY_QUANTITY * price * numberOfDiscounts;
            subtotal += price * numberOfRegularPricedItems;

            return subtotal;
        }
    }
}
