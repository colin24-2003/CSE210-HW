using System;

public class Player : Investor
{
    public bool GameEnded { get; private set; } = false;

    public Player(string name, double startingCash) : base(name, startingCash) { }

    public override void TakeTurn(Market market)
    {
        // Show current portfolio
        Console.WriteLine("\nYour Portfolio:");
        Portfolio.Display(market);

        // Show menu
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("1. Buy Stock");
        Console.WriteLine("2. Sell Stock");
        Console.WriteLine("3. Skip Day");
        Console.WriteLine("4. End Game");
        Console.Write("> ");

        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                BuyStock(market);
                break;
            case "2":
                SellStock(market);
                break;
            case "4":
                GameEnded = true;
                Console.WriteLine("Ending game early...");
                break;
            default:
                Console.WriteLine("Skipping day...");
                break;
        }
    }

    private void BuyStock(Market market)
    {
        Console.WriteLine("\nAvailable Stocks:");
        market.ShowAllStocks();
        
        Console.Write("\nEnter stock ticker to buy (e.g., AAPL): ");
        Console.Write("> ");
        string ticker = Console.ReadLine()?.ToUpper();

        Stock stock = market.GetStock(ticker);
        if (stock == null)
        {
            Console.WriteLine("Stock not found!");
            return;
        }

        Console.Write("Enter quantity to buy: ");
        Console.Write("> ");
        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
        {
            if (Portfolio.BuyStock(stock, quantity))
            {
                Console.WriteLine($"✅ Purchase successful: {quantity} shares of {ticker} at ${stock.Price:F2}");
                Console.WriteLine($"Remaining Cash: ${Portfolio.Cash:F2}");
            }
            else
            {
                Console.WriteLine("❌ Not enough cash!");
            }
        }
        else
        {
            Console.WriteLine("Invalid quantity!");
        }
    }

    private void SellStock(Market market)
    {
        if (Portfolio.Holdings.Count == 0)
        {
            Console.WriteLine("You don't own any stocks!");
            return;
        }

        Console.WriteLine("\nYour Holdings:");
        Portfolio.ShowHoldings(market);

        Console.Write("\nEnter stock ticker to sell: ");
        Console.Write("> ");
        string ticker = Console.ReadLine()?.ToUpper();

        if (!Portfolio.Holdings.ContainsKey(ticker))
        {
            Console.WriteLine("You don't own that stock!");
            return;
        }

        Console.Write("Enter quantity to sell: ");
        Console.Write("> ");
        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
        {
            Stock stock = market.GetStock(ticker);
            if (Portfolio.SellStock(stock, quantity))
            {
                Console.WriteLine($"✅ Sold {quantity} shares of {ticker} @ ${stock.Price:F2}");
                Console.WriteLine($"New Cash Balance: ${Portfolio.Cash:F2}");
            }
            else
            {
                Console.WriteLine("❌ Can't sell that many shares!");
            }
        }
        else
        {
            Console.WriteLine("Invalid quantity!");
        }
    }
}