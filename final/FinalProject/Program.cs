using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Stock Market Simulator!");
        Console.Write("Enter your name: ");
        string playerName = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(playerName))
        {
            playerName = "Player";
        }
        
        Game game = new Game();
        game.StartGame(playerName);
        
        Console.WriteLine("\nThanks for playing! Press any key to exit...");
        Console.ReadKey();
    }
}