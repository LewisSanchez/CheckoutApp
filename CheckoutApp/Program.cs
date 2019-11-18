using System;

namespace CheckoutApp
{
    /// <summary>
    /// This program determines the total checkout amount for a
    /// sequence of items.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var items = "ABBACBBAB";
            var market = new Supermarket(ItemPriceLoader.Load());

            Console.WriteLine(market.Checkout(items));
        }
    }
}
