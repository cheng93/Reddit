﻿using System;

namespace Reddit235
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Original Message");
            //const string originalMessage = "Hello, world!";
            //const string originalMessage = "hooray /r/dailyprogrammer!";
            const string originalMessage = "Here's the thing. You said a \"jackdaw is a crow.\" Is it in the same family? Yes. No one's arguing that. As someone who is a scientist who studies crows, I am telling you, specifically, in science, no one calls jackdaws crows. If you want to be \"specific\" like you said, then you shouldn't either. They're not the same thing. If you're saying \"crow family\" you're referring to the taxonomic grouping of Corvidae, which includes things from nutcrackers to blue jays to ravens. So your reasoning for calling a jackdaw a crow is because random people \"call the black ones crows?\" Let's get grackles and blackbirds in there, then, too. Also, calling someone a human or an ape? It's not one or the other, that's not how taxonomy works. They're both. A jackdaw is a jackdaw and a member of the crow family. But that's not what you said. You said a jackdaw is a crow, which is not true unless you're okay with calling all members of the crow family crows, which means you'd call blue jays, ravens, and other birds crows, too. Which you said you don't. It's okay to just admit you're wrong, you know?";
            Console.WriteLine(originalMessage);

            var solution = new Solution();
            var encrypted = solution.Encrypt(originalMessage);
            Console.WriteLine("Encrypt Cipher");
            Console.WriteLine(encrypted.Item1);
            Console.WriteLine("Encrypt Message");
            Console.WriteLine(encrypted.Item2);
            Console.WriteLine("Decrypted Message");
            Console.WriteLine(solution.Decrypt(encrypted.Item1, encrypted.Item2));
            Console.Read();
        }
    }
}