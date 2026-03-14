using System;

public class GoalMenu
{
    private List<Goal> goals = new List<Goal>();
    private int totalPoints;
    private List<string> achievements = new List<string>();
    private int goalsCompleted = 0;
    public void Start()
    {
        Console.WriteLine("Welcome to the Goal Manager!");
        while (true)
        {
            DisplayMenu();
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    if(goals.Count < 1)
                    {
                        Console.WriteLine("\nThere are currently no goals recorded.");
                        break;
                    }
                    else
                    {
                        ListGoals();
                        break;
                    }
                case "3":
                    if(goals.Count < 1)
                    {
                        Console.WriteLine("\nThere are currently no goals recorded.");
                        break;
                    }
                    else
                    {
                        SaveGoals();
                        break;
                    }
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    if(goals.Count < 1)
                    {
                        Console.WriteLine("\nThere are currently no goals recorded.");
                        break;
                    }
                    else
                    {
                        RecordEvent();
                        break;
                    }
                case "6":
                    DisplayAchievements();
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayMenu()
    {
        Console.WriteLine($"\nYou currently have {totalPoints} points.");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. View Achievements");
        Console.WriteLine("7. Quit");
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Write("Enter goal name: ");
                string name = Console.ReadLine();
                Console.Write("Enter goal description: ");
                string description = Console.ReadLine();
                Console.Write("Enter points for completing the goal: ");
                int points = int.Parse(Console.ReadLine());
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                goals.Add(simpleGoal);
                break;
            case "2":
                Console.Write("Enter goal name: ");
                name = Console.ReadLine();
                Console.Write("Enter goal description: ");
                description = Console.ReadLine();
                Console.Write("Enter points for completing the goal: ");
                points = int.Parse(Console.ReadLine());
                EternalGoal eternalGoal = new EternalGoal(name, description, points, 0);
                goals.Add(eternalGoal);
                break;
            case "3":
                Console.Write("Enter goal name: ");
                name = Console.ReadLine();
                Console.Write("Enter goal description: ");
                description = Console.ReadLine();
                Console.Write("Enter the target number: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter points for completing each step of the goal: ");
                points = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completing the goal: ");
                int bonus = int.Parse(Console.ReadLine());
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, 0, bonus);
                goals.Add(checklistGoal);
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine($"{goal.GetName()} - {goal.GetDescription()} - {goal.GetPoints()} points - {goal.GetStatus()}");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }
        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice >= 0 && choice < goals.Count)
        {
            int pointsEarned = goals[choice].RecordEvent();
            if (pointsEarned > 0)
            {
                goalsCompleted++;
            }
            totalPoints += pointsEarned;
            CheckAchievements();
            Console.WriteLine($"You earned {pointsEarned} points! You now have {totalPoints} total points!");
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalPoints);
            writer.WriteLine(goalsCompleted);
            writer.WriteLine(achievements.Count);
            foreach (string achievement in achievements)
            {
                writer.WriteLine(achievement);
            }
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetGoalData());
            }
        }
        Console.WriteLine("Goals, score, and achievements saved successfully!");
    }


    public void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        goals.Clear();
        achievements.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            totalPoints = int.Parse(reader.ReadLine());
            goalsCompleted = int.Parse(reader.ReadLine());
            int achievementCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < achievementCount; i++)
            {
                achievements.Add(reader.ReadLine());
            }
            while (!reader.EndOfStream)
            {
                string goalData = reader.ReadLine();
                string[] parts = goalData.Split('|');

                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                switch (type)
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(name, description, points));
                        break;

                    case "EternalGoal":
                        int timesCompleted = int.Parse(parts[4]);
                        goals.Add(new EternalGoal(name, description, points, timesCompleted));
                        break;

                    case "ChecklistGoal":
                        int target = int.Parse(parts[4]);
                        int current = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        goals.Add(new ChecklistGoal(name, description, points, target, current, bonus));
                        break;
                }
            }
        }

        Console.WriteLine("Goals, score, and achievements loaded successfully!");
    }


    public void CheckAchievements()
    {
        if (goalsCompleted >= 1 && !achievements.Contains("First Goal Completed"))
        {
            achievements.Add("First Goal Completed");
            Console.WriteLine("Achievement Unlocked: First Goal Completed!");
        }

        if (totalPoints >= 500 && !achievements.Contains("500 Points Earned"))
        {
            achievements.Add("500 Points Earned");
            Console.WriteLine("Achievement Unlocked: 500 Points Earned!");
        }

        if (totalPoints >= 1000 && !achievements.Contains("1000 Points Earned"))
        {
            achievements.Add("1000 Points Earned");
            Console.WriteLine("Achievement Unlocked: 1000 Points Earned!");
        }

        if (goalsCompleted >= 10 && !achievements.Contains("Goal Master"))
        {
            achievements.Add("Goal Master");
            Console.WriteLine("Achievement Unlocked: Goal Master - Complete 10 Goals!");
        }
    }

    public void DisplayAchievements()
    {
        Console.WriteLine("\nAchievements:");

        if (achievements.Count == 0)
        {
            Console.WriteLine("No achievements unlocked yet.");
        }
        else
        {
            foreach (string achievement in achievements)
            {
                Console.WriteLine($"{achievement}");
            }
        }
    }
}