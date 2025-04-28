using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);
        Console.Write($"What is the magic number: {number} \n");
        Console.Write("What is your guess?: ");
        string userGuess = Console.ReadLine();
        int guess = int.Parse(userGuess);

        while (guess != number){
            Console.WriteLine($"What is the magic number: {number} \n");
            int guess1 = int.Parse(userGuess);
            if (guess1 > number)
        {
            Console.Write("Lower");
        }
        else if (guess1 < number)
        {
            Console.WriteLine("Higher");

        }
            Console.WriteLine("\nWhat is your guess?: ");
            userGuess = Console.ReadLine();
            guess = int.Parse(userGuess);

        } 
        Console.WriteLine("You guessed it!");
        // i++ is the same as i += 1 in python

    }
}