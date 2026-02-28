using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?", 
        "What are personal strengths of yours?", 
        "Who are people that you have helped this week?", 
        "When have you felt the Holy Ghost this month?", 
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int i = random.Next(_prompts.Count);
        return _prompts[i];
    }

    public void Start()
    {
        DisplayStartMessage();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        for (int i = 5; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine("");
        List<string> responses = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            string response = Console.ReadLine();
            responses.Add(response);
        }
        Console.WriteLine($"You listed {responses.Count} items!");
        DisplayEndMessage();
    }
}