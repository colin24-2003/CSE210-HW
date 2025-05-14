using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {
        private List<JournalEntry> _entries = new List<JournalEntry>(); // stores the list of journal entries

        public void AddEntry(JournalEntry entry)
        {
            _entries.Add(entry); // adds a new entry to the journal
        }

        public void DisplayEntries()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries to display."); // message when there are no entries
                return;
            }

            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.FormatEntry()); // displays each journal entry
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename)) // opens file for writing
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.ToFileLine()); // writes each journal entry to the file
                }
            }
            Console.WriteLine($"Journal saved to {filename}"); // confirms that the journal has been saved
        }

        public int GetEntryCount()
        {
        return _entries.Count; // returns the number of journal entries
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found."); // message if the file doesn't exist
                return;
            }

            _entries.Clear(); // clears current entries before loading new ones
            string[] lines = File.ReadAllLines(filename); // reads all lines from the file

            foreach (string line in lines)
            {
                JournalEntry entry = JournalEntry.FromFileLine(line); // creates a journal entry from each line
                if (entry != null)
                {
                    _entries.Add(entry); // adds valid entries to the list
                }
            }

            Console.WriteLine($"Journal loaded from {filename}"); // confirms that the journal has been loaded
        }
    }
}