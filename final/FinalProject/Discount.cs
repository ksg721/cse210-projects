public class Discount
{
    private double _discountRate;
    private int _loyaltyThreshold;

    public Discount(double discountRate, int loyaltyThreshold)
    {
        _discountRate = discountRate;
        _loyaltyThreshold = loyaltyThreshold;
    }

    public double ApplyLoyaltyDiscount(Customer customer, double price)
    {
        if (customer.GetLoyaltyPoints() >= _loyaltyThreshold)
        {
            return price * _discountRate;
        }

        return price;
    }
}