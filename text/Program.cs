using System;
using System.Collections.Generic;
using System.IO;

namespace Words5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFile = @"D:\Skole\Programering\words.txt";
            string outputFile = @"D:\Skole\Programering\Wordle.txt";

            List<string> lines = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(inputFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                Console.WriteLine("File read successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return;
            }

            List<string> worldeWords = new List<string>();
            foreach (string word in lines)
            {
                string badChars = "!#1234567890æøå¤%&/()=?-*.,`´'<>";
                if (word.Length == 5 && !ContainsAny(word, badChars))
                {
                    worldeWords.Add(word);
                }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(outputFile))
                {
                    foreach (string word in worldeWords)
                    {
                        string LoverWord = word.ToLower();
                        sw.WriteLine(LoverWord);
                    }
                }
                Console.WriteLine("Filtered words saved to file successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        static bool ContainsAny(string word, string chars)
        {
            foreach (char c in chars)
            {
                if (word.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}