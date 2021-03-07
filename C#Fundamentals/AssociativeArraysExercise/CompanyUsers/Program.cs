using System;
using System.Collections.Generic;

namespace CompanyUsers
{
    class Program
    {
        static void Main()
        {
            //keeps information about companies and their employees
            //order the companies by the name in ascending order
            SortedDictionary<string, List<string>> employeesToCompanies = new SortedDictionary<string, List<string>>();
            //You will be receiving a company name and an employee's id, 
            //until you receive the command "End" command.
            string line = Console.ReadLine();

            while (line != "End")
            {
                //receiving input in the format: "{companyName} -> {employeeId}".
                string[] info = line.Split(" -> ");
                string companyName = info[0];
                string employeeId = info[1];

                //Add each employee to the given company.
                if (employeesToCompanies.ContainsKey(companyName) == false)
                {
                    employeesToCompanies.Add(companyName, new List<string>());
                }

                //Keep in mind that a company cannot have two employees with the same id.
                if (employeesToCompanies[companyName].Contains(employeeId) == false)
                {
                    employeesToCompanies[companyName].Add(employeeId); ;
                }

                line = Console.ReadLine();
            }
            //Print the company name and each employee's id in the following format:
            //{ companyName}
            //-- { id1}
            //-- { id2}
            //-- { idN}
            foreach (var kvp in employeesToCompanies)
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var id in kvp.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
