using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public static Reference CreateFromUserInput()
{
    Console.WriteLine("Enter the book name (e.g., John):");
    string book = Console.ReadLine();

    Console.WriteLine("Enter the chapter number:");
    int chapter = int.Parse(Console.ReadLine());

    Console.WriteLine("Is this a single verse or a range? (type 'single' or 'range')");
    string type = Console.ReadLine().ToLower();

    if (type == "range")
    {
        Console.WriteLine("Enter the starting verse number:");
        int startVerse = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the ending verse number:");
        int endVerse = int.Parse(Console.ReadLine());

        return new Reference(book, chapter, startVerse, endVerse);
    }
    else
    {
        Console.WriteLine("Enter the verse number:");
        int verse = int.Parse(Console.ReadLine());

        return new Reference(book, chapter, verse);
    }
}

    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}