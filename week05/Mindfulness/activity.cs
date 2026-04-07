using System;
using System.Threading;

class Activity
{
  protected string _name;
  protected string _description;
  protected int _duration;

  public Activity()
  {
    _name = "Activity";
    _description = "This is a generic activity.";
    _duration = 0;
  }

  public void DisplayStartingMessage()
  {
    Console.Clear();
    Console.WriteLine($"Welcome to the {_name} Activity.");
    Console.WriteLine($"\n{_description}");
    Console.Write("\nHow many seconds would you like to do this activity? ");
    _duration = int.Parse(Console.ReadLine());

    Console.WriteLine("\nGet ready...");
    ShowSpinner(3);
  }

  public void DisplayEndingMessage()
  {
    Console.WriteLine("\nWell done!");
    Console.WriteLine($"You have completed {_duration} seconds of the {_name} Activity.");
    ShowSpinner(3);
  }

  public void ShowSpinner(int seconds)
  {
    List<string> spinner = new List<string> { "|", "/", "-", "\\" };
    DateTime endTime = DateTime.Now.AddSeconds(seconds);
    int i = 0;

    while (DateTime.Now < endTime)
    {
      Console.Write(spinner[i % spinner.Count]);
      Thread.Sleep(200);
      Console.Write("\b");
      i++;
    }
    Console.Write(" ");
  }

  public void ShowCountdown(int seconds)
  {
    for (int i = seconds; i > 0; i--)
    {
      Console.Write(i);
      Thread.Sleep(1000);
      Console.Write("\b \b");
    }
  }

  public void PauseWithSpinner()
  {
    ShowSpinner(5);
  }
}