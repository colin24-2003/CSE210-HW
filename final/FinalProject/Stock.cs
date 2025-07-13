using System;

public class Stock
{
    private string _ticker;
    private string _name;
    private double _currentPrice;
    private double _previousPrice;
    private string _sector;

    public Stock(string ticker, string name, double startingPrice, string sector)
    {
        _ticker = ticker;
        _name = name;
        _currentPrice = startingPrice;
        _previousPrice = startingPrice;
        _sector = sector;
    }

    // Update price and store previous price
    public void UpdatePrice(double newPrice)
    {
        _previousPrice = _currentPrice;
        _currentPrice = newPrice;
    }

    // Get absolute price change
    public double GetPriceChange()
    {
        return _currentPrice - _previousPrice;
    }

    // Get percentage price change
    public double GetPriceChangePercent()
    {
        if (_previousPrice == 0) return 0;
        return ((_currentPrice - _previousPrice) / _previousPrice) * 100;
    }

    // Apply news impact to stock price
    public void ApplyNewsImpact(double impactPercent)
    {
        _previousPrice = _currentPrice;
        _currentPrice *= (1 + impactPercent / 100);
        
        // Ensure price doesn't go negative
        if (_currentPrice < 0.01)
        {
            _currentPrice = 0.01;
        }
    }

    // Display stock information with price change
    public void DisplayStock()
    {
        string changeSymbol = GetPriceChange() >= 0 ? "↑" : "↓";
        ConsoleColor color = GetPriceChange() >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
        
        Console.Write($"- {_ticker}: ");
        Console.ForegroundColor = color;
        Console.WriteLine($"${_currentPrice:F2} {changeSymbol} ({GetPriceChangePercent():+0.00;-0.00}%)");
        Console.ResetColor();
    }

    // Display stock with price transition (for market updates)
    public void DisplayPriceTransition()
    {
        Console.WriteLine($"- {_ticker}: ${_previousPrice:F2} → ${_currentPrice:F2}");
    }

    // Check if this stock belongs to a specific sector
    public bool IsInSector(string sector)
    {
        return _sector.Equals(sector, StringComparison.OrdinalIgnoreCase);
    }

    // Getters
    public string GetTicker() => _ticker;
    public string GetName() => _name;
    public double GetCurrentPrice() => _currentPrice;
    public double GetPreviousPrice() => _previousPrice;
    public string GetSector() => _sector;
}