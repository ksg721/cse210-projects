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

// I exceeded the requirements by having the user input the scripture and reference 
// so they can do any scripture they want and I changed the word hiding to only hide
// words that are not already hidden.