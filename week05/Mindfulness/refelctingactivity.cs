using System;
using System.Collections.Generic;
using System.Threading;

class ReflectingActivity : Activity
{
  private List<string> _prompts;
  private List<string> _questions;

  public ReflectingActivity()
  {
    _name = "Reflecting";
    _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

    _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

    _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience?",
            "What did you learn about yourself?",
            "How can you apply this to your future?"
        };
  }

  public void Run()
  {
    DisplayStartingMessage();

    Console.WriteLine("\nConsider the following prompt:");
    Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
    Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
    Console.ReadLine();

    Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
    Console.Write("You may begin in: ");
    ShowCountdown(5);

    DateTime endTime = DateTime.Now.AddSeconds(_duration);

    while (DateTime.Now < endTime)
    {
      Console.Write($"\n> {GetRandomQuestion()} ");
      ShowSpinner(8);
    }

    DisplayEndingMessage();
  }

  private string GetRandomPrompt()
  {
    Random random = new Random();
    return _prompts[random.Next(_prompts.Count)];
  }

  private string GetRandomQuestion()
  {
    Random random = new Random();
    return _questions[random.Next(_questions.Count)];
  }
}