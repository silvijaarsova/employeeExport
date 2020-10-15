using EmployeeApp.Contracts;
using System.Collections.Generic;

namespace EmployeeApp
{
    public interface IEmployeeManager
    {
        void ExportFile(List<Employee> employee, FileTypeEnum fileType);
    }
}
