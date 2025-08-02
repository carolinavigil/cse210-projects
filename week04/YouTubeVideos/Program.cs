using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Basics", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "This helped me a lot."));
        video1.AddComment(new Comment("Charlie", "Thanks for the clear example."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Unity Game Dev", "Brackeys", 900);
        video2.AddComment(new Comment("Dave", "Best Unity tutorial ever."));
        video2.AddComment(new Comment("Eva", "Please make more of these!"));
        video2.AddComment(new Comment("Frank", "Loved the animations section."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Web Dev Crash Course", "FreeCodeCamp", 1200);
        video3.AddComment(new Comment("Gina", "This video is gold."));
        video3.AddComment(new Comment("Henry", "My first website thanks to this!"));
        video3.AddComment(new Comment("Irene", "Very comprehensive."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Machine Learning Intro", "AI School", 1100);
        video4.AddComment(new Comment("Jack", "Awesome introduction."));
        video4.AddComment(new Comment("Kira", "Clear and easy to follow."));
        video4.AddComment(new Comment("Liam", "Excited to dive deeper."));
        videos.Add(video4);

        // Display info for all videos
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
