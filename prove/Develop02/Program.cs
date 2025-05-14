// Program.cs
// I added a method to count the total amount of entries for the user. This is my attempt on the exceeeding requirements
using JournalApp;

public class Program
{
    public static void Main(){
        Journal journal = new Journal(); // creates a Journal object
        PromptGenerator promptGen = new PromptGenerator(); // creates a PromptGenerator object
        DisplayMenu(journal, promptGen); // passes both objects as arguments to the DisplayMenu method
    }
    


    public static void DisplayMenu(Journal journal, PromptGenerator promptGen)
    {
        bool isRunning = true;

        while(isRunning){
            Console.WriteLine("1. Write ");
            Console.WriteLine("2. Display ");
            Console.WriteLine("3. Save ");
            Console.WriteLine("4. Load ");
            Console.WriteLine("5. Total Entries ");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do?: ");
            string userInput = Console.ReadLine(); // stores user input
            Console.WriteLine(userInput);

            switch(userInput)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt(); // gets a random prompt from PromptGenerator
                    Console.WriteLine($"\nPrompt: {prompt}"); // displays the prompt to the user
                    Console.Write("Your response: ");
                    string response = Console.ReadLine(); // stores user response to prompt
                    string date = DateTime.Now.ToShortDateString(); // gets the current date as a string
                    JournalEntry entry = new JournalEntry(date, prompt, response); // creates a JournalEntry object with date, prompt, and response
                    journal.AddEntry(entry); // adds the entry to the journal
                    break;

                case "2":
                    journal.DisplayEntries(); // calls the method to display all journal entries
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine(); // gets filename from user input
                    journal.SaveToFile(saveFile); // calls method to save entries to the specified file
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine(); // gets filename from user input
                    journal.LoadFromFile(loadFile); // calls method to load entries from the specified file
                    break;

                case "5":
                    Console.WriteLine($"Your total entries are {journal.GetEntryCount()}");
                    break; // added a method to count the amount of entries the user enters 
                case "6":
                    isRunning = false; // stops the loop to quit the program
                    Console.WriteLine("Goodbye! ");
                    break;

                default:
                    Console.WriteLine("Invalid option. "); // handles invalid menu selections
                    break;
            }
        }
    }
}
