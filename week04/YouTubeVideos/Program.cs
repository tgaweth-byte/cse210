using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Programming Tutorial", "TechWithTim", 600);
        video1.AddComment(new Comment("JohnDoe", "Great tutorial! Really helped me understand classes."));
        video1.AddComment(new Comment("JaneSmith", "Could you make one about inheritance next?"));
        video1.AddComment(new Comment("CodeMaster", "Best C# video I've seen so far."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 10 Coding Mistakes", "DeveloperLife", 450);
        video2.AddComment(new Comment("NewCoder", "I've made all of these lol"));
        video2.AddComment(new Comment("SeniorDev", "Number 3 got me my first year."));
        video2.AddComment(new Comment("BugHunter", "This should be required viewing for juniors."));
        video2.AddComment(new Comment("TeaDrinker", "The null reference one hits different"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("How to Stay Motivated", "CodeJourney", 320);
        video3.AddComment(new Comment("Student22", "Needed this today, thank you."));
        video3.AddComment(new Comment("GrindSet", "Consistency over intensity."));
        video3.AddComment(new Comment("NightOwl", "Watching this instead of coding lol"));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("GitHub Basics", "OpenSourceGuy", 780);
        video4.AddComment(new Comment("NoobCoder", "Finally understand pull requests!"));
        video4.AddComment(new Comment("CommitStrip", "Git merge still scares me though"));
        video4.AddComment(new Comment("VersionKing", "Great explanation of branching."));
        videos.Add(video4);

        // Display all videos
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: \"{comment.GetText()}\"");
            }

            Console.WriteLine(); // Blank line between videos
        }
    }
}