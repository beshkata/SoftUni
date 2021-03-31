using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main()
        {
            string emojiPattern = @"(\*\*|::)[A-Z][a-z]{2,}\1";
            string digitPattern = @"\d";

            string text = Console.ReadLine();

            List<string> emojiList = new List<string>();

            int coolThreshold = 1;

            MatchCollection digitsMatches = Regex.Matches(text, digitPattern);

            foreach (Match digit in digitsMatches)
            {
                coolThreshold *= int.Parse(digit.ToString());
            }

            MatchCollection emojiMatches = Regex.Matches(text, emojiPattern);

            foreach (Match emoji in emojiMatches)
            {
                int coolnes = GetEmojiCoolnes(emoji.Value);

                if (coolnes >= coolThreshold)
                {
                    emojiList.Add(emoji.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
            foreach (string coolEmoji in emojiList)
            {
                Console.WriteLine(coolEmoji);
            }
        }

        private static int GetEmojiCoolnes(string emoji)
        {
            int result = 0;
            string emojiName = emoji.Substring(2, emoji.Length - 4);

            foreach (char letter in emojiName)
            {
                result += letter;
            }

            return result;
        }
    }
}
