public class Breathing : Activity
{
    public Breathing(int duration, string description, string name)
        : base(duration, description, name)
    {

    }

    public void BreatheIn(int delay = 1000)
    {

        char[] countingDown = { '3', '2', '1' };

        foreach (char number in countingDown)
        {
            Console.Write("\rBreathe in..." + number);
            Thread.Sleep(delay);
            Console.Write("\b \b");
        }
        Console.WriteLine("");

    }
    public void BreatheOut(int delay = 1000)
    {

        char[] countingDown = { '3', '2', '1' };

        foreach (char number in countingDown)
        {
            Console.Write("\rNow breathe out..." + number);
            Thread.Sleep(delay);
            Console.Write("\b \b");
        }
        Console.WriteLine("");


    }
    public void RunBreathingExercise(int duration, int delay = 1000)
    {


        int secondsPerCycle = 6;
        int cycles = duration / secondsPerCycle;
        for (int i = 0; i < cycles; i++)
        {
            BreatheIn(1000);
            BreatheOut(1000);
            Console.WriteLine();

        }
    }

   
}