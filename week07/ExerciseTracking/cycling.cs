using System;

class Cycling : Activity
{
  private double _speed; // in mph

  public Cycling(string date, int lengthInMinutes, double speed)
      : base(date, lengthInMinutes)
  {
    _speed = speed;
  }

  public override double GetDistance()
  {
    // Distance = speed * time (in hours)
    return _speed * (_lengthInMinutes / 60.0);
  }

  public override double GetSpeed()
  {
    return _speed;
  }

  public override double GetPace()
  {
    // Pace = time / distance (minutes per mile)
    double distance = GetDistance();
    return distance > 0 ? _lengthInMinutes / distance : 0;
  }
}