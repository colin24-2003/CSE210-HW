using System;
using System.Collections.Generic;

public class NewsGenerator
{
    private List<News> possibleNews;
    private Random random;

    public NewsGenerator()
    {
        random = new Random();
        CreateNewsList();
    }

    private void CreateNewsList()
    {
        possibleNews = new List<News>
        {
            new News("Global Tech Demand Surges!", 120, new List<string> { "Tech" }),
            new News("Market Crash Rumor Spooks Investors!", -50),
            new News("AI Sector Growth Promising!", 80, new List<string> { "Tech" }),
            new News("Auto Industry Faces Supply Issues", -60, new List<string> { "Auto" }),
            new News("Interest Rates Cut by Fed", 30),
            new News("Retail Sales Jump Unexpectedly", 40, new List<string> { "Retail" }),
            new News("Tech Companies Report Strong Earnings", 7, new List<string> { "Tech" }),
            new News("Economic Uncertainty Grows", -50),
            new News("Dallens portfolio sky rockets ", 100, new List<string> {"Tech"}),
        };
    }

    public News GenerateNews()
    {
        int index = random.Next(possibleNews.Count);
        return possibleNews[index];
    }
}