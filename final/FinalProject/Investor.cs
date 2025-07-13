using System;

public abstract class Investor
{
    protected string _name;
    protected Portfolio _portfolio;
    protected string _strategy;

    public Investor(string name, Portfolio portfolio, string strategy) 
    {
        _name = name;
        _portfolio = portfolio;
        _strategy = strategy;
    }

    // Abstract method that must be implemented by derived classes
    public abstract void MakeDecision(Market market);

    // Check if investor can afford to buy specified quantity of stock
    public bool CanAfford(Stock stock, int quantity)
    {
        double totalCost = stock.GetCurrentPrice() * quantity;
        return _portfolio.GetCash() >= totalCost;
    }

    // Calculate total portfolio value including cash and stock holdings
    public double GetPortfolioValue(Market market)
    {
        return _portfolio.GetTotalValue(market);
    }

    // Display current portfolio status
    public virtual void DisplayStatus()
    {
        Console.WriteLine($"Investor: {_name}");
        Console.WriteLine($"Strategy: {_strategy}");
        _portfolio.DisplayPortfolio();
    }

    // Getters for protected fields
    public string GetName() => _name;
    public Portfolio GetPortfolio() => _portfolio;
    public string GetStrategy() => _strategy;
}