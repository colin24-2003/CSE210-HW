using System;
using System.Collections.Generic;
using System.Linq;

public class Market
{
    private List<Stock> stocks;
    private Random random;

    public Market()
    {
        stocks = new List<Stock>();
        random = new Random();
        InitializeStocks();
    }

    private void InitializeStocks()
    {
        stocks.Add(new Stock("AAPL", "Apple Inc.", 150.00, "Tech"));
        stocks.Add(new Stock("TSLA", "Tesla Inc.", 720.00, "Auto"));
        stocks.Add(new Stock("GME", "GameStop", 18.00, "Retail"));
        stocks.Add(new Stock("AMZN", "Amazon", 3200.00, "Tech"));
    }

    public Stock GetStock(string ticker)
    {
        return stocks.FirstOrDefault(s => s.Ticker.Equals(ticker, StringComparison.OrdinalIgnoreCase));
    }

    public List<Stock> GetAllStocks()
    {
        return new List<Stock>(stocks);
    }

    public void UpdatePrices(News news)
    {
        foreach (var stock in stocks)
        {
            // Apply news effect if it affects this stock
            if (news.AffectsStock(stock))
            {
                stock.ApplyNewsEffect(news.Impact);
            }
            else
            {
                // Random small price change (-2% to +2%)
                double randomChange = (random.NextDouble() - 0.5) * 4;
                stock.ApplyNewsEffect(randomChange);
            }
        }
    }

    public void ShowAllStocks()
    {
        foreach (var stock in stocks)
        {
            Console.WriteLine($"- {stock.Ticker}: ${stock.Price:F2}");
        }
    }

    public void ShowPriceChanges()
    {
        Console.WriteLine("\nMarket Update:");
        foreach (var stock in stocks)
        {
            stock.ShowPriceChange();
        }
    }
}