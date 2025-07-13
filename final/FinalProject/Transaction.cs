using System;

public enum TransactionType
{
    Buy,
    Sell
}

public class Transaction
{
    private string _ticker;
    private int _quantity;
    private double _price;
    private DateTime _timestamp;
    private TransactionType _type;

    public Transaction(string ticker, int quantity, double price, DateTime timestamp, TransactionType type)
    {
        _ticker = ticker;
        _quantity = quantity;
        _price = price;
        _timestamp = timestamp;
        _type = type;
    }

    // Default constructor for compatibility
    public Transaction()
    {
        _ticker = "";
        _quantity = 0;
        _price = 0.0;
        _timestamp = DateTime.Now;
        _type = TransactionType.Buy;
    }

    // Returns total transaction value
    public double GetTotalValue()
    {
        return _price * _quantity;
    }

    // Shows formatted transaction details
    public void DisplayTransaction()
    {
        string typeSymbol = _type == TransactionType.Buy ? "📈" : "📉";
        string action = _type == TransactionType.Buy ? "Bought" : "Sold";
        
        Console.WriteLine($"{typeSymbol} {action} {_quantity} shares of {_ticker} at ${_price:F2} each");
        Console.WriteLine($"   Total Value: ${GetTotalValue():F2}");
        Console.WriteLine($"   Time: {_timestamp:MM/dd/yyyy HH:mm:ss}");
    }

    // Simple transaction summary
    public void DisplaySummary()
    {
        string action = _type == TransactionType.Buy ? "BUY" : "SELL";
        Console.WriteLine($"{action} {_quantity} {_ticker} @ ${_price:F2}");
    }

    // Getters
    public string GetTicker() => _ticker;
    public int GetQuantity() => _quantity;
    public double GetPrice() => _price;
    public DateTime GetTimestamp() => _timestamp;
    public TransactionType GetTransactionType() => _type;
}