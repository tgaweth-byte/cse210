using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{
  private List<string> _prompts;

  public ListingActivity()
  {
    _name = "Listing";
    _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "What are some things that make you happy?"
        };
  }

  public void Run()
  {
    DisplayStartingMessage();

    Console.WriteLine("\nList as many responses as you can to the following prompt:");
    Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
    Console.Write("\nYou may begin in: ");
    ShowCountdown(5);

    Console.WriteLine("\nStart listing! Press Enter after each item. (Press Enter twice to finish early)");

    List<string> items = new List<string>();
    DateTime endTime = DateTime.Now.AddSeconds(_duration);
    string lastInput = "";

    while (DateTime.Now < endTime)
    {
      Console.Write("> ");
      string input = Console.ReadLine();

      if (string.IsNullOrEmpty(input) && string.IsNullOrEmpty(lastInput))
      {
        break;
      }

      if (!string.IsNullOrEmpty(input))
      {
        items.Add(input);
      }

      lastInput = input;
    }

    Console.WriteLine($"\nYou listed {items.Count} items!");
    DisplayEndingMessage();
  }

  private string GetRandomPrompt()
  {
    Random random = new Random();
    return _prompts[random.Next(_prompts.Count)];
  }
}