using System;

// SimpleGoal.cs - A goal that can be completed once
public class SimpleGoal : Goal
{
    public SimpleGoal(int points, string description, string name) 
        : base(points, description, name) //call base class constructor
    {
        //simple goals start as incomplete (handled by base class)
    }

    public override int RecordEvent()
    {
        if (!_isComplete) //check if goal is not already complete
        {
            _isComplete = true; //mark goal as complete
            return Points; //return points for completion
        }
        return 0; //no points if already complete
    }

    public override bool IsComplete()
    {
        return _isComplete; //return completion status
    }

    public static SimpleGoal FullProcess()
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

        return new SimpleGoal(points, description, name); //create and return new SimpleGoal
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}"; //format for saving with completion status
    }
}