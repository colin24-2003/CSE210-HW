using System;
using System.Collections.Generic;
using System.IO;

// GoalManager.cs - Manages all goals and handles file I/O
public class GoalManager
{
    private List<Goal> _allGoals = new List<Goal>(); //collection to store all goals
    private const string FILENAME = "goals.txt"; //default filename for saving/loading

    public void AddGoal(Goal goal)
    {
        _allGoals.Add(goal); //add goal to collection
        Console.WriteLine($"Goal '{goal.Name}' added successfully!");
    }

    public void RemoveGoal(Goal goal)
    {
        if (_allGoals.Remove(goal)) //try to remove goal from collection
        {
            Console.WriteLine($"Goal '{goal.Name}' removed successfully!");
        }
        else
        {
            Console.WriteLine("Goal not found in collection."); //goal wasn't in collection
        }
    }

    public void DisplayGoals()
    {
        if (_allGoals.Count == 0) //check if no goals exist
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _allGoals.Count; i++) //loop through all goals
        {
            Console.WriteLine($"{i + 1}. {_allGoals[i].GetDisplayInfo()}"); //display each goal with number
        }
    }

    public int RecordGoalEvent()
    {
        if (_allGoals.Count == 0) //check if no goals exist
        {
            Console.WriteLine("No goals available to record events for.");
            return 0;
        }

        Console.WriteLine("The goals are:");
        DisplayGoals(); //show all goals with numbers

        Console.Write("Which goal did you accomplish? Enter the number: ");
        string input = Console.ReadLine(); //get user's goal selection

        if (int.TryParse(input, out int selectedNumber)) //validate input is a number
        {
            int index = selectedNumber - 1; //convert to zero-based index
            
            if (index >= 0 && index < _allGoals.Count) //validate selection is in range
            {
                Goal selectedGoal = _allGoals[index]; //get the selected goal
                int pointsEarned = selectedGoal.RecordEvent(); //record the event and get points

                if (pointsEarned > 0) //check if points were earned
                {
                    Console.WriteLine($"Congratulations! You have accomplished the goal: {selectedGoal.Name}");
                    Console.WriteLine($"You have earned {pointsEarned} points!");
                    return pointsEarned; //return points earned
                }
                else
                {
                    Console.WriteLine("No points earned. Goal may already be complete or no progress made.");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number. Please select a valid goal."); //selection out of range
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number."); //non-numeric input
        }

        return 0; //return 0 points if no valid selection made
    }

    public void SaveGoals(int totalScore)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(FILENAME)) //create file writer
            {
                writer.WriteLine(totalScore.ToString()); //save total score as first line
                
                foreach (Goal goal in _allGoals) //loop through all goals
                {
                    writer.WriteLine(goal.GetStringRepresentation()); //save each goal's data
                }
            }
            Console.WriteLine($"Goals saved to {FILENAME}");
        }
        catch (Exception ex) //handle file errors
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public int LoadGoals()
    {
        if (!File.Exists(FILENAME)) //check if save file exists
        {
            Console.WriteLine($"No save file found ({FILENAME}). Starting fresh.");
            return 0;
        }

        try
        {
            string[] lines = File.ReadAllLines(FILENAME); //read all lines from file
            
            if (lines.Length == 0) //check if file is empty
            {
                Console.WriteLine("Save file is empty.");
                return 0;
            }

            int totalScore = int.Parse(lines[0]); //first line contains total score
            
            _allGoals.Clear(); //clear existing goals before loading

            for (int i = 1; i < lines.Length; i++) //process each goal line
            {
                string[] parts = lines[i].Split('|'); //split line into parts
                
                if (parts.Length >= 4) //check minimum required parts
                {
                    string goalType = parts[0]; //goal type identifier
                    string name = parts[1]; //goal name
                    string description = parts[2]; //goal description
                    int points = int.Parse(parts[3]); //goal points

                    Goal goal = null; //variable to hold created goal
                    
                    switch (goalType) //create appropriate goal type
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal(points, description, name); //create simple goal
                            if (parts.Length > 4 && bool.Parse(parts[4])) //check if was complete
                            {
                                goal.RecordEvent(); //mark as complete
                            }
                            break;
                            
                        case "EternalGoal":
                            goal = new EternalGoal(points, description, name); //create eternal goal
                            break;
                            
                        case "ChecklistGoal":
                            if (parts.Length >= 7) //check for all checklist parts
                            {
                                int bonus = int.Parse(parts[4]); //bonus points
                                int numComplete = int.Parse(parts[5]); //target completions
                                int timesCompleted = int.Parse(parts[6]); //current completions
                                
                                goal = new ChecklistGoal(points, description, name, bonus, numComplete); //create checklist goal
                                
                                for (int j = 0; j < timesCompleted; j++) //restore completion count
                                {
                                    goal.RecordEvent(); //record each completion
                                }
                            }
                            break;
                    }

                    if (goal != null) //check if goal was created successfully
                    {
                        _allGoals.Add(goal); //add goal to collection
                    }
                }
            }

            Console.WriteLine($"Loaded {_allGoals.Count} goals from {FILENAME}");
            return totalScore; //return loaded total score
        }
        catch (Exception ex) //handle file errors
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
            return 0;
        }
    }

    public int GetGoalCount()
    {
        return _allGoals.Count; //return number of goals in collection
    }

    public IReadOnlyList<Goal> GetAllGoals()
    {
        return _allGoals.AsReadOnly(); //return read-only view of goals
    }
}