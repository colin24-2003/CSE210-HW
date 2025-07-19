using System;
using System.Collections.Generic;

public class Portfolio
{
    public double Cash { get; private set; }
    public Dictionary<string, int> Holdings { get; private set; }

    public Portfolio(double startingCash)
    {
        Cash = startingCash;
        Holdings = new Dictionary<string, int>();
    }

    public bool BuyStock(Stock stock, int quantity)
    {
        double cost = stock.Price * quantity;
        if (Cash >= cost)
        {
            Cash -= cost;
            
            if (Holdings.ContainsKey(stock.Ticker))
                Holdings[stock.Ticker] += quantity;
            else
                Holdings[stock.Ticker] = quantity;
            
            return true;
        }
        return false;
    }

    public bool SellStock(Stock stock, int quantity)
    {
        if (Holdings.ContainsKey(stock.Ticker) && Holdings[stock.Ticker] >= quantity)
        {
            Cash += stock.Price * quantity;
            Holdings[stock.Ticker] -= quantity;
            
            if (Holdings[stock.Ticker] == 0)
                Holdings.Remove(stock.Ticker);
            
            return true;
        }
        return false;
    }

    public double GetTotalValue(Market market)
    {
        double total = Cash;
        
        foreach (var holding in Holdings)
        {
            Stock stock = market.GetStock(holding.Key);
            if (stock != null)
                total += stock.Price * holding.Value;
        }
        
        return total;
    }

    public void Display(Market market)
    {
        Console.WriteLine($"- Cash: ${Cash:F2}");
        
        if (Holdings.Count == 0)
        {
            Console.WriteLine("- Holdings: None");
        }
        else
        {
            Console.WriteLine("- Holdings:");
            ShowHoldings(market);
        }
    }

    public void ShowHoldings(Market market)
    {
        foreach (var holding in Holdings)
        {
            Stock stock = market.GetStock(holding.Key);
            double value = stock.Price * holding.Value;
            Console.WriteLine($"  - {holding.Key}: {holding.Value} shares @ ${stock.Price:F2} → ${value:F2}");
        }
    }
}