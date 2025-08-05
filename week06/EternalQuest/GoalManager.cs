using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private List<string> _badges = new List<string>();
    private Random _random = new Random();

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine($"\nYou have {_score} points. Level {_level}");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter point value: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == "3")
        {
            Console.Write("Enter target count: ");
            int count = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, count, bonus));
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        if (_badges.Count > 0)
        {
            Console.WriteLine("\n🏅 Your Badges:");
            foreach (var badge in _badges)
                Console.WriteLine($"- {badge}");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            writer.WriteLine(string.Join(",", _badges));
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
            _badges = new List<string>(lines[2].Split(',', StringSplitOptions.RemoveEmptyEntries));

            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    goal.LoadState(bool.Parse(parts[4]));
                    _goals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (type == "ChecklistGoal")
                {
                    var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[4]));
                    goal.LoadProgress(int.Parse(parts[6]));
                    _goals.Add(goal);
                }
            }
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            int earned = goal.RecordEvent();
            _score += earned;

            Console.WriteLine($"\n🎉 You earned {earned} points!");
            ShowRandomMessage();

            if (goal is SimpleGoal sg && sg.IsComplete() && !_badges.Contains("🏁 Finisher"))
            {
                _badges.Add("🏁 Finisher");
                Console.WriteLine("🏅 You earned a new badge: Finisher!");
            }
            else if (goal is ChecklistGoal cg && cg.IsComplete() && !_badges.Contains("✅ Master of Habits"))
            {
                _badges.Add("✅ Master of Habits");
                Console.WriteLine("🏅 You earned a new badge: Master of Habits!");
            }

            if (_score >= 5000 && !_badges.Contains("🌟 Quest Champion"))
            {
                _badges.Add("🌟 Quest Champion");
                Console.WriteLine("🏆 You earned the ultimate badge: Quest Champion!");
            }

            int newLevel = (_score / 1000) + 1;
            if (newLevel > _level)
            {
                _level = newLevel;
                Console.WriteLine($"🆙 You leveled up to Level {_level}!");
            }
        }
    }

    private void ShowRandomMessage()
    {
        string[] messages = {
            "Keep going! You're doing amazing!",
            "Another step forward on your quest!",
            "Great work! Stay consistent!",
            "You’re building something eternal!",
            "One day at a time. One point at a time."
        };

        Console.WriteLine("💬 " + messages[_random.Next(messages.Length)]);
    }
}


