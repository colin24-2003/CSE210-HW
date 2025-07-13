using System;
using System.Collections.Generic;
using System.Linq;

public class AIInvestor : Investor
{
    private double _riskTolerance; // 0.0 to 1.0
    private double _tradingFrequency; // 0.0 to 1.0
    private Random _random;

    public AIInvestor(string name, double startingCash, string strategy, double riskTolerance, double tradingFrequency)
        : base(name, new Portfolio(startingCash), strategy)
    {
        _riskTolerance = riskTolerance;
        _tradingFrequency = tradingFrequency;
        _random = new Random();
    }

    // Implementation of abstract method from Investor
    public override void MakeDecision(Market market)
    {
        // Check if AI should trade this turn based on frequency
        if (_random.NextDouble() > _tradingFrequency)
        {
            Console.WriteLine($"[AI Action] {_name} held position");
            return;
        }

        AnalyzeMarket(market);

        // Decide whether to buy or sell based on strategy
        if (_random.NextDouble() < 0.6) // 60% chance to buy
        {
            AttemptBuy(market);
        }
        else
        {
            AttemptSell(market);
        }
    }

    // Analyze market conditions
    private void AnalyzeMarket(Market market)
    {
        // Simple analysis - could be expanded with more sophisticated logic
        var stocks = market.GetAllStocks();
        // AI uses this to inform decisions (implementation can be expanded)
    }

    // Attempt to buy a stock
    private void AttemptBuy(Market market)
    {
        Stock selectedStock = SelectStock(market.GetAllStocks());
        if (selectedStock != null)
        {
            // Calculate quantity based on risk tolerance
            double maxInvestment = _portfolio.GetCash() * _riskTolerance;
            int quantity = (int)(maxInvestment / selectedStock.GetCurrentPrice());

            if (quantity > 0 && CanAfford(selectedStock, quantity))
            {
                if (_portfolio.BuyStock(selectedStock, quantity))
                {
                    Console.WriteLine($"[AI Action] {_name} bought {quantity} shares of {selectedStock.GetTicker()}");
                }
            }
            else
            {
                Console.WriteLine($"[AI Action] {_name} held position");
            }
        }
    }

    // Attempt to sell a stock
    private void AttemptSell(Market market)
    {
        var holdings = _portfolio.GetAllHoldings();
        if (holdings.Count > 0)
        {
            var randomHolding = holdings.ElementAt(_random.Next(holdings.Count));
            string ticker = randomHolding.Key;
            int owned = randomHolding.Value;

            // Sell a portion based on risk tolerance
            int quantityToSell = Math.Max(1, (int)(owned * (1 - _riskTolerance)));

            Stock stock = market.GetStock(ticker);
            if (stock != null && _portfolio.SellStock(stock, quantityToSell))
            {
                Console.WriteLine($"[AI Action] {_name} sold {quantityToSell} shares of {ticker}");
            }
        }
        else
        {
            Console.WriteLine($"[AI Action] {_name} held position");
        }
    }

    // Select stock based on AI strategy
    private Stock SelectStock(List<Stock> stocks)
    {
        if (stocks.Count == 0) return null;

        // Conservative investors prefer stable stocks
        if (_riskTolerance < 0.5)
        {
            return stocks.Where(s => s.GetCurrentPrice() > 100).OrderBy(s => s.GetPriceChangePercent()).FirstOrDefault() ?? stocks[0];
        }
        // Aggressive investors prefer volatile stocks
        else
        {
            return stocks.OrderByDescending(s => Math.Abs(s.GetPriceChangePercent())).FirstOrDefault();
        }
    }

    // Getters
    public double GetRiskTolerance() => _riskTolerance;
    public double GetTradingFrequency() => _tradingFrequency;
}