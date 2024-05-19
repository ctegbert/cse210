using System;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:\n 1. Start breathing activity\n 2. Start reflecting activity\n 3. Start listing activity\n 4. Quit\nSelect a choice from the menu:");
                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        var breathing = new BreathingActivity();
                        RunActivity(breathing);
                        break;
                    case "2":
                        var reflection = new ReflectionActivity();
                        RunActivity(reflection);
                        break;
                    case "3":
                        var listing = new ListingActivity();
                        RunActivity(listing);
                        break;
                    case "4":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("That is not a valid response");
                        Console.WriteLine("Hit any key to try again");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void RunActivity(Activity activity)
        {
            Console.Clear();
            activity.StartActivity();
            activity.PerformActivity();
            activity.EndActivity();
            Console.WriteLine("Hit any key to continue...");
            Console.ReadKey();
        }
    }

    public abstract class Activity
    {
        protected string _activityTitle;
        protected string _activityDescription;
        protected int _activityDuration;

        public Activity(string activityTitle, string activityDescription)
        {
            _activityTitle = activityTitle;
            _activityDescription = activityDescription;
        }

        public void StartActivity()
        {
            Console.WriteLine($"Starting {_activityTitle}: {_activityDescription}");
            Console.WriteLine("Enter duration (in seconds) for this activity:");
            _activityDuration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            Thread.Sleep(5000); // Pause for 5 seconds
        }

        public void EndActivity()
        {
            Console.WriteLine($"End of {_activityTitle}. Good job!");
            Console.WriteLine($"You have completed the {_activityTitle} for {_activityDuration} seconds.");
            Thread.Sleep(5000); // Pause for 5 seconds
        }

        public abstract void PerformActivity();
    }

    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void PerformActivity()
        {
            Console.WriteLine("Starting breathing activity...");
            int count = 0;
            while (count < _activityDuration)
            {
                Console.WriteLine("Breathe in...");
                Thread.Sleep(2000); // Pause for 2 seconds
                Console.WriteLine("Breathe out...");
                Thread.Sleep(2000 + (count / 3)); // Pause for 2 seconds plus dynamic adjustment
                count += 4; // Increment count by 4 seconds for each breath cycle
            }
        }
    }

    public class ReflectionActivity : Activity
    {
        private string[] _prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private string[] _questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
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

        public override void PerformActivity()
        {
            Console.WriteLine("Starting reflection activity...");
            Random rand = new Random();
            int count = 0;
            while (count < _activityDuration)
            {
                string prompt = _prompts[rand.Next(_prompts.Length)];
                Console.WriteLine($"Prompt: {prompt}");
                Thread.Sleep(5000); // Pause for 5 seconds
                foreach (var question in _questions)
                {
                    Console.WriteLine($"Question: {question}");
                    Thread.Sleep(5000); // Pause for 5 seconds
                }
                count += _questions.Length * 5; // 5 seconds per question
            }
        }
    }

    public class ListingActivity : Activity
    {
        private string[] _prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public override void PerformActivity()
        {
            Console.WriteLine("Starting listing activity...");
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Length)];
            Console.WriteLine($"Prompt: {prompt}");
            Console.WriteLine($"You have {_activityDuration} seconds to list as many items as you can.");
            Thread.Sleep(_activityDuration * 1000); // Pause for activity duration
        }
    }
}
