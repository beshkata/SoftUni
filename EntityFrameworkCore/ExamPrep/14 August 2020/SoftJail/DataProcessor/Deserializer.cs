namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ImportDto;
    using SoftJail.Data.Models;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.IO;
    using SoftJail.Data.Models.Enums;

    public class Deserializer
    {
        private const string errorMessage = "Invalid Data";

        private const string successMessageDepartment = "Imported {0} with {1} cells";

        private const string successMessagePrisoner = "Imported {0} {1} years old";

        private const string successMessageOfficer = "Imported {0} ({1} prisoners)";


        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            HashSet<Department> validDepartments = new HashSet<Department>();

            foreach (var departmentDto in departmentDtos)
            {
                bool isDepValid = true;

                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                Department department = new Department
                {
                    Name = departmentDto.Name
                };

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine(errorMessage);
                        isDepValid = false;
                        continue;
                    }

                    Cell cell = new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };

                    department.Cells.Add(cell);
                }

                if (department.Cells.Count == 0 )
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                if (isDepValid == false)
                {
                    continue;
                }

                validDepartments.Add(department);

                sb.AppendLine(string.Format(successMessageDepartment, department.Name, department.Cells.Count));
            }

            context.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var prisonersDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            List<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDtos)
            {
                bool isPrisonerValid = true;

                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                if (prisonerDto.Bail.HasValue && prisonerDto.Bail.Value < 0)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                if (!DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                DateTime? releaseDate = null;

                if (!DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDateValue))
                {
                    if (prisonerDto.ReleaseDate != null)
                    {
                        sb.AppendLine(errorMessage);
                        continue;
                    }
                }

                if (prisonerDto.Bail != null && prisonerDto.Bail < 0)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                releaseDate = releaseDateValue;

                Prisoner prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                foreach (var mailDto in prisonerDto.Mails)
                {
                    
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(errorMessage);
                        isPrisonerValid = false;
                        continue;
                    }

                    Mail mail = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    };

                    prisoner.Mails.Add(mail);
                }

                if (isPrisonerValid == false)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                validPrisoners.Add(prisoner);
                sb.AppendLine(string.Format(successMessagePrisoner, prisoner.FullName, prisoner.Age));
            }

            context.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Officers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportOfficerDto[]), root);

            using StringReader stringReader = new StringReader(xmlString);

            var officerDtos = (ImportOfficerDto[])serializer.Deserialize(stringReader);

            var validOfficers = new HashSet<Officer>();

            foreach (var officerDto in officerDtos)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                Position validPosition = new Position();
                if (!Enum.TryParse(officerDto.Position, out validPosition ))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                Weapon validWeapon = new Weapon();

                if (!Enum.TryParse(officerDto.Weapon, out validWeapon))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                Officer officer = new Officer
                {
                    FullName = officerDto.FullName,
                    Salary = officerDto.Salary,
                    Weapon = validWeapon,
                    Position = validPosition,
                    DepartmentId = officerDto.DepartmentId
                };

                foreach (var prisonerId in officerDto.PrisonersIds)
                {
                    Prisoner prisoner = context
                        .Prisoners
                        .Find(prisonerId.PrisonerId);

                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        Prisoner = prisoner,
                        Officer = officer
                    });
                }

                sb.AppendLine(string.Format(successMessageOfficer, officer.FullName, officer.OfficerPrisoners.Count));
                validOfficers.Add(officer);
            }

            context.AddRange(validOfficers);
            context.SaveChanges();
            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}