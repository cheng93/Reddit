using System;
using System.Collections.Generic;
using System.Linq;

namespace Reddit235
{
    public class Solution
    {
        public string Decrypt(string key, string message)
        {
            var cipher = GetCipher(key);
            string output = null;
            var position = 0;
            while (position < message.Length)
            {
                if (!char.IsLetter(char.Parse(message.Substring(position, 1))))
                {
                    output += message.Substring(position, 1);
                    position++;
                    continue;
                }
                for (var i = 0; i < message.Length - position; i++)
                {
                    if (cipher.ContainsKey(message.Substring(position, i)))
                    {
                        output += cipher[message.Substring(position, i)];
                        position += i;
                        break;
                    }
                }
            }
            return output;
        }

        private Dictionary<string, string> GetCipher(string key)
        {
            var output = new Dictionary<string, string>();
            var split = key.Split(' ');
            for (var i = 0; i < split.Length / 2; i++)
            {
                output.Add(split[2*i + 1], split[2*i]);
            }
            return output;
        }

        /// <summary>
        /// Encypts a message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Returns a tuple, where Item1 is the cipher and Item2 is the encrypted message.</returns>
        public Tuple<string, string> Encrypt(string message)
        {
            var stripedMessage = message.Where(char.IsLetter).Aggregate<char, string>(null, (current, c) => current + c);
            var huffman = new Huffman();
            return null;
        }
    }
}