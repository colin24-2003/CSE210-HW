using System;
using System.Collections.Generic;
using System.Linq;

public class Market
{
    private List<Stock> _stocks;
    private int _currentDay;
    private bool _isOpen;
    private Random _random;

    public Market()
    {
        _stocks = new List<Stock>();
        _currentDay = 0;
        _isOpen = true;
        _random = new Random();
        InitializeStocks();
    }

    // Initialize market with sample stocks
    private void InitializeStocks()
    {
        _stocks.Add(new Stock("AAPL", "Apple Inc.", 150.00, "Tech"));
        _stocks.Add(new Stock("TSLA", "Tesla Inc.", 720.00, "Auto"));
        _stocks.Add(new Stock("GME", "GameStop Corp.", 18.00, "Retail"));
        _stocks.Add(new Stock("AMZN", "Amazon.com Inc.", 3200.00, "Tech"));
        _stocks.Add(new Stock("MSFT", "Microsoft Corp.", 280.00, "Tech"));
        _stocks.Add(new Stock("GOOGL", "Alphabet Inc.", 2400.00, "Tech"));
        _stocks.Add(new Stock("NVDA", "NVIDIA Corp.", 450.00, "Tech"));
        _stocks.Add(new Stock("JPM", "JPMorgan Chase", 140.00, "Finance"));
    }

    // Returns stock by ticker symbol
    public Stock GetStock(string ticker)
    {
        return _stocks.FirstOrDefault(s => s.GetTicker().Equals(ticker, StringComparison.OrdinalIgnoreCase));
    }

    // Returns complete stock list
    public List<Stock> GetAllStocks()
    {
        return new List<Stock>(_stocks);
    }

    // Updates all stock prices for new day (random fluctuation)
    public void UpdatePrices()
    {
        foreach (var stock in _stocks)
        {
            // Random price movement between -5% and +5%
            double changePercent = (_random.NextDouble() - 0.5) * 10; // -5% to +5%
            double newPrice = stock.GetCurrentPrice() * (1 + changePercent / 100);
            
            // Ensure price doesn't go too low
            if (newPrice < 0.01)
                newPrice = 0.01;
                
            stock.UpdatePrice(newPrice);
        }
    }

    // Applies news impacts to relevant stocks
    public void ApplyNewsEvent(NewsEvent newsEvent)
    {
        foreach (var stock in _stocks)
        {
            if (newsEvent.AffectsStock(stock))
            {
                stock.ApplyNewsImpact(newsEvent.GetImpact());
            }
        }
    }

    // Shows price changes for all stocks
    public void DisplayMarketUpdate()
    {
        Console.WriteLine("\nMarket Update:");
        foreach (var stock in _stocks)
        {
            stock.DisplayPriceTransition();
        }
        Console.WriteLine();
    }

    // Display current market status
    public void DisplayMarketStatus()
    {
        Console.WriteLine($"\n--- Market Status (Day {_currentDay}) ---");
        Console.WriteLine($"Market Status: {(_isOpen ? "Open" : "Closed")}");
        Console.WriteLine("Current Prices:");
        
        foreach (var stock in _stocks)
        {
            stock.DisplayStock();
        }
        Console.WriteLine();
    }

    // Advance to next trading day
    public void NextDay()
    {
        _currentDay++;
    }

    // Add a new stock to the market
    public void AddStock(Stock stock)
    {
        if (!_stocks.Any(s => s.GetTicker().Equals(stock.GetTicker(), StringComparison.OrdinalIgnoreCase)))
        {
            _stocks.Add(stock);
        }
    }

    // Remove a stock from the market
    public bool RemoveStock(string ticker)
    {
        var stock = GetStock(ticker);
        if (stock != null)
        {
            _stocks.Remove(stock);
            return true;
        }
        return false;
    }

    // Getters
    public int GetCurrentDay() => _currentDay;
    public bool IsOpen() => _isOpen;
    public int GetStockCount() => _stocks.Count;
    
    // Setters
    public void SetMarketOpen(bool isOpen) => _isOpen = isOpen;
}