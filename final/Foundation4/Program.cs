using System;
using System.Collections.Generic;

// Base class for all types of activities
public class Activity
{
    public DateTime Date { get; private set; }
    public int LengthInMinutes { get; private set; }

    // Constructor
    public Activity(DateTime date, int lengthInMinutes)
    {
        Date = date;
        LengthInMinutes = lengthInMinutes;
    }

    // Virtual method to get distance
    public virtual double GetDistance()
    {
        return 0; // Default implementation for activities without distance calculation
    }

    // Virtual method to get speed
    public virtual double GetSpeed()
    {
        return 0; // Default implementation for activities without speed calculation
    }

    // Virtual method to get pace
    public virtual double GetPace()
    {
        return 0; // Default implementation for activities without pace calculation
    }

    // Method to generate summary
    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} - {GetType().Name} ({LengthInMinutes} min)";
    }
}

// Derived class for running activity
public class Running : Activity
{
    public double Distance { get; private set; }

    // Constructor
    public Running(DateTime date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        Distance = distance;
    }

    // Override method to get distance
    public override double GetDistance()
    {
        return Distance;
    }

    // Override method to get speed
    public override double GetSpeed()
    {
        return (Distance / LengthInMinutes) * 60;
    }

    // Override method to get pace
    public override double GetPace()
    {
        return LengthInMinutes / Distance;
    }

    // Override method to generate summary
    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {Distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

// Derived class for stationary bicycle activity
public class StationaryBicycle : Activity
{
    public double Speed { get; private set; }

    // Constructor
    public StationaryBicycle(DateTime date, int lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        Speed = speed;
    }

    // Override method to get speed
    public override double GetSpeed()
    {
        return Speed;
    }

    // Override method to get pace
    public override double GetPace()
    {
        return 60 / Speed;
    }

    // Override method to generate summary
    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Speed: {Speed} kph, Pace: {GetPace()} min per km";
    }
}

// Derived class for swimming activity
public class Swimming : Activity
{
    public int Laps { get; private set; }

    // Constructor
    public Swimming(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        Laps = laps;
    }

    // Override method to get distance
    public override double GetDistance()
    {
        return Laps * 50 / 1000; // Convert laps to kilometers
    }

    // Override method to get speed
    public override double GetSpeed()
    {
        return (GetDistance() / LengthInMinutes) * 60;
    }

    // Override method to get pace
    public override double GetPace()
    {
        return LengthInMinutes / GetDistance();
    }

    // Override method to generate summary
    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create activities
        Activity running = new Running(DateTime.Parse("2024-11-03"), 30, 3.0);
        Activity bicycle = new StationaryBicycle(DateTime.Parse("2024-11-03"), 45, 25.0);
        Activity swimming = new Swimming(DateTime.Parse("2024-11-03"), 60, 20);

        // Put activities in a list
        List<Activity> activities = new List<Activity> { running, bicycle, swimming };

        // Display summaries for all activities
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
