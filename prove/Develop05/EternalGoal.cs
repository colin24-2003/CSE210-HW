using System;

// EternalGoal.cs - A goal that can be completed repeatedly
public class EternalGoal : Goal
{
    public EternalGoal(int points, string description, string name) 
        : base(points, description, name) //call base class constructor
    {
        //eternal goals are never truly complete
    }

    public override int RecordEvent()
    {
        return Points; //always award points for eternal goals
    }

    public override bool IsComplete()
    {
        return false; //eternal goals are never "complete"
    }

    public static EternalGoal FullProcess()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine(); //get goal name from user

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine(); //get goal description from user

        int points; //variable to store points value
        Console.Write("What is the amount of points associated with this goal? ");
        while (!int.TryParse(Console.ReadLine(), out points) || points < 0) //validate points input
        {
            Console.WriteLine("Please enter a valid positive number for points:");
        }

        return new EternalGoal(points, description, name); //create and return new EternalGoal
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}|{false}"; //format for saving (never complete)
    }
}