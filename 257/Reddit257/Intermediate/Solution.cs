using System.Collections.Generic;
using System.Linq;

namespace Reddit257.Intermediate
{
    public class Solution
    {
        private readonly ILettersUtils _lettersUtils;
        private readonly IWordGrabber _wordGrabber;

        public Solution(IWordGrabber wordGrabber, ILettersUtils lettersUtils)
        {
            _wordGrabber = wordGrabber;
            _lettersUtils = lettersUtils;
        }

        public IEnumerable<string> Solve(int length, string letters)
        {
            var wordSquare = new WordSquare();

            var starts = letters.Distinct();

            foreach (var letter in starts)
            {
                var firstWords = _wordGrabber.Grab(letter.ToString(), length);
                firstWords = firstWords.Where(w => _lettersUtils.CanBeFormed(w, letters));

                foreach (var firstWord in firstWords)
                {
                    wordSquare.Add(firstWord);

                    Solve(wordSquare, _lettersUtils.Remove(firstWord, letters));

                    if (wordSquare.Count == length)
                    {
                        return wordSquare;
                    }
                    wordSquare.Clear();
                }
            }
            return wordSquare;
        }

        private void Solve(IWordSquare wordSquare, string lettersRemaining)
        {
            if (string.IsNullOrEmpty(lettersRemaining))
            {
                return;
            }

            var depth = wordSquare.Count;
            var prefix = wordSquare.GetWord(depth);
            var words = _wordGrabber.Grab(prefix, wordSquare[0].Length);

            if (depth == wordSquare[0].Length)
            {
                var remaining = lettersRemaining;
                words = words.Where(w => w.Last().ToString() == remaining);
                lettersRemaining = null;
            }
            else if (depth < wordSquare[0].Length)
            {
                words = words.Where(w => _lettersUtils.CanBeFormed(w.Substring(prefix.Length), lettersRemaining));
            }

            foreach (var word in words)
            {
                wordSquare.Add(word);
                Solve(wordSquare, _lettersUtils.Remove(word.Substring(prefix.Length), lettersRemaining));

                if (wordSquare.Count != wordSquare[0].Length)
                {
                    wordSquare.RemoveAt(depth);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
