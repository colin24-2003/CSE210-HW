using System;
using System.Collections.Generic;
using System.Linq;

public class Verse
{
    private List<Word> _words;

    public Verse(string text)
    {
        _words = new List<Word>();
        
        
        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        foreach (string wordText in wordArray)
        {
            Word word = new Word(wordText);
            _words.Add(word);
        }
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        
        return string.Join(" ", displayWords);
    }

    public void HideRandomWord()
    {
        // Get all visible words
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        
        if (visibleWords.Count > 0)
        {
            Random random = new Random();
            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public int GetVisibleWordCount()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                count++;
            }
        }
        return count;
    }
}