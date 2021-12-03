namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			throw new NotImplementedException();
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			StringBuilder sb = new StringBuilder();

			XmlRootAttribute root = new XmlRootAttribute("Users");
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), root);

			using StringWriter sw = new StringWriter(sb);


			var users = context
				.Purchases
				.Where(p => p.Type.ToString() == storeType)
				.Select(p => new ExportUserDto
                {
					Username = p.Card.User.Username,
					Purchases = p.Card.User.
                })




			xmlSerializer.Serialize(sw, users, namespaces);


			return sb.ToString().TrimEnd();


		}
	}
}