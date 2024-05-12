using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
static void Main()
{
    Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
    Console.Clear();
    scripture.DisplayScripture();
    
    while (true)
    {
        Console.WriteLine("Press enter to hide a word or type quit to exit:");
        string userInput = Console.ReadLine();
        
        if (userInput.ToLower() == "quit")
        {
            break;
        }
        else
        {
            Console.Clear();
            scripture.HideWord();
            scripture.DisplayScripture();
            
            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("Congratulations, you have memorized the scripture!");
                break;
            }
        }
    }
}

}
class Scripture
{
 private string reference;
 private string text;
 private List<string> hiddenWords;
 public Scripture(string reference, string text)
 {
 this.reference = reference;
 this.text = text;
 this.hiddenWords = new List<string>();
 }
  public void DisplayScripture()
 {
 Console.WriteLine(reference);
 string[] words = text.Split(' ');
 foreach (string word in words)
 {
 if (hiddenWords.Contains(word))
 {
 Console.Write("_____ ");
 }
 else
 {
 Console.Write(word + " ");
 }
 }
 Console.WriteLine();
 }
 public void HideWord()
 {
 string[] words = text.Split(' ');
 Random rand = new Random();
 int index = rand.Next(words.Length);
 string wordToHide = words[index];
 hiddenWords.Add(wordToHide);
 }
 public bool AllWordsHidden()
 {
 string[] words = text.Split(' ');
 return hiddenWords.Count == words.Length;
 }
}