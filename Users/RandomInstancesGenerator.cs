using System;
using System.Collections.Generic;

namespace Users
{
    public static class RandomInstancesGenerator
    {
        private const int MaxObjectsAmount = 200;
        public static (List<Candidate>, List<Employee>) RandomInstanceGenerator()
        {
            var random = new Random();
            var candidates = new List<Candidate>();
            var employees = new List<Employee>();

            // Generating random amount of Candidate and Employee objects.
            for (var i = 0; i < random.Next(MaxObjectsAmount); i++)
            {
                candidates.Add(BogusObjectFiller.FillCandidate());
                
                employees.Add(BogusObjectFiller.FillEmployee());
            }

            return (candidates, employees);
        }
    }
}
