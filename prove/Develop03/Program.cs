using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = Reference.CreateFromUserInput();

        Console.WriteLine("Enter the scripture text:");
        string text = Console.ReadLine();

        Scripture scripture = new Scripture(reference, text);

        scripture.StartMemorizing();
    }
}