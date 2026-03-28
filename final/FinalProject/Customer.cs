using System.Collections.Generic;

public class Customer
{
    private string _name;
    private int _customerId;
    private int _loyaltyPoints;
    private List<Order> _orders;

    public Customer(string name, int customerId)
    {
        _name = name;
        _customerId = customerId;
        _loyaltyPoints = 0;
        _orders = new List<Order>();
    }

    public Customer(string name, int customerId, int loyaltyPoints)
    {
        _name = name;
        _customerId = customerId;
        _loyaltyPoints = loyaltyPoints;
        _orders = new List<Order>();
    }

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    public List<Order> GetOrders()
    {
        return _orders;
    }

    public void AddLoyaltyPoints(int points)
    {
        _loyaltyPoints += points;
    }

    public string GetCustomerInfo()
    {
        return $"{_name} (ID: {_customerId}) - Points: {_loyaltyPoints}";
    }

    public int GetLoyaltyPoints()
    {
        return _loyaltyPoints;
    }
}