using System;
using System.Collections.Generic;

public class Game
{
    private Market market;
    private List<Investor> investors;
    private NewsGenerator newsGen;
    private int currentDay;

    public Game()
    {
        market = new Market();
        investors = new List<Investor>();
        newsGen = new NewsGenerator();
        currentDay = 0;
    }

    public void StartGame(string playerName)
    {
        // Create investors
        Player player = new Player(playerName, 10000);
        AIInvestor warren = new AIInvestor("WarrenBot", 10000, "Conservative");
        AIInvestor risky = new AIInvestor("RiskyRandy", 10000, "Aggressive");
        
        investors.Add(player);
        investors.Add(warren);
        investors.Add(risky);

        ShowWelcomeMessage(player);

        // Game loop
        while (currentDay < 10) // Run for 10 days
        {
            currentDay++;
            PlayDay();
            
            // Check if player ended the game early
            Player playerInvestor = (Player)investors.Find(inv => inv is Player);
            if (playerInvestor.GameEnded)
            {
                break;
            }
        }

        ShowFinalResults();
    }

    private void ShowWelcomeMessage(Player player)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Welcome to the Stock Market Simulator!");
        Console.WriteLine($"Player: {player.Name} | Starting Cash: ${player.Portfolio.Cash:F0}");
        Console.WriteLine("AI Investors: WarrenBot, RiskyRandy");
        Console.WriteLine("----------------------------------------");
    }

    private void PlayDay()
    {
        Console.WriteLine($"\nDay {currentDay}:");
        
        // Generate news and update market
        News todayNews = newsGen.GenerateNews();
        todayNews.Display();
        
        market.UpdatePrices(todayNews);
        market.ShowPriceChanges();

        // Each investor takes their turn
        foreach (var investor in investors)
        {
            if (investor is Player p)
            {
                p.TakeTurn(market);
                if (p.GameEnded)
                {
                    return; // Exit early if player chose to end game
                }
            }
            else if (investor is AIInvestor ai)
            {
                ai.TakeTurn(market);
            }
        }

        ShowDayResults();
    }

    private void ShowDayResults()
    {
        Console.WriteLine($"\n--- End of Day {currentDay} Summary ---");
        foreach (var investor in investors)
        {
            double value = investor.Portfolio.GetTotalValue(market);
            Console.WriteLine($"{investor.Name}: Portfolio Value = ${value:F2}");
        }
        Console.WriteLine("----------------------------------------");
    }

    private void ShowFinalResults()
    {
        Console.WriteLine("\n🏆 FINAL RESULTS 🏆");
        // Sort by portfolio value
        investors.Sort((a, b) => b.Portfolio.GetTotalValue(market).CompareTo(a.Portfolio.GetTotalValue(market)));
        
        for (int i = 0; i < investors.Count; i++)
        {
            var investor = investors[i];
            double value = investor.Portfolio.GetTotalValue(market);
            string medal = i == 0 ? "🥇" : i == 1 ? "🥈" : "🥉";
            Console.WriteLine($"{medal} {i + 1}. {investor.Name}: ${value:F2}");
        }
    }
}