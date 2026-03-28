public class Discount
{
    private double _discountRate;
    private int _loyaltyThreshold;

    public Discount(double discountRate, int loyaltyThreshold)
    {
        _discountRate = discountRate;
        _loyaltyThreshold = loyaltyThreshold;
    }

    public double ApplyDiscount(Order order)
    {
        return CalculateDiscount(order);
    }

    public double CalculateDiscount(Order order)
    {
        double total = order.CalculateTotal();
        return total * _discountRate;
    }

    public double ApplyLoyaltyDiscount(Customer customer)
    {
        if (customer.GetLoyaltyPoints() >= _loyaltyThreshold)
        {
            return 5.0; // flat discount
        }

        return 0;
    }
}