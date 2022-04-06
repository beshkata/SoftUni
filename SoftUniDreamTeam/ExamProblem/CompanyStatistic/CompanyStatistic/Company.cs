using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyStatistic
{
    public class Company
    {
        private readonly List<Employee> data;

        public Company(string name, int maxPersonel)
        {
            Name = name;
            MaxPersonel = maxPersonel;
            data = new List<Employee>();
        }

        public string Name { get; set; }

        public int MaxPersonel { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if (data.Count < MaxPersonel)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name, string department)
        {
            Employee employee = data
                .Where(e => e.Name == name && e.Department == department)
                .FirstOrDefault();

            if (employee == null)
            {
                return false;
            }

            return data.Remove(employee);
        }

        public Employee GetDepartmentOldestEmployee(string department)
        {
            return data
                .Where(e => e.Department == department)
                .OrderByDescending(e => e.Age)
                .First();
        }

        public Employee GetDepartmentLessPaidEmployee(string department)
        {
            return data
                .Where(e => e.Department == department)
                .OrderBy(e => e.Salary)
                .First(); 
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"The employees in {Name}:");

            foreach (Employee employee in data)
            {
                result.AppendLine(employee.ToString());
            }

            return result.ToString();
        }
    }
}
