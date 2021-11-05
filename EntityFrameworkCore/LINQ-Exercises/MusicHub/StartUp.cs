namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            string result = ExportSongsAboveDuration(context, 4);

            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriter = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.SongWriter)
                    .ToArray(),
                    TotalPrice = a.Price
                });

            

            foreach (var a in albums)
            {
                sb
                    .Append($"-AlbumName: {a.AlbumName}" + Environment.NewLine)
                    .AppendLine($"-ReleaseDate: {a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}")
                    .AppendLine($"-ProducerName: {a.ProducerName}")
                    .AppendLine("-Songs:");

                int i = 1;
                foreach (var s in a.Songs)
                {
                    sb
                        .AppendLine($"---#{i++}")
                        .AppendLine($"---SongName: {s.SongName}")
                        .AppendLine($"---Price: {s.SongPrice:F2}")
                        .AppendLine($"---Writer: {s.SongWriter}");
                }

                sb.AppendLine($"-AlbumPrice: {a.TotalPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context.Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    PreformerName = s.SongPerformers
                    .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                    .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PreformerName)
                .ToArray();

            int i = 1;
            foreach (var s in songs)
            {
                sb
                    .AppendLine($"-Song #{i++}")
                    .AppendLine($"---SongName: {s.SongName}")
                    .AppendLine($"---Writer: {s.WriterName}")
                    .AppendLine($"---Performer: {s.PreformerName}")
                    .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                    .AppendLine($"---Duration: {s.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
