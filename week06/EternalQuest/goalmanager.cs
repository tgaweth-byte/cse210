using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
  private List<Goal> _goals;
  private int _score;

  public GoalManager()
  {
    _goals = new List<Goal>();
    _score = 0;
  }

  public void Start()
  {
    bool running = true;

    while (running)
    {
      Console.Clear();
      Console.WriteLine($"You have {_score} points.\n");
      Console.WriteLine("Menu Options:");
      Console.WriteLine("  1. Create New Goal");
      Console.WriteLine("  2. List Goals");
      Console.WriteLine("  3. Save Goals");
      Console.WriteLine("  4. Load Goals");
      Console.WriteLine("  5. Record Event");
      Console.WriteLine("  6. Quit");
      Console.Write("Select a choice: ");

      string choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          CreateGoal();
          break;
        case "2":
          ListGoals();
          break;
        case "3":
          SaveGoals();
          break;
        case "4":
          LoadGoals();
          break;
        case "5":
          RecordEvent();
          break;
        case "6":
          running = false;
          break;
      }
    }
  }

  private void CreateGoal()
  {
    Console.Clear();
    Console.WriteLine("The types of goals are:");
    Console.WriteLine("  1. Simple Goal");
    Console.WriteLine("  2. Eternal Goal");
    Console.WriteLine("  3. Checklist Goal");
    Console.Write("Which type would you like to create? ");
    string type = Console.ReadLine();

    Console.Write("What is the name of your goal? ");
    string name = Console.ReadLine();

    Console.Write("What is a short description of it? ");
    string desc = Console.ReadLine();

    Console.Write("What is the amount of points associated with this goal? ");
    int points = int.Parse(Console.ReadLine());

    if (type == "1")
    {
      _goals.Add(new SimpleGoal(name, desc, points));
    }
    else if (type == "2")
    {
      _goals.Add(new EternalGoal(name, desc, points));
    }
    else if (type == "3")
    {
      Console.Write("How many times does this goal need to be completed? ");
      int target = int.Parse(Console.ReadLine());
      Console.Write("What is the bonus for completing it that many times? ");
      int bonus = int.Parse(Console.ReadLine());
      _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
    }
  }

  private void ListGoals()
  {
    Console.Clear();
    Console.WriteLine("Your Goals:");
    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }
    Console.WriteLine($"\nYou have {_score} points.");
    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
  }

  private void SaveGoals()
  {
    Console.Write("Enter filename: ");
    string filename = Console.ReadLine();

    using (StreamWriter writer = new StreamWriter(filename))
    {
      writer.WriteLine(_score);
      foreach (Goal goal in _goals)
      {
        writer.WriteLine(goal.GetStringRepresentation());
      }
    }
    Console.WriteLine("Goals saved! Press Enter...");
    Console.ReadLine();
  }

  private void LoadGoals()
  {
    Console.Write("Enter filename: ");
    string filename = Console.ReadLine();

    if (!File.Exists(filename))
    {
      Console.WriteLine("File not found. Press Enter...");
      Console.ReadLine();
      return;
    }

    _goals.Clear();
    string[] lines = File.ReadAllLines(filename);
    _score = int.Parse(lines[0]);

    for (int i = 1; i < lines.Length; i++)
    {
      string[] parts = lines[i].Split('|');
      string type = parts[0];

      if (type == "SimpleGoal")
      {
        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
      }
      else if (type == "EternalGoal")
      {
        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
      }
      else if (type == "ChecklistGoal")
      {
        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[4]), int.Parse(parts[6])));
      }
    }
    Console.WriteLine("Goals loaded! Press Enter...");
    Console.ReadLine();
  }

  private void RecordEvent()
  {
    Console.Clear();
    Console.WriteLine("Your Goals:");
    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
    }
    Console.Write("Which goal did you accomplish? ");
    int index = int.Parse(Console.ReadLine()) - 1;

    int pointsEarned = _goals[index].RecordEvent();
    _score += pointsEarned;

    Console.WriteLine($"\nYou earned {pointsEarned} points!");
    Console.WriteLine($"You now have {_score} points.");
    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
  }
}