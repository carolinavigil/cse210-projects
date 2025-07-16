using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

// Enhancements:
// - Loads scripture from a text file named "scriptures.txt"
// - Randomly selects one scripture to use in the program
// - Supports both single verses and verse ranges

class Program
{
    static void Main(string[] args)
    {
        string filePath = "scriptures.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: scriptures.txt not found.");
            return;
        }

        Scripture scripture = LoadRandomScripture(filePath);

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                return;

            scripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden. Press Enter to exit.");
        Console.ReadLine();
    }

    static Scripture LoadRandomScripture(string filePath)
    {
        List<string> lines = File.ReadAllLines(filePath).ToList();
        Random random = new Random();
        string selected = lines[random.Next(lines.Count)];

        string[] parts = selected.Split('|');

        string book = parts[0];
        int chapter = int.Parse(parts[1]);
        int startVerse = int.Parse(parts[2]);
        string endVersePart = parts[3];
        string text = parts[4];

        Reference reference;
        if (string.IsNullOrWhiteSpace(endVersePart))
        {
            reference = new Reference(book, chapter, startVerse);
        }
        else
        {
            int endVerse = int.Parse(endVersePart);
            reference = new Reference(book, chapter, startVerse, endVerse);
        }

        return new Scripture(reference, text);
    }
}

