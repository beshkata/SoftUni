namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Theatre.Common;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPlayDto[]), root);

            StringReader sr = new StringReader(xmlString);

            var playDtos = (ImportPlayDto[])serializer.Deserialize(sr);

            HashSet<Play> validPlays = new HashSet<Play>();

            foreach (var playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.TryParse(playDto.Genre, out Genre genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture);
                if (duration.Hours < GlobalConstants.PlayDurationMinValue)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                validPlays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            context.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Casts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCastDto[]), root);

            StringReader sr = new StringReader(xmlString);

            var castDtos = (ImportCastDto[])serializer.Deserialize(sr);

            HashSet<Cast> validCasts = new HashSet<Cast>();

            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                validCasts.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.AddRange(validCasts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var theatreDtos = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            HashSet<Theatre> validTheatres = new HashSet<Theatre>();

            foreach (var theatreDto in theatreDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                HashSet<Ticket> validTickets = new HashSet<Ticket>();

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    validTickets.Add(ticket);
                }

                Theatre theatre = new Theatre
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                    Tickets = validTickets
                };

                validTheatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.AddRange(validTheatres);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
