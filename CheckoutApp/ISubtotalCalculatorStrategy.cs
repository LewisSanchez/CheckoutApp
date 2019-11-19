namespace CheckoutApp
{
    /// <summary>
    /// Interface for item subtotal calculators
    /// </summary>
    public interface ISubtotalCalculatorStrategy
    {
        /// <summary>
        /// Calculates the total for a particular item and quantity.
        /// </summary>
        /// <param name="price">The price of the item.</param>
        /// <param name="checkoutQuantity">The checkout quantity of an item</param>
        /// <returns>The checkout total for the item.</returns>
        int CalculateSubtotal(int price, int checkoutQuantity);
    }
}
