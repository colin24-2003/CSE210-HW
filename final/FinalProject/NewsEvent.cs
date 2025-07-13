using System;
using System.Collections.Generic;
using System.Linq;

public class NewsEvent
{
    private string _headline;
    private double _impact;
    private List<string> _affectedSectors;
    private string _eventType;

    public NewsEvent(string headline, double impact, List<string> affectedSectors, string eventType)
    {
        _headline = headline;
        _impact = impact;
        _affectedSectors = affectedSectors ?? new List<string>();
        _eventType = eventType;
    }

    // Default constructor
    public NewsEvent()
    {
        _headline = "No news today";
        _impact = 0.0;
        _affectedSectors = new List<string>();
        _eventType = "General";
    }

    // Returns the price impact percentage
    public double GetImpact()
    {
        return _impact;
    }

    // Determines if news affects a specific stock
    public bool AffectsStock(Stock stock)
    {
        if (_affectedSectors.Count == 0) return true; // Affects all stocks
        
        return _affectedSectors.Any(sector => stock.IsInSector(sector));
    }

    // Shows formatted news with impact indicator
    public void DisplayNews()
    {
        string impactIcon = _impact > 0 ? "🚀" : _impact < 0 ? "📉" : "📊";
        string impactText = _impact > 0 ? "+" : "";
        
        Console.WriteLine($"[News] {impactIcon} {_headline}");
        
        if (_affectedSectors.Count > 0)
        {
            string sectors = string.Join(", ", _affectedSectors);
            Console.WriteLine($"- Impact: {impactText}{_impact:F1}% on {sectors} Stocks");
        }
        else
        {
            Console.WriteLine($"- Impact: {impactText}{_impact:F1}% on all stocks");
        }
    }

    // Create some sample news events
    public static List<NewsEvent> GetSampleNewsEvents()
    {
        return new List<NewsEvent>
        {
            new NewsEvent("Global Tech Demand Surges!", 5.0, new List<string> { "Tech" }, "Economic"),
            new NewsEvent("Market Crash Rumor Spooks Investors!", -10.0, new List<string>(), "Economic"),
            new NewsEvent("AI Sector Growth Promising!", 8.0, new List<string> { "Tech" }, "Technology"),
            new NewsEvent("Auto Industry Faces Supply Chain Issues", -6.0, new List<string> { "Auto" }, "Industry"),
            new NewsEvent("Federal Reserve Announces Interest Rate Cut", 3.0, new List<string>(), "Economic"),
            new NewsEvent("Oil Prices Surge Amid Global Tensions", 4.0, new List<string> { "Energy" }, "Commodity"),
            new NewsEvent("New Trade Agreement Boosts Manufacturing", 7.0, new List<string> { "Manufacturing" }, "Political"),
            new NewsEvent("Cybersecurity Breach Affects Major Banks", -8.0, new List<string> { "Finance" }, "Security"),
            new NewsEvent("Green Energy Initiative Announced", 6.0, new List<string> { "Energy" }, "Environmental"),
            new NewsEvent("Consumer Confidence Drops Unexpectedly", -4.0, new List<string> { "Retail" }, "Economic")
        };
    }

    // Getters
    public string GetHeadline() => _headline;
    public List<string> GetAffectedSectors() => new List<string>(_affectedSectors);
    public string GetEventType() => _eventType;
}