using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Step 1: Create the list to store numbers
        List<int> numbers = new List<int>();
        int userNumber;

        // Step 2: Prompt for numbers
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            userNumber = int.Parse(input);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        } while (userNumber != 0);

        // Step 3: Calculate the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Step 4: Calculate the average
        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Step 5: Find the largest number
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        // ✅ Stretch Challenge: Find the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        if (smallestPositive == int.MaxValue)
        {
            Console.WriteLine("There were no positive numbers.");
        }
        else
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // ✅ Stretch Challenge: Sort and display the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
