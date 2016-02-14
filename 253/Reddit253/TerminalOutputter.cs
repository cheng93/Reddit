using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Reddit253.UnitTest")]    
namespace Reddit253
{
    internal class TerminalOutputter : ITerminalOutputter
    {
        public string Output(ITerminal terminal)
        {
            var rowStrings = GetRowStrings(terminal);
            var output = ToString(rowStrings);
            return output;
        }

        private IList<string> GetRowStrings(ITerminal terminal)
        {
            var output = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                var row = new List<char?>();
                for (int j = 0; j < 10; j++)
                {
                    var character = terminal.GetValue(i, j);
                    row.Add(character);
                }
                output.Add(ToString(row));
            }
            return output;
        }

        private string ToString(IList<char?> characters)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                var character = characters[i];
                if (character != null)
                {
                    builder.Append(character);
                }
                else
                {
                    if (characters.Skip(i + 1).Take(9 - i).All(s => s == null))
                    {
                        break;
                    }
                    builder.Append(' ');
                }
            }

            var output = builder.Length == 0 ? null : builder.ToString();
            return output;
        }

        private string ToString(IList<string> rowStrings)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                var line = rowStrings[i];
                if (line != null)
                {
                    builder.AppendLine(line);
                }
                else
                {
                    if (rowStrings.Skip(i + 1).Take(9 - i).All(s => s == null))
                    {
                        break;
                    }
                    builder.AppendLine();
                }
            }

            var output = builder.Length == 0 ? null : builder.ToString();
            return output;
        }
    }
}
