public class Activity
{
    private int _duration;

    private string _description;
    private string _name;

    public Activity(int duration, string description, string name)
    {
        _duration = duration;
        _description = description;
        _name = name;
    }


    public static void SpinnerAnimation(int cycles, int delay = 300) // sets the default parameters to loop 3 times for .30 seconds each time
    {

        char[] spinner = { '|', '/', '-', '\\' }; // creates a list of chars to loop through

        for (int i = 0; i < cycles * spinner.Length; i++) // loops through total spinner steps (cycles × spinner chars)
        {
            Console.Write(spinner[i % spinner.Length]);    // prints current spinner char 
            Thread.Sleep(delay);
            Console.Write("\b \b");
        }

    }


    public static void CountDown(int delay)
    {
        for (int i = 5; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(delay);
            Console.Write("\b \b");
        }
        Console.WriteLine("");

    
    }

}