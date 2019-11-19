namespace CheckoutApp
{
    /// <summary>
    /// Class that assists with the standard subtotal calculation for items that aren't on sale
    /// </summary>
    public class StandardSubtotalCalculator : ISubtotalCalculatorStrategy
    {
        /// <summary>
        /// Instantiates a StandardSubtotalCalculator
        /// </summary>
        public StandardSubtotalCalculator()
        {

        }

        /// <summary>
        /// Calculates the standard subtotal for items that aren't on a promotional sale.
        /// </summary>
        /// <param name="price">The price of an item.</param>
        /// <param name="checkoutQuantity">The checkout quantity of an item.</param>
        /// <returns>The checkout total for the item.</returns>
        public int CalculateSubtotal(int price, int checkoutQuantity)
        {
            return price * checkoutQuantity;
        }
    }
}
