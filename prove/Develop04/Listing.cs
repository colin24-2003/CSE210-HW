public class Listing : Activity
{
    private Random _random = new Random();
    
    private List<string> _prompts = new List<string>
    {
        "--Who are people that you appreciate?--",
        "--What are personal strengths of yours?--",
        "--Who are people that you have helped this week?--",
        "--When have you felt the Holy Ghost this month?--",
        "--Who are some of your personal heroes?--"
    };
    private List<string> _responses = new List<string>
    {

    };

    public Listing(int duration, string description, string name)
    : base(duration, description, name)
    {
        
    }

    public void GetAndDisplayRandomPrompt()
    {
        Console.WriteLine("List as many responses as you can to the following prompt: ");
        int index = _random.Next(0, _prompts.Count);
        string prompt = _prompts[index];
        Console.WriteLine(prompt);

        Console.WriteLine("Enter your responses (press Enter on a blank line to finish):");

        List<string> responses = new List<string>();
        while (true)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(response))
            {
                break;
            }
            responses.Add(response);
        }

        if (responses.Count > 1)
        {
            Console.WriteLine($"\nYou listed {responses.Count} items!");
        }
        else if (responses.Count <= 1)
        {
            Console.WriteLine($"\nYou listed {responses.Count} item!");
        }

     
}

}