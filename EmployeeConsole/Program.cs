using EmployeeApp;
using EmployeeApp.Contracts;
using System;
using System.Collections.Generic;

namespace EmployeeConsole
{
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { FirstName = "ss", LastName = "dd", Id = 1});
            FileTypeEnum fileType = FileTypeEnum.DELIMITED; 
            ExportEmployees exportEmployees = null;  

            switch (fileType)
            {
                case FileTypeEnum.CSV:
                    exportEmployees = new ExportCSVEmployees(employees);
                    break;
                case FileTypeEnum.JSON:
                    exportEmployees = new ExportJsonEmployees(employees);
                    break;
                case FileTypeEnum.DELIMITED:
                    exportEmployees = new ExportPipeDelimetedEmployees(employees);
                    break;
                default:
                    break;
            }

            exportEmployees.ExportEmplyees();         
        }
    }
}
