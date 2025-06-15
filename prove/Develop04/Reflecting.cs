using System.Collections.Generic;
public class Reflecting : Activity
{
    private Random _random = new Random(); 
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "> Think of a time when you stood up for someone else.",
        "> Think of a time when you did something really difficult.",
        "> Think of a time when you helped someone in need.",
        "> Think of a time when you did something truly selfless.",
        "> Why was this experience meaningful to you?",
        "> Have you ever done anything like this before?",
        "> How did you get started?",
        "> How did you feel when it was complete?",
        "> What made this time different than other times when you were not as successful?",
        "> What is your favorite thing about this experience?",
        "> What could you learn from this experience that applies to other situations?",
        "> What did you learn about yourself through this experience?",
        "> How can you keep this experience in mind in the future?"
    };


    public Reflecting(int duration, string description, string name)
    : base(duration, description, name)
    {
        

    }

    public void GetRandomPrompt()
    {
        int index = _random.Next(0, _prompts.Count);
        string item = _prompts[index];
        Console.WriteLine(item); ;
    }

     public void GetRandomQuestion()
    {
        if (_questions.Count == 0)
        {
            Console.WriteLine("No questions available.");
            return;
        }
        int index = _random.Next(0, _questions.Count);
        string item = _questions[index]; 
        Console.WriteLine(item);
    }






}