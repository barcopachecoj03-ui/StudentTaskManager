using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1ST & 2ND step : Personal Info, Write vs WriteLine & Variables

        Console.WriteLine("Student Task Manager");
        Console.WriteLine("i want tacos so bad heheeh");
        Console.WriteLine("Welcome to the application!");
    // Me
        Console.WriteLine("my name is Johana Guadalupe Barco Pacheco :) ");
        Console.WriteLine("my faavorite programming language: C#");
        Console.WriteLine("Reason to learn .NET: Because I want to build apps without my computer crashing :) ");
        Console.WriteLine();
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("What is your favorite programming language? ");
        string favoriteLanguage = Console.ReadLine();

        Console.Write("One reason you want to learn .NET? ");
        string reason = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine($"Hello {name}!");
        Console.WriteLine($"Your favorite programming language is {favoriteLanguage}.");
        Console.WriteLine($"One reason you want to learn .NET is {reason}.");
        Console.WriteLine();

        // Testing Write WriteLine
        Console.WriteLine("--- Testing Write vs WriteLine :) ---");
        Console.Write("we went to a cat cafe ");
        Console.Write("yesterday ");
        Console.Write("(the cats were only interested in food hahaha)\n\n");

        Console.WriteLine("mi youngest dog is:");
        Console.WriteLine("Pelusita ");
        Console.WriteLine("The oldest are:");
        Console.WriteLine("Jose, Panchita y moquitos");
        Console.WriteLine("The weirdest is:");
        Console.WriteLine("Limon ");
        Console.WriteLine();

        // Additional variables & constants Step 2
        const int MaxDailyTasks = 10;
        const string AppName = "Student Task Manager";

        Console.WriteLine($"Application: {AppName}");
        Console.WriteLine($"Maximum recommended daily tasks: {MaxDailyTasks}");

        Console.Write("Enter your student age: ");
        int age = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("What is your course name? ");
        string courseName = Console.ReadLine() ?? "Software Engineering";

        Console.Write("Do you already know C#? (yes/no) ");
        string knowsCSharpAnswer = Console.ReadLine() ?? "no";
        bool knowsCSharp = string.Equals(knowsCSharpAnswer, "yes", StringComparison.OrdinalIgnoreCase);

        Console.WriteLine();
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Course: {courseName}");
        Console.WriteLine($"Already knows C#: {knowsCSharp}");
        Console.WriteLine();

        // 3RD step: Conditions (if / else) & Menu preview
        Console.Write("How many tasks have you completed today? ");
        int completedTasks = int.Parse(Console.ReadLine() ?? "0");

        if (completedTasks == 0)
        {
            Console.WriteLine("Time to get started!");
        }
        else if (completedTasks < 3)
        {
            Console.WriteLine("Good start. Keep going!");
        }
        else
        {
            Console.WriteLine("Great progress!");
        }
        Console.WriteLine();

        // 4TH & 6TH step: Lists, Loop, Switch & Enums
        List<string> tasks = new List<string>();

        // Example enum usage (Step 6 requirement)
        TaskPriority priority = TaskPriority.High;
        Console.WriteLine($"Default Task Priority: {priority}");

        switch (priority)
        {
            case TaskPriority.Low:
                Console.WriteLine("This task can wait.");
                break;
            case TaskPriority.Medium:
                Console.WriteLine("Try to finish this task today.");
                break;
            case TaskPriority.High:
                Console.WriteLine("Prioritize this task.");
                break;
        }

        bool running = true;

        while (running)
        {
            ShowMenu();

            Console.Write("Choose: ");
            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (option)
            {
                case 1:
                    AddTask(tasks);
                    break;

                case 2:
                    ShowTasks(tasks);
                    break;

                case 3:
                    RemoveTask(tasks);
                    break;

                case 4:
                    ShowTaskCount(tasks);
                    break;

                case 0:
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    // 5TH step: METHODS

    static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Student Task Manager");
        Console.WriteLine("====================");
        Console.WriteLine("1. Add task");
        Console.WriteLine("2. View tasks");
        Console.WriteLine("3. Remove task");
        Console.WriteLine("4. Show task count");
        Console.WriteLine("0. Exit");
    }

    static void AddTask(List<string> tasks)
    {
        const int maxAllowed = 10;
        if (tasks.Count >= maxAllowed)
        {
            Console.WriteLine("Maximum number of tasks reached.");
            return;
        }

        Console.Write("Enter task: ");
        string task = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(task))
        {
            tasks.Add(task);
            Console.WriteLine("Task added successfully!");
        }
        else
        {
            Console.WriteLine("Task cannot be empty.");
        }
    }

    static void ShowTasks(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    static void RemoveTask(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks to remove.");
            return;
        }

        ShowTasks(tasks);
        Console.Write("Task to remove: ");

        if (int.TryParse(Console.ReadLine(), out int taskNumber))
        {
            int index = taskNumber - 1;
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Task removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    static void ShowTaskCount(List<string> tasks)
    {
        int maxAllowed = 10;
        int currentCount = tasks.Count;
        int remaining = maxAllowed - currentCount;

        Console.WriteLine($"You currently have {currentCount} tasks.");
        Console.WriteLine($"Maximum allowed: {maxAllowed}");
        Console.WriteLine($"Remaining capacity: {remaining}");
    }
}

// 6TH step: ENUM

enum TaskPriority
{
    Low,
    Medium,
    High
}