using System;

public class Customer
{
    private string _name;
    private int _loyaltyPoints;

    public Customer(string name)
    {
        _name = name;
        _loyaltyPoints = 0;
    }

    public Customer(string name, int loyaltyPoints)
    {
        _name = name;
        _loyaltyPoints = loyaltyPoints;
    }

    public void AddLoyaltyPoints(int points)
    {
        _loyaltyPoints += points;
    }

    public string GetCustomerInfo()
    {
        return $"{_name},{_loyaltyPoints}";
    }

    public int GetLoyaltyPoints()
    {
        return _loyaltyPoints;
    }

    public string GetName()
    {
        return _name;
    }
}