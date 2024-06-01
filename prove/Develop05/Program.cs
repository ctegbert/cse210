using System;
using System.Collections.Generic;

// Base class for all types of activities
public abstract class Activity
{
    public string Name { get; set; }
    public int Points { get; protected set; }

    // Constructor
    public Activity(string name, int points)
    {
        Name = name;
        Points = points;
    }

    // Abstract method to record activity
    public abstract void RecordActivity();
}

// Derived class for simple activities
public class SimpleActivity : Activity
{
    // Constructor
    public SimpleActivity(string name, int points) : base(name, points)
    {
    }

    // Method to record the completion of the activity
    public override void RecordActivity()
    {
        Console.WriteLine($"Completed {Name}! You've earned {Points} points.");
    }
}

// Derived class for eternal activities
public class EternalActivity : Activity
{
    // Constructor
    public EternalActivity(string name, int points) : base(name, points)
    {
    }

    // Method to record the completion of the activity
    public override void RecordActivity()
    {
        Console.WriteLine($"Recorded {Name}. You've earned {Points} points.");
    }
}

// Derived class for checklist activities
public class ChecklistActivity : Activity
{
    public int BonusPoints { get; set; }

    // Constructor
    public ChecklistActivity(string name, int points, int bonusPoints) : base(name, points)
    {
        BonusPoints = bonusPoints;
    }

    // Method to record the completion of the activity
    public override void RecordActivity()
    {
        Console.WriteLine($"Completed {Name}! You've earned {Points} points.");

        if (BonusPoints > 0)
        {
            Console.WriteLine($"You've earned a bonus of {BonusPoints} points!");
        }
    }
}

// Class to represent a specific goal
public class Goal
{
    public string Name { get; set; }
    public int Target { get; set; }
    public int Progress { get; set; }
    public Activity Activity { get; set; }

    // Constructor
    public Goal(string name, int target, Activity activity)
    {
        Name = name;
        Target = target;
        Progress = 0;
        Activity = activity;
    }

    // Method to check if the goal is completed
    public bool IsCompleted()
    {
        return Progress >= Target;
    }
}

// Class to manage the user's score
public class Scoreboard
{
    public int TotalScore { get; private set; }

    // Constructor
    public Scoreboard()
    {
        TotalScore = 0;
    }

    // Method to update the score
    public void UpdateScore(int points)
    {
        TotalScore += points;
    }

    // Method to display the current score
    public void DisplayScore()
    {
        Console.WriteLine($"Your current score is: {TotalScore}");
    }
}

// Class to manage saving and loading of user data
public class FileHandler
{
    private string filePath = "userdata.txt";

    // Method to save user data to a file
    public void SaveUserData(List<Goal> goals, Scoreboard scoreboard)
    {
        // Implement saving logic here
        // Example: Serialize goals and scoreboard to a file
    }

    // Method to load user data from a file
    public void LoadUserData(out List<Goal> goals, out Scoreboard scoreboard)
    {
        goals = new List<Goal>();
        scoreboard = new Scoreboard();

        // Implement loading logic here
        // Example: Deserialize goals and scoreboard from a file
    }
}

// Main program class to handle user interaction
class EternalQuestProgram
{
    private List<Goal> goals;
    private Scoreboard scoreboard;
    private FileHandler fileHandler;

    // Constructor
    public EternalQuestProgram()
    {
        goals = new List<Goal>();
        scoreboard = new Scoreboard();
        fileHandler = new FileHandler();
    }

    // Method to display the main menu
    private void DisplayMainMenu()
    {
        Console.WriteLine("===== Eternal Quest Program =====");
        Console.WriteLine("1. View Goals");
        Console.WriteLine("2. Add New Goal");
        Console.WriteLine("3. Record Activity");
        Console.WriteLine("4. View Score");
        Console.WriteLine("5. Save and Exit");
        Console.WriteLine("===============================");
        Console.Write("Enter your choice: ");
    }

    // Method to handle user input
    public void Run()
    {
        LoadUserData();

        bool exit = false;
        while (!exit)
        {
            DisplayMainMenu();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewGoals();
                    break;
                case "2":
                    AddNewGoal();
                    break;
                case "3":
                    RecordActivity();
                    break;
                case "4":
                    scoreboard.DisplayScore();
                    break;
                case "5":
                    SaveAndExit();
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Method to load user data from file
    private void LoadUserData()
    {
        fileHandler.LoadUserData(out goals, out scoreboard);
    }

    // Method to save user data to file and exit
    private void SaveAndExit()
    {
        fileHandler.SaveUserData(goals, scoreboard);
        Console.WriteLine("User data saved. Exiting...");
    }

    // Method to display user's goals
    private void ViewGoals()
    {
        Console.WriteLine("===== Your Goals =====");
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - Progress: {goal.Progress}/{goal.Target}");
        }
        Console.WriteLine("======================");
    }

    // Method to add a new goal
    private void AddNewGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal target: ");
        int target = int.Parse(Console.ReadLine());

        // Choose activity type
        Console.WriteLine("Choose activity type:");
        Console.WriteLine("1. Simple Activity");
        Console.WriteLine("2. Eternal Activity");
        Console.WriteLine("3. Checklist Activity");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Activity activity = null;
        switch (choice)
        {
            case "1":
                Console.Write("Enter points for completing the activity: ");
                int points = int.Parse(Console.ReadLine());
                activity = new SimpleActivity(name, points);
                break;
            case "2":
                Console.Write("Enter points for recording the activity: ");
                int points2 = int.Parse(Console.ReadLine());
                activity = new EternalActivity(name, points2);
                break;
            case "3":
                Console.Write("Enter points for completing the activity: ");
                int points3 = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completing the checklist: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                activity = new ChecklistActivity(name, points3, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        if (activity != null)
        {
            goals.Add(new Goal(name, target, activity));
            Console.WriteLine("Goal added successfully!");
        }
    }

    // Method to record activity for a goal
    private void RecordActivity()
    {
        Console.WriteLine("Choose a goal to record activity for:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }
        Console.Write("Enter goal number: ");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < goals.Count)
        {
            Goal selectedGoal = goals[goalNumber];
            selectedGoal.Activity.RecordActivity();
            selectedGoal.Progress++;
            scoreboard.UpdateScore(selectedGoal.Activity.Points);
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    // Main method to run the program
    static void Main(string[] args)
    {
        EternalQuestProgram program = new EternalQuestProgram();
        program.Run();
    }
}

