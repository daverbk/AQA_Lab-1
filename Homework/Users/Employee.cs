using System;

namespace Users
{
    public class Employee : Person, IJob
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public decimal JobSalary { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyAddress { get; set; }
        
        public void SelfPresentation()
        {
            Console.WriteLine($"Hello, I am {Name}, {JobTitle} in {CompanyName} ({CompanyCountry}, {CompanyCity}, {CompanyAddress}) and my salary is {JobSalary}");
        }
    }
}
