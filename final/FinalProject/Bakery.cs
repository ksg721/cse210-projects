using System;
using System.Collections.Generic;

public class Bakery
{
    private Order _currentOrder;
    private List<Customer> _customers;
    private Customer _currentCustomer;
    private FileManager _fileManager;
    private Menu menu = new Menu();

    public Bakery(List<Customer> customers)
    {
        _customers = customers;
        _currentOrder = new Order();
        _fileManager = new FileManager("customer_data.txt");
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
                    if (_currentOrder.CalculateTotal() == 0)
                    {
                        Console.WriteLine("Your order is empty.");
                        break;
                    }
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
        string name = Console.ReadLine().Trim();
        _currentCustomer = null;

        foreach (Customer customer in _customers)
        {
            if (customer.GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                _currentCustomer = customer;
                break;
            }
        }

        if (_currentCustomer == null)
        {
            _currentCustomer = new Customer(name);
            _customers.Add(_currentCustomer);
        }

        Console.WriteLine($"Welcome, {_currentCustomer.GetName()}! You have {_currentCustomer.GetLoyaltyPoints()} loyalty points.");
    }

    public void AddItemToOrder()
    {
        menu.DisplayMenu();
        Product product = menu.GetSelection();
        _currentOrder.AddItem(product);
    }

    public void Checkout()
    {
        Discount discount = new Discount(.9, 100);

        double total = discount.ApplyLoyaltyDiscount(_currentCustomer, _currentOrder.CalculateTotal());
        Console.WriteLine($"Your total is: ${total:F2}");
        _currentCustomer.AddLoyaltyPoints((int)total);
        Console.WriteLine($"You have {_currentCustomer.GetLoyaltyPoints()} loyalty points.");

        _fileManager.SaveCustomerData(_customers);
    }
}