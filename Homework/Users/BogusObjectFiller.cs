using Bogus;
using System;

namespace Users
{
    public static class BogusObjectFiller
    {
        public static Candidate FillCandidate()
        {
            var candidateFaker = new Faker<Candidate>()
                    .RuleFor(x => x.Id, Guid.NewGuid)
                    .RuleFor(x => x.Name, x => x.Person.FirstName)
                    .RuleFor(x => x.SecondName, x => x.Person.LastName)
                    .RuleFor(x => x.JobTitle, x => x.Name.JobTitle())
                    .RuleFor(x => x.JobDescription, x => x.Name.JobDescriptor())
                    .RuleFor(x => x.JobSalary, x => x.Finance.Amount());
            
            return candidateFaker.Generate();
        }

        public static Employee FillEmployee()
        {
            var employeeFaker = new Faker<Employee>()
                    .RuleFor(x => x.Id, Guid.NewGuid)
                    .RuleFor(x => x.Name, x => x.Person.FirstName)
                    .RuleFor(x => x.SecondName, x => x.Person.LastName)
                    .RuleFor(x => x.JobTitle, x => x.Name.JobTitle())
                    .RuleFor(x => x.JobDescription, x => x.Name.JobDescriptor())
                    .RuleFor(x => x.JobSalary, x => x.Finance.Amount())
                    .RuleFor(x => x.CompanyName, x => x.Company.CompanyName())
                    .RuleFor(x => x.CompanyCountry, x => x.Address.Country())
                    .RuleFor(x => x.CompanyCity, x => x.Address.City())
                    .RuleFor(x => x.CompanyAddress, x => x.Address.StreetAddress());
            
            return employeeFaker.Generate();
        }
    }
}
