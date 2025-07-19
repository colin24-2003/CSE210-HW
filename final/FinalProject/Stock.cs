using System;

public class Stock
{
    public string Ticker { get; private set; }
    public string Name { get; private set; }
    public double Price { get; private set; }
    public double PreviousPrice { get; private set; }
    public string Sector { get; private set; }

    public Stock(string ticker, string name, double price, string sector)
    {
        Ticker = ticker;
        Name = name;
        Price = price;
        PreviousPrice = price;
        Sector = sector;
    }

    public void UpdatePrice(double newPrice)
    {
        PreviousPrice = Price;
        Price = Math.Max(0.01, newPrice); // Don't let price go below 1 cent
    }

    public void ApplyNewsEffect(double percentChange)
    {
        PreviousPrice = Price;
        Price *= (1 + percentChange / 100);
        Price = Math.Max(0.01, Price);
    }

    public void ShowPriceChange()
    {
        Console.WriteLine($"- {Ticker}: ${PreviousPrice:F2} → ${Price:F2}");
    }
}