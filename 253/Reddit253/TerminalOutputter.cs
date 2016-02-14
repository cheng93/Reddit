using System;
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

        private string ToString<T>(IList<T> items)
        {
            var builder = new StringBuilder();
            Action<object> append;
            Action appendEmpty;

            if (typeof(T) == typeof (string))
            {
                append = (o => builder.AppendLine((string)o));
                appendEmpty = (() => builder.AppendLine());
            }
            else if (typeof(T) == typeof (char?))
            {
                append = (o => builder.Append(o));
                appendEmpty = (() => builder.Append(' '));
            }
            else
            {
                throw new InvalidOperationException("items of not of type string or char");
            }

            for (int i = 0; i < 10; i++)
            {
                var line = items[i];
                if (line != null)
                {
                    append(line);
                }
                else
                {
                    if (items.Skip(i + 1).Take(9 - i).All(s => s == null))
                    {
                        break;
                    }
                    appendEmpty();
                }
            }

            var output = builder.Length == 0 ? null : builder.ToString();
            return output;
        }
    }
}
