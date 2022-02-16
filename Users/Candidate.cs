using System;

namespace Users
{
    public class Candidate : Person, IJob
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public decimal JobSalary { get; set; }
        
        public void SelfPresentation()
        {
            Console.WriteLine($"Hello, I am {Name + " " + SecondName} I want to be a {JobTitle} ({JobDescription}) with a salary from {JobSalary}");
        }
    };
}
