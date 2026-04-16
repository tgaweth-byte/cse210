using System;

abstract class Activity
{
  protected string _date;
  protected int _lengthInMinutes; // duration in minutes

  public Activity(string date, int lengthInMinutes)
  {
    _date = date;
    _lengthInMinutes = lengthInMinutes;
  }

  // Abstract methods that derived classes must override
  public abstract double GetDistance(); // in miles or kilometers
  public abstract double GetSpeed();    // in mph or kph
  public abstract double GetPace();     // in minutes per mile or km

  // Virtual method that can be overridden but provides base implementation
  public virtual string GetSummary()
  {
    return $"{_date} {GetType().Name} ({_lengthInMinutes} min) - " +
           $"Distance: {GetDistance():F1} miles, " +
           $"Speed: {GetSpeed():F1} mph, " +
           $"Pace: {GetPace():F2} min per mile";
  }

  // Protected getter for derived classes to access length
  protected int GetLengthInMinutes()
  {
    return _lengthInMinutes;
  }
}