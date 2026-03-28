using System.Collections.Generic;

public class Order
{
    private List<Product> _items;
    private Customer _customer;
    private double _orderTotal;

    public Order(Customer customer)
    {
        _customer = customer;
        _items = new List<Product>();
        _orderTotal = 0;
    }

    public void AddItem(Product item)
    {
        _items.Add(item);
    }

    public void RemoveItem(int item)
    {
        _items.RemoveAt(item);
    }

    public double CalculateTotal()
    {
        _orderTotal = 0;

        foreach (Product item in _items)
        {
            _orderTotal += item.CalculatePrice();
        }

        return _orderTotal;
    }

    public void ApplyDiscount(Discount discount)
    {
        _orderTotal -= discount.ApplyDiscount(this);
    }

    public string GetOrderSummary()
    {
        string summary = "Order Summary:\n";

        foreach (Product item in _items)
        {
            summary += "- " + item.GetDescription() + "\n";
        }

        summary += "Total: $" + CalculateTotal();

        return summary;
    }

    public void ListOrder()
    {
        int i = 1;
        foreach (Product item in _items)
        {
            Console.WriteLine($"{i}. {item.GetDescription()}");
            i++;
        }
    }
}