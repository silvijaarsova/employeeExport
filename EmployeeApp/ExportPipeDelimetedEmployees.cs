using EmployeeApp.Contracts;
using System.Collections.Generic;
using System.Data;

namespace EmployeeApp
{
    public class ExportPipeDelimetedEmployees : ExportEmployees
    {
        public const string FILENAME = @"d:\employee.txt";
        public const string DELIMITER = "|";

        public override void ExportEmplyees(List<Employee> employees)
        {
            DataTable dt = CreateDataTable(employees);
            ToCSV(dt, FILENAME, DELIMITER);
        }
    }
}
