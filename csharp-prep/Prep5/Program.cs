using System;
using System.Globalization;
using System.Runtime.InteropServices.Marshalling;

class Program
{

    /* 
    Program requirements 
    DisplayWelcome - Displays the message, "Welcome to the Program!"
    PromptUserName - Asks for and returns the user's name (as a string)
    PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
    SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
    DisplayResult - Accepts the user's name and the squared number and displays them.
    function example: returnType(string, void, int) FunctionName(data type parameter1, data typeparameter2)
    return int, string, double, etc. if no data type such as void then you don't need to return anything like in Main and DisplayWelcome

    */
    static void Main(string[] args)
    {
        DisplayWelcome(); // calls the DisplayWelcome function 
        string userName = PromptUserName(); // assigns a variable for the users name and calls the PromptUserName function
        int userNumber = PromptUserNumber(); // assigns a variable for the users number and calls the PromptUserNumber function
        int squaredNumber = SquareNumber(userNumber); // assings a variable for the sqaured number and calls SquareNumber function and then passes
        // userNumber as the parameter
        DisplayResult(userName, squaredNumber); // calls and DisplayResult and passes userName and squaredNumber as parameters
    }

    static void DisplayWelcome() // since we aren't returning a value we don't need to change void
    {
        Console.WriteLine("Welcome to the Program!");// printing a message to the console
    }

    static string PromptUserName() // adds string to be able to be returned
    {
        // prompts user for name and then assigns it to a string variable called name and then returns name
        Console.Write("Enter your name: ");
        string name = Console.ReadLine(); 
        return name;

    }

    static int SquareNumber(int first) // allows to return an int 
    {
        // does a square calculation and returns a square
        int square = first * first;
        return square;
    }
    static int PromptUserNumber() // allows to return an int
    {
        // prompts user to enter number, changes string into an int and then returns favNum
        Console.Write("Enter your favorite number: ");  
        // string favNumString = Console.ReadLine(); |removed not needed code "string favNumString = Console.ReadLine();"     
        int favNum = int.Parse(Console.ReadLine());  
        return favNum;
    }

    static void DisplayResult(string name, int squareNum) // displays users name and their squared number
    {
        Console.WriteLine($"Hello {name}, your square of your number is {squareNum}");
    }
}