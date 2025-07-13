using System;

public class Program
{
    public static void Main()
    {
        try
        {
            // Show welcome message
            ShowWelcome();
            
            // Get player name
            string playerName = GetPlayerName();
            
            // Create and initialize simulation
            SimulationEngine simulation = new SimulationEngine();
            simulation.InitializeSimulation(playerName);
            
            // Run the simulation
            simulation.RunSimulation();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    // Display game introduction
    private static void ShowWelcome()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("    STOCK MARKET SIMULATOR");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("Welcome to the Stock Market Trading Game!");
        Console.WriteLine();
        Console.WriteLine("Game Features:");
        Console.WriteLine("• Start with $10,000 cash");
        Console.WriteLine("• Trade stocks with AI competitors");
        Console.WriteLine("• React to daily news events");
        Console.WriteLine("• Build your portfolio over time");
        Console.WriteLine("• Compete for the highest returns");
        Console.WriteLine();
        Console.WriteLine("How to Play:");
        Console.WriteLine("• Each day brings new market conditions");
        Console.WriteLine("• News events affect stock prices");
        Console.WriteLine("• Buy low, sell high to maximize profits");
        Console.WriteLine("• Watch out for WarrenBot and RiskyRandy!");
        Console.WriteLine();
        Console.WriteLine("Available Stocks:");
        Console.WriteLine("• AAPL - Apple Inc. (Tech)");
        Console.WriteLine("• TSLA - Tesla Inc. (Auto)");
        Console.WriteLine("• GME - GameStop Corp. (Retail)");
        Console.WriteLine("• AMZN - Amazon.com Inc. (Tech)");
        Console.WriteLine("• MSFT - Microsoft Corp. (Tech)");
        Console.WriteLine("• GOOGL - Alphabet Inc. (Tech)");
        Console.WriteLine("• NVDA - NVIDIA Corp. (Tech)");
        Console.WriteLine("• JPM - JPMorgan Chase (Finance)");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    // Get player name input
    private static string GetPlayerName()
    {
        string playerName;
        
        do
        {
            Console.Write("Enter your name: ");
            playerName = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrEmpty(playerName))
            {
                Console.WriteLine("Please enter a valid name.");
            }
            
        } while (string.IsNullOrEmpty(playerName));
        
        return playerName;
    }

    // Display game instructions
    private static void ShowInstructions()
    {
        Console.WriteLine("TRADING INSTRUCTIONS:");
        Console.WriteLine("=====================");
        Console.WriteLine("1. Each day starts with a news event");
        Console.WriteLine("2. News events affect stock prices");
        Console.WriteLine("3. Review your portfolio and market prices");
        Console.WriteLine("4. Make your trading decisions:");
        Console.WriteLine("   - Buy stocks when prices are low");
        Console.WriteLine("   - Sell stocks when prices are high");
        Console.WriteLine("   - Or skip the day if no good opportunities");
        Console.WriteLine("5. AI competitors will also make moves");
        Console.WriteLine("6. Day ends with portfolio value summary");
        Console.WriteLine();
        Console.WriteLine("TIPS FOR SUCCESS:");
        Console.WriteLine("• Diversify your portfolio across sectors");
        Console.WriteLine("• Pay attention to news events and their impacts");
        Console.WriteLine("• Don't invest all your money at once");
        Console.WriteLine("• Sometimes the best move is to wait");
        Console.WriteLine("• Learn from AI competitor strategies");
        Console.WriteLine();
        Console.WriteLine("Press any key to start trading...");
        Console.ReadKey();
        Console.Clear();
    }

    // Display error message
    private static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
    }

    // Display success message
    private static void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Success: {message}");
        Console.ResetColor();
    }

    // Confirm exit
    private static bool ConfirmExit()
    {
        Console.Write("Are you sure you want to exit? (y/n): ");
        string response = Console.ReadLine()?.ToLower();
        return response == "y" || response == "yes";
    }
}