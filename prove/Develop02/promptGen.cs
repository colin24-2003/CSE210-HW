using System; 
using System.Collections.Generic; 

namespace JournalApp // Grouping related classes under one name 
{

    public class PromptGenerator // This class will create and give random journal prompts
    {
        private List<string> _promptList; // A private list that holds all the journal prompts

        public PromptGenerator() // Constructor: runs automatically when we create a new PromptGenerator
        {
            _promptList = new List<string> // Initialize the list and fill it with prompts
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?", 
                "What was the strongest emotion I felt today?", 
                "If I had one thing I could do over today, what would it be?"
            };
        }

        public string GetRandomPrompt() // Method that returns a random prompt from the list
        {
            Random rand = new Random(); // Create a new random number generator
            return _promptList[rand.Next(_promptList.Count)]; // Pick a random index and return the prompt at that position
        }
    }
}
