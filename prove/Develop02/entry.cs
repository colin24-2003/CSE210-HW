namespace JournalApp
{
    public class JournalEntry
    {
        private string _date; // stores the date of the entry
        private string _prompt; // stores the prompt of the entry
        private string _response; // stores the user's response

        public JournalEntry(string date, string prompt, string response)
        {
            _date = date; // initializes the date of the journal entry
            _prompt = prompt; // initializes the prompt of the journal entry
            _response = response; // initializes the response to the journal entry
        }

        public string FormatEntry()
        {
            return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\n"; // formats the journal entry for display
        }

        public string ToFileLine()
        {
            return $"{_date}|{_prompt}|{_response}"; // converts the entry to a string to save to a file
        }

        public static JournalEntry FromFileLine(string line)
        {
            string[] parts = line.Split("|"); // splits the line into parts based on the separator
            if (parts.Length == 3)
            {
                return new JournalEntry(parts[0], parts[1], parts[2]); // creates a new journal entry from the parts
            }
            return null; // returns null if the line is invalid
        }
    }
}