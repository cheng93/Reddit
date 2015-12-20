using System.Collections.Generic;

namespace Reddit235
{
    public class Decrypter
    {
        private readonly string _Key;
        private readonly string _Message;
        private Dictionary<string, string> _keys;

        public Decrypter(string key, string message)
        {
            _Key = key;
            _Message = message;
        }

        public string Decrypt()
        {
            _keys = GetKeys();
            string output = null;
            var position = 0;
            while (position < _Message.Length)
            {
                if (!char.IsLetter(char.Parse(_Message.Substring(position, 1))))
                {
                    output += _Message.Substring(position, 1);
                    position++;
                    continue;
                }
                for (var i = 0; i < _Message.Length - position; i++)
                {
                    if (_keys.ContainsKey(_Message.Substring(position, i)))
                    {
                        output += _keys[_Message.Substring(position, i)];
                        position += i;
                        break;
                    }
                }
            }
            return output;
        }

        private Dictionary<string, string> GetKeys()
        {
            var output = new Dictionary<string, string>();
            var split = _Key.Split(' ');
            for (var i = 0; i < split.Length / 2; i++)
            {
                output.Add(split[2*i + 1], split[2*i]);
            }
            return output;
        }
    }
}