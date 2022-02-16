using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Users
{
    public class CandidateReportGenerator : IReportGenerator
    {
        private static int _tableWidth = 150;
        
        private const string UserId = "UsrId";
        private const string UserFullName = "User Full Name";
        private const string JobTitle = "Job Title";
        private const string Salary = "Salary";
        
        public void PrintReport(List<Candidate> candidates)
        {
            candidates = candidates.OrderBy(x => x.JobTitle).ThenByDescending(x => (int)x.JobSalary).ToList();
            
            Console.Clear();
            // Created the header of the table.
            PrintLine();
            PrintRow(UserId, UserFullName, JobTitle, Salary);
            PrintLine();
            
            for (var i = 0; i < candidates.Count; i++)
            {
                PrintRow(candidates[i].Id.ToString(), candidates[i].Name + " " + candidates[i].SecondName,
                    candidates[i].JobTitle, candidates[i].JobSalary.ToString(CultureInfo.CurrentCulture));
                PrintLine();
            }
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', _tableWidth));
        }
        
        public void PrintRow(params string[] columns)
        {
            var width = (_tableWidth - columns.Length) / columns.Length;
        
            string row = "|";

            foreach (var column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }
    
        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            return string.IsNullOrEmpty(text) ? new string(' ', width) : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}
