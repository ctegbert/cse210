using System;
using System.Collections.Generic;

// Class to represent a comment on a video
public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    // Constructor
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Class to represent a YouTube video
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(string commenterName, string commentText)
    {
        Comment comment = new Comment(commenterName, commentText);
        comments.Add(comment);
    }

    // Method to get the number of comments on the video
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // Method to display video details and comments
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        List<Video> videos = new List<Video>
        {
            new Video("Title 1", "Author A", 120),
            new Video("Title 2", "Author B", 180),
            new Video("Title 3", "Author C", 150)
        };

        // Add comments to videos
        videos[0].AddComment("User1", "Great video!");
        videos[0].AddComment("User2", "I learned a lot.");

        videos[1].AddComment("User3", "Interesting content.");
        videos[1].AddComment("User4", "Can't wait for the next one!");

        videos[2].AddComment("User5", "Awesome job!");
        videos[2].AddComment("User6", "Very informative.");

        // Display video details and comments
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
