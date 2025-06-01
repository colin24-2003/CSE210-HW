using System;
using System.Collections.Generic;
using System.IO;

public class Scripture
{
    private Reference _reference;
    private List<Verse> _verses;

   
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _verses = new List<Verse>();
        
       
        string[] verseParts = text.Split(new char[] { '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
        
        if (verseParts.Length > 1)
        {
            foreach (string versePart in verseParts)
            {
                string trimmedVerse = versePart.Trim();
                if (!string.IsNullOrEmpty(trimmedVerse))
                {
                    _verses.Add(new Verse(trimmedVerse));
                }
            }
        }
        else
        {
            // Treat as single verse
            _verses.Add(new Verse(text.Trim()));
        }
    }

       public Scripture(string referenceText, string text)
    {
        _reference = new Reference(referenceText);
        _verses = new List<Verse>();
        
        _verses.Add(new Verse(text.Trim()));
    }

       public Scripture(StreamReader reader)
    {
        string referenceText = reader.ReadLine()?.Trim();
        _reference = new Reference(referenceText ?? "Unknown");
        
        _verses = new List<Verse>();
        
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string trimmedLine = line.Trim();
            if (!string.IsNullOrEmpty(trimmedLine))
            {
                _verses.Add(new Verse(trimmedLine));
            }
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";
        
        foreach (Verse verse in _verses)
        {
            result += verse.GetDisplayText();
            if (_verses.IndexOf(verse) < _verses.Count - 1)
            {
                result += " ";
            }
        }
        
        return result;
    }

    public void HideRandomWords(int count = 1)
    {
        Random random = new Random();
        
        for (int i = 0; i < count; i++)
        {
         
            List<Verse> versesWithVisibleWords = new List<Verse>();
            foreach (Verse verse in _verses)
            {
                if (!verse.IsCompletelyHidden())
                {
                    versesWithVisibleWords.Add(verse);
                }
            }

            
            if (versesWithVisibleWords.Count > 0)
            {
                int randomVerseIndex = random.Next(versesWithVisibleWords.Count);
                versesWithVisibleWords[randomVerseIndex].HideRandomWord();
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Verse verse in _verses)
        {
            if (!verse.IsCompletelyHidden())
            {
                return false;
            }
        }
        return true;
    }

    public Reference GetReference()
    {
        return _reference;
    }
}