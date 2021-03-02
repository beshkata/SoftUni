using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main()
        {
            int articlesCount = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>(articlesCount);

            for (int i = 0; i < articlesCount; i++)
            {
                string[] articleInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string title = articleInfo[0];
                string constent = articleInfo[1];
                string author = articleInfo[2];

                Article article = new Article(title, constent, author);
                articles.Add(article);
            }

            string orderCriteria = Console.ReadLine();

            switch (orderCriteria)
            {
                case "title":
                    articles = articles.OrderBy(t => t.Title).ToList();
                    break;
                case "content":
                    articles = articles.OrderBy(c => c.Content).ToList();
                    break;
                case "author":
                    articles = articles.OrderBy(a => a.Author).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid order criteria!");
                    break;
            }

            foreach (Article article1 in articles)
            {
                Console.WriteLine(article1.ToString());
            }
        }
    }
}
