using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Users
{
    public class EmployeeReportGenerator : IReportGenerator
    {
        private static int _tableWidth = 150;
        
        private const string UserId = "UsrId";
        private const string CompanyName = "Company Name";
        private const string UserFullName = "User Full Name";
        private const string Salary = "Salary";
        
        public void PrintReport(List<Employee> employees)
        {
            employees = employees.OrderBy(x => x.CompanyName).ThenBy(x => (int)x.JobSalary).ToList();

            Console.Clear();
            // Created the header of the table.
            PrintLine();
            PrintRow(UserId, CompanyName, UserFullName, Salary);
            PrintLine();
            
            for (var i = 0; i < employees.Count; i++)
            {
                PrintRow(employees[i].Id.ToString(), employees[i].CompanyName,
                    employees[i].Name + " " + employees[i].SecondName, employees[i].JobSalary.ToString(CultureInfo.CurrentCulture));
                PrintLine();
            }
        }

        public  void PrintLine()
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

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
