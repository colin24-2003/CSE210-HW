using System;
using System.Collections.Generic;
using System.Linq;

public class Portfolio
{
    private double _cash;
    private Dictionary<string, int> _holdings;
    private List<Transaction> _transactions;

    public Portfolio(double startingCash)
    {
        _cash = startingCash;
        _holdings = new Dictionary<string, int>();
        _transactions = new List<Transaction>();
    }

    // Buy stock and add to holdings
    public bool BuyStock(Stock stock, int quantity)
    {
        double totalCost = stock.GetCurrentPrice() * quantity;
        
        if (_cash >= totalCost)
        {
            _cash -= totalCost;
            
            // Add to holdings
            if (_holdings.ContainsKey(stock.GetTicker()))
            {
                _holdings[stock.GetTicker()] += quantity;
            }
            else
            {
                _holdings[stock.GetTicker()] = quantity;
            }

            // Record transaction
            Transaction transaction = new Transaction(
                stock.GetTicker(), 
                quantity, 
                stock.GetCurrentPrice(), 
                DateTime.Now, 
                TransactionType.Buy
            );
            AddTransaction(transaction);
            
            return true;
        }
        
        return false;
    }

    // Sell stock and remove from holdings
    public bool SellStock(Stock stock, int quantity)
    {
        if (_holdings.ContainsKey(stock.GetTicker()) && _holdings[stock.GetTicker()] >= quantity)
        {
            double totalValue = stock.GetCurrentPrice() * quantity;
            _cash += totalValue;
            
            _holdings[stock.GetTicker()] -= quantity;
            
            // Remove from holdings if quantity becomes 0
            if (_holdings[stock.GetTicker()] == 0)
            {
                _holdings.Remove(stock.GetTicker());
            }

            // Record transaction
            Transaction transaction = new Transaction(
                stock.GetTicker(), 
                quantity, 
                stock.GetCurrentPrice(), 
                DateTime.Now, 
                TransactionType.Sell
            );
            AddTransaction(transaction);
            
            return true;
        }
        
        return false;
    }

    // Calculate total portfolio value including cash and stock holdings
    public double GetTotalValue(Market market)
    {
        double totalValue = _cash;
        
        foreach (var holding in _holdings)
        {
            Stock stock = market.GetStock(holding.Key);
            if (stock != null)
            {
                totalValue += stock.GetCurrentPrice() * holding.Value;
            }
        }
        
        return totalValue;
    }

    // Get number of shares owned for specific stock
    public int GetHolding(string ticker)
    {
        return _holdings.ContainsKey(ticker) ? _holdings[ticker] : 0;
    }

    // Add transaction to history
    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    // Display portfolio information
    public void DisplayPortfolio()
    {
        Console.WriteLine($"- Cash: ${_cash:F2}");
        
        if (_holdings.Count == 0)
        {
            Console.WriteLine("- Holdings: None");
        }
        else
        {
            Console.WriteLine("- Holdings:");
            foreach (var holding in _holdings)
            {
                Console.WriteLine($"  - {holding.Key}: {holding.Value} shares");
            }
        }
    }

    // Display detailed portfolio with current values
    public void DisplayPortfolioWithValues(Market market)
    {
        Console.WriteLine($"- Cash: ${_cash:F2}");
        
        if (_holdings.Count == 0)
        {
            Console.WriteLine("- Holdings: None");
        }
        else
        {
            Console.WriteLine("- Holdings:");
            foreach (var holding in _holdings)
            {
                Stock stock = market.GetStock(holding.Key);
                if (stock != null)
                {
                    double currentValue = stock.GetCurrentPrice() * holding.Value;
                    Console.WriteLine($"  - {holding.Key}: {holding.Value} shares @ ${stock.GetCurrentPrice():F2} → ${currentValue:F2}");
                }
            }
        }
    }

    // Getters
    public double GetCash() => _cash;
    public Dictionary<string, int> GetAllHoldings() => new Dictionary<string, int>(_holdings);
    public List<Transaction> GetTransactionHistory() => new List<Transaction>(_transactions);
}