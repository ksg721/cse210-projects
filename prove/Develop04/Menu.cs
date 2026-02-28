using System;

public class Menu
{
    public void Display()
    {
        bool on = true;
        while (on)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflection Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Start();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Start();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Start();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    on = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}