using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Start()
    {
        DisplayStartMessage();
        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            int i = duration / 6;
            Console.WriteLine("\nBreathe in...");
            while (i >= 1)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
                i--;
            }
            Console.WriteLine("Breathe out...");
            i = duration / 6;
            while (i >= 1)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
                i--;
            }
        }
        DisplayEndMessage();
    }
}