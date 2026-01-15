using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();

        int number;
        int sum = 0;
        int max = 0;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        foreach (int num in numbers)
        {
            sum += num;
            if (num > max)
            {
                max = num;
            }
        }
        
        float average = (float)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}