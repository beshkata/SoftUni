using System;

namespace CompanyStatistic
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // Initialize the repository
            Company company = new Company("Nike Inc.", 5);

            // Initialize entity
            Employee firstEmployee = new Employee("Petar", "Finance", 29, 2000);

            // Print Employee
            Console.WriteLine(firstEmployee); // Petar - Finance - 29 - 2000

            // Add Employee
            company.Add(firstEmployee);

            // Remove Employee
            Console.WriteLine(company.Remove("Ivan", "Maintenance")); //False
            Console.WriteLine(company.Remove("Petar", "Finance")); //True

            Employee secondEmployee = new Employee("Ivan", "Maintenance", 33, 2000);
            Employee thirdEmployee = new Employee("Ivan", "Finance", 30, 2100);
            Employee fourthEmployee = new Employee("Georgi", "Finance", 29, 2000);

            company.Add(secondEmployee);
            company.Add(thirdEmployee);
            company.Add(fourthEmployee);

            // Get oldest employee in given department
            Employee oldestEmployee = company.GetDepartmentOldestEmployee("Finance");
            Console.WriteLine(oldestEmployee); // Ivan - Finance - 30 - 2100

            // Get less paid employee in given department
            Employee lessPaid = company.GetDepartmentLessPaidEmployee("Finance");
            Console.WriteLine(lessPaid); // Georgi - Finance - 29 - 2000

            // Count
            Console.WriteLine(company.Count); // 3

            // Get Statistics
            Console.WriteLine(company.GetStatistics());
            //The employees in Nike Inc.:
            //Ivan - Maintenance - 33 - 2000
            //Ivan - Finance - 30 - 2100
            //Georgi - Finance - 29 - 2000

        }
    }
}
