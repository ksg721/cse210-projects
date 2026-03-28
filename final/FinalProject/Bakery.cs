using System;
using System.Collections.Generic;

public class Bakery
{
    Order _currentOrder;

    public Bakery()
    {
        
    }
        public void Start()
    {

        Console.WriteLine("Welcome to the Bakery!");

        CreateOrder();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. View Order");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddItemToOrder();
                    break;
                case "2":
                    Product item = new Cookie("cookie", 5, "cookie", 5);
                    Console.WriteLine("What item would you like to remove?");
                    _currentOrder.ListOrder();
                    choice = Console.ReadLine();
                    _currentOrder.RemoveItem(int.Parse(choice) - 1);
                    break;
                case "3":
                    Console.WriteLine(_currentOrder.GetOrderSummary());
                    break;
                case "4":
                    Checkout();
                    running = false;
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    public void CreateOrder()
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine();

        int id = new Random().Next(1000, 9999);
        Customer customer = new Customer(name, id);

        _currentOrder = new Order(customer);
        customer.AddOrder(_currentOrder);

        Console.WriteLine("Order created for " + name);
    }

    public void AddItemToOrder()
    {
        Menu menu = new Menu();
        menu.DisplayMenu();
        Product product = menu.GetSelection();
        _currentOrder.AddItem(product);
    }

    public void Checkout()
    {
        double total = _currentOrder.CalculateTotal();
        Console.WriteLine("\nOrder Total: $" + total);

        Console.WriteLine("Thank you for your order!");
    }
}