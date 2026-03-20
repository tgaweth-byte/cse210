using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
  private List<Entry> _entries;

  public Journal()
  {
    _entries = new List<Entry>();
  }

  public void AddEntry(Entry entry)
  {
    _entries.Add(entry);
  }

  public void DisplayAll()
  {
    if (_entries.Count == 0)
    {
      Console.WriteLine("\nNo entries found. Write your first entry!");
      return;
    }

    Console.WriteLine("\n=== Journal Entries ===\n");
    foreach (Entry entry in _entries)
    {
      entry.Display();
      Console.WriteLine(); // Blank line between entries
    }
  }

  public void SaveToFile(string filename)
  {
    using (StreamWriter writer = new StreamWriter(filename))
    {
      foreach (Entry entry in _entries)
      {
        // Format: date~|~prompt~|~response
        writer.WriteLine($"{entry._date}~|~{entry._prompt}~|~{entry._response}");
      }
    }
    Console.WriteLine($"Journal saved to {filename}");
  }

  public void LoadFromFile(string filename)
  {
    if (!File.Exists(filename))
    {
      Console.WriteLine($"File {filename} not found.");
      return;
    }

    _entries.Clear();
    string[] lines = File.ReadAllLines(filename);

    foreach (string line in lines)
    {
      string[] parts = line.Split("~|~");
      if (parts.Length == 3)
      {
        string date = parts[0];
        string prompt = parts[1];
        string response = parts[2];

        Entry entry = new Entry(prompt, response);
        entry._date = date; // Override date with stored date
        _entries.Add(entry);
      }
    }
    Console.WriteLine($"Loaded {_entries.Count} entries from {filename}");
  }
}