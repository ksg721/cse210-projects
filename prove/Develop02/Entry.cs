using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _prompt2;
    public string _response2;
    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine($"{_prompt2}");
        Console.WriteLine(_response2);
        Console.WriteLine();
    }
}