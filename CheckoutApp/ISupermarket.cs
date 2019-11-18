namespace CheckoutApp
{
    /// <summary>
    /// Interface for concrete supermarkets.
    /// </summary>
    public interface ISupermarket
    {
        /// <summary>
        /// Determines the total price for a sequence of characters representing
        /// items to be checked out.
        /// </summary>
        /// <param name="items">Character string.</param>
        /// <returns>The total price for the passed in items.</returns>
        int Checkout(string items);
    }
}
