namespace SoftJail.DataProcessor
{

    using Data;
    using SoftJail.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .ToArray()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new ExportPrisonerByIdDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                    .Select(po => new ExportOfficersByPrisonerDto
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(po => Math.Round(po.Officer.Salary, 2))
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Prisoners");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPrisonerWithMailDto[]), root);

            using StringWriter sw = new StringWriter(sb);

            string[] prisonersNamesArr = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var prisoners = context
                .Prisoners
                .ToArray()
                .Where(p => prisonersNamesArr.Contains(p.FullName))
                .Select(p => new ExportPrisonerWithMailDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails
                    .Select(m => new ExportPrisonerMessageDto
                    {
                        Description = string.Join("",m.Description.Reverse())
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            xmlSerializer.Serialize(sw, prisoners, namespaces);


            return sb.ToString().TrimEnd();
        }
    }
}