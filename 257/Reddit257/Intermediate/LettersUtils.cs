using System;
using System.Linq;

namespace Reddit257.Intermediate
{
    public class LettersUtils : ILettersUtils
    {
        public bool CanBeFormed(string word, string lettersRemaining)
        {
            var canBeFormed = lettersRemaining.Contains(word.Substring(0,1));

            if (!canBeFormed) return false;

            lettersRemaining = lettersRemaining.Remove(lettersRemaining.IndexOf(word.Substring(0, 1), StringComparison.Ordinal), 1);

            if (word.Length == 1)
            {
                return true;
            }

            foreach (var letter in word.Substring(1))
            {
                if (lettersRemaining.Count(l => l == letter) < 2)
                {
                    return false;
                }

                lettersRemaining = lettersRemaining.Remove(lettersRemaining.IndexOf(letter), 1);
                lettersRemaining = lettersRemaining.Remove(lettersRemaining.IndexOf(letter), 1);
            }

            return true;
        }

        public string Remove(string word, string letters)
        {
            letters = letters.Remove(letters.IndexOf(word.Substring(0, 1), StringComparison.Ordinal), 1);
            if (word.Length == 1) return letters;

            foreach (var letter in word.Substring(1))
            {
                letters = letters.Remove(letters.IndexOf(letter), 1);
                letters = letters.Remove(letters.IndexOf(letter), 1);
            }
            return letters;
        }
    }
}