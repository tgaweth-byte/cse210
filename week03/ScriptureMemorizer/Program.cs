using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture
        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life.";
        Scripture scripture = new Scripture(reference, text);

        bool quit = false;

        while (!quit && !scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                quit = true;
            }
            else
            {
                scripture.HideRandomWords(3);
            }
        }

        if (scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden! Great job memorizing!");
        }
    }
}