using System;
using System.Text;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h1>");
            sb.Append("    ");
            sb.AppendLine(Console.ReadLine());
            sb.AppendLine("</h1>");
            sb.AppendLine("<article>");
            sb.Append("    ");
            sb.AppendLine(Console.ReadLine());
            sb.AppendLine("</article>");

            string line = Console.ReadLine();

            while (line != "end of comments")
            {
                sb.AppendLine("<div>");
                sb.Append("    ");
                sb.AppendLine(line);
                sb.AppendLine("</div>");

                line = Console.ReadLine();
            }

            Console.WriteLine(sb);
        }
    }
}
