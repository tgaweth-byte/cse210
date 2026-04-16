using System;

class Running : Activity
{
  private double _distance; // in miles

  public Running(string date, int lengthInMinutes, double distance)
      : base(date, lengthInMinutes)
  {
    _distance = distance;
  }

  public override double GetDistance()
  {
    return _distance;
  }

  public override double GetSpeed()
  {
    // Speed = distance / time (in hours)
    return _distance / (_lengthInMinutes / 60.0);
  }

  public override double GetPace()
  {
    // Pace = time / distance (minutes per mile)
    return _lengthInMinutes / _distance;
  }
}