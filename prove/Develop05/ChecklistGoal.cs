using System;

// ChecklistGoal.cs - A goal that must be completed a certain number of times
public class ChecklistGoal : Goal
{
    private int _bonus; //bonus points awarded when goal is fully complete
    private int _numComplete; //target number of times goal must be completed
    private int _timesCompleted; //current number of times goal has been completed

    public int NumComplete => _numComplete; //property to access target completions
    public int TimesCompleted => _timesCompleted; //property to access current completions
    public int Bonus => _bonus; //property to access bonus points

    public ChecklistGoal(int points, string description, string name, int bonus, int numComplete)
        : base(points, description, name) //call base class constructor
    {
        _bonus = bonus; //set bonus points
        _numComplete = numComplete; //set target completions
        _timesCompleted = 0; //start with zero completions
    }

    public override int RecordEvent()
    {
        if (_timesCompleted < _numComplete) //only record if not already fully complete
        {
            _timesCompleted++; //increment completion counter
            int pointsEarned = Points; //start with regular points

            if (_timesCompleted == _numComplete) //check if we've reached the target
            {
                pointsEarned += _bonus; //add bonus points
                _isComplete = true; //mark goal as complete
                Console.WriteLine($"Congratulations! You completed the goal and earned a bonus of {_bonus} points!");
            }

            return pointsEarned; //return total points earned
        }
        return 0; //no points if already fully complete
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _numComplete; //check if completed required number of times
    }

    public override string GetDisplayInfo()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]"; //show completion status
        return $"{checkbox} {Name} ({Description}) -- Currently completed: {_timesCompleted}/{_numComplete}"; //show progress
    }

    public static ChecklistGoal FullProcess()
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

        int numComplete; //variable to store target completions
        Console.Write("How many times does this goal need to be accomplished for completion? ");
        while (!int.TryParse(Console.ReadLine(), out numComplete) || numComplete <= 0) //validate completion target
        {
            Console.WriteLine("Please enter a valid positive number:");
        }

        int bonus; //variable to store bonus points
        Console.Write("What is the bonus for completing it that many times? ");
        while (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0) //validate bonus points
        {
            Console.WriteLine("Please enter a valid positive number:");
        }

        return new ChecklistGoal(points, description, name, bonus, numComplete); //create and return new ChecklistGoal
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_bonus}|{_numComplete}|{_timesCompleted}"; //format for saving with all data
    }
}