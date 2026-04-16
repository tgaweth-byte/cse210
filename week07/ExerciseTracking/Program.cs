using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Create activities
        Running running = new Running("03 Nov 2022", 30, 3.0);
        activities.Add(running);

        Cycling cycling = new Cycling("04 Nov 2022", 45, 15.0);
        activities.Add(cycling);

        Swimming swimming = new Swimming("05 Nov 2022", 20, 30);
        activities.Add(swimming);

        // Display summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}