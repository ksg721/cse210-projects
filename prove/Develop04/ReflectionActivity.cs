using System;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.", 
        "Think of a time when you did something really difficult.", 
        "Think of a time when you helped someone in need.", 
        "Think of a time when you did something truly selfless."   
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int i = random.Next(_prompts.Count);
        return _prompts[i];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int i = random.Next(_questions.Count);
        return _questions[i];
    }

    public void Start()
    {
        DisplayStartMessage();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        for (int i = 5; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        List <string> used = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            if (!used.Contains(question))
            {
                Console.WriteLine($"\n{question}");
                used.Add(question);
                DisplaySpinner();
                DisplaySpinner();
            }
        }
        DisplayEndMessage();
    }
}