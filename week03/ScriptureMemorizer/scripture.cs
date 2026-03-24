using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
  private Reference _reference;
  private List<Word> _words;
  private Random _random;

  public Scripture(Reference reference, string text)
  {
    _reference = reference;
    _words = new List<Word>();
    _random = new Random();

    // Split text into words and create Word objects
    string[] wordArray = text.Split(' ');
    foreach (string word in wordArray)
    {
      // Clean up punctuation for display purposes
      _words.Add(new Word(word));
    }
  }

  public string GetDisplayText()
  {
    string scriptureText = "";
    foreach (Word word in _words)
    {
      scriptureText += word.GetDisplayText() + " ";
    }
    return $"{_reference.GetDisplayText()}\n\n{scriptureText.Trim()}";
  }

  public void HideRandomWords(int count)
  {
    // Stretch: only hide words that aren't already hidden
    List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

    int wordsToHide = Math.Min(count, visibleWords.Count);

    for (int i = 0; i < wordsToHide; i++)
    {
      int index = _random.Next(visibleWords.Count);
      visibleWords[index].Hide();
      visibleWords.RemoveAt(index);
    }
  }

  public bool AllWordsHidden()
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
}