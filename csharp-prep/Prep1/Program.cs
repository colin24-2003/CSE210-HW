using System;


/* What is your first name? Scott

What is your last name? Burton

Your name is Burton, Scott Burton.

This is what the output is expected to be*/

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name?: ");
        string firstName = Console.ReadLine();
        Console.Write("What is your last name?: ");
        string lastName = Console.ReadLine();
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}

/* first_name = input("What is your first name?: )
last_name = input("What is your last name?: )
print(f"Your name is {last_name}, {first_name} {last_name}")

I wrote the program in python first to give me an idea of how it might need to be formatted
*/