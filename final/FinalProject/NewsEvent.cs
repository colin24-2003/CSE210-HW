using System.Collections.Generic;
using System;

public class News
{
    public string Headline { get; private set; }
    public double Impact { get; private set; } // Percentage change
    public List<string> AffectedSectors { get; private set; }

    public News(string headline, double impact, List<string> sectors = null)
    {
        Headline = headline;
        Impact = impact;
        AffectedSectors = sectors ?? new List<string>();
    }

    public bool AffectsStock(Stock stock)
    {
        // If no specific sectors, affects all stocks
        if (AffectedSectors.Count == 0) return true;
        
        // Check if stock's sector is affected
        return AffectedSectors.Contains(stock.Sector);
    }

    public void Display()
    {
        string icon = Impact > 0 ? "🚀" : Impact < 0 ? "📉" : "📊";
        Console.WriteLine($"[News] {icon} {Headline}");
        
        if (AffectedSectors.Count > 0)
        {
            string sectors = string.Join(", ", AffectedSectors);
            Console.WriteLine($"- Impact: {Impact:+0;-0}% on {sectors} stocks");
        }
        else
        {
            Console.WriteLine($"- Impact: {Impact:+0;-0}% on all stocks");
        }
    }
}