public abstract class Investor
{
    public string Name { get; protected set; }
    public Portfolio Portfolio { get; protected set; }

    public Investor(string name, double startingCash)
    {
        Name = name;
        Portfolio = new Portfolio(startingCash);
    }

    public abstract void TakeTurn(Market market);
}