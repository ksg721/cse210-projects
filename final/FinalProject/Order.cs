using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _items;

    public Order()
    {
        _items = new List<Product>();
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
        double Total = 0;

        foreach (Product item in _items)
        {
            Total += item.CalculatePrice();
        }

        return Total;
    }

    public string GetOrderSummary()
    {
        if (_items.Count == 0)
        {
            return "Your order is empty.";
        }

        string summary = "Order Summary:\n";

        foreach (Product item in _items)
        {
            summary += "- " + item.GetDescription() + "\n";
        }

        summary += $"Total: ${CalculateTotal():F2}";

        return summary;
    }

    public void ListOrder()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("Your order is empty.");
            return;
        }
        int i = 1;
        foreach (Product item in _items)
        {
            Console.WriteLine($"{i}. {item.GetDescription()}");
            i++;
        }
    }
}