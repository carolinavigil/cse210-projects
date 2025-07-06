using System;

class Program
{
    static void Main()
    {
        string playAgain = "yes";
        Random randomGenerator = new Random();

        while (playAgain == "yes")
        {
            // Generate a random magic number from 1 to 100
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("I've picked a number between 1 and 100. Can you guess it?");

            // Game loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if they want to play again
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine().ToLower();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing. Goodbye!");
    }
}
