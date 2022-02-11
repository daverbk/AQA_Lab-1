
namespace Users
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Creating an object of Candidate type.
            var exampleCandidateObject = UserFactory.GiveCandidateObject();
            exampleCandidateObject.SelfPresentation();
            // Creating an object of Employee type.
            var exampleEmployeeObject = UserFactory.GiveEmployeeObject();
            exampleEmployeeObject.SelfPresentation();

            var employees = RandomInstancesGenerator.RandomInstanceGenerator().Item2;
            var candidates = RandomInstancesGenerator.RandomInstanceGenerator().Item1;
            // Employee report presentation.
            var employeeReport = new EmployeeReportGenerator();
            employeeReport.PrintReport(employees);
            // Candidate report presentation.
            var candidateReport = new CandidateReportGenerator();
            candidateReport.PrintReport(candidates);
        }
    }
}
