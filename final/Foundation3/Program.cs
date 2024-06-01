using System;

// Class to represent an address
public class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    // Constructor
    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    // Method to return the full address as a string
    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

// Base class for all types of events
public class Event
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public string Time { get; private set; }
    public Address Location { get; private set; }

    // Constructor
    public Event(string title, string description, DateTime date, string time, Address location)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Location = location;
    }

    // Method to generate standard event details message
    public virtual string GenerateStandardDetails()
    {
        return $"Event: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nLocation: {Location}";
    }

    // Method to generate full event details message
    public virtual string GenerateFullDetails()
    {
        return GenerateStandardDetails();
    }

    // Method to generate short event description message
    public virtual string GenerateShortDescription()
    {
        return $"Event Type: {GetType().Name}\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}

// Derived class for lectures
public class Lecture : Event
{
    public string Speaker { get; private set; }
    public int Capacity { get; private set; }

    // Constructor
    public Lecture(string title, string description, DateTime date, string time, Address location, string speaker, int capacity) 
        : base(title, description, date, time, location)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    // Method to generate full event details message for lectures
    public override string GenerateFullDetails()
    {
        return $"{base.GenerateFullDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

// Derived class for receptions
public class Reception : Event
{
    public string RSVP { get; private set; }

    // Constructor
    public Reception(string title, string description, DateTime date, string time, Address location, string rsvp) 
        : base(title, description, date, time, location)
    {
        RSVP = rsvp;
    }

    // Method to generate full event details message for receptions
    public override string GenerateFullDetails()
    {
        return $"{base.GenerateFullDetails()}\nType: Reception\nRSVP: {RSVP}";
    }
}

// Derived class for outdoor gatherings
public class OutdoorGathering : Event
{
    public string WeatherForecast { get; private set; }

    // Constructor
    public OutdoorGathering(string title, string description, DateTime date, string time, Address location, string weatherForecast) 
        : base(title, description, date, time, location)
    {
        WeatherForecast = weatherForecast;
    }

    // Method to generate full event details message for outdoor gatherings
    public override string GenerateFullDetails()
    {
        return $"{base.GenerateFullDetails()}\nType: Outdoor Gathering\nWeather Forecast: {WeatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address lectureAddress = new Address("123 Lecture St", "Lectureville", "CA", "USA");
        Address receptionAddress = new Address("456 Reception Rd", "Receptiontown", "NY", "USA");
        Address outdoorAddress = new Address("789 Park Ave", "Outdoortown", "FL", "USA");

        // Create events
        Event lecture = new Lecture("Tech Talk", "Learn about new technologies", DateTime.Parse("2024-07-15"), "10:00 AM", lectureAddress, "John Smith", 50);
        Event reception = new Reception("Networking Mixer", "Connect with professionals", DateTime.Parse("2024-07-20"), "6:00 PM", receptionAddress, "email@example.com");
        Event outdoorGathering = new OutdoorGathering("Summer Picnic", "Enjoy outdoor activities", DateTime.Parse("2024-08-05"), "12:00 PM", outdoorAddress, "Sunny");

        // Generate and display marketing messages for each event
        Console.WriteLine("Event 1 Marketing Messages:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lecture.GenerateStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(lecture.GenerateFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(lecture.GenerateShortDescription());

        Console.WriteLine("\nEvent 2 Marketing Messages:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(reception.GenerateStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(reception.GenerateFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(reception.GenerateShortDescription());

        Console.WriteLine("\nEvent 3 Marketing Messages:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(outdoorGathering.GenerateStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(outdoorGathering.GenerateFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(outdoorGathering.GenerateShortDescription());
    }
}