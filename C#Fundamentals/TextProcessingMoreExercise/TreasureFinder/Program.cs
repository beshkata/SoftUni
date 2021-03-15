using System;
using System.Linq;
using System.Text;

namespace TreasureFinder
{
    class Program
    {
        static void Main()
        {
            int[] keys = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string message = Console.ReadLine();

            while (message != "find")
            {
                string decryptedMessage = DecryptMessage(keys, message);
                Console.WriteLine(decryptedMessage);

                message = Console.ReadLine();
            }
        }

        private static string DecryptMessage(int[] keys, string message)
        {
            StringBuilder sb = new StringBuilder();
            int keyIndex = 0;

            for (int i = 0; i < message.Length; i++)
            {
                if (keyIndex == keys.Length)
                {
                    keyIndex = 0;
                }

                char letter = (char)(message[i] - keys[keyIndex]);
                sb.Append(letter);
                keyIndex++;
            }

            string hiddenMessage = sb.ToString();

            string treasure = hiddenMessage.Substring(hiddenMessage.IndexOf('&') + 1,
                hiddenMessage.LastIndexOf('&') - hiddenMessage.IndexOf('&') - 1);

            string coordinates = hiddenMessage.Substring(hiddenMessage.IndexOf('<') + 1,
                hiddenMessage.IndexOf('>') - hiddenMessage.IndexOf('<') - 1);


            return $"Found {treasure} at {coordinates}";
        }
    }
}
