using System;
using System.Linq;

public class AIInvestor : Investor
{
    private string strategy;
    private Random random;

    public AIInvestor(string name, double startingCash, string strategy) : base(name, startingCash)
    {
        this.strategy = strategy;
        this.random = new Random();
    }

    public override void TakeTurn(Market market)
    {
        // AI decides randomly whether to trade
        if (random.NextDouble() < 0.5) // 50% chance to trade
        {
            if (random.NextDouble() < 0.7) // 70% chance to buy, 30% to sell
            {
                TryToBuy(market);
            }
            else
            {
                TryToSell(market);
            }
        }
        else
        {
            Console.WriteLine($"[AI Action] {Name} held position");
        }
    }

    private void TryToBuy(Market market)
    {
        var stocks = market.GetAllStocks();
        if (stocks.Count == 0) return;

        Stock stockToBuy = ChooseStock(stocks);
        double maxSpend = Portfolio.Cash * (strategy == "Conservative" ? 0.2 : 0.4);
        int quantity = (int)(maxSpend / stockToBuy.Price);

        if (quantity > 0 && Portfolio.BuyStock(stockToBuy, quantity))
        {
            Console.WriteLine($"[AI Action] {Name} bought {quantity} shares of {stockToBuy.Ticker}");
        }
        else
        {
            Console.WriteLine($"[AI Action] {Name} held position");
        }
    }

    private void TryToSell(Market market)
    {
        if (Portfolio.Holdings.Count == 0)
        {
            Console.WriteLine($"[AI Action] {Name} held position");
            return;
        }

        var randomStock = Portfolio.Holdings.Keys.ElementAt(random.Next(Portfolio.Holdings.Count));
        int owned = Portfolio.Holdings[randomStock];
        int toSell = Math.Max(1, owned / 2); // Sell half

        Stock stock = market.GetStock(randomStock);
        if (Portfolio.SellStock(stock, toSell))
        {
            Console.WriteLine($"[AI Action] {Name} sold {toSell} shares of {randomStock}");
        }
    }

    private Stock ChooseStock(System.Collections.Generic.List<Stock> stocks)
    {
        if (strategy == "Conservative")
        {
            // Choose cheaper, stable stocks
            return stocks.OrderBy(s => s.Price).First();
        }
        else
        {
            // Choose more expensive, volatile stocks  
            return stocks.OrderByDescending(s => s.Price).First();
        }
    }
}