using System;

public class Activity
{
    private string _activityName;
    private string _description;
    private int _duration;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());
        SetDuration(duration);
        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplaySpinner();
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("Well done!");
        DisplaySpinner();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_activityName}.");
        Console.Clear();
    }

    public void DisplaySpinner()
    {
        List<string> spinner = ["|", "/", "-", "\\"];

        int i = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(5);
        while (DateTime.Now < endTime)
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
    }
}