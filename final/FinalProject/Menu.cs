using System;
using System.Collections.Generic;

public class Menu
{
    private List<string> _cakeFlavors;
    private List<string> _cakeFrostings;
    private List<string> _cookieTypes;
    private List<string> _aebleskiverFillings;
    private List<string> _aebleskiverToppings;

    public Menu()
    {
        _cakeFlavors = new List<string> { "Chocolate", "Vanilla", "Red Velvet", "Lemon", "Carrot", "Chocolate Carrot"};
        _cakeFrostings = new List<string> { "Chocolate", "Vanilla", "Butter Cream", "Cream Cheese"};
        _cookieTypes = new List<string> { "Chocolate Chip", "Peanut Butter", "Oatmeal", "Sugar", "Snickerdoodle", "White Chocolate Macadamia Nut"};
        _aebleskiverFillings = new List<string> { "Strawberry", "Blueberry", "Cinnamon Apple", "Sausage", "Cheese", "Plain"};
        _aebleskiverToppings = new List<string> { "Powdered Sugar", "Syrup", "Plain"};
    }

    public void DisplayMenu()
    {
        Console.WriteLine("1. Cake");
        Console.WriteLine("2. Cookie");
        Console.WriteLine("3. Banana Bread");
        Console.WriteLine("4. Aebleskiver");
    }

    public Product GetSelection()
    {
        while (true)
        {
            Console.Write("Select item: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string flavor = GetOption("Select a cake flavor:", _cakeFlavors);
                    string frosting = GetOption("Select a frosting:", _cakeFrostings);
                    return new Cake($"{flavor} {frosting} frosting cake", 5, flavor, frosting);

                case "2":
                    string cookieType = GetOption("Select a cookie type:", _cookieTypes);
                    int quantity = GetQuantity("How many Cookies do you want?");
                    return new Cookie($"{cookieType} cookie", 5, cookieType, quantity);

                case "3":
                    bool chips = GetYesNo("Would you like chocolate chips in your Banana Bread? (y/n)");
                    bool nuts = GetYesNo("Would you like nuts in your Banana Bread? (y/n)");
                    return new BananaBread("Banana Bread", 5, nuts, chips);

                case "4":
                    string filling = GetOption("Select a filling:", _aebleskiverFillings);
                    string topping = GetOption("Select a topping:", _aebleskiverToppings);
                    quantity = GetQuantity("How many Aebleskivers do you want?");
                    return new Aebleskiver($"{filling} Aebleskivers", 5, quantity, filling, topping);

                default:
                    Console.WriteLine("Invalid selection. Please try again.\n");
                    break;
            }
        }
    }

    private string GetOption(string prompt, List<string> options)
    {
        while (true)
        {
            Console.WriteLine(prompt);

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.Write("Enter choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice) &&
                choice >= 1 && choice <= options.Count)
            {
                return options[choice - 1];
            }

            Console.WriteLine("Invalid input. Please enter a valid number.\n");
        }
    }

    private int GetQuantity(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            Console.WriteLine("1. 3");
            Console.WriteLine("2. 6");
            Console.WriteLine("3. 12");
            Console.WriteLine("4. 24");

            Console.Write("Enter choice: ");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1": 
                    return 3;

                case "2": 
                    return 6;

                case "3": 
                    return 12;

                case "4": 
                    return 24;

                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
    }

    private bool GetYesNo(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().ToLower();

            if (input == "y") return true;
            if (input == "n") return false;

            Console.WriteLine("Please enter 'y' or 'n'.\n");
        }
    }
}