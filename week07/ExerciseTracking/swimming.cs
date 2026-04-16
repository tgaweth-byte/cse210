using System;

class Swimming : Activity
{
  private int _laps;
  private const double LAP_DISTANCE_MILES = 0.05; // 50 meters = 0.05 miles

  public Swimming(string date, int lengthInMinutes, int laps)
      : base(date, lengthInMinutes)
  {
    _laps = laps;
  }

  public override double GetDistance()
  {
    return _laps * LAP_DISTANCE_MILES;
  }

  public override double GetSpeed()
  {
    double distance = GetDistance();
    return distance / (_lengthInMinutes / 60.0);
  }

  public override double GetPace()
  {
    double distance = GetDistance();
    return distance > 0 ? _lengthInMinutes / distance : 0;
  }
}