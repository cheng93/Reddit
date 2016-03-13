using System;
using System.Collections.Generic;

namespace Reddit257.Intermediate
{
    public class WordBank : IWordBank
    {
        public IEnumerable<string> Get()
        {
            return Properties.Resources.enable1.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }
}
