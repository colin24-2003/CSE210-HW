using System;

public class Player : Investor
{
    private double _startingCash;

    public Player(string name, double startingCash) 
        : base(name, new Portfolio(startingCash), "Human Player")
    {
        _startingCash = startingCash;
    }

    // Implementation of abstract method from Investor
    public override void MakeDecision(Market market)
    {
        ShowMenu();
        string choice = Console.ReadLine();
        
        switch (choice?.ToUpper())
        {
            case "1":
            case "B":
                HandleBuyStock(market);
                break;
            case "2":
            case "S":
                HandleSellStock(market);
                break;
            case "3":
            case "P":
                DisplayStatus();
                break;
            case "4":
            case "M":
                market.DisplayMarketUpdate();
                break;
            case "5":
            case "E":
                Console.WriteLine("Ending turn...");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                MakeDecision(market);
                break;
        }
    }

    // Display trading menu options
    public void ShowMenu()
    {
        Console.WriteLine("\n--- Trading Menu ---");
        Console.WriteLine("1. (B)uy Stock");
        Console.WriteLine("2. (S)ell Stock");
        Console.WriteLine("3. (P)ortfolio Status");
        Console.WriteLine("4. (M)arket Update");
        Console.WriteLine("5. (E)nd Turn");
        Console.Write("Enter your choice: ");
    }

    // Handle stock purchase with validation
    private void HandleBuyStock(Market market)
    {
        Console.Write("Enter stock ticker: ");
        string ticker = Console.ReadLine()?.ToUpper();
        
        Stock stock = market.GetStock(ticker);
        if (stock == null)
        {
            Console.WriteLine("Stock not found!");
            return;
        }

        Console.Write("Enter quantity: ");
        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
        {
            BuyStock(stock, quantity);
        }
        else
        {
            Console.WriteLine("Invalid quantity!");
        }
    }

    // Handle stock sale with validation
    private void HandleSellStock(Market market)
    {
        Console.Write("Enter stock ticker: ");
        string ticker = Console.ReadLine()?.ToUpper();
        
        Stock stock = market.GetStock(ticker);
        if (stock == null)
        {
            Console.WriteLine("Stock not found!");
            return;
        }

        Console.Write("Enter quantity: ");
        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
        {
            SellStock(stock, quantity);
        }
        else
        {
            Console.WriteLine("Invalid quantity!");
        }
    }

    // Buy stock with validation
    public bool BuyStock(Stock stock, int quantity)
    {
        if (CanAfford(stock, quantity))
        {
            if (_portfolio.BuyStock(stock, quantity))
            {
                Console.WriteLine($"Successfully bought {quantity} shares of {stock.GetTicker()} at ${stock.GetCurrentPrice():F2} each");
                return true;
            }
        }
        else
        {
            Console.WriteLine($"Insufficient funds! Need ${stock.GetCurrentPrice() * quantity:F2}, have ${_portfolio.GetCash():F2}");
        }
        return false;
    }

    // Sell stock with validation
    public bool SellStock(Stock stock, int quantity)
    {
        if (_portfolio.SellStock(stock, quantity))
        {
            Console.WriteLine($"Successfully sold {quantity} shares of {stock.GetTicker()} at ${stock.GetCurrentPrice():F2} each");
            return true;
        }
        else
        {
            Console.WriteLine($"Cannot sell {quantity} shares of {stock.GetTicker()}. You only own {_portfolio.GetHolding(stock.GetTicker())} shares.");
        }
        return false;
    }

    public double GetStartingCash() => _startingCash;
}