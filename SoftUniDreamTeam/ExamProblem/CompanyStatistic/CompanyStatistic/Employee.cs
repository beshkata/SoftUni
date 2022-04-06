namespace CompanyStatistic
{
    public class Employee
    {
        public Employee(string name, string department, int age, decimal salary)
        {
            Name = name;
            Department = department;
            Age = age;
            Salary = salary;
        }
        public string Name { get; set; }

        public string Department { get; set; }

        public int Age { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Department} - {Age} - {Salary}";
        }
    }
}
