using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        string scriptureText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        
        Scripture scripture = new Scripture(reference, scriptureText);
        
        RunScriptureMemorizer(scripture);
    }

    private static void RunScriptureMemorizer(Scripture scripture)
    {
        while (true)
        {
           
            Console.Clear();
            
            
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            
            
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You have memorized the scripture!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                break;
            }
            
            
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit:");
            string userInput = Console.ReadLine();
            
            
            if (userInput?.ToLower() == "quit")
            {
                Console.WriteLine("Thank you for using the Scripture Memorizer!");
                break;
            }
            
            
            Random random = new Random();
            int wordsToHide = random.Next(1, 4); 
            scripture.HideRandomWords(wordsToHide);
        }
    }

 
    private static Scripture LoadScriptureFromFile(string filename)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                return new Scripture(reader);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{filename}' not found. Using default scripture.");
            return new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}. Using default scripture.");
            return new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        }
    }
}