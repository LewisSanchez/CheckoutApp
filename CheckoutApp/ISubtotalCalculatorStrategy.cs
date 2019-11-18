namespace CheckoutApp
{
    public interface ISubtotalCalculatorStrategy
    {
        int CalculateSubtotal(int price, int checkoutQuantity);
    }
}
