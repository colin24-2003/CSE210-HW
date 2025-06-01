using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private string _verse;

    
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse.ToString();
    }

   
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = $"{startVerse}-{endVerse}";
    }

    
    public Reference(string referenceText)
    {
        string[] parts = referenceText.Split(' ');
        
        if (parts.Length >= 2)
        {
            
            if (char.IsDigit(parts[0][0]) && parts.Length >= 3)
            {
                _book = $"{parts[0]} {parts[1]}";
                string[] chapterVerse = parts[2].Split(':');
                _chapter = int.Parse(chapterVerse[0]);
                _verse = chapterVerse[1];
            }
            else
            {
                _book = parts[0];
                string[] chapterVerse = parts[1].Split(':');
                _chapter = int.Parse(chapterVerse[0]);
                _verse = chapterVerse[1];
            }
        }
        else
        {
            _book = "Unknown";
            _chapter = 0;
            _verse = "0";
        }
    }

    public string GetDisplayText()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
}