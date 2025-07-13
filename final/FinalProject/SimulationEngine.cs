using System;
using System.Collections.Generic;
using System.Linq;

public class SimulationEngine
{
    private List<Investor> _investors;
    private Market _market;
    private List<NewsEvent> _newsEvents;
    private Random _random;
    private int _currentDay;
    private int _maxDays;

    public SimulationEngine(int maxDays = 30)
    {
        _investors = new List<Investor>();
        _market = new Market();
        _newsEvents = NewsEvent.GetSampleNewsEvents();
        _random = new Random();
        _currentDay = 0;
        _maxDays = maxDays;
    }

    // Add investor to simulation
    public void AddInvestor(Investor investor)
    {
        _investors.Add(investor);
    }

    // Initialize simulation with default investors
    public void InitializeSimulation(string playerName)
    {
        // Add human player
        Player player = new Player(playerName, 10000.0);
        AddInvestor(player);

        // Add AI investors
        AIInvestor warrenBot = new AIInvestor("WarrenBot", 10000.0, "Conservative", 0.3, 0.4);
        AIInvestor riskyRandy = new AIInvestor("RiskyRandy", 10000.0, "Aggressive", 0.8, 0.7);
        
        AddInvestor(warrenBot);
        AddInvestor(riskyRandy);
    }

    // Run the entire simulation
    public void RunSimulation()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Welcome to the Stock Market Simulator!");
        
        // Display initial setup
        var player = _investors.FirstOrDefault(i => i is Player);
        var aiInvestors = _investors.Where(i => i is AIInvestor).ToList();
        
        Console.WriteLine($"Player: {player?.GetName()} | Starting Cash: ${player?.GetPortfolio().GetCash():F2}");
        Console.Write("AI Investors: ");
        Console.WriteLine(string.Join(", ", aiInvestors.Select(ai => ai.GetName())));
        Console.WriteLine("----------------------------------------");

        // Run simulation for specified days
        for (int day = 1; day <= _maxDays; day++)
        {
            _currentDay = day;
            _market.NextDay();
            
            if (!RunDay())
            {
                break; // Player chose to exit
            }
            
            if (CheckGameEnd())
            {
                break;
            }
        }
        
        ShowFinalResults();
    }

    // Execute one complete trading day
    public bool RunDay()
    {
        Console.WriteLine($"\nDay {_currentDay}:");
        
        // Generate and apply news event
        NewsEvent todaysNews = GenerateNews();
        todaysNews.DisplayNews();
        Console.WriteLine();
        
        // Apply news impact to market
        _market.ApplyNewsEvent(todaysNews);
        
        // Display market update
        _market.DisplayMarketUpdate();
        
        // Process all investor decisions
        if (!ProcessAllTrades())
        {
            return false; // Player chose to exit
        }
        
        // Display end of day results
        DisplayDayResults();
        
        return true;
    }

    // Generate random news event
    private NewsEvent GenerateNews()
    {
        if (_newsEvents.Count == 0)
        {
            return new NewsEvent(); // Default no-news event
        }
        
        int randomIndex = _random.Next(_newsEvents.Count);
        return _newsEvents[randomIndex];
    }

    // Process trading decisions for all investors
    private bool ProcessAllTrades()
    {
        foreach (var investor in _investors)
        {
            if (investor is Player player)
            {
                // Display player's portfolio
                Console.WriteLine("Your Portfolio:");
                player.GetPortfolio().DisplayPortfolioWithValues(_market);
                Console.WriteLine();
                
                // Get player decision
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Buy Stock");
                Console.WriteLine("2. Sell Stock");
                Console.WriteLine("3. Skip Day");
                Console.WriteLine("4. Exit Game");
                Console.Write("> ");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        HandlePlayerBuy(player);
                        break;
                    case "2":
                        HandlePlayerSell(player);
                        break;
                    case "3":
                        Console.WriteLine("Skipping day...");
                        break;
                    case "4":
                        return false; // Exit game
                    default:
                        Console.WriteLine("Invalid choice. Skipping day...");
                        break;
                }
            }
            else
            {
                // AI investor makes decision
                investor.MakeDecision(_market);
            }
        }
        
        return true;
    }

    // Handle player buy action
    // Handle player buy action
