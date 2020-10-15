using EmployeeApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class EmployeeManager : IEmployeeManager
    {
        public void ExportFile(List<Employee> employees, FileTypeEnum fileType)
        {
            ExportFileFactory factory = new ExportFileImplFactory();

            ExportEmployees exportEmployees = factory.GetExportFile(fileType);
            exportEmployees.ExportEmplyees(employees);
        }
    }
}


