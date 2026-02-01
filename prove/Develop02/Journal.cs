using System;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

public void AddEntry()
{
    PromptGenerator promptGenerator = new PromptGenerator();

    string prompt = promptGenerator.GetRandomPrompt();
    Console.WriteLine($"Prompt: {prompt}");
    Console.Write("Your response: ");
    string response = Console.ReadLine();

    string prompt2 = promptGenerator.GetPromptTwo();
    Console.WriteLine($"Prompt 2: {prompt2}");
    Console.Write("Your response: ");
    string response2 = Console.ReadLine();

    Entry entry = new Entry
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd"),
        _prompt = prompt,
        _response = response,
        _prompt2 = prompt2,
        _response2 = response2
    };

    _entries.Add(entry);
}

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._prompt}~|~{entry._response}~|~{entry._prompt2}~|~{entry._response2}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] lineParts = line.Split("~|~");
            Entry entry = new Entry();
            entry._date = lineParts[0];
            entry._prompt = lineParts[1];
            entry._response = lineParts[2];
            entry._prompt2 = lineParts[3];
            entry._response2 = lineParts[4];
            _entries.Add(entry);
        }
    }
}