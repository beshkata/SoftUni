namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
	using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		private static string errorMessage = "Invalid Data";
		private static string successMesageImportGame = "Added {0} ({1}) with {2} tags";
		private static string successMesageImportUser = "Imported {0} with {1} cards";
		private static string successMesageImportPurchase = "Imported {0} for {1}";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var gameDtos = JsonConvert.DeserializeObject<ImportGameDeveloperGenreTagDto[]>(jsonString);

			HashSet<Game> validGames = new HashSet<Game>();
			HashSet<Developer> developers = new HashSet<Developer>();
			HashSet<Tag> tags = new HashSet<Tag>();
			HashSet<Genre> genres = new HashSet<Genre>();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				Game game = new Game
				{
					Name = gameDto.GameName,
					Price = gameDto.GamePrice,
					ReleaseDate = DateTime.ParseExact(gameDto.GameReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
				};

				Developer developer = developers.FirstOrDefault(d => d.Name == gameDto.DeveloperName);
                if (developer == null)
                {
					developer = new Developer
					{
						Name = gameDto.DeveloperName
					};
					developers.Add(developer);
				}

				Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.GenreName);
                if (genre == null)
                {
					genre = new Genre
					{
						Name = gameDto.GenreName
					};
					genres.Add(genre);
				}

				game.Developer = developer;
				game.Genre = genre;

                foreach (var tagname in gameDto.Tags)
                {
					Tag tag = tags.FirstOrDefault(t => t.Name == tagname);
                    if (tag == null)
                    {
						tag = new Tag
						{
							Name = tagname
						};
						tags.Add(tag);
					}

					game.GameTags.Add(new GameTag
					{
						Tag = tag,
						Game = game
					});
                }
                if (game.GameTags.Count == 0)
                {
					sb.AppendLine(errorMessage);
					continue;
				}
				validGames.Add(game);
				sb.AppendLine(string.Format(successMesageImportGame, game.Name, genre.Name, game.GameTags.Count));
            }
			context.AddRange(validGames);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var userDtos = JsonConvert.DeserializeObject<ImportUsersDto[]>(jsonString);

			HashSet<User> validUsers = new HashSet<User>();

            foreach (var userDto in userDtos)
            {
				bool isUserValid = true;

                if (!IsValid(userDto))
                {
					sb.AppendLine(errorMessage);
					continue;
                }

				User user = new User
				{
					Username = userDto.Username,
					FullName = userDto.FullName,
					Age = userDto.Age,
					Email = userDto.Email
				};

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
						sb.AppendLine(errorMessage);
						isUserValid = false;
						break;
					}

                    if (!Enum.TryParse(cardDto.Type, out CardType cardType))
                    {
						sb.AppendLine(errorMessage);
						isUserValid = false;
						break;
					}

					Card card = new Card
					{
						Number = cardDto.Number,
						Cvc = cardDto.Cvc,
						Type = cardType
					};

					user.Cards.Add(card);
				}

                if (!isUserValid)
                {
					continue;
                }

				validUsers.Add(user);
				sb.AppendLine(string.Format(successMesageImportUser, user.Username, user.Cards.Count));
            }

			context.AddRange(validUsers);
			context.SaveChanges();
			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();

			XmlRootAttribute root = new XmlRootAttribute("Purchases");
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), root);

			StringReader sr = new StringReader(xmlString);

			ImportPurchaseDto[]purchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(sr);

			HashSet<Purchase> validPurchases = new HashSet<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
					sb.AppendLine(errorMessage);
					continue;
                }

                if (!Enum.TryParse(purchaseDto.Type, out PurchaseType purchaseType))
                {
					sb.AppendLine(errorMessage);
					continue;
				}

				Card card = context
					.Cards
					.FirstOrDefault(c => c.Number == purchaseDto.CardNumber);
                if (card == null)
                {
					sb.AppendLine(errorMessage);
					continue;
				}

				Game game = context
					.Games
					.FirstOrDefault(g => g.Name == purchaseDto.GameTitle);

                if (game == null)
                {
					sb.AppendLine(errorMessage);
					continue;
				}

				Purchase purchase = new Purchase
				{
					Type = purchaseType,
					ProductKey = purchaseDto.ProductKey,
					Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
					Card = card,
					Game = game
				};

				validPurchases.Add(purchase);
				sb.AppendLine(string.Format(successMesageImportPurchase, game.Name, card.User.Username));
			}

			context.AddRange(validPurchases);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}