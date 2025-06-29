using System;

class Program
{
    static void Main(string[] args)
    {
        Menu(); //start the main menu system
    }

    public static void Menu()
    {
        int totalPoints = 0; //track user's total accumulated points
        GoalManager goalManager = new GoalManager(); //create manager to handle all goals
        bool isRunning = true; //control variable for main menu loop
        
        while (isRunning) //continue until user chooses to quit
        {
            Console.WriteLine($"\nYou have {totalPoints} points."); //display current point total
            Console.Write(@"Menu Options: 
    1. Create New Goal
    2. List Goals
    3. Save Goals
    4. Load Goals
    5. Record Event
    6. Quit
Select a choice from the menu: "); //show menu options to user

            string userInput = Console.ReadLine(); //get user's menu choice
            
            if (int.TryParse(userInput, out int userChoice)) //validate input is a number
            {
                switch (userChoice) //handle each menu option
                {
                    case 1:
                        MiniMenu(goalManager); //create new goal using submenu
                        break;
                    case 2:
                        Console.WriteLine("\nThe goals are:");
                        goalManager.DisplayGoals(); //display all current goals with their status
                        break;
                    case 3:
                        goalManager.SaveGoals(totalPoints); //save goals and current score to file
                        Console.WriteLine("Goals saved successfully!");
                        break;
                    case 4:
                        totalPoints = goalManager.LoadGoals(); //load goals and score from file
                        Console.WriteLine("Goals loaded successfully!");
                        break;
                    case 5:
                        int earnedPoints = goalManager.RecordGoalEvent(); //record an event and get points earned
                        totalPoints += earnedPoints; //add earned points to total
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        isRunning = false; //exit the program
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again!"); //handle invalid menu choice
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number!"); //handle non-numeric input
            }
        }
    }

    public static void MiniMenu(GoalManager goalManager)
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("What type of Goal would you like to create: "); //prompt for goal type selection
        
        string userInputMini = Console.ReadLine(); //get user's goal type choice
        
        if (int.TryParse(userInputMini, out int userChoice)) //validate input is a number
        {
            switch (userChoice) //create appropriate goal type
            {
                case 1:
                    SimpleGoal newSimpleGoal = SimpleGoal.FullProcess(); //create a Simple Goal through user input
                    goalManager.AddGoal(newSimpleGoal); //add the new goal to manager
                    Console.WriteLine("Simple goal created successfully!");
                    break;
                case 2:
                    EternalGoal newEternalGoal = EternalGoal.FullProcess(); //create an Eternal Goal through user input
                    goalManager.AddGoal(newEternalGoal); //add the new goal to manager
                    Console.WriteLine("Eternal goal created successfully!");
                    break;
                case 3:
                    ChecklistGoal newChecklistGoal = ChecklistGoal.FullProcess(); //create a Checklist Goal through user input
                    goalManager.AddGoal(newChecklistGoal); //add the new goal to manager
                    Console.WriteLine("Checklist goal created successfully!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again!"); //handle invalid goal type choice
                    break;
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number!"); //handle non-numeric input
        }
    }
}