private void HandlePlayerBuy(Player player)
{
    Console.WriteLine("\nAvailable Stocks:");
    foreach (var currentStock in _market.GetAllStocks())
    {
        Console.WriteLine($"- {currentStock.GetTicker()}: ${currentStock.GetCurrentPrice():F2}");
    }
    
    Console.Write("\nEnter stock ticker to buy (e.g., AAPL): ");
    string ticker = Console.ReadLine()?.ToUpper();
    
    Stock selectedStock = _market.GetStock(ticker);  // Changed 'stock' to 'selectedStock'
    if (selectedStock == null)
    {
        Console.WriteLine("Stock not found!");
        return;
    }
    
    Console.Write("Enter quantity to buy: ");
    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
    {
        if (player.BuyStock(selectedStock, quantity))  // Updated reference
        {
            Console.WriteLine($"✅ Purchase successful: {quantity} shares of {ticker} at ${selectedStock.GetCurrentPrice():F2}");
            Console.WriteLine($"Remaining Cash: ${player.GetPortfolio().GetCash():F2}");
        }
    }
    else
    {
        Console.WriteLine("Invalid quantity!");
    }
}

    // Handle player sell action
    // Handle player sell action
private void HandlePlayerSell(Player player)
{
    var holdings = player.GetPortfolio().GetAllHoldings();
    if (holdings.Count == 0)
    {
        Console.WriteLine("You don't own any stocks to sell!");
        return;
    }
    
    Console.WriteLine("\nYour Holdings:");
    foreach (var holding in holdings)
    {
        Console.WriteLine($"- {holding.Key}: {holding.Value} shares");
    }
    
    Console.Write("\nEnter stock ticker to sell: ");
    string ticker = Console.ReadLine()?.ToUpper();
    
    if (!holdings.ContainsKey(ticker))
    {
        Console.WriteLine("You don't own any shares of that stock!");
        return;
    }
    
    Console.Write("Enter quantity to sell: ");
    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
    {
        Stock selectedStock = _market.GetStock(ticker);  // Changed 'stock' to 'selectedStock'
        if (selectedStock != null && player.SellStock(selectedStock, quantity))
        {
            Console.WriteLine($"✅ Sold {quantity} shares of {ticker} @ ${selectedStock.GetCurrentPrice():F2}");
            Console.WriteLine($"New Cash Balance: ${player.GetPortfolio().GetCash():F2}");
        }
    }
    else
    {
        Console.WriteLine("Invalid quantity!");
    }
}

    // Display end of day summary
    private void DisplayDayResults()
    {
        Console.WriteLine($"\n--- End of Day {_currentDay} Summary ---");
        
        foreach (var investor in _investors)
        {
            double portfolioValue = investor.GetPortfolioValue(_market);
            Console.WriteLine($"{investor.GetName()}: Portfolio Value = ${portfolioValue:F2}");
        }
        
        Console.WriteLine("----------------------------------------");
    }

    // Check if game should end
    private bool CheckGameEnd()
    {
        // Game ends if player runs out of money and has no stocks
        var player = _investors.FirstOrDefault(i => i is Player);
        if (player != null)
        {
            double portfolioValue = player.GetPortfolioValue(_market);
            if (portfolioValue < 1.0) // Less than $1 total
            {
                Console.WriteLine("\nGame Over: You've run out of money!");
                return true;
            }
        }
        
        return false;
    }

    // Display final results and rankings
    private void ShowFinalResults()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("FINAL RESULTS");
        Console.WriteLine("========================================");
        
        // Calculate final portfolio values and sort by value
        var results = _investors.Select(investor => new
        {
            Name = investor.GetName(),
            Value = investor.GetPortfolioValue(_market),
            Investor = investor
        }).OrderByDescending(r => r.Value).ToList();
        
        Console.WriteLine("Final Rankings:");
        for (int i = 0; i < results.Count; i++)
        {
            var result = results[i];
            string medal = i == 0 ? "🏆" : i == 1 ? "🥈" : i == 2 ? "🥉" : "  ";
            Console.WriteLine($"{medal} {i + 1}. {result.Name}: ${result.Value:F2}");
        }
        
        // Show detailed breakdown for player
        var player = results.FirstOrDefault(r => r.Investor is Player);
        if (player != null)
        {
            Console.WriteLine($"\nYour Performance:");
            Console.WriteLine($"Starting Cash: $10,000.00");
            Console.WriteLine($"Final Value: ${player.Value:F2}");
            double gain = player.Value - 10000.0;
            Console.WriteLine($"Total Gain/Loss: ${gain:+F2;-F2}");
            Console.WriteLine($"Return: {(gain / 10000.0) * 100:+F1;-F1}%");
        }
        
        Console.WriteLine("\nThank you for playing the Stock Market Simulator!");
    }

    // Getters
    public List<Investor> GetInvestors() => new List<Investor>(_investors);
    public Market GetMarket() => _market;
    public int GetCurrentDay() => _currentDay;
    public int GetMaxDays() => _maxDays;
}