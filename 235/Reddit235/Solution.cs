using System.Collections.Generic;

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
    }
}