using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }

        public double Salary { get; set; }

        public string Department { get; set; }

        public override string ToString()
        {
            return $"{Name} {Salary:f2}";
        }
    }
    class Program
    {
        static void Main()
        {
            int employeesCount = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>(employeesCount);

            for (int i = 0; i < employeesCount; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split();
                string name = employeeInfo[0];
                double salary = double.Parse(employeeInfo[1]);
                string deprtment = employeeInfo[2];

                Employee employee = new Employee(name, salary, deprtment);
                employees.Add(employee);
            }

            List<string> departments = new List<string>();

            foreach (Employee employee1 in employees)
            {
                if (departments.Contains(employee1.Department) == false)
                {
                    departments.Add(employee1.Department);
                }
            }

            int empCountInDepartment = 0;
            double averageSalaryInDepartment = 0;
            double bestAverageSalary = 0;
            string bestDepartment = "";

            for (int i = 0; i < departments.Count; i++)
            {
                for (int j = 0; j < employees.Count; j++)
                {
                    if (employees[j].Department == departments[i])
                    {
                        empCountInDepartment++;
                        averageSalaryInDepartment += employees[j].Salary;
                    }
                }
                averageSalaryInDepartment /= empCountInDepartment;

                if (averageSalaryInDepartment > bestAverageSalary)
                {
                    bestAverageSalary = averageSalaryInDepartment;
                    bestDepartment = departments[i];
                }
                empCountInDepartment = 0;
                averageSalaryInDepartment = 0;
            }

            List<Employee> bestDepartmentEmployees = employees
                .Where(d => d.Department == bestDepartment)
                .OrderByDescending(s => s.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");

            foreach (Employee employee2 in bestDepartmentEmployees)
            {
                Console.WriteLine(employee2.ToString());
            }
        }
    }
}
